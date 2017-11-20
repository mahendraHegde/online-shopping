using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using System.Data.SqlClient;
using global;

public partial class Bill : System.Web.UI.Page
{
    connect c = new connect();
    SqlDataAdapter adp = new SqlDataAdapter();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    DataTable dt5 = new DataTable();
    public static int j = 0;
    DropDownList ddop = new DropDownList();
    protected void Page_Load(object sender, EventArgs e)
    {
       if (Session["buyer_id"] == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
            Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
        }
        else if (Session["order_id"] == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('OOPS!! No Order to show')</script>");
            Response.AddHeader("REFRESH", "3;URL=Home.aspx");
        }
        else
        {
            if (Session["product_id"] != null)
            {
                ddop.Style.Add("margin-left","45%");
                ddop.Style.Add("margin-top", "40px");
                ddop.Items.Add("Select Bill");
                ddop.Items.Add("Get bill of this Product");
                ddop.Items.Add("Get Full Bill of this order");
                ddop.AutoPostBack = true;
                form1.Controls.Add(ddop);
                ddop.SelectedIndexChanged+=new EventHandler(ddop_SelectedIndexChanged);
            }
            else
            {
                fullbil();
                try
                {
                    
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        
    }
    protected void ddop_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList d = (DropDownList)sender;
        if (d.SelectedIndex.ToString()== "1")
        {
            orddetails.InnerHtml = "";
            singlebill();
        }
        else if (d.SelectedIndex.ToString() == "2")
        {
            orddetails.InnerHtml = "";
            fullbil();
        }
    }
    protected void singlebill()
    {
        try
        {
            int loop = 2, qty = 0;
            long tot = 0;
            c.cmd.CommandText = "select * from order_detail where order_id=" +Convert.ToInt64( Session["order_id"]) + " and product_id='" + Session["product_id"].ToString() + "' ";
            adp.SelectCommand = c.cmd;
            dt2.Clear();
            adp.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell[] td = new HtmlTableCell[4];
               
                for (j = 0; j < 4; j++)
                {
                    td[j] = new HtmlTableCell();
                    td[j].InnerHtml = dt2.Rows[0].ItemArray[loop].ToString();
                    td[j].InnerHtml = td[j].InnerHtml.ToString().ToUpper();
                    tr.Controls.Add(td[j]);
                    if (loop == 4)
                    {
                        qty += Convert.ToInt16(dt2.Rows[0].ItemArray[loop]);
                    }
                    if (loop == 5)
                    {
                        tot += Convert.ToInt64(dt2.Rows[0].ItemArray[loop]);
                    }
                    loop++;
                }
                tablebill.Controls.Add(tr);
                address();
                c.cmd.CommandText = "select date,payment from orders where order_id=" +Convert.ToInt64( Session["order_id"]) + "";
                adp.SelectCommand = c.cmd;
                dt3.Clear();
                adp.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {
                    orddetails.InnerHtml = "OrderID:ORD"+Session["order_id"].ToString() + "<br/>Date:" + dt3.Rows[0].ItemArray[0].ToString();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
 }
    protected void fullbil()
    {
        j = 0;
        int qty = 0, shipping = 0;
        long tot = 0;
        c.cmd.CommandText = "select * from order_detail where order_id=" +Convert.ToInt64( Session["order_id"]) + "";
        adp.SelectCommand = c.cmd;
        dt.Clear();
        adp.Fill(dt);
        int loop = 2;
        if (dt.Rows.Count > 0)
        {
            HtmlTableRow[] tr = new HtmlTableRow[dt.Rows.Count];
            HtmlTableCell[] td = new HtmlTableCell[dt.Rows.Count * 4];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                loop = 2;
                tr[i] = new HtmlTableRow();
                for (; j < (i + 1) * 4; j++)
                {
                    td[j] = new HtmlTableCell();
                    if (dt.Rows[i].ItemArray[6].ToString() != "cancelled")
                    {
                        td[j].InnerHtml = dt.Rows[i].ItemArray[loop].ToString();
                        td[j].InnerHtml = td[j].InnerHtml.ToString().ToUpper();
                        tr[i].Controls.Add(td[j]);
                        if (loop == 4)
                        {
                            qty += Convert.ToInt16(dt.Rows[i].ItemArray[loop]);
                        }
                        if (loop == 5)
                        {
                            tot += Convert.ToInt64(dt.Rows[i].ItemArray[loop]);
                        }
                    }
                    loop++;
                }
                tablebill.Controls.Add(tr[i]);
            }
        }
        if (tot < 1000)
            shipping = 100;
        HtmlTableRow tr1 = new HtmlTableRow();
        HtmlTableCell[] td1 = new HtmlTableCell[4];
        for (int i = 0; i < 4; i++)
        {
            td1[i] = new HtmlTableCell();
            tr1.Controls.Add(td1[i]);
        }
        td1[2].InnerHtml = "TOTAL QTY:" + qty.ToString();
        td1[1].InnerHtml = "Shipping:" + shipping.ToString();
        if (dt.Rows[0].ItemArray[1].ToString() == "yes")
        {
            td1[3].InnerHtml = "Total:" + Convert.ToString(tot + shipping) + "(Prepaid)";
        }
        else
        {
            td1[3].InnerHtml = "Total:" + Convert.ToString(tot + shipping);
        }
        tablebill.Controls.Add(tr1);
        address();
        c.cmd.CommandText = "select date,payment from orders where order_id=" +Convert.ToInt64(Session["order_id"]) + "";
        adp.SelectCommand = c.cmd;
        dt3.Clear();
        adp.Fill(dt3);
        if (dt3.Rows.Count > 0)
        {
            orddetails.InnerHtml = "OrderID:ORD" + Session["order_id"].ToString() + "<br/>Date:" + dt3.Rows[0].ItemArray[0].ToString();
        }
    }
    protected void address()
    {
        
        c.cmd.CommandText = "select name,address,city,state,pin,country,phone from buyer where buyer_id='"+Session["buyer_id"].ToString()+"'";
        adp.SelectCommand = c.cmd;
        dt1.Clear();
        adp.Fill(dt1);
        divbuyer.InnerHtml = "Shipped to,<br>";
        if (dt1.Rows.Count > 0)
        {
            for (int i = 0; i < 7; i++)
                divbuyer.InnerHtml = "   " + divbuyer.InnerHtml.ToUpper() + "<br/>" + dt1.Rows[0].ItemArray[i].ToString();
        }
        if (Session["product_id"] != null && ddop.SelectedIndex.ToString()=="1")
        {
            c.cmd.CommandText = "select name,address,city,state,pin,country,phone from seller where seller_id in(select seller_id from order_detail where order_id=" + Convert.ToInt64(Session["order_id"]) + " and product_id='" + Session["product_id"].ToString() + "')";
            adp.SelectCommand = c.cmd;
            dt4.Clear();
            adp.Fill(dt4);
        }
        else
        {
            c.cmd.CommandText = "select distinct name,address,city,state,pin,country,phone from seller where seller_id in(select seller_id from order_detail where order_id=" + Convert.ToInt64(Session["order_id"]) + ")";
            adp.SelectCommand = c.cmd;
            dt4.Clear();
            adp.Fill(dt4);
        }
        divseller.InnerHtml = "Sold by,<br>";
        for (int j = 0; j < dt4.Rows.Count; j++)
        {
            if (dt4.Rows.Count > 0)
            {
                for (int i = 0; i < 7; i++)
                    divseller.InnerHtml = "   " + divseller.InnerHtml.ToUpper() + "<br/>" + dt4.Rows[j].ItemArray[i].ToString();
            }
            divseller.InnerHtml = divseller.InnerHtml + "<br/><br/>";
        }
        divlogistic.InnerHtml = "Logistic,<br>";
        c.cmd.CommandText = "select name,address,city,state,pin,country,phone from logistic where log_id in(select log_id from orders where order_id="+Convert.ToInt64(Session["order_id"])+")";
        adp.SelectCommand = c.cmd;
        dt5.Clear();
        adp.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            for (int i = 0; i < 7; i++)
                divlogistic.InnerHtml = "   " + divlogistic.InnerHtml.ToUpper() + "<br/>" + dt5.Rows[0].ItemArray[i].ToString();
        }
    }
}

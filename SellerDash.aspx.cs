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
public partial class sellerDash : System.Web.UI.Page
{
    connect c = new connect();
    static int click,ordcnt=0,retcnt=0;
    SqlDataAdapter adp = new SqlDataAdapter();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    DataTable dt5 = new DataTable();
    DataTable dt6 = new DataTable();
    DataTable dt7 = new DataTable();
    DataTable dt8 = new DataTable();
    DataTable dt9 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["seller_id"] == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please login first')</script>");
            Session["slink"] = "SellerDash.aspx"; 
            Response.AddHeader("REFRESH", "3;URL=SeLoLogReg.aspx?val=login");
        }
        else
        {
            try
            {
                int loop = 0, i = 0,ct=0;
                DateTime date = new DateTime();
                date = DateTime.Now;
                TableCell[] tc = new TableCell[16];
                TableRow[] tr = new TableRow[8];
                c.cmd.CommandText = "select name,email,phone,address,city,state,pin,country from seller where seller_id=" + Convert.ToInt64(Session["seller_id"]) + "";
                adp.SelectCommand = c.cmd;
                dt.Clear();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        tr[loop] = new TableRow();
                        tc[i] = new TableCell();
                        tc[i].Text = dc.ColumnName.ToString();
                        tc[i].Text = tc[i].Text.ToUpper() + ":";
                        tc[i].CssClass = "tblhead";
                        tr[loop].Controls.Add(tc[i]);
                        i++;
                        tc[i] = new TableCell();
                        tc[i].Text = dt.Rows[0].ItemArray[loop].ToString();
                        tc[i].Text = tc[i].Text.ToUpper();
                        tr[loop].Controls.Add(tc[i]);
                        tr[loop].CssClass = "tblcontent";
                        i++;
                        addresstbl.Controls.Add(tr[loop]);
                        loop++;
                    }
                    lblname.Text = lblname1.Text = dt.Rows[0].ItemArray[0].ToString().ToLower();
                    string ch = lblname.Text.Substring(0, 1).ToUpper();
                    lblname.Text = lblname1.Text = ch.ToString() + lblname.Text.Substring(1, lblname.Text.Length - 1);
                    TableCell tc1 = new TableCell();
                    TableRow tr1 = new TableRow();
                    tr1.CssClass = "updateaddr";
                    LinkButton lnkaddress = new LinkButton();
                    lnkaddress.Click += new EventHandler(lnkaddress_Click);
                    lnkaddress.CssClass = " lnkaddress";
                    addresstbl.Controls.Add(tr1);
                    tr1.Controls.Add(tc1);
                    tc1.Controls.Add(lnkaddress);
                    lnkaddress.Text = "Update Address>>";
                    tc1.ColumnSpan = 2;
                    orders();
                    returns();
                    updateproduct();
                    dashboard();
                    if (!Page.IsPostBack)
                    {
                        adashboard_Click(sender, EventArgs.Empty);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    protected void adashboard_Click(object sender, EventArgs e)
    {
        divdash.Visible = true;
        divproducts.Visible = false;
        divtbls.Visible = false;
        divcharts.Visible = true;
        lidash.Style.Add("background-color", "#179b77");
        lidash.Style.Add("color", "#fff");
        liproducts.Style.Add("background-color", "transperent");
        liproducts.Style.Add("color", "#179b77");
        divleftbar.Style.Add("height", "930px");
    }
    protected void aproducts_Click(object sender, EventArgs e)
    {
        divdash.Visible = false;
        divproducts.Visible = true;
        tblproducts.Visible = false;
        liproducts.Style.Add("background-color", "#179b77");
        liproducts.Style.Add("color", "#fff");
        lidash.Style.Add("background-color", "transperent");
        lidash.Style.Add("color", "#179b77");
        divleftbar.Style.Add("height", "730px");
    }
    protected void lnkaddress_Click(object sender, EventArgs e)
    {
        Response.Redirect("Address.aspx?user=seller");
    }
    protected void dashboard()
    {
        try
        {
            DataSet ds = new DataSet();
            int d1;
            string m, n;
            string[] tot = new string[12] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
            HtmlGenericControl[] div = new HtmlGenericControl[4];
            for (int i = 0; i < 4; i++)
            {
                div[i] = new HtmlGenericControl("div");
                div[i].Style.Add("height", "350px");
                div[i].Style.Add("width", "49%");
                div[i].Style.Add("float", "left");
                divcharts.Controls.Add(div[i]);
            }
            div[0].ID = "ch1";
            div[0].Attributes.Add("class", "chart1");
            div[1].ID = "ch2";
            div[1].Attributes.Add("class", "chart2");
            div[2].ID = "ch3";
            div[2].Attributes.Add("class", "chart3");
            div[3].ID = "ch4";
            div[3].Attributes.Add("class", "chart4");
            c.cmd.CommandText = "select sum(qty),count(*) from product where seller_id=" + Convert.ToInt64(Session["seller_id"]) + "";
            adp.SelectCommand = c.cmd;
            dt1.Clear();
            adp.Fill(dt1);
            c.cmd.CommandText = "select sum(qty),count(*) from product";
            adp.SelectCommand = c.cmd;
            dt2.Clear();
            adp.Fill(dt2);
            if (Convert.ToInt64(dt1.Rows[0].ItemArray[1]) > 0)
            {
                d1 = Convert.ToInt16(dt1.Rows[0].ItemArray[0]);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ch1", "<script>ch1(" + (Convert.ToInt16(dt2.Rows[0].ItemArray[0])-d1) + "," + Convert.ToInt16(dt1.Rows[0].ItemArray[0]) + ")</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ch1", "<script>ch1(" + Convert.ToInt16(dt2.Rows[0].ItemArray[0]) + "," + 0 + ")</script>");
            }
            c.cmd.CommandText = "select sum(qty),count(*) from order_detail,orders where orders.order_id=order_detail.order_id and seller_id=" + Convert.ToInt64(Session["seller_id"]) + " ";
            adp.SelectCommand = c.cmd;
            dt6.Clear();
            adp.Fill(dt6);
            c.cmd.CommandText = "select count(DISTINCT(return_id)) from sales_return,order_detail where sales_return.order_id=order_detail.order_id and seller_id=" + Convert.ToInt64(Session["seller_id"]) + " ";
            adp.SelectCommand = c.cmd;
            dt7.Clear();
            adp.Fill(dt7);
            if (Convert.ToInt64(dt6.Rows[0].ItemArray[1]) > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ch2", "<script>ch2(" + Convert.ToInt16(dt6.Rows[0].ItemArray[0]) + "," + Convert.ToInt16(dt7.Rows[0].ItemArray[0]) + ")</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ch2", "<script>ch2(" + 0 + "," + Convert.ToInt16(dt7.Rows[0].ItemArray[0]) + ")</script>");
            }
            c.cmd.CommandText = "SELECT SUM(order_detail.total),month(orders.date) FROM  orders, order_detail WHERE orders.order_id = order_detail.order_id and status<>'cancelled' and year(orders.date)="+DateTime.Now.Year+" and order_detail.seller_id =" + Convert.ToInt64(Session["seller_id"]) + " GROUP BY MONTH(orders.date)";
            adp.SelectCommand = c.cmd;
            dt5.Clear();
            adp.Fill(dt5);
            for (int i = 0; i < dt5.Rows.Count; i++)
            {
                tot[Convert.ToInt16(dt5.Rows[i].ItemArray[1]) - 1] = dt5.Rows[i].ItemArray[0].ToString();
            }
            m = string.Join(",", tot);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ch3", "<script>ch3('" + m + "')</script>");

            c.cmd.CommandText = "SELECT SUM(qty),category FROM product where seller_id=" + Convert.ToInt64(Session["seller_id"]) + " GROUP BY category";
            adp.SelectCommand = c.cmd;
            dt9.Clear();
            adp.Fill(dt9);
            if (dt9.Rows.Count > 0)
            {
                string[] qty = new string[dt9.Rows.Count];
                string[] cat = new string[dt9.Rows.Count];
                for (int i = 0; i < dt9.Rows.Count; i++)
                {
                    cat[i] = dt9.Rows[i].ItemArray[1].ToString();
                    qty[i] = dt9.Rows[i].ItemArray[0].ToString();
                }
                m = string.Join(",", cat);
                n = string.Join(",", qty);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ch4", "<script>ch4('" + m + "','" + n + "')</script>");
            }
            }
            catch (Exception)
            {
                throw;
            }
    }
    protected void imgreturn_ServerClick(object sender, EventArgs e)
    {
        divleftbar.Style.Add("height", "730px");
        divtbls.Visible = true;
        divcharts.Visible = false;
        tblret.Visible = true;
        ordertbl.Visible = false;
        c.cmd.CommandText = "update order_detail set status='return accepted' where seller_id=" + Convert.ToInt64(Session["seller_id"]) + "and status='return'";
        c.cmd.ExecuteNonQuery();
    }
    protected void imgorder_Click(object sender, EventArgs e)
    {
        divleftbar.Style.Add("height", "730px");
        divtbls.Visible = true;
        divcharts.Visible = false;
        tblret.Visible = false;
        ordertbl.Visible = true;
        c.cmd.CommandText = "update order_detail set status='accepted' where seller_id=" + Convert.ToInt64(Session["seller_id"]) + "and status='placed'";
        c.cmd.ExecuteNonQuery();
    }

    void orders()
    {
        try
        {
            ordcnt = 0;
            c.cmd.CommandText = "select date,name,order_detail.total,status,product_id,qty,buyer_id,order_detail.order_id from order_detail,orders where orders.order_id=order_detail.order_id and seller_id=" + Convert.ToInt64(Session["seller_id"]) + " order by date desc";
            adp.SelectCommand = c.cmd;
            dt3.Clear();
            adp.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                int j = 0;
                int num = 1, loop;
                TableRow[] tr1 = new TableRow[dt3.Rows.Count];
                TableCell[] tc1 = new TableCell[dt3.Rows.Count * 8];
                System.Web.UI.WebControls.Button[] b = new System.Web.UI.WebControls.Button[dt3.Rows.Count];
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (dt3.Rows[i].ItemArray[3].ToString()=="placed")
                    {
                        ordcnt++;
                    }
                        loop = 0;
                        tr1[i] = new TableRow();
                        tr1[i].CssClass = "tblcontent";
                        for (; j < (i + 1) * 8; j++)
                        {
                            tc1[j] = new TableCell();
                            tc1[j].CssClass = "ordercontent";
                            if (j % 8 == 0)
                            {
                                if (dt3.Rows[i].ItemArray[3].ToString() == "cancelled")
                                {
                                    tc1[j].Style.Add("color", "red");
                                }
                                tc1[j].Text = num.ToString().ToUpper();
                                num++;
                            }
                            else if (j == ((i + 1) * 8) - 1)
                            {
                                b[i] = new System.Web.UI.WebControls.Button();
                                b[i].CssClass = "invoicebtn";
                                b[i].Attributes.Add("order_id", dt3.Rows[i].ItemArray[7].ToString());
                                b[i].Attributes.Add("product_id", dt3.Rows[i].ItemArray[4].ToString());
                                b[i].Attributes.Add("buyer_id", dt3.Rows[i].ItemArray[6].ToString());
                                b[i].CausesValidation = false;
                                b[i].Click += new EventHandler(btninvoice_Click);
                                b[i].Text = "Bill";
                                tc1[j].Controls.Add(b[i]);
                            }
                            else
                            {
                                if (dt3.Rows[i].ItemArray[3].ToString() == "cancelled")
                                {
                                    tc1[j].Style.Add("color", "red");
                                }
                                tc1[j].Text = dt3.Rows[i].ItemArray[loop].ToString().ToUpper();
                                loop++;
                            }
                            tr1[i].Controls.Add(tc1[j]);
                        }
                        ordertbl.Controls.Add(tr1[i]);
                }
            }
            txtordnot.Text = ordcnt.ToString();
        }
        catch (Exception)
        {
            throw;
        }
    }
    void returns()
    {
        try
        {
            retcnt = 0;
            c.cmd.CommandText = "select sales_return.date,name,total,order_detail.status,reason,description from sales_return,order_detail where sales_return.order_id=order_detail.order_id and sales_return.product_id=order_detail.product_id  and seller_id=" + Convert.ToInt64(Session["seller_id"]) + "";
            adp.SelectCommand = c.cmd;
            dt4.Clear();
            adp.Fill(dt4);
             if (dt4.Rows.Count > 0)
            {
                int j = 0;
                int num = 1, loop = 0;
                TableRow[] tr1 = new TableRow[dt4.Rows.Count];
                TableCell[] tc1 = new TableCell[dt4.Rows.Count * 6];
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    if (dt4.Rows[i].ItemArray[3].ToString()=="return")
                    {
                        retcnt++;
                    }
                        loop = 0;
                        tr1[i] = new TableRow();
                        for (; j < (i + 1) * 6; j++)
                        {
                            tc1[j] = new TableCell();
                            tc1[j].CssClass = "ordercontent";
                            if (j % 6 == 0)
                            {
                                
                                tc1[j].Text = num.ToString().ToUpper();
                                num++;
                            }
                            else
                            {
                                tc1[j].Text = dt4.Rows[i].ItemArray[loop].ToString().ToUpper();
                                loop++;
                            }
                            tr1[i].Controls.Add(tc1[j]);
                        }
                        tblret.Controls.Add(tr1[i]);
                }
            }
            
            txtretnot.Text = retcnt.ToString().ToUpper();
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void btninvoice_Click(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.Button b = (System.Web.UI.WebControls.Button)sender;
        Session["order_id"] = b.Attributes["order_id"].ToString();
        Session["product_id"] = b.Attributes["product_id"].ToString();
        Session["buyer_id"]=b.Attributes["buyer_id"].ToString();
        Response.Redirect("Bill.aspx");
    }
    protected void imgupdateprdct_Click(object sender, EventArgs e)
    {
        tblproducts.Visible = true;
    }
    protected void updateproduct()
    {
        c.cmd.CommandText = "select product_id,name,category,brand,price,qty,color,weight,description from product where seller_id=" + Convert.ToInt64(Session["seller_id"]) + " order by date desc";
        adp.SelectCommand = c.cmd;
        dt8.Clear();
        adp.Fill(dt8);
        if (dt8.Rows.Count > 0)
        {
            int j = 0;
            int num = 1, loop;
            TableRow[] tr1 = new TableRow[dt8.Rows.Count];
            TableCell[] tc1 = new TableCell[dt8.Rows.Count * 11];
            System.Web.UI.WebControls.Button[] b = new System.Web.UI.WebControls.Button[dt8.Rows.Count * 2];
            for (int i = 0; i < dt8.Rows.Count; i++)
            {
                loop = 1;
                tr1[i] = new TableRow();
                for (; j < (i + 1) * 11; j++)
                {
                    tc1[j] = new TableCell();
                    tc1[j].CssClass = "ordercontent";
                    if (j % 11 == 0)
                    {
                        tc1[j].Text = num.ToString();
                        num++;
                    }
                    else if (j == ((i + 1) * 11) - 1)
                    {
                        b[i] = new System.Web.UI.WebControls.Button();
                        b[i].CssClass = "invoicebtn";
                        b[i].Attributes.Add("product_id", dt8.Rows[i].ItemArray[0].ToString());
                        b[i].OnClientClick = "return confirm('Are You Sure You Want To Delete This Product?')";
                        b[i].Click += new EventHandler(btndelete_Click);
                        b[i].Text = "Delete";
                        tc1[j].Controls.Add(b[i]);
                    }
                    else if (j == ((i + 1) * 11) - 2)
                    {
                        b[i] = new System.Web.UI.WebControls.Button();
                        b[i].CssClass = "invoicebtn";
                        b[i].Attributes.Add("product_id", dt8.Rows[i].ItemArray[0].ToString());
                        b[i].Click += new EventHandler(btnupdate_Click);
                        b[i].Text = "Update";
                        tc1[j].Controls.Add(b[i]);
                    }
                    else
                    {
                        tc1[j].Text = dt8.Rows[i].ItemArray[loop].ToString().ToUpper();
                        loop++;
                    }
                    tr1[i].Controls.Add(tc1[j]);
                }
                tblproducts.Controls.Add(tr1[i]);
            }
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        string physical, path;
        physical = Server.MapPath("~/");
          System.Web.UI.WebControls.Button b = (System.Web.UI.WebControls.Button)sender;
          DataTable tempdt = new DataTable();
          c.cmd.CommandText = "select img1,img2,img3 from product where product_id='" + b.Attributes["product_id"].ToString() + "'";
          adp.SelectCommand = c.cmd;
          tempdt.Clear();
          adp.Fill(tempdt);
          if (tempdt.Rows.Count > 0)
          { 
              for(int i=0;i<3;i++)
              {
                  path = tempdt.Rows[0].ItemArray[i].ToString();
                  path = path.Substring(2, path.Length - 2);
                if(System.IO.File.Exists(physical+path))
                {
                    System.IO.File.Delete(physical + path);
                }
              }
          }
          c.cmd.CommandText = "delete from product where product_id='" + b.Attributes["product_id"].ToString() + "'";
          c.cmd.ExecuteNonQuery();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Deleted successfully')</script>");
        
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.Button b = (System.Web.UI.WebControls.Button)sender;
        Response.Redirect("AddProducts.aspx?product_id="+b.Attributes["product_id"].ToString());
    }
    protected void imgadd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddProducts.aspx");
    }
    protected void logout_Click(object sender, EventArgs e)
    {
        Session["seller_id"] = null;
        Response.Redirect("Home.aspx");
    }
}

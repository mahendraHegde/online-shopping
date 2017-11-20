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

public partial class BuyerProfile : System.Web.UI.Page
{
    connect c = new connect();
    SqlDataAdapter adp = new SqlDataAdapter();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    DataTable dt5 = new DataTable();
    static int j = 0;
    static int num = 0;
    static long tot=0;
    long total = 0;
    int qty=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["buyer_id"]==null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
            Session["link"] = "BuyerProfile.aspx";
            Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
        }
        else
        {
            try
           {
                int loop = 0, i = 0;
                DateTime date = new DateTime();
                date = DateTime.Now;
                TableCell[] tc = new TableCell[16];
                TableRow[] tr = new TableRow[8];
                c.cmd.CommandText = "select name,email,phone,address,city,state,pin,country from buyer where buyer_id='" + Session["buyer_id"].ToString() + "'";
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
                        tc[i].Text = tc[i].Text.ToUpper()+":";
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
                    TableCell tc2 = new TableCell();
                    TableRow tr2 = new TableRow();
                    tr2.CssClass = "updateaddr";
                    LinkButton lnkaddress = new LinkButton();
                    lnkaddress.Click+=new EventHandler(lnkaddress_Click);
                    lnkaddress.CssClass = " lnkaddress";
                    addresstbl.Controls.Add(tr2);
                    tr2.Controls.Add(tc2);
                    tc2.Controls.Add(lnkaddress);
                    lnkaddress.Text = "Update Address>>";
                    tc2.ColumnSpan = 2;
                    c.cmd.CommandText = "select date,name,order_detail.total,status,payment,order_detail.order_id,product_id,qty,delivery_date from orders,order_detail where orders.order_id=order_detail.order_id and buyer_id='" + Session["buyer_id"].ToString()+ "' order by date desc";
                    adp.SelectCommand = c.cmd;
                    dt1.Clear();
                    adp.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        ordertbl.Visible = true;
                        j = 0;
                        num = 1;
                        TableRow[] tr1 = new TableRow[dt1.Rows.Count];
                        TableCell[] tc1 = new TableCell[dt1.Rows.Count * 9];
                        System.Web.UI.WebControls.Button[] b = new System.Web.UI.WebControls.Button[dt1.Rows.Count*3];
                        for (i = 0; i < dt1.Rows.Count; i++)
                        {
                            loop = 0;
                            tr1[i] = new TableRow();
                            tr1[i].CssClass = "row";
                            total+=Convert.ToInt64(dt1.Rows[i].ItemArray[2]);
                            qty += Convert.ToInt16(dt1.Rows[i].ItemArray[7]);
                            for (; j < (i + 1) * 9; j++)
                            {
                                HtmlAnchor a = new HtmlAnchor();
                                tc1[j] = new TableCell();
                                tc1[j].CssClass = "ordercontent";
                                if (j % 9 == 0)
                                {
                                    tc1[j].Text = num.ToString().ToUpper();
                                    num++;
                                }
                                else if (j == ((i + 1) * 9) - 1)
                                {
                                    if (dt1.Rows[i].ItemArray[3].ToString() == "delivered")
                                    {
                                        tc1[j].Text = "Delivered";
                                    }
                                    else if (dt1.Rows[i].ItemArray[3].ToString() == "cancelled")
                                    {
                                        tc1[j].Text = "Cancelled";
                                    }
                                    else
                                    {
                                        b[i] = new System.Web.UI.WebControls.Button();
                                        b[i].CssClass = "invoicebtn";
                                        b[i].Attributes.Add("order_id", dt1.Rows[i].ItemArray[5].ToString());
                                        b[i].Attributes.Add("product_id", dt1.Rows[i].ItemArray[6].ToString());
                                        b[i].Click += new EventHandler(track_Click);
                                        b[i].Text = "Track";
                                        tc1[j].Controls.Add(b[i]);
                                    }
                                }
                                else if (j == ((i + 1) * 9) - 3)
                                {
                                    b[i] = new System.Web.UI.WebControls.Button();
                                    b[i].CssClass = "invoicebtn";
                                    b[i].Attributes.Add("order_id", dt1.Rows[i].ItemArray[5].ToString());
                                    b[i].Attributes.Add("product_id", dt1.Rows[i].ItemArray[6].ToString());
                                    b[i].Click+=new EventHandler(btninvoice_Click);
                                    b[i].Text = "Invoice";
                                    tc1[j].Controls.Add(b[i]);
                                }
                                else if (j == ((i + 1) * 9) - 2)
                                {
                                    b[i] = new System.Web.UI.WebControls.Button();
                                    b[i].CssClass = "returnbtn";
                                    b[i].Attributes.Add("order_id", dt1.Rows[i].ItemArray[5].ToString());
                                    b[i].Attributes.Add("product_id", dt1.Rows[i].ItemArray[6].ToString());
                                    TimeSpan ts = date.Date - date.Date;
                                    if (dt1.Rows[i].ItemArray[8].ToString() != "")
                                    {
                                         ts = date.Date - Convert.ToDateTime(dt1.Rows[i].ItemArray[8]).Date;
                                    }

                                    if (ts.TotalDays > 7 && dt1.Rows[i].ItemArray[3].ToString() == "delivered")
                                    {
                                        c.cmd.CommandText = "select * from reviews where buyer_id='"+Session["buyer_id"].ToString()+"' and product_id='"+b[i].Attributes["product_id"].ToString()+"'and order_id="+Convert.ToInt64(b[i].Attributes["order_id"])+"";
                                        adp.SelectCommand = c.cmd;
                                        dt4.Clear();
                                        adp.Fill(dt4);
                                        if (dt4.Rows.Count <= 0)
                                        {
                                            b[i].Text = "Rate";
                                        }
                                        else
                                        {
                                            b[i].Text = "Edit Rate";
                                        }
                                        b[i].Click += new EventHandler(rate_Click);
                                    }
                                    else if (dt1.Rows[i].ItemArray[3].ToString()=="delivered")
                                    {
                                        b[i].Text = "Return";
                                        b[i].Click+=new EventHandler(btnreturn_Click);
                                    }
                                    else
                                    {
                                        b[i].Text = "Cancel";
                                        b[i].Attributes.Add("qty", dt1.Rows[i].ItemArray[7].ToString());
                                        b[i].OnClientClick = "return Confirm()";
                                        b[i].Click += new EventHandler(btncancel_Click);
                                    }
                                    if (dt1.Rows[i].ItemArray[3].ToString() == "cancelled")
                                    {
                                        b[i].Enabled = false;
                                        b[i].Text = "Cancelled";
                                    }
                                    if (dt1.Rows[i].ItemArray[3].ToString().Substring(0,6) == "return")
                                    {
                                        b[i].Enabled = false;
                                        b[i].Text = "Retun Request Received";
                                    }
                                    tc1[j].Controls.Add(b[i]);
                                }
                                else
                                {
                                    tc1[j].Text = dt1.Rows[i].ItemArray[loop].ToString().ToUpper();
                                    loop++;
                                }
                                tr1[i].Controls.Add(tc1[j]);
                            }
                            ordertbl.Controls.Add(tr1[i]);
                        }
                    }
                    else
                    {
                        ordertbl.Visible = false;
                    }
                }
                c.cmd.CommandText = "SELECT * FROM cart WHERE (buyer_id = '"+Session["buyer_id"].ToString()+"')";
                adp.SelectCommand = c.cmd;
                dt3.Clear();
                adp.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {
                    tot = 0;
                    lblitemcount.Text = dt3.Rows.Count.ToString();
                    for (int k = 0; k < dt3.Rows.Count; k++)
                    {
                        tot += Convert.ToInt64(dt3.Rows[k].ItemArray[4]);
                    }
                    lblamt.Text = "RS:" + tot;
                }
                else
                {
                    lblitemcount.Text = "0";
                    lblamt.Text = "0";
                }
                lblpurchaseitemcount.Text = qty.ToString();
                lblpurchaseamt.Text = total.ToString();
          }
          catch (NullReferenceException)
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
                Session["link"] = "BuyerProfile.aspx";
                Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    protected void rate_Click(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.Button b = (System.Web.UI.WebControls.Button)sender;
        Session["product_id"] = b.Attributes["product_id"].ToString();
        Session["order_id"] = b.Attributes["order_id"].ToString();
        if (b.Text == "Edit Rate")
        {
            Response.Redirect("Rate.aspx?action=edit");
        }
        else
        {
            Response.Redirect("Rate.aspx");
        }
    }
    protected void track_Click(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.Button b = (System.Web.UI.WebControls.Button)sender;
        Session["product_id"] = b.Attributes["product_id"].ToString();
        Session["order_id"] = b.Attributes["order_id"].ToString();
        Response.Redirect("Track.aspx");
    }
    protected void lnkaddress_Click(object sender, EventArgs e)
    {
        Response.Redirect("Address.aspx?user=buyer");
    }
    protected void btninvoice_Click(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.Button b = (System.Web.UI.WebControls.Button)sender;
        Session["order_id"] = b.Attributes["order_id"].ToString();
        Session["product_id"] = b.Attributes["product_id"].ToString();
        Response.Redirect("Bill.aspx");
    }
    protected void btnreturn_Click(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.Button b = (System.Web.UI.WebControls.Button)sender;
        Session["order_id"] = b.Attributes["order_id"];
        Session["product_id"] = b.Attributes["product_id"].ToString();
        Response.Redirect("ReturnProduct.aspx");
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        DataTable tempdt = new DataTable();
        System.Web.UI.WebControls.Button b = (System.Web.UI.WebControls.Button)sender;
        c.cmd.CommandText = "select check3,order_detail.total,log_id from order_detail,orders where orders.order_id=order_detail.order_id and check3 is not null and (order_detail.order_id = " +Convert.ToInt64( b.Attributes["order_id"]) + ") AND (product_id = '" + b.Attributes["product_id"].ToString() + "')";
        adp.SelectCommand = c.cmd;
        tempdt.Clear();
        adp.Fill(tempdt);
        if (tempdt.Rows.Count > 0)
        {
            c.cmd.CommandText = "insert into logistic_pay(log_id,pay,remaining,date) values(" + Convert.ToInt64(tempdt.Rows[0].ItemArray[2]) + "," + Convert.ToDecimal(((Convert.ToDouble(tempdt.Rows[0].ItemArray[1]) * .12) * .1) / 2) + ","+Convert.ToDecimal(((Convert.ToDouble(tempdt.Rows[0].ItemArray[1]) * .12) * .1) / 2)+",@date)";
            c.cmd.Parameters.Clear();
            c.cmd.Parameters.Add("@date",SqlDbType.DateTime).Value=DateTime.Now;
            c.cmd.ExecuteNonQuery();
        }
        c.cmd.CommandText = "UPDATE order_detail SET status = 'cancelled'WHERE (order_id = " +Convert.ToInt64( b.Attributes["order_id"]) + ") AND (product_id = '" + b.Attributes["product_id"].ToString() + "')";
        c.cmd.ExecuteNonQuery();
        c.cmd.CommandText = "update product set qty=qty+" + Convert.ToInt16(b.Attributes["qty"]) + "where product_id='" + b.Attributes["product_id"].ToString() + "'";
        c.cmd.ExecuteNonQuery();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Order Cancelled')</script>");
    }
    protected void logout_Click(object sender, EventArgs e)
    {

        Session["buyer_id"] = null;
        Response.Redirect("Home.aspx");
    }
}



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

public partial class LogisticDash : System.Web.UI.Page
{
    connect c = new connect();
    static int ordcnt = 0, retcnt = 0;
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
    DataTable dt10 = new DataTable();
    DateTime date = DateTime.Now;
    string[] tot = new string[12] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["log_id"] == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please login first')</script>");
            Session["llink"] = "LogisticDash.aspx";
            Response.AddHeader("REFRESH", "3;URL=LogisticLogReg.aspx?val=login");
        }
        else
        {
            //try
           // {
                int loop = 0, i = 0;
                DateTime date = new DateTime();
                date = DateTime.Now;
                TableCell[] tc = new TableCell[16];
                TableRow[] tr = new TableRow[8];
                c.cmd.CommandText = "select name,email,phone,address,city,state,pin,country from logistic where log_id=" + Convert.ToInt64(Session["log_id"]) + "";
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
                    lnkaddress.Click+=new EventHandler(lnkaddress_Click);
                    lnkaddress.CssClass = " lnkaddress";
                    addresstbl.Controls.Add(tr1);
                    tr1.Controls.Add(tc1);
                    tc1.Controls.Add(lnkaddress);
                    lnkaddress.Text = "Update Address>>";
                    tc1.ColumnSpan = 2;
                    dashboard();
                    orders();
                    returns();
                    tasks();
                    if (!Page.IsPostBack)
                    {
                        adashboard_Click(sender, EventArgs.Empty);
                    }
                }
           //}
           /* catch (Exception)
            {
                throw;
            }*/
        }
    }

    protected void adashboard_Click(object sender, EventArgs e)
    {
        divdash.Visible = true;
        divtbls.Visible = false;
        divcharts.Visible = true;
        divtasks.Visible = false;
        lidash.Style.Add("background-color", "#179b77");
        lidash.Style.Add("color", "#fff");
        liproducts.Style.Add("background-color", "transperent");
        liproducts.Style.Add("color", "#179b77");
    }
    protected void atasks_Click(object sender, EventArgs e)
    {
        divtasks.Visible = true;
        divtbls.Visible = false;
        divcharts.Visible = false;
        liproducts.Style.Add("background-color", "#179b77");
        liproducts.Style.Add("color", "#fff");
        lidash.Style.Add("background-color", "transperent");
        lidash.Style.Add("color", "#179b77");
    }
    protected void lnkaddress_Click(object sender, EventArgs e)
    {
        Response.Redirect("Address.aspx?user=logistic");
    }
    protected void dashboard()
    {
       // try
        //{
             DataSet ds = new DataSet();
             int d1, d2;
             string m, n;
             string[] tot = new string[12] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
             HtmlGenericControl[] div = new HtmlGenericControl[2];
             for (int i = 0; i < 2; i++)
             {
                 div[i] = new HtmlGenericControl("div");
                 div[i].Style.Add("height", "350px");
                 div[i].Style.Add("width", "49%");
                 div[i].Style.Add("float", "left");
                 divcharts.Controls.Add(div[i]);
             }
             div[0].ID = "ch6";
             div[0].Attributes.Add("class", "chart6");
             div[1].ID = "ch7";
             div[1].Attributes.Add("class", "chart7");
             c.cmd.CommandText = "SELECT count(order_detail.order_id) FROM  orders  INNER JOIN order_detail  ON orders.order_id = order_detail.order_id WHERE (orders.log_id = " + Convert.ToInt64(Session["log_id"]) + ") AND order_detail.status in (select order_detail.status from order_detail where status = 'shipped'OR order_detail.status = 'in transit' OR order_detail.status = 'delivered' or order_detail.status = 'accepted')";
             adp.SelectCommand = c.cmd;
             dt1.Clear();
             adp.Fill(dt1);
             c.cmd.CommandText = "select count(order_id) from order_detail";
             adp.SelectCommand = c.cmd;
             dt2.Clear();
             adp.Fill(dt2);
             if (Convert.ToInt64(dt1.Rows[0].ItemArray[0]) > 0)
             {
                 d1 = Convert.ToInt16(dt1.Rows[0].ItemArray[0]);
                 Page.ClientScript.RegisterStartupScript(this.GetType(), "ch6", "<script>ch6(" + (Convert.ToInt16(dt2.Rows[0].ItemArray[0])-d1) + "," + Convert.ToInt16(dt1.Rows[0].ItemArray[0]) + ")</script>");
             }
             else
             {
                 Page.ClientScript.RegisterStartupScript(this.GetType(), "ch6", "<script>ch6(" + Convert.ToInt16(dt2.Rows[0].ItemArray[0]) + "," + 0 + ")</script>");
             }
             c.cmd.CommandText ="SELECT ((SUM(order_detail.total)*.12)*.1),month(orders.date),status FROM  orders,order_detail WHERE orders.order_id=order_detail.order_id and order_detail.status in(select status from order_detail where status='delivered' or status='return delivered') and year(orders.date)=" + DateTime.Now.Year + " and log_id=" + Convert.ToInt64(Session["log_id"]) + " GROUP BY MONTH(orders.date),status";
             adp.SelectCommand = c.cmd;
             dt6.Clear();
             adp.Fill(dt6);
             for (int i = 0; i < dt6.Rows.Count; i++)
             {
                 tot[Convert.ToInt16(dt6.Rows[i].ItemArray[1]) - 1] = dt6.Rows[i].ItemArray[0].ToString();
                 if (dt6.Rows[i].ItemArray[2].ToString() == "return delivered")
                 {
                     tot[Convert.ToInt16(dt6.Rows[i].ItemArray[1]) - 1] = Convert.ToString(dt6.Rows[i].ItemArray[0]);//Convert.ToString((Convert.ToInt64(tot[Convert.ToInt16(dt6.Rows[i].ItemArray[1]) - 1])* 2);
                 }
             }
             m = "";
             m = string.Join(",", tot);
               Page.ClientScript.RegisterStartupScript(this.GetType(), "ch7", "<script>ch7('" +m+ "')</script>");
       /* }
        catch (Exception)
        {
            throw;
        }*/
    }
     protected void imgreturn_ServerClick(object sender, EventArgs e)
    {
        divtbls.Visible = true;
        divcharts.Visible = false;
        ordertbl.Visible = false;
        divtasks.Visible = false;
        c.cmd.CommandText = "UPDATE order_detail SET status = 'return shipped' FROM order_detail INNER JOIN orders ON order_detail.order_id = orders.order_id WHERE (order_detail.status = 'return accepted') AND (orders.log_id ="+Convert.ToInt64(Session["log_id"])+")";
        c.cmd.ExecuteNonQuery();
    }
    protected void imgorder_Click(object sender, EventArgs e)
    {
        divtasks.Visible = false;
        divtbls.Visible = true;
        divcharts.Visible = false;
        tblret.Visible = false;
       c.cmd.CommandText = "UPDATE order_detail SET status = 'shipped' FROM order_detail INNER JOIN orders ON order_detail.order_id = orders.order_id WHERE (order_detail.status ='accepted') AND (orders.log_id ="+Convert.ToInt64(Session["log_id"])+")";
        c.cmd.ExecuteNonQuery();
    }

    void orders()
    {
        try
        {
            ordcnt = 0;
            c.cmd.CommandText = "SELECT orders.date, order_detail.name, order_detail.total, order_detail.status, order_detail.product_id, order_detail.qty, orders.buyer_id,order_detail.order_id FROM  orders  INNER JOIN order_detail  ON orders.order_id = order_detail.order_id WHERE (orders.log_id = " + Convert.ToInt64(Session["log_id"]) + ") AND order_detail.status in (select order_detail.status from order_detail where status = 'shipped'OR order_detail.status = 'in transit' OR order_detail.status = 'delivered' OR order_detail.status = 'cancelled' or order_detail.status = 'accepted')ORDER BY orders.date DESC";
            adp.SelectCommand = c.cmd;
            dt3.Clear();
            adp.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                ordertbl.Visible = true;
                int j = 0;
                int num = 1, loop;
                TableRow[] tr1 = new TableRow[dt3.Rows.Count];
                TableCell[] tc1 = new TableCell[dt3.Rows.Count * 8];
                System.Web.UI.WebControls.Button[] b = new System.Web.UI.WebControls.Button[dt3.Rows.Count];
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (dt3.Rows[i].ItemArray[3].ToString() == "accepted")
                    {
                        ordcnt++;
                    }
                    loop = 0;
                    tr1[i] = new TableRow();
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
                            tc1[j].Text = num.ToString();
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
            else
            {
                ordertbl.Visible = false;
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
            c.cmd.CommandText = "select sales_return.date,name,order_detail.total,order_detail.status,qty,order_detail.product_id,order_detail.order_id,buyer_id from sales_return,order_detail,orders where orders.order_id=order_detail.order_id and sales_return.order_id=order_detail.order_id and sales_return.product_id=order_detail.product_id  and log_id=" + Convert.ToInt64(Session["log_id"]) + " and order_detail.status in(select status from order_detail where status='return accepted' or order_detail.status = 'return shipped'OR order_detail.status = 'return in transit' OR order_detail.status = 'return delivered') ORDER BY orders.date DESC";
            adp.SelectCommand = c.cmd;
            dt4.Clear();
            adp.Fill(dt4);
            if (dt4.Rows.Count > 0)
            {
                tblret.Visible = true;
                int num = 1, loop = 0;
                TableRow[] tr1 = new TableRow[dt4.Rows.Count];
                TableCell[] tc1 = new TableCell[dt4.Rows.Count * 8];

                System.Web.UI.WebControls.Button[] b = new System.Web.UI.WebControls.Button[dt4.Rows.Count];
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    if (dt4.Rows[i].ItemArray[3].ToString() == "return accepted")
                    {
                        retcnt++;
                    }
                    if (dt4.Rows[i].ItemArray[3].ToString() != "return accepted" || dt4.Rows[i].ItemArray[3].ToString() != "return")
                    {
                        loop = 0;
                        tr1[i] = new TableRow();
                        for (int j = i * 8; j < (i * 8) + 8; j++)
                        {
                            tc1[j] = new TableCell();
                            tc1[j].CssClass = "ordercontent";
                            if (j % 8 == 0)
                            {
                                tc1[j].Text = num.ToString();
                                num++;
                            }
                            else if (j % 8 == 7)
                            {
                                b[i] = new System.Web.UI.WebControls.Button();
                                b[i].CssClass = "invoicebtn";
                                b[i].Attributes.Add("order_id", dt4.Rows[i].ItemArray[6].ToString());
                                b[i].Attributes.Add("product_id", dt4.Rows[i].ItemArray[5].ToString());
                                b[i].Attributes.Add("buyer_id", dt4.Rows[i].ItemArray[7].ToString());
                                b[i].CausesValidation = false;
                                b[i].Click += new EventHandler(btninvoice_Click);
                                b[i].Text = "Bill";
                                tc1[j].Controls.Add(b[i]);
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
            }
            else
            {
                tblret.Visible = false;
            }
            txtretnot.Text = retcnt.ToString();
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
        Session["buyer_id"] = b.Attributes["buyer_id"].ToString();
        Response.Redirect("Bill.aspx");
    }
    protected void txtpin_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dtpin = new DataTable();
            DataTable dtdet = new DataTable();
            System.Web.UI.WebControls.TextBox t = (System.Web.UI.WebControls.TextBox)sender;
            if (t.Text!="" && Global.checkfordigit(t))
            {
                c.cmd.CommandText = "select pin,taluk,district,state from pincodes where pin=" + Convert.ToDouble(t.Text) + "";
                adp.SelectCommand = c.cmd;
                dtpin.Clear();
                adp.Fill(dtpin);
                if (dtpin.Rows.Count > 0)
                {
                    c.cmd.CommandText = "select check1,check2,check3,check4,seller.pin,buyer.pin from order_detail,seller,orders,buyer where order_detail.seller_id=seller.seller_id and order_detail.order_id=orders.order_id and orders.buyer_id=buyer.buyer_id and order_detail.order_id="+Convert.ToInt64(t.Attributes["order_id"])+" and product_id='"+t.Attributes["product_id"].ToString()+"'";
                    adp.SelectCommand = c.cmd;
                    dtdet.Clear();
                    adp.Fill(dtdet);
                    
                    if (dtdet.Rows.Count > 0)
                    {
                        
                        if (dtdet.Rows[0].ItemArray[0].ToString()=="")
                        {
                            if (dtdet.Rows[0].ItemArray[4].ToString() == t.Text)
                            {
                                if (t.Attributes["type"].ToString() == "order")
                                {
                                    c.cmd.CommandText = "update order_detail set check1=@pin,status='in transit' where order_id=" + Convert.ToInt64(t.Attributes["order_id"]) + " and product_id='" + t.Attributes["product_id"].ToString() + "'";
                                    c.cmd.Parameters.Clear();
                                    c.cmd.Parameters.Add("@pin", SqlDbType.Int).Value = t.Text;
                                    c.cmd.ExecuteNonQuery();
                                }
                                else if (t.Attributes["type"].ToString() == "return")
                                {
                                    c.cmd.CommandText = "update order_detail set check1=@pin,status='return in transit' where order_id=" + Convert.ToInt64(t.Attributes["order_id"]) + " and product_id='" + t.Attributes["product_id"].ToString() + "'";
                                    c.cmd.Parameters.Clear();
                                    c.cmd.Parameters.Add("@pin", SqlDbType.Int).Value = t.Text;
                                    c.cmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Enter Seller Pin Here')</script>");
                            }
                        }
                        else if (dtdet.Rows[0].ItemArray[1].ToString() == "")
                        {
                            if (t.Attributes["type"].ToString() == "order")
                            {
                                c.cmd.CommandText = "update order_detail set check2=@pin,status='in transit' where order_id=" + Convert.ToInt64(t.Attributes["order_id"]) + " and product_id='" + t.Attributes["product_id"].ToString() + "'";
                                c.cmd.Parameters.Clear();
                                c.cmd.Parameters.Add("@pin", SqlDbType.Int).Value = t.Text;
                                c.cmd.ExecuteNonQuery();
                            }
                            else if (t.Attributes["type"].ToString() == "return")
                            {
                                c.cmd.CommandText = "update order_detail set check2=@pin,status='return in transit' where order_id=" + Convert.ToInt64(t.Attributes["order_id"]) + " and product_id='" + t.Attributes["product_id"].ToString() + "'";
                                c.cmd.Parameters.Clear();
                                c.cmd.Parameters.Add("@pin", SqlDbType.Int).Value = t.Text;
                                c.cmd.ExecuteNonQuery();
                            }
                            
                        }
                        else if (dtdet.Rows[0].ItemArray[2].ToString() == "")
                        {
                            if (t.Attributes["type"].ToString() == "order")
                            {
                                c.cmd.CommandText = "update order_detail set check3=@pin,status='in transit' where order_id=" + Convert.ToInt64(t.Attributes["order_id"]) + " and product_id='" + t.Attributes["product_id"].ToString() + "'";
                                c.cmd.Parameters.Clear();
                                c.cmd.Parameters.Add("@pin", SqlDbType.Int).Value = t.Text;
                                c.cmd.ExecuteNonQuery();
                            }
                            else if (t.Attributes["type"].ToString() == "return")
                            {
                                c.cmd.CommandText = "update order_detail set check3=@pin,status='return in transit' where order_id=" + Convert.ToInt64(t.Attributes["order_id"]) + " and product_id='" + t.Attributes["product_id"].ToString() + "'";
                                c.cmd.Parameters.Clear();
                                c.cmd.Parameters.Add("@pin", SqlDbType.Int).Value = t.Text;
                                c.cmd.ExecuteNonQuery();
                            }
                        }
                        else  if (dtdet.Rows[0].ItemArray[3].ToString() == "")
                        {
                            if (dtdet.Rows[0].ItemArray[5].ToString() == t.Text)
                            {
                                c.cmd.CommandText = "select * from shoppie where order_id=" + Convert.ToInt64(t.Attributes["order_id"]) + "";
                                adp.SelectCommand = c.cmd;
                                dt10.Clear();
                                adp.Fill(dt10);
                                if (t.Attributes["type"].ToString() == "order")
                                {
                                    c.cmd.CommandText = "update order_detail set check4=@pin,status='delivered' where order_id=" + Convert.ToInt64(t.Attributes["order_id"]) + " and product_id='" + t.Attributes["product_id"].ToString() + "'";
                                    c.cmd.Parameters.Clear();
                                    c.cmd.Parameters.Add("@pin", SqlDbType.Int).Value = t.Text;
                                    c.cmd.ExecuteNonQuery();

                                    c.cmd.CommandText = "insert into seller_pay(seller_id,pay,remaining,date) select seller_id,(order_detail.total)-(order_detail.total*.12),(order_detail.total)-(order_detail.total*.12),@date from order_detail where order_id=" + Convert.ToInt64(t.Attributes["order_id"]) + " and product_id='"+t.Attributes["product_id"].ToString() + "'";
                                    c.cmd.Parameters.Clear();
                                    c.cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
                                    c.cmd.ExecuteNonQuery();

                                    c.cmd.CommandText = "insert into logistic_pay(log_id,pay,remaining,date) select log_id,((order_detail.total*.12)*.1),((order_detail.total*.12)*.1),@date from orders,order_detail where orders.order_id=order_detail.order_id and order_detail.order_id=" + Convert.ToInt64(t.Attributes["order_id"]) + " and product_id='" + t.Attributes["product_id"].ToString() + "'";
                                    c.cmd.Parameters.Clear();
                                    c.cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
                                    c.cmd.ExecuteNonQuery();

                                    if (dt10.Rows.Count <= 0)
                                    {
                                        c.cmd.CommandText = "insert into shoppie(order_id,commission,seller,logistic,date) select @dd,total*.12,(total-(total*.12)),((total*.12)*.1),@date from orders where order_id=" + Convert.ToInt64(t.Attributes["order_id"]) + "";
                                        c.cmd.Parameters.Clear();
                                        c.cmd.Parameters.Add("@dd", SqlDbType.BigInt).Value = Convert.ToInt64(t.Attributes["order_id"]);
                                        c.cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
                                        c.cmd.ExecuteNonQuery();
                                    }
                                    
                                }
                                else if (t.Attributes["type"].ToString() == "return")
                                {
                                    c.cmd.CommandText = "update order_detail set check4=@pin,status='return delivered' where order_id=" + Convert.ToInt64(t.Attributes["order_id"]) + " and product_id='" + t.Attributes["product_id"].ToString() + "'";
                                    c.cmd.Parameters.Clear();
                                    c.cmd.Parameters.Add("@pin", SqlDbType.Int).Value = t.Text;
                                    c.cmd.ExecuteNonQuery();

                                    c.cmd.CommandText = "insert into logistic_pay(log_id,pay,remaining,date) select log_id,((order_detail.total*.12)*.1),((order_detail.total*.12)*.1),@date from orders,order_detail where orders.order_id=order_detail.order_id and order_detail.order_id=" + Convert.ToInt64(t.Attributes["order_id"]) + " and product_id='" + t.Attributes["product_id"].ToString() + "'";
                                    c.cmd.Parameters.Clear();
                                    c.cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
                                    c.cmd.ExecuteNonQuery();

                                        c.cmd.CommandText = "update shoppie set commission=commission-logistic,logistic=logistic*2 where order_id=" + Convert.ToInt64(t.Attributes["order_id"]) + "";
                                        c.cmd.ExecuteNonQuery();
                                }
                                c.cmd.CommandText = "update orders set delivery_date=@date,payment='yes' where order_id=" + Convert.ToInt64(t.Attributes["order_id"]) + " ";
                                c.cmd.Parameters.Clear();
                                c.cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
                                c.cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Enter Buyer Pin ')</script>");
                            }
                        }
                        
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Enter Correct Pin')</script>");
                }
            }
        }
        catch (FormatException)
        {
        }
    }
    void tasks()
    {
        int loop=0;
        DataView dv = new DataView(dt3);
        DataView dv1 = new DataView(dt4);
        dv.RowFilter ="status='shipped' or status='in transit'or status='cancelled'";
        dv1.RowFilter = "status='return shipped' or status='return in transit' or status='return delivered'";
        DataTable d=dv.ToTable();
        DataTable d1=dv1.ToTable();
        if (d.Rows.Count <= 0 && d1.Rows.Count <= 0)
        {
            tbltaskreturn.Visible = false;
            tbltaskorder.Visible = false;
            divtasks.Style.Add("background-image", "css/image/icon/nothing-icon.jpg");
            divtasks.Style.Add("background-size", "50%");
            divtasks.Style.Add("background-position", "center");
            divtasks.Style.Add("background-repeat", "no-repeat");
        }
        if (d.Rows.Count > 0)
        {
            TableRow[] tr = new TableRow[d.Rows.Count];
            TableCell[] tc = new TableCell[d.Rows.Count * 9];
            System.Web.UI.WebControls.TextBox[] t = new System.Web.UI.WebControls.TextBox[d.Rows.Count];
             System.Web.UI.WebControls.Button[] b = new System.Web.UI.WebControls.Button[d.Rows.Count];
            for (int i = 0; i < d.Rows.Count; i++)
            {
                loop = 0;
                tr[i] = new TableRow();
                for (int j = (i * 9); j < (i * 9) + 9; j++)
                {
                    tc[j] = new TableCell();
                    tc[j].CssClass = "ordercontent";
                    if (j % 9== 0)
                    {
                        if (d.Rows[i].ItemArray[3].ToString() == "cancelled")
                        {
                            tc[j].Style.Add("color", "red");
                            
                        }
                        tc[j].Text =Convert.ToString(i + 1);
                    }
                    else if (j % 9 == 7)
                    {
                        b[i] = new System.Web.UI.WebControls.Button();
                        b[i].CssClass = "invoicebtn";
                        b[i].Attributes.Add("order_id", d.Rows[i].ItemArray[7].ToString());
                        b[i].Attributes.Add("product_id", d.Rows[i].ItemArray[4].ToString());
                        b[i].Attributes.Add("buyer_id", d.Rows[i].ItemArray[6].ToString());
                        b[i].CausesValidation = false;
                        b[i].Click += new EventHandler(btninvoice_Click);
                        b[i].Text = "Bill";
                        tc[j].Controls.Add(b[i]);
                    }
                    else if (j % 9 == 8)
                    {
                        t[i] = new System.Web.UI.WebControls.TextBox();
                        t[i].AutoPostBack = true;
                        t[i].MaxLength = 6;
                        t[i].TextChanged += new EventHandler(txtpin_TextChanged);
                        tc[j].Controls.Add(t[i]);
                        t[i].CssClass = "txtpin";
                        t[i].Attributes.Add("order_id", d.Rows[i].ItemArray[7].ToString());
                        t[i].Attributes.Add("product_id", d.Rows[i].ItemArray[4].ToString());
                        t[i].Attributes.Add("type","order");
                        if (d.Rows[i].ItemArray[3].ToString() == "cancelled")
                        {
                            t[i].Enabled = false;
                        }
                    }
                    else
                    {
                        if (d.Rows[i].ItemArray[3].ToString() == "cancelled")
                        {
                            tc[j].Style.Add("color", "red");
                            
                        }
                        tc[j].Text = d.Rows[i].ItemArray[loop].ToString().ToUpper();
                        loop++;
                    }
                    tr[i].Controls.Add(tc[j]);
                }
                tbltaskorder.Controls.Add(tr[i]);
            }
        }
        else
        {
            tbltaskorder.Visible = false;
        }
        if (d1.Rows.Count > 0)
        {
            TableRow[] tr = new TableRow[d1.Rows.Count];
            TableCell[] tc = new TableCell[d1.Rows.Count * 9];
            System.Web.UI.WebControls.TextBox[] t = new System.Web.UI.WebControls.TextBox[d1.Rows.Count];
            System.Web.UI.WebControls.Button[] b = new System.Web.UI.WebControls.Button[d1.Rows.Count];
            for (int i = 0; i < d1.Rows.Count; i++)
            {
                tr[i] = new TableRow();
                loop = 0;
                for (int j = (i * 9); j < (i * 9) + 9; j++)
                {
                    tc[j] = new TableCell();
                    if (j % 9 == 0)
                    {
                        tc[j].Text = Convert.ToString(i + 1);
                    }
                    else if (j % 9 == 7)
                    {
                        b[i] = new System.Web.UI.WebControls.Button();
                        b[i].CssClass = "invoicebtn";
                        b[i].Attributes.Add("order_id", d1.Rows[i].ItemArray[6].ToString());
                        b[i].Attributes.Add("product_id", d1.Rows[i].ItemArray[5].ToString());
                        b[i].Attributes.Add("buyer_id", d1.Rows[i].ItemArray[7].ToString());
                        b[i].CausesValidation = false;
                        b[i].Click += new EventHandler(btninvoice_Click);
                        b[i].Text = "Bill";
                        tc[j].Controls.Add(b[i]);
                    }
                    else if (j % 9 == 8)
                    {
                        t[i] = new System.Web.UI.WebControls.TextBox();
                        t[i].AutoPostBack = true;
                        t[i].MaxLength = 6;
                        t[i].TextChanged += new EventHandler(txtpin_TextChanged);
                        tc[j].Controls.Add(t[i]);
                        t[i].CssClass = "txtpin";
                        t[i].Attributes.Add("order_id", d1.Rows[i].ItemArray[6].ToString());
                        t[i].Attributes.Add("product_id", d1.Rows[i].ItemArray[5].ToString());
                        t[i].Attributes.Add("type", "return");
                    }
                    else 
                    {
                        tc[j].Text = d1.Rows[i].ItemArray[loop].ToString().ToUpper();
                        loop++;
                    }
                    tr[i].Controls.Add(tc[j]);
                }
                tbltaskreturn.Controls.Add(tr[i]);
            }
        }
        else
        {
            tbltaskreturn.Visible = false;
        }
    }
    protected void logout_Click(object sender, EventArgs e)
    {
        Session["log_id"] = null;
        Response.Redirect("Home.aspx");
    }
}

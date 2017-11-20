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
public partial class AdminDash : System.Web.UI.Page
{
    connect c = new connect();
    int loop = 0, loop1 = 0;
    static string uid = "", utype = "";
    static string clik;
    SqlDataAdapter adp = new SqlDataAdapter();
    DataTable searchdt = new DataTable();
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
   static DataTable dt10 = new DataTable();
    DataTable dt11 = new DataTable();
    DataTable dt12 = new DataTable();
    DataTable dt13 = new DataTable();
   static DataTable dt14 = new DataTable();
    DataTable dt15 = new DataTable();
   static DataTable dt16 = new DataTable();
    DataTable dt17 = new DataTable();
    DataTable dt18 = new DataTable();
    static DataTable dt19 = new DataTable();
    DataTable dt20 = new DataTable();
    DataTable dt21 = new DataTable();
    static DataTable dt22 = new DataTable();
    DataTable dt23 = new DataTable();
    DataTable dt24 = new DataTable();
    static DataTable dt25 = new DataTable();
    DataTable dt26 = new DataTable();
    DataTable dt27 = new DataTable();
    DataTable dt28 = new DataTable();
    DataTable dt29 = new DataTable();
   static DataTable dt30 = new DataTable();
    DataTable dt31 = new DataTable();
    DataTable dt32 = new DataTable();
    DataTable dt33 = new DataTable();
    DataTable dt34 = new DataTable();
    DataTable dt35 = new DataTable();
    DataTable dt36 = new DataTable();
    static int ct = 0, ct1 = 0, ct2 = 0, ct3 = 0, sellerselectedIndex = 0, logselectedIndex = 0;
    string m, n,o;
    string[] b = new string[12] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
    string[] s = new string[12] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
    string[] l = new string[12] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
    string[] cat = new string[1];
    string[] num = new string[1];
    DateTime date = DateTime.Now;
    static bool enable = false;
    string[] tot = new string[12] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
    string[] com = new string[12] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
 string[] logpay = new string[12] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin_id"] == null)
        {
            main.Visible = false;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
            Response.AddHeader("REFRESH", "3;URL=LoginAdmin.aspx");
        }
        else
        {
            main.Visible = true;
            c.cmd.CommandText = "select order_detail.order_id,product.name,order_detail.qty,order_detail.total,img1,order_detail.product_id,orders.buyer_id from orders,order_detail,product where orders.order_id=order_detail.order_id and order_detail.product_id=product.product_id";
            adp.SelectCommand = c.cmd;
            dt33.Clear();
            adp.Fill(dt33);
            if (dt33.Rows.Count > 0)
            {
                TableRow []tr = new TableRow[dt33.Rows.Count];
                TableCell[] tc = new TableCell[dt33.Rows.Count * 6];
                System.Web.UI.WebControls.Button[] b = new System.Web.UI.WebControls.Button[dt33.Rows.Count];
                Image[] img = new Image[dt33.Rows.Count];
                for (int i = 0; i < dt33.Rows.Count; i++)
                {
                    loop = 0;
                    tr[i] = new TableRow();
                    tr[i].CssClass = "tblcontent";
                    for (int j = i * 6; j < (i * 6) + 6; j++)
                    {
                        tc[j] = new TableCell();
                        tc[j].CssClass = "ordercontent";
                        if (j % 6 == 1)
                        {
                            img[i] = new Image();
                            img[i].CssClass = "recentimg";
                            img[i].ImageUrl = dt33.Rows[i].ItemArray[4].ToString();
                            tc[j].Controls.Add(img[i]);
                        }
                        else if (j % 6 == 5)
                        {
                            b[i] = new System.Web.UI.WebControls.Button();
                            b[i].CssClass = "paybtn";
                            b[i].Attributes.Add("product_id", dt33.Rows[i].ItemArray[5].ToString());
                            b[i].Attributes.Add("order_id", dt33.Rows[i].ItemArray[0].ToString());
                            b[i].Attributes.Add("buyer_id",dt33.Rows[i].ItemArray[6].ToString());
                            b[i].Click+=new EventHandler(bill_Click);
                            b[i].Text = "Bill";
                            tc[j].Controls.Add(b[i]);
                        }
                        else
                        {
                            tc[j].Text = dt33.Rows[i].ItemArray[loop].ToString().ToUpper();
                            loop++;
                        }
                        tr[i].Controls.Add(tc[j]);
                    }
                    horders.Controls.Add(tr[i]);
                }
            }

            c.cmd.CommandText = "select return_id,img1,product.name,sales_return.product_id,sales_return.order_id,orders.buyer_id from orders,sales_return,product where orders.order_id=sales_return.order_id and sales_return.product_id=product.product_id";
            adp.SelectCommand = c.cmd;
            dt34.Clear();
            adp.Fill(dt34);
            if (dt34.Rows.Count > 0)
            {
                TableRow[] tr1 = new TableRow[dt34.Rows.Count];
                TableCell[] tc1 = new TableCell[dt34.Rows.Count * 4];
                Image[] img1 = new Image[dt34.Rows.Count];
                System.Web.UI.WebControls.Button[] b = new System.Web.UI.WebControls.Button[dt34.Rows.Count];
                for (int i = 0; i < dt34.Rows.Count; i++)
                {
                    tr1[i] = new TableRow();
                    tr1[i].CssClass = "tblcontent";
                    for (int j = i * 4; j < (i * 4) + 4; j++)
                    {
                        tc1[j] = new TableCell();
                        tc1[j].CssClass = "ordercontent";
                        if (j % 4 == 1)
                        {
                            img1[i] = new Image();
                            img1[i].CssClass = "recentimg";
                            img1[i].ImageUrl = dt34.Rows[i].ItemArray[1].ToString();
                            tc1[j].Controls.Add(img1[i]);
                        }
                        else if (j % 4 == 3)
                        {
                            b[i] = new System.Web.UI.WebControls.Button();
                            b[i].Text = "Bill";
                            b[i].CssClass = "paybtn";
                            b[i].Attributes.Add("product_id",dt34.Rows[i].ItemArray[3].ToString());
                            b[i].Attributes.Add("order_id", dt34.Rows[i].ItemArray[4].ToString());
                            b[i].Attributes.Add("buyer_id", dt34.Rows[i].ItemArray[5].ToString());
                            b[i].Click += new EventHandler(bill_Click);
                            tc1[j].Controls.Add(b[i]);
                        }
                        else if(j%4==0)
                        {
                            tc1[j].Text = dt34.Rows[i].ItemArray[0].ToString().ToUpper();
                        }
                        else if (j % 4 == 2)
                        {
                            tc1[j].Text = dt34.Rows[i].ItemArray[2].ToString().ToUpper();
                        }
                        tr1[i].Controls.Add(tc1[j]);
                    }
                    hreturns.Controls.Add(tr1[i]);
                }
            }
        }
        if (!Page.IsPostBack)
        {
            dashboard_Click(this, EventArgs.Empty);
            sellerselectedIndex=0;
            logselectedIndex = 0;
        }
        if (enable)
        {
            enable = false;
            messages();
        }
    }

    void bill_Click(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.Button b = (System.Web.UI.WebControls.Button)sender;
        Session["order_id"] = b.Attributes["order_id"].ToString();
        Session["product_id"] = b.Attributes["product_id"].ToString();
        Session["buyer_id"] = b.Attributes["buyer_id"].ToString();
        Response.Redirect("Bill.aspx");
    }
    protected void dashboard_Click(object sender, EventArgs e)
    {
        paymentdiv.Visible = false;
        admindash.Visible = true;
        messagediv.Visible = false;
        products();
        seller();
        logistic();
        buyer();
        dash();
        clik = "dash";
        click(lidash);
    }
    protected void products_Click(object sender, EventArgs e)
    {
        paymentdiv.Visible = false;
        admindash.Visible = true;
        messagediv.Visible = false;
        products();
        clik="product";
        click(liproducts);
    }
    protected void sellers_Click(object sender, EventArgs e)
    {
        paymentdiv.Visible = false;
        admindash.Visible = true;
        messagediv.Visible = false;
        seller();
        clik = "seller";
        click(liseller);
    }
    protected void buyers_Click(object sender, EventArgs e)
    {
        paymentdiv.Visible = false;
        admindash.Visible = true;
        messagediv.Visible = false;
        buyer();
        clik = "buyer";
        click(libuyer);
    }
    protected void logistics_Click(object sender, EventArgs e)
    {
        paymentdiv.Visible = false;
        admindash.Visible = true;
        messagediv.Visible = false;
        logistic();
        clik = "logistic";
        click(lilogistic);
    }
    protected void payments_Click(object sender, EventArgs e)
    {
        ddfill();
        paymentdiv.Visible = true;
        admindash.Visible = false;
        messagediv.Visible = false;
        lblmessage.Text = "Messages";
        lblnewmember.Text = "Total Members";
        ct = ct1 + ct2 + ct3;
        lblmember.Text = ct.ToString();
        c.cmd.CommandText = "select count(*) from help where response is null and date in(select max(date) from help group by id)";
        adp.SelectCommand = c.cmd;
        dt35.Clear();
        adp.Fill(dt35);
        if (dt35.Rows.Count > 0)
        {
            lblmsg.Text = dt35.Rows[0].ItemArray[0].ToString();
        }
        clik = "payment";
        click(lipayment);
    }
    void dash()
    {
        txtkeyword.Visible = false;
        btnsearch.Visible = false;
        lblltest.Text = "Latest Orders";
        lblmessage.Text = "Messages";
        lblnewmember.Text = "Total Members";
        ct = ct1 + ct2 + ct3;
        lblmember.Text = ct.ToString();
        ordertbl.Visible = true;
        divmngprdcts.Visible = false;
        divrecentproduct.Visible = true;
        divlatest.Visible = true;
        divmngproducts.Visible = false;
        c.cmd.CommandText = "select count(*) from help where response is null and date in(select max(date) from help group by id)";
        adp.SelectCommand = c.cmd;
        dt29.Clear();
        adp.Fill(dt29);
        if (dt29.Rows.Count > 0)
        {
            lblmsg.Text = dt29.Rows[0].ItemArray[0].ToString();
        }
        c.cmd.CommandText = "SELECT SUM(order_detail.total),month(orders.date) FROM  orders, order_detail WHERE orders.order_id = order_detail.order_id GROUP BY MONTH(orders.date)";
        adp.SelectCommand = c.cmd;
        dt1.Clear();
        adp.Fill(dt1);
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            tot[Convert.ToInt16(dt1.Rows[i].ItemArray[1]) - 1] = dt1.Rows[i].ItemArray[0].ToString();
        }
        c.cmd.CommandText = "select sum(commission),month(date) from shoppie group by month(date)";
        adp.SelectCommand = c.cmd;
        dt28.Clear();
        adp.Fill(dt28);
        for (int i = 0; i < dt28.Rows.Count; i++)
        {
            com[Convert.ToInt16(dt28.Rows[i].ItemArray[1]) - 1] = dt28.Rows[i].ItemArray[0].ToString();
        }
        m = ""; n = "";
        m = string.Join(",", tot);
        n = string.Join(",",com);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "ch12", "<script>ch12('" + m + "','"+n+"')</script>");
        c.cmd.CommandText = "select order_id from orders";
        adp.SelectCommand = c.cmd;
        dt2.Clear();
        adp.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {
            lblorders.Text = dt2.Rows.Count.ToString();
        }
        else
        {
            lblorders.Text = "0";
        }
        c.cmd.CommandText = "select return_id from sales_return";
        adp.SelectCommand = c.cmd;
        dt3.Clear();
        adp.Fill(dt3);
        if (dt3.Rows.Count > 0)
        {
            lblreturns.Text = dt3.Rows.Count.ToString();
        }
        else
        {
            lblreturns.Text = "0";
        }
        c.cmd.CommandText = "select count(buyer_id),month(date) from buyer group by month(date)";
        adp.SelectCommand = c.cmd;
        dt4.Clear();
        adp.Fill(dt4);
        for (int i = 0; i < dt4.Rows.Count; i++)
        {
            b[Convert.ToInt16(dt4.Rows[i].ItemArray[1]) - 1] = dt4.Rows[i].ItemArray[0].ToString();
        }
        c.cmd.CommandText = "select count(seller_id),month(date) from seller group by month(date)";
        adp.SelectCommand = c.cmd;
        dt5.Clear();
        adp.Fill(dt5);
        for (int i = 0; i < dt5.Rows.Count; i++)
        {
            s[Convert.ToInt16(dt5.Rows[i].ItemArray[1]) - 1] = dt5.Rows[i].ItemArray[0].ToString();
        }
        c.cmd.CommandText = "select count(log_id),month(date) from logistic group by month(date)";
        adp.SelectCommand = c.cmd;
        dt6.Clear();
        adp.Fill(dt6);
        for (int i = 0; i < dt6.Rows.Count; i++)
        {
            l[Convert.ToInt16(dt6.Rows[i].ItemArray[1]) - 1] = dt6.Rows[i].ItemArray[0].ToString();
        }
        m = ""; n = ""; o = "";
        m = string.Join(",",b);
        n = string.Join(",", s);
        o = string.Join(",",l);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "ch5", "<script>ch5('" + m + "','" + n + "','"+o+"')</script>");


        c.cmd.CommandText = "select product.img1,orders.order_id,order_detail.name,order_detail.total,order_detail.status from product,orders,order_detail where orders.order_id=order_detail.order_id and order_detail.product_id=product.product_id and day(orders.date)=@day and month(orders.date)=@month and year(orders.date)=@year";
        c.cmd.Parameters.Clear();
        c.cmd.Parameters.Add("@day", SqlDbType.Int).Value = date.Day;
        c.cmd.Parameters.Add("@month", SqlDbType.Int).Value = date.Month;
        c.cmd.Parameters.Add("@year", SqlDbType.Int).Value = date.Year;
        adp.SelectCommand = c.cmd;
        dt7.Clear();
        
        adp.Fill(dt7);
        if (dt7.Rows.Count > 0)
        {
            divlatest.Style.Add("background-image", "none");
            TableRow[] tr = new TableRow[5];
            TableCell[] tc = new TableCell[25];
            Image[] img = new Image[5];
            for (int i = 0; i < 5 && i < dt7.Rows.Count; i++)
            {
                tr[i] = new TableRow();
                tr[i].CssClass = "tblcontent";
                loop = 0;
                int loop1 = 0;
                for (int j = i * 5; j < (i * 5) + 5; j++)
                {
                    tc[j] = new TableCell();
                    tc[j].CssClass = "ordercontent";
                    if (j % 5 == 0)
                    {
                        img[loop1] = new Image();
                        img[loop1].ImageUrl = dt7.Rows[i].ItemArray[loop].ToString();
                        img[loop1].CssClass = "recentimg";
                        tc[j].Controls.Add(img[loop1]);
                        loop1++;
                    }
                    else if (j % 5 == 1)
                    {
                        tc[j].Text = "ORD" + dt7.Rows[i].ItemArray[loop].ToString();
                    }
                    else
                    {
                        tc[j].Text = dt7.Rows[i].ItemArray[loop].ToString().ToUpper();
                    }
                    loop++;
                    tr[i].Controls.Add(tc[j]);
                }
                ordertbl.Controls.Add(tr[i]);
            }
        }
        else
        {
            ordertbl.Visible = false;
            divlatest.Style.Add("background-image", "css/image/icon/nothing-icon.jpg");
            divlatest.Style.Add("background-size", "50%");
            divlatest.Style.Add("background-position", "center");
            divlatest.Style.Add("background-repeat", "no-repeat");

        }
        c.cmd.CommandText = "select img1,product_id,name,brand,price,qty from product order by date desc";
        adp.SelectCommand = c.cmd;
        dt11.Clear();
        adp.Fill(dt11);
        if (dt11.Rows.Count > 0)
        {
            Image[] img = new Image[dt11.Rows.Count];
            TableRow[] tr1 = new TableRow[dt11.Rows.Count];
            TableCell[] tc1 = new TableCell[dt11.Rows.Count * 5];
            loop = 0;
            for (int i = 0; i < dt11.Rows.Count && i < 5; i++)
            {
                tr1[i] = new TableRow();
                tr1[i].CssClass = "tblcontent";
                for (int j = 0; j < 6; j++)
                {
                    tc1[j] = new TableCell();
                    tc1[j].CssClass = "ordercontent";
                    tc1[j].ID = "productcontent" + j;
                    if (j % 6 == 0)
                    {
                        img[loop] = new Image();
                        img[loop].ImageUrl = dt11.Rows[i].ItemArray[j].ToString();
                        img[loop].CssClass = "recentimg";
                        tc1[j].Controls.Add(img[loop]);
                        loop++;
                    }
                    else
                    {
                        tc1[j].Text = dt11.Rows[i].ItemArray[j].ToString().ToUpper();
                    }
                    tr1[i].Controls.Add(tc1[j]);
                }
                tblrecentorder.Controls.Add(tr1[i]);
            }

        }
        else
        {
            
        }
    }
    void products()
    {
        lblltest.Text = "Manage Products";
        lblmessage.Text = "Messages";
        lblnewmember.Text = "Total Members";
        ct = ct1 + ct2 + ct3;
        lblmember.Text = ct.ToString();
        txtkeyword.Visible = true;
        btnsearch.Visible = true;
        ordertbl.Visible = false;
        divmngprdcts.Visible = true;
        divrecentproduct.Visible = false;
        divlatest.Visible = false;
        divmngproducts.Visible = true;
        tblseller.Visible = false;
        tblprdcts.Visible = true;
        productcharts();
        c.cmd.CommandText = "select img1,product_id,name,category,qty,price,brand,keyword from product order by date";
        adp.SelectCommand = c.cmd;
        dt10.Clear();
        adp.Fill(dt10);
        producttbl(dt10);
 }
    void productcharts()
    {
        c.cmd.CommandText = "SELECT SUM(qty),category FROM product GROUP BY category";
        adp.SelectCommand = c.cmd;
        dt.Clear();
        adp.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            string[] qty = new string[dt.Rows.Count];
            string[] cat = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cat[i] = dt.Rows[i].ItemArray[1].ToString();
                qty[i] = dt.Rows[i].ItemArray[0].ToString();
            }
            m = string.Join(",", cat);
            n = string.Join(",", qty);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ch4", "<script>ch4('" + m + "','" + n + "')</script>");
        }
        c.cmd.CommandText = "select sum(order_detail.qty),category,count(*) from order_detail,product where order_detail.product_id=product.product_id group by category";
        adp.SelectCommand = c.cmd;
        dt8.Clear();
        adp.Fill(dt8);
        c.cmd.CommandText = "select cat_name from category";
        adp.SelectCommand = c.cmd;
        dt9.Clear();
        adp.Fill(dt9);
        if (dt9.Rows.Count > 0)
        {
            Array.Resize(ref cat, dt9.Rows.Count);
            Array.Resize(ref num, dt9.Rows.Count);
            for (int i = 0; i < dt9.Rows.Count; i++)
            {
                cat[i] = dt9.Rows[i].ItemArray[0].ToString();
                num[i] = "0";
            }
        }
        loop = 0;
        if (Convert.ToInt16(dt8.Rows[0].ItemArray[2]) > 0)
        {
            for (int i = 0; i < dt9.Rows.Count; i++)
            {
                for (int j = 0; j < dt8.Rows.Count; j++)
                {
                    if (dt8.Rows[j].ItemArray[1].ToString() == dt9.Rows[i].ItemArray[0].ToString())
                    {
                        num[i] = dt8.Rows[j].ItemArray[0].ToString();
                    }
                }
            }
            m = ""; n = "";
            m = string.Join(",", cat);
            n = string.Join(",", num);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ch8", "<script>ch8('" + m + "','" + n + "')</script>");
        }

    }
    void producttbl(DataTable table)
    {
        loop = 0;
        int loop1 = 0;
        if (table.Rows.Count > 0)
        {
            TableRow[] tr = new TableRow[table.Rows.Count];
            Image[] img = new Image[table.Rows.Count];
            TableCell[] tc = new TableCell[table.Rows.Count * 7];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                tr[i] = new TableRow();
                tr[i].CssClass = "tblcontent";
                loop = 0;
                for (int j = i * 7; j < (i * 7) + 7; j++)
                {
                    tc[j] = new TableCell();
                    tc[j].CssClass = "ordercontent";
                    if (j % 7 == 0)
                    {
                        img[loop1] = new Image();
                        img[loop1].ImageUrl = table.Rows[i].ItemArray[loop].ToString();
                        img[loop1].CssClass = "recentimg";
                        tc[j].Controls.Add(img[loop1]);
                        loop1++;
                    }
                    else
                    {
                        tc[j].Text = table.Rows[i].ItemArray[loop].ToString().ToUpper();
                    }
                    tr[i].Controls.Add(tc[j]);
                    loop++;
                }
                tblprdcts.Controls.Add(tr[i]);
            }
        }
        else
        { 
        
        }
    }
    void seller()
    {
        lblltest.Text = "Manage Sellers";
        ordertbl.Visible = false;
        divmngprdcts.Visible = true;
        divrecentproduct.Visible = false;
        tblseller.Visible = true;
        tblprdcts.Visible = false;
        divlatest.Visible = false;
        txtkeyword.Visible = true;
        btnsearch.Visible = true;
        sellercharts();
        c.cmd.CommandText = "select count(*) from help where response is null and utype='seller'  and date in(select max(date) from help group by id)";
        adp.SelectCommand = c.cmd;
        dt29.Clear();
        adp.Fill(dt29);
        if (dt29.Rows.Count > 0)
        {
            lblmsg.Text = dt29.Rows[0].ItemArray[0].ToString();
        }
        c.cmd.CommandText = "select count(seller_id) from seller";
        adp.SelectCommand = c.cmd;
        dt12.Clear();
        adp.Fill(dt12);
        lblnewmember.Text = "Total Sellers";
        lblmessage.Text = "Sellers Messages";
        if (dt12.Rows.Count > 0)
        {
            lblmember.Text = dt12.Rows[0].ItemArray[0].ToString();
        }
        else
        {
            lblmember.Text = "0";
        }
        ct1= Convert.ToInt16(lblmember.Text);
        c.cmd.CommandText = "select seller_id,name,email,phone,country,state,city,address,pin from seller";
        adp.SelectCommand = c.cmd;
        dt14.Clear();
        adp.Fill(dt14);
        sellertbl(dt14);
    }
    void sellertbl(DataTable table)
    {
        loop = 0;
        if (table.Rows.Count > 0)
        {
            TableRow[] tr = new TableRow[table.Rows.Count];
            TableCell[] tc = new TableCell[table.Rows.Count * 9];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                tr[i] = new TableRow();
                tr[i].CssClass = "tblcontent";
                loop = 0;
                for (int j = i * 9; j < (i * 9) +9; j++)
                {
                    tc[j] = new TableCell();
                    tc[j].CssClass = "ordercontent";
                    if (j % 9 == 0)
                    {
                         tc[j].Text ="SEL"+table.Rows[i].ItemArray[loop].ToString().ToUpper();
                    }
                    else
                    {
                        tc[j].Text = table.Rows[i].ItemArray[loop].ToString().ToUpper();
                        tr[i].Controls.Add(tc[j]);
                    loop++;
                }
                tblseller.Controls.Add(tr[i]);
            }
        }
    }
    else
    {

    }
    }
    void sellercharts()
    {
        c.cmd.CommandText = "select top 5 seller.seller_id,seller.name,sum(total) from seller,order_detail where seller.seller_id=order_detail.seller_id group by seller.seller_id,seller.name order by sum(total) desc";
        adp.SelectCommand = c.cmd;
        dt13.Clear();
        adp.Fill(dt13);
        m = ""; n = "";
        if (dt13.Rows.Count > 0)
        {
            string[] name = new string[dt13.Rows.Count];
            string[] t = new string[dt13.Rows.Count];
            for (int i = 0; i < dt13.Rows.Count; i++)
            {
                name[i] = dt13.Rows[i].ItemArray[1].ToString();
                name[i] = name[i].ToUpper();
                t[i] = dt13.Rows[i].ItemArray[2].ToString();
            }
            m = string.Join(",", name);
            n = string.Join(",", t);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ch9", "<script>ch9('" + m + "','" + n + "')</script>");
        }
        else
        {
            
        }
        c.cmd.CommandText = "select top 5 seller.seller_id,seller.name,sum(qty) from seller,product where seller.seller_id=product.seller_id group by seller.seller_id,seller.name order by sum(qty) desc";
        adp.SelectCommand = c.cmd;
        dt15.Clear();
        adp.Fill(dt15);
        m = "";n="";
        if (dt15.Rows.Count > 0)
        {
            string[] name = new string[dt15.Rows.Count];
            string[] t = new string[dt15.Rows.Count];
            for (int i = 0; i < dt15.Rows.Count; i++)
            {
                name[i] = dt15.Rows[i].ItemArray[1].ToString();
                name[i] = name[i].ToUpper();
                t[i] = dt15.Rows[i].ItemArray[2].ToString();
            }
            m = string.Join(",", name);
            n = string.Join(",", t);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ch10", "<script>ch10('" + m + "','" + n + "')</script>");
        }
        else
        { 
            
        }

    }
    void buyer()
    {
        lblltest.Text = "Manage Buyers";
        ordertbl.Visible = false;
        divmngprdcts.Visible = true;
        divrecentproduct.Visible = false;
        tblseller.Visible = true;
        tblprdcts.Visible = false;
        divlatest.Visible = false;
        txtkeyword.Visible = true;
        btnsearch.Visible = true;
        buyercharts();
        c.cmd.CommandText = "select count(*) from help where response is null and utype='buyer'  and date in(select max(date) from help group by id)";
        adp.SelectCommand = c.cmd;
        dt29.Clear();
        adp.Fill(dt29);
        if (dt29.Rows.Count > 0)
        {
            lblmsg.Text = dt29.Rows[0].ItemArray[0].ToString();
        }
        c.cmd.CommandText = "select count(buyer_id) from buyer";
        adp.SelectCommand = c.cmd;
        dt12.Clear();
        adp.Fill(dt20);
        lblnewmember.Text = "Total Buyers";
        lblmessage.Text = "Buyers Messages";
        if (dt20.Rows.Count > 0)
        {
            lblmember.Text = dt20.Rows[0].ItemArray[0].ToString();
        }
        else
        {
            lblmember.Text = "0";
        }
        ct2 = Convert.ToInt16(lblmember.Text);
        c.cmd.CommandText = "select buyer_id,name,email,phone,country,state,city,address,pin from buyer";
        adp.SelectCommand = c.cmd;
        dt16.Clear();
        adp.Fill(dt16);
        buyertbl(dt16);
    }
    void buyertbl(DataTable table)
    {
        loop = 0;
        if (table.Rows.Count > 0)
        {
            TableRow[] tr = new TableRow[table.Rows.Count];
            TableCell[] tc = new TableCell[table.Rows.Count * 9];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                tr[i] = new TableRow();
                tr[i].CssClass = "tblcontent";
                loop = 0;
                for (int j = i * 9; j < (i * 9) + 9; j++)
                {
                    tc[j] = new TableCell();
                    tc[j].CssClass = "ordercontent";
                    if (j % 9 == 0)
                    {
                        tc[j].Text = "BUY" + table.Rows[i].ItemArray[loop].ToString().ToUpper();
                    }
                    else
                    {
                        tc[j].Text = table.Rows[i].ItemArray[loop].ToString().ToUpper();
                        tr[i].Controls.Add(tc[j]);
                        loop++;
                    }
                    tblseller.Controls.Add(tr[i]);
                }
            }
        }
        else
        {

        }
    }
    void buyercharts()
    {
        c.cmd.CommandText = "select top 5 buyer.buyer_id,buyer.name,sum(orders.total) from buyer,orders where buyer.buyer_id=orders.buyer_id  group by buyer.buyer_id,buyer.name order by sum(orders.total) desc";
        adp.SelectCommand = c.cmd;
        dt17.Clear();
        adp.Fill(dt17);
        m = ""; n = "";
        if (dt17.Rows.Count > 0)
        {
            string[] name = new string[dt17.Rows.Count];
            string[] t = new string[dt17.Rows.Count];
            for (int i = 0; i < dt17.Rows.Count; i++)
            {
                name[i] = dt17.Rows[i].ItemArray[1].ToString();
                name[i] = name[i].ToUpper();
                t[i] = dt17.Rows[i].ItemArray[2].ToString();
            }
            m = string.Join(",", name);
            n = string.Join(",", t);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ch11", "<script>ch11('" + m + "','" + n + "')</script>");
        }
        else
        { 
        
        }
        c.cmd.CommandText = "select top 5 buyer.buyer_id,buyer.name,count(orders.order_id) from buyer,orders where buyer.buyer_id=orders.buyer_id  group by buyer.buyer_id,buyer.name order by count(orders.order_id) desc";
        adp.SelectCommand = c.cmd;
        dt18.Clear();
        adp.Fill(dt18);
        m = ""; n = "";
        if (dt18.Rows.Count > 0)
        {
            string[] name = new string[dt18.Rows.Count];
            string[] t = new string[dt18.Rows.Count];
            for (int i = 0; i < dt18.Rows.Count; i++)
            {
                name[i] = dt18.Rows[i].ItemArray[1].ToString();
                name[i] = name[i].ToUpper();
                t[i] = dt18.Rows[i].ItemArray[2].ToString();
            }
            m = string.Join(",", name);
            n = string.Join(",", t);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ch15", "<script>ch15('" + m + "','" + n + "')</script>");
        }
        else
        {

        }
    }
    void logistic()
    {
        lblltest.Text = "Manage Logistics";
        ordertbl.Visible = false;
        divmngprdcts.Visible = true;
        divrecentproduct.Visible = false;
        tblseller.Visible = true;
        tblprdcts.Visible = false;
        divlatest.Visible = false;
        txtkeyword.Visible = true;
        btnsearch.Visible = true;
        logistoccharts();
        c.cmd.CommandText = "select count(*) from help where response is null and utype='logistic'  and date in(select max(date) from help group by id)";
        adp.SelectCommand = c.cmd;
        dt29.Clear();
        adp.Fill(dt29);
        if (dt29.Rows.Count > 0)
        {
            lblmsg.Text = dt29.Rows[0].ItemArray[0].ToString();
        }
        c.cmd.CommandText = "select count(log_id) from logistic";
        adp.SelectCommand = c.cmd;
        dt21.Clear();
        adp.Fill(dt21);
        lblnewmember.Text = "Total Logistics";
        lblmessage.Text = "Logistic Messages";
        if (dt21.Rows.Count > 0)
        {
           lblmember.Text = dt21.Rows[0].ItemArray[0].ToString();
        }
        else
        {
            lblmember.Text = "0";
        }
        ct3 = Convert.ToInt16(lblmember.Text);
        c.cmd.CommandText = "select log_id,name,email,phone,country,state,city,address,pin from logistic";
        adp.SelectCommand = c.cmd;
        dt19.Clear();
        adp.Fill(dt19);
        logistictbls(dt19);
    }
    void logistictbls(DataTable table)
    {
        loop = 0;
        if (table.Rows.Count > 0)
        {
            TableRow[] tr = new TableRow[table.Rows.Count];
            TableCell[] tc = new TableCell[table.Rows.Count * 9];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                tr[i] = new TableRow();
                tr[i].CssClass = "tblcontent";
                loop = 0;
                for (int j = i * 9; j < (i * 9) + 9; j++)
                {
                    tc[j] = new TableCell();
                    tc[j].CssClass = "ordercontent";
                    if (j % 9 == 0)
                    {
                        tc[j].Text = "LOG" + table.Rows[i].ItemArray[loop].ToString().ToUpper();
                    }
                    else
                    {
                        tc[j].Text = table.Rows[i].ItemArray[loop].ToString().ToUpper();
                        tr[i].Controls.Add(tc[j]);
                        loop++;
                    }
                    tblseller.Controls.Add(tr[i]);
                }
            }
        }
        else
        {

        }
    }
void logistoccharts()
    {
        c.cmd.CommandText = "select sum(pay),month(date) from logistic_pay where remaining=0 group by month(date)";
        adp.SelectCommand = c.cmd;
        dt35.Clear();
        adp.Fill(dt35);
        if (dt35.Rows.Count > 0)
        {
            for (int i = 0; i < dt35.Rows.Count; i++)
            {
                logpay[Convert.ToInt16(dt35.Rows[i].ItemArray[1]) - 1] = dt35.Rows[i].ItemArray[0].ToString();
            }
            m = "";
            m = string.Join(",", logpay);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ch13", "<script>ch13('" + m + "')</script>");
        }
        else
        {
            m = "";
            m = string.Join(",", logpay);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ch13", "<script>ch13('" + m + "')</script>");
        }

        c.cmd.CommandText = "select top 5 logistic.log_id,logistic.name,sum(total) from logistic,orders where logistic.log_id=orders.log_id group by logistic.log_id,name order by sum(total) desc";
        adp.SelectCommand = c.cmd;
        dt36.Clear();
        adp.Fill(dt36);
        m = ""; n = "";
        if (dt36.Rows.Count > 0)
        {
            string[] name = new string[dt36.Rows.Count];
            string[] t = new string[dt36.Rows.Count];
            for (int i = 0; i < dt36.Rows.Count; i++)
            {
                name[i] = dt36.Rows[i].ItemArray[1].ToString();
                name[i] = name[i].ToUpper();
                t[i] = dt36.Rows[i].ItemArray[2].ToString();
            }
            m = string.Join(",", name);
            n = string.Join(",", t);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ch14", "<script>ch14('" + m + "','" + n + "')</script>");
        }
    }
    void ddfill()
    {
        c.cmd.CommandText = "select distinct(year(date)) from orders order by year(date)";
        adp.SelectCommand = c.cmd;
        dt26.Clear();
        adp.Fill(dt26);
        ddyear.Items.Clear();
        ddyear.Items.Add("Select Here");
        ddyear1.Items.Clear();
        ddyear1.Items.Add("Select Here");
        for (int i = 0; i < dt26.Rows.Count; i++)
        {
            ddyear.Items.Add(dt26.Rows[i].ItemArray[0].ToString());
            ddyear1.Items.Add(dt26.Rows[i].ItemArray[0].ToString());
        }
    }
    protected void ddseller_change(object sender, EventArgs e)
    {
        try
        {
            sellerselectedIndex = Convert.ToInt16(ddseller.SelectedIndex);
            DataView dv = new DataView();
            if (dt22.Rows.Count > 0)
            {
                dv = dt22.DefaultView;
                dv.RowFilter = "seller_id=" + Convert.ToInt64(ddseller.SelectedItem.Text) + "";
                if (dv.ToTable().Rows.Count > 0)
                {
                    cellname.Text = dv.ToTable().Rows[0].ItemArray[3].ToString().ToUpper();
                    cellpay.Text = dv.ToTable().Rows[0].ItemArray[1].ToString();
                }
            }
        }
        catch (FormatException)
        {
            cellname.Text = "";
            cellpay.Text = "";
        }
    }
    protected void ddlogistic_change(object sender, EventArgs e)
    {
        try
        {
            logselectedIndex = Convert.ToInt16(ddlogistic.SelectedIndex);
            DataView dv = new DataView();
            if (dt25.Rows.Count > 0)
            {
                dv = dt25.DefaultView;
                dv.RowFilter = "log_id=" + Convert.ToInt64(ddlogistic.SelectedItem.Text)+ "";
                if (dv.ToTable().Rows.Count > 0)
                {
                    cellname1.Text = dv.ToTable().Rows[0].ItemArray[3].ToString().ToUpper();
                    cellpay1.Text = dv.ToTable().Rows[0].ItemArray[1].ToString();
                }
            }
        }
        catch (FormatException)
        {
            cellname1.Text = "";
            cellpay1.Text = "";
        }
    }
    protected void ddyear_change(object sender, EventArgs e)
    {
        try
        {
            ddmonth.Items.Clear();
            ddseller.Items.Clear() ;
            cellname.Text = "";
            cellpay.Text = "";
            c.cmd.CommandText = "select distinct DATENAME(month,date),month(date) from orders,order_detail where orders.order_id=order_detail.order_id and status in(select status from order_detail where status='delivered' or status='return delivered') and year(date)=" + Convert.ToInt32(ddyear.SelectedItem.Text) + " and month(date)<>@month order by month(date)";
            c.cmd.Parameters.Clear();
            c.cmd.Parameters.Add("@month", SqlDbType.Int).Value = DateTime.Now.Month;
            adp.SelectCommand = c.cmd;
            dt26.Clear();
            adp.Fill(dt26);
            ddmonth.Items.Clear();
            ddmonth.Items.Add("Select Here");
            if (dt26.Rows.Count > 0)
            {
                for (int i = 0; i < dt26.Rows.Count; i++)
                {
                    ddmonth.Items.Add(dt26.Rows[i].ItemArray[0].ToString());
                }
            }
            else
            {
                ddmonth.Items.Clear();
                ddseller.Items.Clear();
                cellname.Text = "";
                cellpay.Text = "";
            }
        }
        catch (FormatException)
        {
            ddmonth.Items.Clear();
            ddseller.Items.Clear();
            cellname.Text = "";
            cellpay.Text = "";
        }
    }
    protected void ddmonth_change(object sender, EventArgs e)
    {
        c.cmd.CommandText = "select  seller_pay.seller_id,sum(pay),sum(remaining),name from seller,seller_pay where seller.seller_id=seller_pay.seller_id and month(seller_pay.date)=@month and year(seller_pay.date)=@year group by seller_pay.seller_id,name";
        c.cmd.Parameters.Clear();
        c.cmd.Parameters.Add("@month", SqlDbType.Int).Value = monthtonumber(ddmonth.SelectedItem.Text);
        c.cmd.Parameters.Add("@year", SqlDbType.Int).Value = ddyear.SelectedItem.Text;
        adp.SelectCommand = c.cmd;
        dt22.Clear();
        adp.Fill(dt22);
        if (dt22.Rows.Count > 0)
        {
            ddseller.Items.Clear();
            ddseller.Items.Add("Select Here");
            for (int i = 0; i < dt22.Rows.Count; i++)
            {
                if (Convert.ToInt64(dt22.Rows[i].ItemArray[2]) > 0)
                {
                    ddseller.Items.Add(dt22.Rows[i].ItemArray[0].ToString());
                }
            }
            ddseller.SelectedIndex = sellerselectedIndex;
        }
        else
        {
            ddseller.Items.Clear();
            ddseller.Items.Add("Payment Done");
        }
        if (ddseller.SelectedIndex > 0)
        {
            ddseller_change(this, EventArgs.Empty);
        }
    }
    protected void ddyear1_change(object sender, EventArgs e)
    {
        try
        {
            ddmonth1.Items.Clear();
            ddlogistic.Items.Clear();
            cellname1.Text = "";
            cellpay1.Text = "";
            c.cmd.CommandText = "select distinct DATENAME(month,date),month(date) from orders,order_detail where orders.order_id=order_detail.order_id and status in(select status from order_detail where status='delivered' or status='return delivered') and year(date)=" + Convert.ToInt32(ddyear1.SelectedItem.Text) + " and month(date)<>@month order by month(date)";
            c.cmd.Parameters.Clear();
            c.cmd.Parameters.Add("@month", SqlDbType.Int).Value = DateTime.Now.Month;
            adp.SelectCommand = c.cmd;
            dt27.Clear();
            adp.Fill(dt27);
            ddmonth1.Items.Clear();
            ddmonth1.Items.Add("Select Here");
            if (dt27.Rows.Count > 0)
            {
                for (int i = 0; i < dt27.Rows.Count; i++)
                {
                    ddmonth1.Items.Add(dt27.Rows[i].ItemArray[0].ToString());
                }
            }
            else
            {
                ddmonth1.Items.Clear();
                ddlogistic.Items.Clear();
                cellname1.Text = "";
                cellpay1.Text = "";
            }
        }
        catch (FormatException)
        {
            ddmonth.Items.Clear();
            ddlogistic.Items.Clear();
            cellname1.Text = "";
            cellpay1.Text = "";
        }
    }
    protected void ddmonth1_change(object sender, EventArgs e)
    {
        try
        {
            c.cmd.CommandText = "select logistic_pay.log_id,sum(pay),sum(remaining),name from logistic,logistic_pay where logistic_pay.log_id=logistic.log_id and month(logistic_pay.date)=@month and year(logistic_pay.date)=@year group by logistic_pay.log_id,name";
            c.cmd.Parameters.Clear();
            c.cmd.Parameters.Add("@month", SqlDbType.Int).Value = monthtonumber(ddmonth1.SelectedItem.Text);
            c.cmd.Parameters.Add("@year", SqlDbType.Int).Value = ddyear1.SelectedItem.Text;
            adp.SelectCommand = c.cmd;
            dt25.Clear();
            adp.Fill(dt25);
            if (dt25.Rows.Count > 0)
            {
                ddlogistic.Items.Clear();
                ddlogistic.Items.Add("Select here");
                for (int i = 0; i < dt25.Rows.Count; i++)
                {
                    if (Convert.ToInt64(dt25.Rows[i].ItemArray[2]) > 0)
                    {
                        ddlogistic.Items.Add(dt25.Rows[i].ItemArray[0].ToString());
                    }
                }
                ddlogistic.SelectedIndex = logselectedIndex;
            }
            else
            {
                ddlogistic.Items.Clear();
                ddlogistic.Items.Add("Payment Done");
            }
        }
        catch (FormatException)
        {

        }
    }
    protected void btnpayseller_Click(object sender, EventArgs e)
    {
        try
        {
            c.cmd.CommandText = "update seller_pay set remaining=0,date=@date where seller_id=" + Convert.ToInt64(ddseller.SelectedItem.Text) + " and month(date)=@month and year(date)=@year";
            c.cmd.Parameters.Clear();
            c.cmd.Parameters.Add("@date",SqlDbType.DateTime).Value=DateTime.Now;
            c.cmd.Parameters.Add("@month", SqlDbType.Int).Value = DateTime.Now.Month;
            c.cmd.Parameters.Add("@year", SqlDbType.Int).Value = DateTime.Now.Year;
            c.cmd.ExecuteNonQuery();
            ddseller.SelectedIndex = 0;
            ddseller_change(this, EventArgs.Empty);
        }
        catch (FormatException)
        { 
        
        }
    }
    protected void btnpaylog_Click(object sender, EventArgs e)
    {
        try
        {
            c.cmd.CommandText = "update logistic_pay set remaining=0,date=@date where log_id=" + Convert.ToInt64(ddlogistic.SelectedItem.Text) + " and month(date)=@month and year(date)=@year";
            c.cmd.Parameters.Clear();
            c.cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
            c.cmd.Parameters.Add("@month", SqlDbType.Int).Value = DateTime.Now.Month-1;
            c.cmd.Parameters.Add("@year", SqlDbType.Int).Value = DateTime.Now.Year;
            c.cmd.ExecuteNonQuery();
            logselectedIndex = 0;
            ddlogistic.SelectedIndex = 0;
            ddlogistic_change(this, EventArgs.Empty);
        }
        catch (FormatException)
        { 
        
        }
    }
    void click(HtmlGenericControl l)
    {
        lidash.Style.Add("background","rgba(19, 35, 47, 1)");
        lidash.Style.Add("color","White");
        lidash.Style.Add("border-left","none");

        liproducts.Style.Add("background", "rgba(19, 35, 47, 1)");
        liproducts.Style.Add("color", "White");
        liproducts.Style.Add("border-left", "none");

        liseller.Style.Add("background", "rgba(19, 35, 47, 1)");
        liseller.Style.Add("color", "White");
        liseller.Style.Add("border-left", "none");

        liseller.Style.Add("background", "rgba(19, 35, 47, 1)");
        liseller.Style.Add("color", "White");
        liseller.Style.Add("border-left", "none");

        libuyer.Style.Add("background", "rgba(19, 35, 47, 1)");
        libuyer.Style.Add("color", "White");
        libuyer.Style.Add("border-left", "none");

        lilogistic.Style.Add("background", "rgba(19, 35, 47, 1)");
        lilogistic.Style.Add("color", "White");
        lilogistic.Style.Add("border-left", "none");

        lipayment.Style.Add("background", "rgba(19, 35, 47, 1)");
        lipayment.Style.Add("color", "White");
        lipayment.Style.Add("border-left", "none");

        HtmlGenericControl li = (HtmlGenericControl)l;
        li.Style.Add("background", "rgba(13, 28, 40, 1)");
        li.Style.Add("color", "#1abc9c");
        li.Style.Add("border-left", "4px solid #337ab7");
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (clik == "product")
        {
            productcharts();
            DataTable d = new DataTable();
            DataView dv = new DataView(dt10);
            dv.RowFilter = "keyword like'*"+txtkeyword.Text+"*'";
            d = dv.ToTable();
            producttbl(d);
        }
        else if (clik == "seller")
        {
            sellercharts();
            DataTable d = new DataTable();
            DataView dv = new DataView(dt14);
            dv.RowFilter = "name like'*" + txtkeyword.Text + "*' or city like '*" + txtkeyword.Text + "*' or country like '*" + txtkeyword.Text + "*' or state like '*" + txtkeyword.Text + "*' or Convert(phone,'System.String') like '*"+txtkeyword.Text+"*' or Convert(seller_id,'System.String') like '*"+txtkeyword.Text+"*'";
            d = dv.ToTable();
            sellertbl(d);
        }
        else if (clik == "buyer")
        {
            buyercharts();
            DataTable d = new DataTable();
            DataView dv = new DataView(dt16);
            dv.RowFilter = "name like'*" + txtkeyword.Text + "*' or city like '*" + txtkeyword.Text + "*' or country like '*" + txtkeyword.Text + "*' or state like '*" + txtkeyword.Text + "*' or Convert(phone,'System.String') like '*" + txtkeyword.Text + "*' or Convert(buyer_id,'System.String') like '*" + txtkeyword.Text + "*'";
            d = dv.ToTable();
            buyertbl(d);
        }
         else if (clik =="logistic")
        {
            logistoccharts();
            DataTable d = new DataTable();
            DataView dv = new DataView(dt19);
            dv.RowFilter = "name like'*" + txtkeyword.Text + "*' or city like '*" + txtkeyword.Text + "*' or country like '*" + txtkeyword.Text + "*' or state like '*" + txtkeyword.Text + "*' or Convert(phone,'System.String') like '*" + txtkeyword.Text + "*' or Convert(log_id,'System.String') like '*" + txtkeyword.Text + "*'";
            d = dv.ToTable();
            logistictbls(d);
        }
    }
    protected void amsg_Click(object sender, EventArgs e)
    {
        paymentdiv.Visible = false;
        admindash.Visible = false;
        messagediv.Visible = true;
        msgdiv.Visible = true;
        chatdiv.Visible = false;
        typediv.Visible = false;
        headdiv.Visible = false;
        enable = true;
        messages();
    }
    void messages()
    {
        if (clik == "dash" || clik=="product" || clik=="payment")
        {
            c.cmd.CommandText = "select id,utype from help where response is null and date in(select max(date) from help group by id )";
            adp.SelectCommand = c.cmd;
            dt30.Clear();
            adp.Fill(dt30);
            if (dt30.Rows.Count > 0)
            {
                HtmlAnchor[] a = new HtmlAnchor[dt30.Rows.Count];
                HtmlGenericControl[] div = new HtmlGenericControl[dt30.Rows.Count];
                HtmlGenericControl q = new HtmlGenericControl("p");
                q.InnerHtml = "New Messages";
                msgdiv.Controls.Add(q);
                for (int i = 0; i < dt30.Rows.Count; i++)
                {
                    a[i] = new HtmlAnchor();
                    a[i].Attributes.Add("class", "aname");
                    div[i] = new HtmlGenericControl("div");
                    div[i].Attributes.Add("class", "headdiv1");
                    div[i].InnerHtml = dt30.Rows[i].ItemArray[0].ToString();
                    a[i].Attributes.Add("id", dt30.Rows[i].ItemArray[0].ToString());
                    a[i].Attributes.Add("utype", dt30.Rows[i].ItemArray[1].ToString());
                    a[i].Controls.Add(div[i]);
                    msgdiv.Controls.Add(a[i]);
                    a[i].ServerClick += new EventHandler(chat_ServerClick);
                }
            }
            HtmlGenericControl p = new HtmlGenericControl("p");
            p.InnerHtml = "Old Messages";
            msgdiv.Controls.Add(p);
            c.cmd.CommandText = "select id,utype from help  group by id,utype ";
            adp.SelectCommand = c.cmd;
            dt32.Clear();
            adp.Fill(dt32);
            if (dt32.Rows.Count > 0)
            {
                HtmlAnchor[] a = new HtmlAnchor[dt32.Rows.Count];
                HtmlGenericControl[] div = new HtmlGenericControl[dt32.Rows.Count];
                for (int i = 0; i < dt32.Rows.Count; i++)
                {
                    a[i] = new HtmlAnchor();
                    a[i].Attributes.Add("class", "aname");
                    div[i] = new HtmlGenericControl("div");
                    div[i].Attributes.Add("class", "headdiv1");
                    div[i].InnerHtml = dt32.Rows[i].ItemArray[0].ToString();
                    a[i].Attributes.Add("id", dt32.Rows[i].ItemArray[0].ToString());
                    a[i].Attributes.Add("utype", dt32.Rows[i].ItemArray[1].ToString());
                    a[i].Controls.Add(div[i]);
                    msgdiv.Controls.Add(a[i]);
                    a[i].ServerClick += new EventHandler(chat_ServerClick);
                }
            }
        }
       else if (clik == "buyer")
        {
            c.cmd.CommandText = "select id,utype from help where response is null and date in(select max(date) from help group by id) and utype='buyer'";
            adp.SelectCommand = c.cmd;
            dt30.Clear();
            adp.Fill(dt30);
            if (dt30.Rows.Count > 0)
            {
                HtmlAnchor[] a = new HtmlAnchor[dt30.Rows.Count];
                HtmlGenericControl[] div = new HtmlGenericControl[dt30.Rows.Count];
                HtmlGenericControl r = new HtmlGenericControl("p");
                r.InnerHtml = "New Messages";
                msgdiv.Controls.Add(r);
                for (int i = 0; i < dt30.Rows.Count; i++)
                {
                    a[i] = new HtmlAnchor();
                    a[i].Attributes.Add("class", "aname");
                    div[i] = new HtmlGenericControl("div");
                    div[i].Attributes.Add("class", "headdiv1");
                    div[i].InnerHtml = dt30.Rows[i].ItemArray[0].ToString();
                    a[i].Attributes.Add("id", dt30.Rows[i].ItemArray[0].ToString());
                    a[i].Attributes.Add("utype", dt30.Rows[i].ItemArray[1].ToString());
                    a[i].Controls.Add(div[i]);
                    msgdiv.Controls.Add(a[i]);
                    a[i].ServerClick += new EventHandler(chat_ServerClick);
                }
            }
            else
            {
                HtmlGenericControl r = new HtmlGenericControl("p");
                r.InnerHtml = " No New Messages";
                msgdiv.Controls.Add(r);
            }
        }
        else if (clik == "seller")
        {
            c.cmd.CommandText = "select id,utype from help where response is null and date in(select max(date) from help group by id) and utype='seller'";
            adp.SelectCommand = c.cmd;
            dt30.Clear();
            adp.Fill(dt30);
            if (dt30.Rows.Count > 0)
            {
                HtmlAnchor[] a = new HtmlAnchor[dt30.Rows.Count];
                HtmlGenericControl[] div = new HtmlGenericControl[dt30.Rows.Count];
                HtmlGenericControl r = new HtmlGenericControl("p");
                r.InnerHtml = "New Messages";
                msgdiv.Controls.Add(r);
                for (int i = 0; i < dt30.Rows.Count; i++)
                {
                    a[i] = new HtmlAnchor();
                    a[i].Attributes.Add("class", "aname");
                    div[i] = new HtmlGenericControl("div");
                    div[i].Attributes.Add("class", "headdiv1");
                    div[i].InnerHtml = dt30.Rows[i].ItemArray[0].ToString();
                    a[i].Attributes.Add("id", dt30.Rows[i].ItemArray[0].ToString());
                    a[i].Attributes.Add("utype", dt30.Rows[i].ItemArray[1].ToString());
                    a[i].Controls.Add(div[i]);
                    msgdiv.Controls.Add(a[i]);
                    a[i].ServerClick += new EventHandler(chat_ServerClick);
                }
            }
            else
            {
                HtmlGenericControl r = new HtmlGenericControl("p");
                r.InnerHtml = " No New Messages";
                msgdiv.Controls.Add(r);
            }
        }
        else if (clik == "logistic")
        {
            c.cmd.CommandText = "select id,utype from help where response is null and date in(select max(date) from help group by id) and utype='logistic'";
            adp.SelectCommand = c.cmd;
            dt30.Clear();
            adp.Fill(dt30);
            if (dt30.Rows.Count > 0)
            {
                HtmlAnchor[] a = new HtmlAnchor[dt30.Rows.Count];
                HtmlGenericControl[] div = new HtmlGenericControl[dt30.Rows.Count];
                HtmlGenericControl r = new HtmlGenericControl("p");
                r.InnerHtml = "New Messages";
                msgdiv.Controls.Add(r);
                for (int i = 0; i < dt30.Rows.Count; i++)
                {
                    a[i] = new HtmlAnchor();
                    a[i].Attributes.Add("class", "aname");
                    div[i] = new HtmlGenericControl("div");
                    div[i].Attributes.Add("class", "headdiv1");
                    div[i].InnerHtml = dt30.Rows[i].ItemArray[0].ToString();
                    a[i].Attributes.Add("id", dt30.Rows[i].ItemArray[0].ToString());
                    a[i].Attributes.Add("utype", dt30.Rows[i].ItemArray[1].ToString());
                    a[i].Controls.Add(div[i]);
                    msgdiv.Controls.Add(a[i]);
                    a[i].ServerClick += new EventHandler(chat_ServerClick);
                }
            }
            else
            {
                HtmlGenericControl r = new HtmlGenericControl("p");
                r.InnerHtml = " No New Messages";
                msgdiv.Controls.Add(r);
            }
        }
    }
   void chat_ServerClick(object sender, EventArgs e)
    {
        int loop = 0;
        msgdiv.Visible = false;
        chatdiv.Visible = true;
        typediv.Visible = true;
        headdiv.Visible = true;
        HtmlAnchor a = (HtmlAnchor)sender;
        uid = a.Attributes["id"].ToString();
        utype = a.Attributes["utype"].ToString();
        lblname.Text = uid;
        lblname1.Text = utype.ToUpper();
        c.cmd.CommandText = "select id,utype,message,response,date,date1 from help where id='" + a.Attributes["id"].ToString() + "' and utype='" +a.Attributes["utype"].ToString()+ "' order by date";
        adp.SelectCommand = c.cmd;
        dt31.Clear();
        adp.Fill(dt31);
        if (dt31.Rows.Count > 0)
        {
            loop = 0;
            loop1 = 0;
            HtmlGenericControl[] div = new HtmlGenericControl[dt31.Rows.Count * 4];
            System.Web.UI.WebControls.Label[] l = new System.Web.UI.WebControls.Label[dt31.Rows.Count * 2];
            for (int i = 0; i < dt31.Rows.Count; i++)
            {
                div[loop] = new HtmlGenericControl("div");
                l[loop1] = new System.Web.UI.WebControls.Label();
                l[loop1].CssClass = "lbldate";
                div[loop].Attributes.Add("class", "divmessageouter");
                chatdiv.Controls.Add(div[loop]);
                loop++;

                div[loop] = new HtmlGenericControl("div");
                div[loop].Attributes.Add("class", "divtri");
                div[loop - 1].Controls.Add(div[loop]);
                div[loop] = new HtmlGenericControl("div");
                div[loop].Attributes.Add("class", "divmessage");
                div[loop].InnerHtml = dt31.Rows[i].ItemArray[2].ToString() + "<br/>";
                l[loop1].Text = dt31.Rows[i].ItemArray[4].ToString();
                div[loop].Controls.Add(l[loop1]);
                div[loop - 1].Controls.Add(div[loop]);
                loop++;
                loop1++;

                div[loop] = new HtmlGenericControl("div");
                l[loop1] = new System.Web.UI.WebControls.Label();
                l[loop1].CssClass = "lbldate1";
                div[loop].Attributes.Add("class", "divresponseouter");
                chatdiv.Controls.Add(div[loop]);
                if (dt31.Rows[i].ItemArray[3].ToString() == "")
                {
                    div[loop].Visible = false;
                }
                loop++;

                div[loop] = new HtmlGenericControl("div");
                div[loop].Attributes.Add("class", "divtri1");
                div[loop - 1].Controls.Add(div[loop]);
                div[loop] = new HtmlGenericControl("div");
                div[loop].Attributes.Add("class", "divresponse");
                div[loop].InnerHtml = dt31.Rows[i].ItemArray[3].ToString()+"<br/>";
                l[loop1].Text = dt31.Rows[i].ItemArray[5].ToString();
                div[loop].Controls.Add(l[loop1]);
                div[loop - 1].Controls.Add(div[loop]);
                loop++;
                loop1++;
            }
        }
    }
    protected void btnsend_Click(object sender, EventArgs e)
    {
        if (txtText.Text != "")
        {
            if (dt30.Rows.Count > 0)
            {
                c.cmd.CommandText = "update help set response=@message,date1=@date where id='" + uid + "' and utype='" + utype + "' and date in(select max(date) from help where id='" + uid + "')";
                c.cmd.Parameters.Clear();
                c.cmd.Parameters.Add("@message", SqlDbType.NVarChar).Value =txtText.Text;
                c.cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
                c.cmd.ExecuteNonQuery();
                txtText.Text = "";
                amsg_Click(this, EventArgs.Empty);
            }
            else
            {
                c.cmd.CommandText = "update help set response=response+@message,date1=@date where id='" + uid + "' and utype='" + utype + "' and date in(select max(date) from help where id='" + uid + "')";
                c.cmd.Parameters.Clear();
                c.cmd.Parameters.Add("@message", SqlDbType.NVarChar).Value = "<br/>" + txtText.Text;
                c.cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
                c.cmd.ExecuteNonQuery();
                txtText.Text = "";
                HtmlAnchor a = new HtmlAnchor();
                a.Attributes.Add("id", uid.ToString());
                a.Attributes.Add("utype", utype.ToString());
                chat_ServerClick(a, EventArgs.Empty);
            }
        }
    }
    int monthtonumber(string s)
    {
        string s1 = s.ToLower();
        switch (s1)
        {
            case "january": return 1; 
            case "february": return 2; 
            case "march": return 3; 
            case "april": return 4; 
            case "may": return 5; 
            case "june": return 6; 
            case "july": return 7; 
            case "august": return 8; 
            case "september": return 9;
            case "october": return 10;
            case "november": return 11; 
            case "december": return 12;
        }
        return 0;
    }
    protected void logout_Click(object sender, EventArgs e)
    {
        Session["admin_id"] = null;
        Response.Redirect("LoginAdmin.aspx");
    }
}

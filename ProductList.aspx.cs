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
using System.Data.SqlClient;
using System.Windows.Forms;
using global;

public partial class product_list : System.Web.UI.Page
{
    connect c = new connect();
    public static int active_page=1;
    SqlDataAdapter adp = new SqlDataAdapter();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    DataTable dt5 = new DataTable();
    DataTable dt6 = new DataTable();
    DataTable orgdt = new DataTable();
    System.Web.UI.WebControls.Panel[] p = new System.Web.UI.WebControls.Panel[9];
    System.Web.UI.WebControls.Panel pagepanel = new System.Web.UI.WebControls.Panel();
    Image[] img = new Image[9];
    System.Web.UI.WebControls.Button[] btncrt = new System.Web.UI.WebControls.Button[9];
    System.Web.UI.WebControls.Button[] btnview = new System.Web.UI.WebControls.Button[9];
    System.Web.UI.WebControls.Label[] lblname = new System.Web.UI.WebControls.Label[9];
    System.Web.UI.WebControls.Label[] lblprice = new System.Web.UI.WebControls.Label[9];
    System.Web.UI.WebControls.Button[] lnkbtn = new System.Web.UI.WebControls.Button[1];
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int page_count = 0;
            if (Session["dt"] == null && Session["dt1"]==null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('OOPS!!! You Havenot Selected Anything to Show')</script>");
                Response.AddHeader("REFRESH", "3;URL=Home.aspx");
            }
            else
            {
                dt = (DataTable)Session["dt"];
                orgdt=(DataTable)Session["dt1"];
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt16(dt.Rows.Count) % 9 == 0 || Convert.ToInt16(dt.Rows.Count) == 9)
                    {
                        page_count = 1;
                    }
                    else
                    {
                        page_count = 1 + (Convert.ToInt16(dt.Rows.Count) / 9);
                    }
                    Array.Resize(ref lnkbtn, page_count);
                    for (int i = 0; i < page_count; i++)
                    {
                        lnkbtn[i] = new System.Web.UI.WebControls.Button();
                        lnkbtn[i].Text = Convert.ToString(i + 1);
                        lnkbtn[i].CssClass = "pageroll";
                        pagepanel.Controls.Add(lnkbtn[i]);
                        lnkbtn[i].Click += new EventHandler(nxtpage_click);
                    }

                    for (int i = 0; i < 9; i++)
                    {
                        p[i] = new System.Web.UI.WebControls.Panel();
                        lblname[i] = new System.Web.UI.WebControls.Label();
                        img[i] = new System.Web.UI.WebControls.Image();
                        btncrt[i] = new System.Web.UI.WebControls.Button();
                        btnview[i] = new System.Web.UI.WebControls.Button();
                        lblprice[i] = new System.Web.UI.WebControls.Label();
                        p[i].CssClass = "productpanel";
                        img[i].CssClass = "productimg";
                        btncrt[i].CssClass = "addcartbtn";
                        lblname[i].CssClass = "namelbl";
                        lblprice[i].CssClass = "pricelbl";
                        btncrt[i].Text = "Add Cart";
                        btnview[i].Text = "View";
                        lblname[i].Text = "Add Cart";
                        btnview[i].CssClass = "viewbtn";
                        btnview[i].Click += new EventHandler(view_click);
                        btncrt[i].Click += new EventHandler(adcart_click);
                        p[i].Controls.Add(lblname[i]);
                        p[i].Controls.Add(img[i]);
                        p[i].Controls.Add(btncrt[i]);
                        p[i].Controls.Add(btnview[i]);
                        p[i].Controls.Add(lblprice[i]);
                        listcontent.Controls.Add(p[i]);
                        p[i].Visible = false;
                    }
                    if (!Page.IsPostBack)
                    {
                        nxtpage_click(lnkbtn[active_page - 1], EventArgs.Empty);
                    }
                    pagerdiv.Controls.Add(pagepanel);
                    DataView dv = orgdt.DefaultView;
                    dt2.Clear();
                    dt2 = dv.ToTable(true, "color");
                    if (dt2.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            ddcolor.Items.Add(dt2.Rows[i].ItemArray[0].ToString());
                        }
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Sorry!! No Product Available')</script>");
                    Response.AddHeader("REFRESH", "3;URL=Home.aspx");
                }
            }
        }
        catch (NullReferenceException)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('OOPS!!! You Havenot Selected Anything to Show')</script>");
            Response.AddHeader("REFRESH", "3;URL=Home.aspx");
        }
        catch (IndexOutOfRangeException)
        {
            nxtpage_click(lnkbtn[0], EventArgs.Empty);
        }
        catch (Exception)
        {
            throw;
        }
        if (Convert.ToString(Session["buyer_id"]) == "")
        {
            userlogin.Visible = false;
            user.Visible = true;
            lblitemcount.Text = "0";
            lblamt.Text = "RS:00";
        }
        else
        {
            long tot = 0;
            user.Visible = false;
            userlogin.Visible = true;
            c.cmd.CommandText = "SELECT * FROM cart WHERE (buyer_id = '" + Session["buyer_id"].ToString() + "')";
            adp.SelectCommand = c.cmd;
            dt4.Clear();
            adp.Fill(dt4);
            if (dt4.Rows.Count > 0)
            {
                lblitemcount.Text = dt4.Rows.Count.ToString();
                for (int k = 0; k < dt4.Rows.Count; k++)
                {
                    tot += Convert.ToInt64(dt4.Rows[k].ItemArray[4]);
                }
                lblamt.Text = "RS:" + tot;
            }
            else
            {
                lblitemcount.Text = "0";
                lblamt.Text = "RS:00";
            }
        }
        int cat_count;
        c.cmd.CommandText = "select cat_name from category ";
        adp.SelectCommand = c.cmd;
        dt5.Clear();
        adp.Fill(dt5);
        cat_count = dt5.Rows.Count;
        if (!Page.IsPostBack)
        {
            ddcatlist.Items.Clear();
            ddcatlist.Items.Add("All");
            for (int i = 1; i < dt5.Rows.Count; i++)
            {
                ddcatlist.Items.Add(dt5.Rows[i - 1].ItemArray[0].ToString());
            }
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void btnsearch_click(object sender, EventArgs e)
    {
        /*int word_count = 0;
        char p = '%';
        txtsearch.Text = txtsearch.Text.Trim();
        for (int i = 0; i < txtsearch.Text.Length; i++)
        {
            if (txtsearch.Text.Substring(i, 1) == " ")
            {
                word_count++;
            }
        }
        word_count++;
        MessageBox.Show(word_count.ToString());*/
        if (ddcatlist.SelectedItem.Text.ToString() == "All")
        {
            c.cmd.CommandText = "select * from product where keyword like'%" + txtsearch.Text.ToString() + "%'";
        }
        else
        {
            c.cmd.CommandText = "select * from product where keyword like'%" + txtsearch.Text.ToString() + "%' and category='" + ddcatlist.SelectedItem.Text.ToString() + "'";
        }
        adp.SelectCommand = c.cmd;
        dt3.Clear();
        adp.Fill(dt3);
        Session["dt"] = dt3;
        Session["dt1"] = dt3;
        Response.Redirect("ProductList.aspx");

    }
    protected void logout_Click(object sender, EventArgs e)
    {

        Session["buyer_id"] = "";
        userlogin.Visible = false;
        user.Visible = true;
        Response.Redirect("Home.aspx");
    }
    protected void checkout_Click(object sender, EventArgs e)
    {
        long tot = 0;
        if (Session["buyer_id"] == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
            Session["link"] = "Cart.aspx";
            Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
        }
        else
        {
            dt5 = (DataTable)Global.getcart(Session["buyer_id"].ToString());
            for (int k = 0; k < dt5.Rows.Count; k++)
            {
                tot += Convert.ToInt64(dt5.Rows[k].ItemArray[4]);
            }
            if (tot < 1000)
            {
                tot += 100;
            }
            Session["cart_tot"] = tot.ToString();
            Response.Redirect("Checkout.aspx");
        }
    }
    protected void nxtpage_click(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.Button l = (System.Web.UI.WebControls.Button)sender;
        active_page = Convert.ToInt16(l.Text);
        int i = (Convert.ToInt16(l.Text)-1)*9;
        int loop=0, j=i;
        for (; i<j+9 && i<(Convert.ToInt16(dt.Rows.Count)); i++)
        {
            p[loop].Visible=true;
            img[loop].ImageUrl = dt.Rows[i].ItemArray[11].ToString();
            lblname[loop].Text = dt.Rows[i].ItemArray[1].ToString();
            lblname[loop].Text = lblname[loop].Text.ToUpper();
            lblprice[loop].Text="RS:"+ dt.Rows[i].ItemArray[4].ToString();
            btnview[loop].Attributes.Add("name", dt.Rows[i].ItemArray[0].ToString());
            btncrt[loop].Attributes.Add("name", dt.Rows[i].ItemArray[0].ToString());
            btncrt[loop].Attributes.Add("lblprice", dt.Rows[i].ItemArray[4].ToString());
            loop++;
        }
    }
    protected void view_click(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.Button s = (System.Web.UI.WebControls.Button)sender;;
        Session["product_id"] = s.Attributes["name"].ToString();
        Response.Redirect("~\\View.aspx");
    }
    protected void adcart_click(object sender, EventArgs e)
    {
        try
        {
            System.Web.UI.WebControls.Button s = (System.Web.UI.WebControls.Button)sender; ;
            Session["product_id"] = s.Attributes["name"].ToString();
            if (Session["buyer_id"].ToString() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('you must login first')</script>");
                Session["link"] = "ProductList.aspx"; 
                Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
            }
            else
            {
                c = new connect();
                c.cmd.CommandText = "select product_id from cart where product_id='" + Session["product_id"].ToString() + "' and buyer_id='" + Session["buyer_id"].ToString() + "'";
                adp.SelectCommand = c.cmd;
                adp.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    //Response.Write("<script>alert('Product already exists in Cart')</script>");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Product already exists in Cart')</script>");
                    nxtpage_click(lnkbtn[active_page - 1], EventArgs.Empty);
                }
                else
                {
                    string cart_id = "CART", temp = Session["buyer_id"].ToString().Substring(3, Session["buyer_id"].ToString().Length - 3);
                    cart_id += temp;
                    c.cmd.CommandText = "insert into cart(cart_id,buyer_id,product_id,qty,total) values('" + cart_id + "','" + Session["buyer_id"].ToString() + "','" + Session["product_id"].ToString() + "'," + 1 + "," + Convert.ToInt64(s.Attributes["lblprice"]) + ")";
                    c.cmd.ExecuteNonQuery();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Product Successfully Added to Cart')</script>");
                    nxtpage_click(lnkbtn[active_page - 1], EventArgs.Empty);
                }
            }
        }
        catch (NullReferenceException)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('you must login first')</script>");
            Session["link"] = "ProductList.aspx"; 
            Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void ddsort_SelectedIndexChanged(object sender, EventArgs e)
    {
        int val=0;
        if (ddsort.SelectedIndex.ToString() == "1")
        {
            DataView dv = new DataView();
            dv = orgdt.DefaultView;
            dv.Sort="price ASC";
            dt = dv.ToTable();
            Session["dt"] = dt;
        }
        else if (ddsort.SelectedIndex.ToString() == "2")
        {
            DataView dv = new DataView();
            dv = orgdt.DefaultView;
            dv.Sort = "price DESC";
            dt = dv.ToTable();
            Session["dt"] = dt;
        }
        else if (ddsort.SelectedIndex.ToString() == "3")
        {
            DataView dv = new DataView();
            dv = orgdt.DefaultView;
            dv.Sort = "rate DESC";
            dt = dv.ToTable();
            Session["dt"] = dt;
        }
        else if (ddsort.SelectedIndex.ToString() == "4")
        {
            DataView dv = new DataView();
            dv = orgdt.DefaultView;
            dv.Sort = "date DESC";
            dt = dv.ToTable();
            Session["dt"] = dt;
        }
        Response.Redirect("ProductList.aspx");
    }
    protected void ddcolor_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable d = new DataTable();
        DataView dv = new DataView(orgdt);
        dv.RowFilter = "color='" + ddcolor.SelectedItem.Text.ToString()+"'";
        d = dv.ToTable();
        Session["dt"] = d;
        Response.Redirect("ProductList.aspx");
    }
}

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

public partial class View : System.Web.UI.Page
{
    connect c = new connect();
    SqlDataAdapter adp = new SqlDataAdapter();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    DataTable dt5 = new DataTable();
    DataTable dt6 = new DataTable();
    DataTable dt7 = new DataTable();
  double rate;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Convert.ToString(Session["buyer_id"]) != "")
        {
            user.Visible = false;
            userlogin.Visible = true;
        }
        else
        {
            user.Visible = true;
            userlogin.Visible = false;
        }
            
        try
       {
            if (Session["product_id"].ToString() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Sorry!! Product You Are Looking is No More Available')</script>");
                Response.AddHeader("REFRESH", "3;URL=Home.aspx");
            }
            else
            {
                int loop = 0, j = 0;
                TableCell[] tc = new TableCell[16];
                TableRow[] tr = new TableRow[8];
                c.cmd.CommandText = "select name,brand,category,qty,price,color,weight,description,img1,img2,img3,rate,no from product where product_id='" + Session["product_id"].ToString() + "'";
                adp.SelectCommand = c.cmd;
                dt.Clear();
                adp.Fill(dt);
                dt3.Clear();
                dt3 = dt.DefaultView.ToTable();
                dt3.Columns.Remove("img1");
                dt3.Columns.Remove("img2");
                dt3.Columns.Remove("img3");
                dt3.Columns.Remove("rate");
                dt3.Columns.Remove("no");
                if (dt3.Rows.Count > 0)
                {
                    loop = 0;
                    foreach (DataColumn dc in dt3.Columns)
                    {
                        tr[loop] = new TableRow();
                        tc[j] = new TableCell();
                        tc[j].CssClass = "ordercontent";
                        tc[j].Text = dc.ColumnName.ToString().ToUpper() + ":";
                        tr[loop].Controls.Add(tc[j]);
                        j++;
                        tc[j] = new TableCell();
                        tc[j].CssClass = "ordercontent1";
                        if (j == 13)
                        {
                            tc[j].Text = dt3.Rows[0].ItemArray[loop].ToString().ToUpper()+"g";      
                        }
                        else
                        {
                            tc[j].Text = dt3.Rows[0].ItemArray[loop].ToString().ToUpper(); 
                        }
                        tr[loop].Controls.Add(tc[j]);
                        j++;
                        prdviewtbl.Controls.Add(tr[loop]);
                        loop++;
                    }
                   
                    img1.ImageUrl = dt.Rows[0].ItemArray[8].ToString();
                    if (!Page.IsPostBack)
                    {
                        imgzoom.Style["background-image"] = Page.ResolveClientUrl(dt.Rows[0].ItemArray[8].ToString());
                    }
                    img2.BorderWidth = 3;
                    img2.ImageUrl = dt.Rows[0].ItemArray[8].ToString();
                    img3.ImageUrl = dt.Rows[0].ItemArray[9].ToString();
                    img4.ImageUrl = dt.Rows[0].ItemArray[10].ToString();
                    rate = Convert.ToDouble(dt.Rows[0].ItemArray[11]) / Convert.ToDouble(dt.Rows[0].ItemArray[12]);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "rate", "<script>rate("+rate*30+")</script>");
                    c.cmd.CommandText = "select review,name,rate from reviews,buyer where reviews.buyer_id=buyer.buyer_id and product_id='" + Session["product_id"].ToString() + "'";
                    adp.SelectCommand = c.cmd;
                    dt2.Clear();
                    adp.Fill(dt2);
                    if (dt2.Rows.Count > 0)
                    {
                        HtmlGenericControl[] div = new HtmlGenericControl[dt2.Rows.Count];
                        HtmlGenericControl[] div1 = new HtmlGenericControl[dt2.Rows.Count];
                        HtmlGenericControl[] stars = new HtmlGenericControl[dt2.Rows.Count];
                        HtmlGenericControl[] span = new HtmlGenericControl[dt2.Rows.Count];
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            stars[i] = new HtmlGenericControl("div");
                            span[i] = new HtmlGenericControl("div");
                            stars[i].Controls.Add(span[i]);
                            stars[i].Attributes.Add("class","stars1");
                            stars[i].ID = i.ToString();
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "r"+i+"", "<script>r('" +i+ "',"+Convert.ToInt16(dt2.Rows[i].ItemArray[2])*30+")</script>");
                            div[i] = new HtmlGenericControl("div");
                            div[i].InnerHtml = "";
                            div1[i] = new HtmlGenericControl("div");
                            div1[i].InnerHtml = "";
                            div1[i].InnerHtml = dt2.Rows[i].ItemArray[1].ToString().ToUpper();
                            div1[i].Controls.Add(stars[i]);
                            div[i].InnerHtml = dt2.Rows[i].ItemArray[0].ToString();
                            reviewdiv.Controls.Add(div1[i]);
                            reviewdiv.Controls.Add(div[i]);
                            div[i].Attributes.Add("class","revdiv");
                            div1[i].Attributes.Add("class","revdiv1");
                        }
                    }
                    else
                    {
                        reviewdiv.InnerHtml = "";
                        reviewdiv.InnerHtml = "Be the first Person to write Review";
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Sorry!! Product You Are Looking is No More Available')</script>");
                    Response.AddHeader("REFRESH", "3;URL=Home.aspx");
                }
            }

        }
        catch (NullReferenceException)
        { 
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('OOpss!! Something Went Wrong')</script>");
            Response.AddHeader("REFRESH", "3;URL=Home.aspx");
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            c.cnn.Close();
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
        dt7.Clear();
        adp.Fill(dt7);
        cat_count = dt7.Rows.Count;
        if (!Page.IsPostBack)
        {
            ddcatlist.Items.Clear();
            ddcatlist.Items.Add("All");
            for (int i = 1; i < dt7.Rows.Count; i++)
            {
                ddcatlist.Items.Add(dt7.Rows[i - 1].ItemArray[0].ToString());
            }
        }
    }
    protected void logout_Click(object sender, EventArgs e)
    {

        Session["buyer_id"] = "";
        userlogin.Visible = false;
        user.Visible = true;
        Response.Redirect("Home.aspx");
    }
    protected void btnaddcart_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["buyer_id"].ToString() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('You must login first')</script>");
                Session["link"] = "View.aspx";
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Product already exists in Cart')</script>");
                }
                else
                {
                    string cart_id = "CART", temp = Session["buyer_id"].ToString().Substring(3, Session["buyer_id"].ToString().Length - 3);
                    cart_id += temp;
                    c.cmd.CommandText = "insert into cart(cart_id,buyer_id,product_id,qty,total) values('" + cart_id + "','" + Session["buyer_id"].ToString() + "','" + Session["product_id"].ToString() + "'," + 1 + "," + Convert.ToInt64(dt.Rows[0].ItemArray[4]) + ")";
                    c.cmd.ExecuteNonQuery();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Product Successfully Added to Cart')</script>");
                    //Response.Redirect("Cart.aspx");
                }
            }
        }
        catch (NullReferenceException)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('You must login first')</script>");
            Session["link"] = "View.aspx";
            Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
        }
        catch (Exception)
        {
            throw;
        }
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
        dt6.Clear();
        adp.Fill(dt6);
        Session["dt"] = dt6;
        Session["dt1"] = dt6;
        Response.Redirect("ProductList.aspx");

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
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
}

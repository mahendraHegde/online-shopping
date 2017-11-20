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

public partial class Cart : System.Web.UI.Page
{
    connect c = new connect();
    SqlDataAdapter adp = new SqlDataAdapter();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    int[] arr ={ 1,2,3,4,5,6,7,8,9,10};
    long tot = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["buyer_id"]==null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
                Session["link"] = "Cart.aspx";
                Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
            }
            else
            {
                cartheaderdiv.InnerHtml = cartheaderdiv.InnerHtml+"Hello " + Session["buyer_name"].ToString()+" !!!";
                cartheaderdiv.Style.Add("color", "black");
                dt.Clear();
                dt = (DataTable)Global.getcart(Session["buyer_id"].ToString());
                if (dt.Rows.Count > 0)
                {
                    HtmlGenericControl [] d = new HtmlGenericControl[dt.Rows.Count];
                    DropDownList[] dd = new DropDownList[dt.Rows.Count];
                    Image[] im = new Image[dt.Rows.Count];
                    System.Web.UI.WebControls.Label[] lblname = new System.Web.UI.WebControls.Label[dt.Rows.Count];
                    System.Web.UI.WebControls.Label[] lblprice = new System.Web.UI.WebControls.Label[dt.Rows.Count];
                    System.Web.UI.WebControls.Button[] btnremove=new System.Web.UI.WebControls.Button[dt.Rows.Count];
                    HtmlAnchor[] a = new HtmlAnchor[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        d[i] = new HtmlGenericControl("div");
                        dd[i] = new DropDownList();
                        im[i] = new Image();
                        a[i] = new HtmlAnchor();
                        lblname[i] = new System.Web.UI.WebControls.Label();
                        lblname[i].CssClass = "cartname";
                        lblprice[i] = new System.Web.UI.WebControls.Label();
                        lblprice[i].CssClass = "cartprice";
                        btnremove[i] = new System.Web.UI.WebControls.Button();
                        btnremove[i].CssClass = "cartremove";
                        btnremove[i].ToolTip = "Remove From Cart";
                        btnremove[i].Click+=new EventHandler(remove_cart);
                        a[i].Controls.Add(im[i]);
                        a[i].ServerClick+=new EventHandler(link_click);
                        d[i].Controls.Add(a[i]);
                        d[i].Controls.Add(lblname[i]);
                        d[i].Controls.Add(lblprice[i]);
                        d[i].Controls.Add(dd[i]);
                        d[i].Controls.Add(btnremove[i]);
                        cartcontent.Controls.Add(d[i]);
                        dd[i].Items.Clear();
                        for(int j=1;j<=10;j++)
                        {
                            dd[i].Items.Add(j.ToString());
                        }
                        dd[i].ClearSelection();
                        dd[i].CssClass = "cartqty";
                        dd[i].Items.FindByText(dt.Rows[i].ItemArray[3].ToString()).Selected = true;
                        dd[i].SelectedIndexChanged+=new EventHandler(update_qty);
                        dd[i].AutoPostBack = true;
                        c.cmd.CommandText = "select name,img1 from product where product_id='" + dt.Rows[i].ItemArray[2].ToString() + "'";
                        adp.SelectCommand = c.cmd;
                        dt1.Clear(); 
                        adp.Fill(dt1);
                        im[i].ImageUrl = dt1.Rows[0].ItemArray[1].ToString();
                        a[i].Attributes.Add("product_id",dt.Rows[i].ItemArray[2].ToString());
                        lblname[i].Text = dt1.Rows[0].ItemArray[0].ToString();
                        lblname[i].Text = lblname[i].Text.ToUpper();
                        lblprice[i].Text = "RS:" + dt.Rows[i].ItemArray[4].ToString();
                        dd[i].Attributes.Add("product_id", dt.Rows[i].ItemArray[2].ToString());
                        btnremove[i].Attributes.Add("product_id", dt.Rows[i].ItemArray[2].ToString());

                    }
                    HtmlGenericControl checkdiv = new HtmlGenericControl("div");
                    System.Web.UI.WebControls.Label lbltot = new System.Web.UI.WebControls.Label();
                    System.Web.UI.WebControls.Label lblship = new System.Web.UI.WebControls.Label();
                    System.Web.UI.WebControls.Button btncheckout = new System.Web.UI.WebControls.Button();
                    btncheckout.Click+=new EventHandler(btncheckout_Click);
                    for (int k = 0; k < dt.Rows.Count;k++ )
                    {
                        tot +=Convert.ToInt64(dt.Rows[k].ItemArray[4]);
                    }
                    if (tot < 1000)
                    {
                        lblship.Text = "Shipping - RS:100";
                        tot += 100;
                    }
                    else
                    {
                        lblship.Text = "Shipping - RS:0";
                    }
                    lblship.CssClass = "totship";
                    lbltot.Text ="RS:"+tot.ToString();
                    Session["cart_tot"] = lbltot.Text;
                    
                    lbltot.CssClass = "totprice";
                    btncheckout.CssClass = "checkbtn1";
                    btncheckout.Text = "Place Order";
                    checkdiv.Attributes.Add("class", "checkdiv");
                   btncheckout.Style.Add("float", "right");
                    btncheckout.Style.Add("margin", "50px");
                    checkdiv.Controls.Add(btncheckout);
                    checkdiv.Controls.Add(lbltot);
                    checkdiv.Controls.Add(lblship);
                   cartcontent.Controls.Add(checkdiv);
                }
                else 
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('No Products Available in your Cart')</script>");
                    Response.AddHeader("REFRESH", "3;URL=Home.aspx");
                }
            }
        }
        catch (NullReferenceException)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
            Session["link"] = "Cart.aspx";
            Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void update_qty(object sender, EventArgs e)
    {
            DropDownList dd = (DropDownList)sender;
            c.cmd.CommandText = "select price,qty from product where product_id='" + dd.Attributes["product_id"].ToString() + "'";
            adp.SelectCommand = c.cmd;
             dt2.Clear();
             adp.Fill(dt2);
             if (dt2.Rows.Count > 0)
             {
                 if (Convert.ToInt16(dd.SelectedItem.ToString()) > Convert.ToInt16(dt2.Rows[0].ItemArray[1].ToString()))
                 {
                     Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Sorry only " + dt2.Rows[0].ItemArray[1].ToString() + " Products Avilable')</script>");
                     dd.SelectedIndex = 0;
                 }
                     long price = Convert.ToInt64(dt2.Rows[0].ItemArray[0]);
                     price *= Convert.ToInt64(dd.SelectedItem.ToString());
                     c.cmd.CommandText = "update cart set qty='" + dd.SelectedItem.ToString() + "', total=" + price + " where product_id='" + dd.Attributes["product_id"].ToString() + "'and buyer_id='" + Session["buyer_id"].ToString() + "' ";
                     c.cmd.ExecuteNonQuery();
                     Response.Redirect("Cart.aspx");
             }
    }
    protected void remove_cart(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button)sender;
        {
            c.cmd.CommandText = "delete from cart where product_id='" + btn.Attributes["product_id"].ToString() + "' and buyer_id='" + Session["buyer_id"].ToString() + "' ";
            c.cmd.ExecuteNonQuery();
            Response.Redirect("Cart.aspx");
        }
    }
    protected void link_click(object sender, EventArgs e)
    {
        HtmlAnchor a = (HtmlAnchor)sender;
        Session["product_id"] = a.Attributes["product_id"].ToString();
        Response.Redirect("View.aspx");
    }
    protected void btncheckout_Click(object sender, EventArgs e)
    {
        Response.Redirect("Checkout.aspx");
    }
    protected void logout_Click(object sender, EventArgs e)
    {

        Session["buyer_id"] = null;
        userlogin.Visible = false;
        user.Visible = true;
        Response.Redirect("Home.aspx");
    }
}

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

public partial class SellerLogin : System.Web.UI.Page
{
    connect c=new connect();
    SqlDataAdapter adp=new SqlDataAdapter();
    DataTable dt=new DataTable();
   static String id,user;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            user = Request.QueryString["user"].ToString();
            if (user == "buyer")
            {
                if (Session["buyer_id"] != null)
                {
                    id = Convert.ToString(Session["buyer_id"]);
                    user = "buyer";
                    if (!Page.IsPostBack)
                    {
                        c.cmd.CommandText = "select * from buyer where buyer_id='" + Session["buyer_id"].ToString() + "'";
                        adp.SelectCommand = c.cmd;
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtaddress.Text = dt.Rows[0].ItemArray[11].ToString();
                            txtcity.Text = dt.Rows[0].ItemArray[10].ToString();
                            txtcontact.Text = dt.Rows[0].ItemArray[4].ToString();
                            txtpin.Text = dt.Rows[0].ItemArray[12].ToString();
                            txtstate.Text = dt.Rows[0].ItemArray[9].ToString();
                            txtcountry.Text = dt.Rows[0].ItemArray[8].ToString();
                            lblname.Text = dt.Rows[0].ItemArray[1].ToString().ToUpper();
                        }
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
                    Session["link"] = "Address.aspx?user=buyer";
                    Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
                }
            }
            else if (user == "seller")
            {
                if (Session["seller_id"] != null)
                {

                    if (!Page.IsPostBack)
                    {
                        c.cmd.CommandText = "select * from seller where seller_id=" + Convert.ToInt64(Session["seller_id"]) + "";
                        adp.SelectCommand = c.cmd;
                        dt.Clear();
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtaddress.Text = dt.Rows[0].ItemArray[11].ToString();
                            txtcity.Text = dt.Rows[0].ItemArray[10].ToString();
                            txtcontact.Text = dt.Rows[0].ItemArray[4].ToString();
                            txtpin.Text = dt.Rows[0].ItemArray[12].ToString();
                            txtstate.Text = dt.Rows[0].ItemArray[9].ToString();
                            txtcountry.Text = dt.Rows[0].ItemArray[8].ToString();
                            lblname.Text = dt.Rows[0].ItemArray[1].ToString().ToUpper();
                        }
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
                    Session["slink"] = "Address.aspx?user=seller";
                    Response.AddHeader("REFRESH", "3;URL=SeLoLogReg.aspx?val=login");
                }
            }
            else if (user == "logistic")
            {
                if (Session["log_id"] != null)
                {

                    if (!Page.IsPostBack)
                    {
                        c.cmd.CommandText = "select * from logistic where log_id=" + Convert.ToInt64(Session["log_id"]) + "";
                        adp.SelectCommand = c.cmd;
                        dt.Clear();
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtaddress.Text = dt.Rows[0].ItemArray[11].ToString();
                            txtcity.Text = dt.Rows[0].ItemArray[10].ToString();
                            txtcontact.Text = dt.Rows[0].ItemArray[4].ToString();
                            txtpin.Text = dt.Rows[0].ItemArray[12].ToString();
                            txtstate.Text = dt.Rows[0].ItemArray[9].ToString();
                            txtcountry.Text = dt.Rows[0].ItemArray[8].ToString();
                            lblname.Text = dt.Rows[0].ItemArray[1].ToString().ToUpper();
                        }
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
                    Session["llink"] = "Address.aspx?user=logistic";
                    Response.AddHeader("REFRESH", "3;URL=LogisticLogReg.aspx?val=login");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('OOps!! Something went wrong')</script>");
                Response.AddHeader("REFRESH", "3;URL=Home.aspx");
            }
        }
        catch (NullReferenceException)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('OOps!! Something went wrong')</script>");
            Response.AddHeader("REFRESH", "3;URL=Home.aspx");
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Global.checkchar(txtstate))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('State Name Must only contain letters')</script>");
            }
            else if (!Global.validatepin(txtpin))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Invalid Pin!!!')</script>");
            }
            else if (!Global.validphone(txtcontact))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Invalid Phone number')</script>");
            }
            else if (!Global.checkchar(txtcountry))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Country Name Must only contain letters')</script>");
            }
            else
            {
                if (user == "buyer")
                {
                    c.cmd.CommandText = "UPDATE buyer SET country = '" + txtcountry.Text + "',state='" + txtstate.Text + "',pin='" + Convert.ToInt64(txtpin.Text) + "',phone='" + Convert.ToInt64(txtcontact.Text) + "',city='" + txtcity.Text + "',address='" + txtaddress.Text + "' WHERE(buyer_id = '" + Session["buyer_id"].ToString() + "')";
                    c.cmd.ExecuteNonQuery();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Address Updated Successfully')</script>");
                    Response.AddHeader("REFRESH", "3;URL=BuyerProfile.aspx");
                }
                else if (user == "seller")
                {
                    c.cmd.CommandText = "update seller set country='" + txtcountry.Text + "',state='" + txtstate.Text + "',city='" + txtcity.Text + "',address='" + txtaddress.Text + "',pin=" + txtpin.Text + ",phone=" + txtcontact.Text + " where seller_id=" + Convert.ToInt64(Session["seller_id"]) + "";
                    c.cmd.ExecuteNonQuery();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Address Updated Successfully')</script>");
                    Response.AddHeader("REFRESH", "3;URL=SellerDash.aspx");
                }
                else if (user == "logistic")
                {
                    c.cmd.CommandText = "update logistic set country='" + txtcountry.Text + "',state='" + txtstate.Text + "',city='" + txtcity.Text + "',address='" + txtaddress.Text + "',pin=" + txtpin.Text + ",phone=" + txtcontact.Text + " where log_id=" + Convert.ToInt64(Session["log_id"]) + "";
                    c.cmd.ExecuteNonQuery();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Address Updated Successfully')</script>");
                    Response.AddHeader("REFRESH", "3;URL=LogisticDash.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('OOps!! Something Went Wrong')</script>");
                    Response.AddHeader("REFRESH", "3;URL=Home.aspx");
                }
            }
            
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            c.cnn.Close();
        }
    }
    protected void txtpin_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (!Global.validatepin(txtpin))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Invalid Pin!!!')</script>");
            }
            else
            {
                txtstate.Text = Global.state;
                txtcity.Text = Global.city;
                txtcountry.Text = "India";
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}

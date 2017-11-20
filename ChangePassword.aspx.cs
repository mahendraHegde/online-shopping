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
    connect c = new connect();
    SqlDataAdapter adp = new SqlDataAdapter();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    string user = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["user"] == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Oops!! Something Went Wrong')</script>");
            Response.AddHeader("REFRESH", "3;URL=Home.aspx");
        }
        else
        {
            user = Request.QueryString["user"].ToString();
        }
        try
        {
            if (user == "admin")
            {
                if (Session["admin_id"] != null)
                {
                    c.cmd.CommandText = "select pswd from admin where admin_id='" + Session["admin_id"].ToString() + "'";
                    adp.SelectCommand = c.cmd;
                    dt3.Clear();
                    adp.Fill(dt3);
                    if (dt3.Rows.Count > 0)
                    {
                        lblname.Text = "Admin";
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
                    Response.AddHeader("REFRESH", "3;URL=LoginAdmin.aspx");
                }
            }
            else if (user == "buyer")
            {
                if (Session["buyer_id"] != null)
                {
                    c.cmd.CommandText = "select name,pswd from buyer where buyer_id='" + Session["buyer_id"].ToString() + "'";
                    adp.SelectCommand = c.cmd;
                    dt.Clear();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblname.Text = dt.Rows[0].ItemArray[0].ToString().ToUpper();
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
                    Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
                }
            }
            else if (user == "seller")
            {
                if (Session["seller_id"] != null)
                {
                    c.cmd.CommandText = "select name,pswd from seller where seller_id='" + Session["seller_id"].ToString() + "'";
                    adp.SelectCommand = c.cmd;
                    dt1.Clear();
                    adp.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        lblname.Text = dt1.Rows[0].ItemArray[0].ToString().ToUpper();
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
                    Response.AddHeader("REFRESH", "3;URL=SeLoLogReg.aspx?val=login");
                }
            }
            else if (user == "logistic")
            {
                if (Session["log_id"] != null)
                {
                    c.cmd.CommandText = "select name,pswd from logistic where log_id='" + Session["log_id"].ToString() + "'";
                    adp.SelectCommand = c.cmd;
                    dt2.Clear();
                    adp.Fill(dt2);
                    if (dt2.Rows.Count > 0)
                    {
                        lblname.Text = dt2.Rows[0].ItemArray[0].ToString().ToUpper();
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
                    Response.AddHeader("REFRESH", "3;URL=LogisticLogReg.aspx?val=login");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
                Response.AddHeader("REFRESH", "3;URL=Home.aspx");
            }
        }
        catch (Exception)
        {
            throw;
        }

    }
    protected void btnchange_Click(object sender, EventArgs e)
    {
        if (user == "admin")
        {
            if (Session["admin_id"] != null)
            {
                if (Global.encrypt(txtold.Text) == dt3.Rows[0].ItemArray[0].ToString())
                {
                    if (txtpswd.Text.Length < 8)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Password must contain 8 characters')</script>");
                    }

                    else if (txtpswd.Text != txtconfirm.Text)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please re-enter correct password')</script>");
                    }
                    else
                    {
                        c.cmd.CommandText = "update admin set pswd='" +Global.encrypt(txtpswd.Text.ToString()) + "' where admin_id='" + Session["admin_id"].ToString() + "'";
                        c.cmd.ExecuteNonQuery();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Password Updated Successfully!! Login Now')</script>");
                        Session["admin_id"] = null;
                        Response.AddHeader("REFRESH", "3;URL=LoginAdmin.aspx");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Enter Correct Password')</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
                Response.AddHeader("REFRESH", "3;URL=LoginAdmin.aspx");
            }
        }
        if (user == "buyer")
        {
            if (Session["buyer_id"] != null)
            {
                if (Global.encrypt(txtold.Text) == dt.Rows[0].ItemArray[1].ToString())
                {
                    if (txtpswd.Text.Length < 8)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Password must contain 8 characters')</script>");
                    }

                    else if (txtpswd.Text != txtconfirm.Text)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('please re-enter correct password')</script>");
                    }
                    else
                    {
                        c.cmd.CommandText = "update buyer set pswd='" +Global.encrypt( txtpswd.Text.ToString()) + "' where buyer_id='" + Session["buyer_id"].ToString() + "'";
                        c.cmd.ExecuteNonQuery();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Password Updated Successfully!! Login Now')</script>");
                        Session["link"] = "Home.aspx";
                        Session["buyer_id"] = null;
                        Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Enter Correct Password')</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
                Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
            }
        }
        else if (user == "seller")
        {
            if (Session["seller_id"] != null)
            {
                if (Global.encrypt(txtold.Text) == dt1.Rows[0].ItemArray[1].ToString())
                {
                    if (txtpswd.Text.Length < 8)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Password must contain 8 characters')</script>");
                    }

                    else if (txtpswd.Text != txtconfirm.Text)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('please re-enter correct password')</script>");
                    }
                    else
                    {
                        c.cmd.CommandText = "update seller set pswd='" +Global.encrypt(txtpswd.Text.ToString() )+ "' where seller_id='" + Session["seller_id"].ToString() + "'";
                        c.cmd.ExecuteNonQuery();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Password Updated Successfully!! Login Now')</script>");
                        Session["slink"] = "SellerDash.aspx";
                        Session["seller_id"] = null;
                        Response.AddHeader("REFRESH", "3;URL=SeLoLogReg.aspx?val=login");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Enter Correct Password')</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
                Response.AddHeader("REFRESH", "3;URL=SeLoLogReg.aspx?val=login");
            }
        }
        if (user == "logistic")
        {
            if (Session["log_id"] != null)
            {
                if (Global.encrypt( txtold.Text) == dt2.Rows[0].ItemArray[1].ToString())
                {
                    if (txtpswd.Text.Length < 8)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Password must contain 8 characters')</script>");
                    }

                    else if (txtpswd.Text != txtconfirm.Text)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('please re-enter correct password')</script>");
                    }
                    else
                    {
                        c.cmd.CommandText = "update logistic set pswd='" +Global.encrypt(txtpswd.Text.ToString()) + "' where log_id='" + Session["log_id"].ToString() + "'";
                        c.cmd.ExecuteNonQuery();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Password Updated Successfully!! Login Now')</script>");
                        Session["llink"] = "LogisticDash.aspx";
                        Session["log_id"] = null;
                        Response.AddHeader("REFRESH", "3;URL=LogisticLogReg.aspx?val=login");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Enter Correct Password')</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
                Response.AddHeader("REFRESH", "3;URL=LogisticLogReg.aspx?val=login");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Old Password Does Not Match')</script>");
        }
    }
}

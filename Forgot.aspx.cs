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

public partial class forgot : System.Web.UI.Page
{
    connect c = new connect();
    SqlDataAdapter adp = new SqlDataAdapter();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    String id, user;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            panelid.Visible = true;
            panelqtn.Visible = false;
            panelpswd.Visible = false;
        }
        if (Request.QueryString["user"] == null)
        {
             
        }
        else
        {
            user = Request.QueryString["user"].ToString();
        }
    }

    protected void btnnext_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (user == "buyer")
            {
                if (txtemailid.Text == "")
                {

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Enter your Email-Id')</script>");
                }
                else
                {
                    try
                    {
                        c.cmd.CommandText = "select question from buyer where email='" + txtemailid.Text.ToString() + "'";
                        adp.SelectCommand = c.cmd;
                        dt.Clear();
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            panelqtn.Visible = true;
                            lblqtn.Text = dt.Rows[0].ItemArray[0].ToString();
                            lblqtn.Text = lblqtn.Text.ToUpper();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Email-Id is Not Registered')</script>");
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else if (user == "seller")
            {
                if (txtemailid.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Enter Email-Id')</script>");
                }
                else
                {
                    try
                    {
                        c.cmd.CommandText = "select question from seller where email='" + txtemailid.Text.ToString() + "'";
                        adp.SelectCommand = c.cmd;
                        dt.Clear();
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            panelqtn.Visible = true;
                            // btnnext.Disabled = true;
                            lblqtn.Text = dt.Rows[0].ItemArray[0].ToString();
                            lblqtn.Text = lblqtn.Text.ToUpper();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Email-Id is Not Registered')</script>");
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else if (user == "logistic")
            {
                if (txtemailid.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Enter Email_Id first')</script>");
                }
                else
                {
                    try
                    {
                        c.cmd.CommandText = "select question from logistic where email='" + txtemailid.Text.ToString() + "'";
                        adp.SelectCommand = c.cmd;
                        dt.Clear();
                        adp.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            panelqtn.Visible = true;
                            // btnnext.Disabled = true;
                            lblqtn.Text = dt.Rows[0].ItemArray[0].ToString();
                            lblqtn.Text = lblqtn.Text.ToUpper();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Email-Id is Not Registered')</script>");
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
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
        finally
        {
            c.cnn.Close();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (user == "buyer")
        {
            if (txtans.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Enter security Answer')</script>");
            }
            else
            {
                c.cmd.CommandText = "select ans from buyer where email='" + txtemailid.Text.ToString() + "'";
                adp.SelectCommand = c.cmd;
                dt1.Clear();
                adp.Fill(dt1);

                if (dt1.Rows.Count > 0)
                {
                    if (txtans.Text == dt1.Rows[0].ItemArray[0].ToString())
                    {
                        panelpswd.Visible = true;
                        //  btnsubmit.Enabled = false;
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Answer You Have Entered is Incorrect')</script>");
                    }
                }
            }
        }
        else if (user == "seller")
        {
            if (txtans.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Enter The Security Answer')</script>");
            }
            else
            {
                c.cmd.CommandText = "select ans from seller where email='" + txtemailid.Text.ToString() + "'";
                adp.SelectCommand = c.cmd;
                dt1.Clear();
                adp.Fill(dt1);

                if (dt1.Rows.Count > 0)
                {
                    if (txtans.Text == dt1.Rows[0].ItemArray[0].ToString())
                    {
                        panelpswd.Visible = true;
                        //  btnsubmit.Enabled = false;
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Answer You Have Entered is Incorrect')</script>");
                    }
                }
            }
        }
        else if (user == "logistic")
        {
            if (txtans.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Enter Security Answer')</script>");
            }
            else
            {
                c.cmd.CommandText = "select ans from logistic where email='" + txtemailid.Text.ToString() + "'";
                adp.SelectCommand = c.cmd;
                dt1.Clear();
                adp.Fill(dt1);

                if (dt1.Rows.Count > 0)
                {
                    if (txtans.Text == dt1.Rows[0].ItemArray[0].ToString())
                    {
                        panelpswd.Visible = true;
                        //  btnsubmit.Enabled = false;
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Answer You Have Entered is Incorrect')</script>");
                    }
                }
            }
        }
        else
        {
            Response.Redirect("~\\Home.aspx");
        }
    }
    protected void btnchange_Click(object sender, EventArgs e)
    {
        if (txtpswd.Text.Length < 8)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Password Must Contain 8 Characters')</script>");
        }

        else if (txtpswd.Text != txtconfirm.Text)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Re-enter the correct password ')</script>");
        }
        else
        {
            if (user == "buyer")
            {
                c.cmd.CommandText = "update buyer set pswd='" + Global.encrypt(txtpswd.Text.ToString()) + "' where email='" + txtemailid.Text.ToString() + "'";
                c.cmd.ExecuteNonQuery();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Password updated Successfully Login Now')</script>");
                Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
            }
            else if (user == "seller")
            {
                c.cmd.CommandText = "update seller set pswd='" + Global.encrypt(txtpswd.Text.ToString()) + "' where email='" + txtemailid.Text.ToString() + "'";
                c.cmd.ExecuteNonQuery();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Password updated Successfully Login Now')</script>");
                Response.AddHeader("REFRESH", "3;URL=SeLoLogReg.aspx?val=login");
            }
            else if (user == "logistic")
            {
                c.cmd.CommandText = "update logistic set pswd='" + Global.encrypt(txtpswd.Text.ToString()) + "' where email='" + txtemailid.Text.ToString() + "'";
                c.cmd.ExecuteNonQuery();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Password updated Successfully Login Now')</script>");
                Response.AddHeader("REFRESH", "3;URL=LogisticLogReg.aspx?val=login");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
                Response.AddHeader("REFRESH", "3;URL=Home.aspx");
            }
        }
    }
}

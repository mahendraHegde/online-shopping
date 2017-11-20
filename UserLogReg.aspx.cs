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
public partial class logreg : System.Web.UI.Page
{
    connect c = new connect();
    SqlDataAdapter adp = new SqlDataAdapter();
    SqlDataAdapter adp2 = new SqlDataAdapter();
    SqlDataAdapter adp1 = new SqlDataAdapter();
    SqlDataAdapter adp3 = new SqlDataAdapter();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        string op=(String)Request.QueryString["val"];
        if (op == "login")
        {
            string login = "<script>tolog()</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "key", login);
        }
        else
        {
            string reg = "<script>toreg()</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "key", reg);
        }
    }
    protected void btnusersignup_Click(object sender, EventArgs e)
    {
        char ch;
        DateTime date = new DateTime();
        date = DateTime.Now;
            for (int i = 0; i < txtcontact.Text.Length; i++)
            {
                ch = Convert.ToChar(txtcontact.Text.Substring(i, 1));
                if (ch < '0' || ch > '9') 
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Contact number should contain only digits')</script>");;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "a", "<script>document.getElementById('btnsign').click();</script>");
                    break;
                }
            }
            if (!Global.validatemail(txtemail))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Enter Valid Email Address')</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "a", "<script>document.getElementById('btnsign').click();</script>");
            }
         else if (!Global.checkchar(txtfirstname))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('First name should contain charactres only!!!')</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "a", "<script>document.getElementById('btnsign').click();</script>");
            }
            else if (!Global.checkchar(txtlastname))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Last name should contain charactres only!!!')</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "a", "<script>document.getElementById('btnsign').click();</script>");
            }
            else if (txtpswd.Text.Length < 8)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Password must contain 8 characters')</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "a", "<script>document.getElementById('btnsign').click();</script>");
            }       
            else if (txtpswd.Text != txtconfirm.Text)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please re-enter correct password')</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "a", "<script>document.getElementById('btnsign').click();</script>");
            }
            else if (txtcontact.Text.Length != 10)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Contact Number must be of 10 digits')</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "a", "<script>document.getElementById('btnsign').click();</script>");
            }
               
            else
            {
               try
               {
                   string temps, id = "BUY", name;
                   int temp, tmp, lenght = 0;
                   c.cmd.CommandText = "select * from buyer where email='" + txtemail.Text + "'";
                   adp2.SelectCommand = c.cmd;
                   adp2.Fill(dt2);
                   if (dt2.Rows.Count > 0)
                   {
                       Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Email already exists!!')</script>");
                       Page.ClientScript.RegisterStartupScript(this.GetType(), "a", "<script>document.getElementById('btnsign').click();</script>");
                   }
                   else
                   {
                       c.cmd.CommandText = "SELECT buyer_id FROM buyer WHERE(date IN(SELECT MAX(date) FROM buyer))";
                       dt.Clear();
                       adp.SelectCommand = c.cmd;
                       adp.Fill(dt);
                       if (dt.Rows.Count <= 0)
                       {
                           id = "BUY1";
                       }
                       else
                       {
                           temps = Convert.ToString(dt.Rows[0].ItemArray[0]);
                           temp = Convert.ToInt16(temps.Substring(3,temps.Length-3));
                           tmp = temp;
                           while (tmp > 0)
                           {
                               tmp /= 10;
                               lenght++;
                           }
                           temp += 1;
                           id += temp;
                       }
                       name = txtfirstname.Text + " " + txtlastname.Text;
                       c.cmd.CommandText = "insert into buyer(buyer_id,name,email,pswd,phone,question,ans,date)VALUES('" + id + "','" + name + "','" + txtemail.Text + "','" +Global.encrypt(txtpswd.Text) + "'," + Convert.ToInt64(txtcontact.Text) + ",'" + ddquestion.SelectedItem.Text.ToString() + "','" + txtans.Text + "',@date)";
                       c.cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
                       c.cmd.ExecuteNonQuery();
                       Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Registered.... Login Now....')</script>");
                       Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
                   }
               }
               catch (SqlException ex)
               {
                   if (ex.Number == 2627)
                   {
                       Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('OOPs!! something went wrong Please Try again')</script>");
                       Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=register");
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
    }
    protected void btnuserlogin_Click(object sender, EventArgs e)
    {
        try
        {
            c = new connect();
            c.cmd.CommandText = "select * from buyer where email='" + txtuserid.Text + "' and pswd='" +Global.encrypt(txtuserpswd.Text) + "'";
            adp3.SelectCommand = c.cmd;
            adp3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                Session["buyer_id"] = Convert.ToString(dt3.Rows[0].ItemArray[0]);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('WelCome " + dt3.Rows[0].ItemArray[1].ToString().ToUpper() + "')</script>");
                Session["buyer_name"] = dt3.Rows[0].ItemArray[1].ToString().ToUpper();
                //c.cmd.CommandText = "update buyer set online=1 where buyer_id='" + Session["buyer_id"].ToString() + "'";
                if (Session["link"]!= null)
                {
                    Response.AddHeader("REFRESH", "3;URL=" + Session["link"].ToString() + "");
                }
                else
                {
                    Response.AddHeader("REFRESH", "3;URL=Home.aspx");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Entered User ID and Password  does not match!!!!')</script>");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "a", "<script>document.getElementById('btnlog').click();</script>");
            }
        }
        catch (NullReferenceException)
        {
            Response.Redirect("Home.aspx");
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

    protected void btnforgot_Click(object sender, EventArgs e)
    {
        Response.Redirect("Forgot.aspx?user=buyer");
    }
}

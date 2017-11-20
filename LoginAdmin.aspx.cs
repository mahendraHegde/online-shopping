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

public partial class SellerLogin : System.Web.UI.Page
{
    connect c;
    DataTable dt = new DataTable();
    SqlDataAdapter adp = new SqlDataAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnadminlogin_Click(object sender, EventArgs e)
    {
        try
        {           
            c = new connect();
            c.cmd.CommandText = "select * from admin where admin_id='"+txtadminid.Text+"' and pswd='"+global.Global.encrypt(txtadminpswd.Text)+"'";
            adp.SelectCommand = c.cmd;
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["admin_id"] = txtadminid.Text;
                Response.Redirect("AdminDash.aspx");
            }
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Entered User ID and password  does not match')</script>");
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

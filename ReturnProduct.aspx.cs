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

public partial class ReturnProduct : System.Web.UI.Page
{
    connect c = new connect();
    SqlDataAdapter adp = new SqlDataAdapter();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    string sts = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["buyer_id"].ToString() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('You Must Login First!!')</script>");
                Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
            }
              else if( Session["order_id"]==null || Session["product_id"]==null)
             {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('OOpss!! Something Went Wrong')</script>");
                    Response.AddHeader("REFRESH", "3;URL=Home.aspx");
             }
            else
            {

                    HtmlGenericControl d = new HtmlGenericControl("div");
                    Image im = new Image();
                    System.Web.UI.WebControls.Label lblname = new System.Web.UI.WebControls.Label();
                    System.Web.UI.WebControls.Label lblprice = new System.Web.UI.WebControls.Label();
                        lblname.CssClass = "cartname";
                        lblprice.CssClass = "cartprice";
                        d.Controls.Add(im);
                        d.Controls.Add(lblname);
                        d.Controls.Add(lblprice);
                        returndiv.Controls.Add(d);
                        c.cmd.CommandText = "select name,img1,price from product where product_id='" + Session["product_id"].ToString() + "'";
                        adp.SelectCommand = c.cmd;
                        dt1.Clear();
                        adp.Fill(dt1);
                        im.ImageUrl = dt1.Rows[0].ItemArray[1].ToString();
                        lblname.Text = dt1.Rows[0].ItemArray[0].ToString().ToUpper();
                        lblprice.Text = "RS:" + dt1.Rows[0].ItemArray[2].ToString();
                        sts ="Return Request Recieved";
            }
        }
        catch (NullReferenceException)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('You Must Login First!!')</script>");
            Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime date = new DateTime();
            date = DateTime.Now;
            c.cmd.CommandText = "insert into sales_return(order_id,product_id,date,status,reason,description) VALUES("+ Convert.ToInt64(Session["order_id"])+",'"+Session["product_id"].ToString()+"',@date,'"+sts+"','"+ddlreason.SelectedItem.Text.ToString()+"','"+txtreason.Text+"')";
            c.cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
            c.cmd.ExecuteNonQuery();
            c.cmd.CommandText = "UPDATE order_detail SET status = 'return'WHERE (order_id = " +Convert.ToInt64(Session["order_id"]) + ") AND (product_id = '" + Session["product_id"].ToString() + "')";
            c.cmd.ExecuteNonQuery();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Return request accepted...')</script>");
            Response.AddHeader("REFRESH", "3;URL=Home.aspx");
        }
        catch (SqlException ex)
        {
            if (ex.Number == 2627)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('OOpss!! Something Went Wrong')</script>");
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

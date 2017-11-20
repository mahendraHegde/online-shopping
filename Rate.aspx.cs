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

public partial class Rate : System.Web.UI.Page
{
    connect c = new connect();
    SqlDataAdapter adp = new SqlDataAdapter();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    int rad = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["buyer_id"] == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('You must login first')</script>");
            Session["link"] = "BuyerProfile.aspx"; 
            Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
        }
        if (Session["product_id"] == null || Session["order_id"] == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('OOpss!! Something Went Wrong')</script>");
            Response.AddHeader("REFRESH", "3;URL=BuyerProfile.aspx");
        }
        else
        {
            c.cmd.CommandText = "select img1,name,rate from product where product_id='" + Session["product_id"].ToString() + "'";
            adp.SelectCommand = c.cmd;
            dt.Clear();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                img.ImageUrl = dt.Rows[0].ItemArray[0].ToString();
                lblname.Text = dt.Rows[0].ItemArray[1].ToString().ToUpper();
            }
            if (Request.QueryString["action"] != null)
                {
                    c.cmd.CommandText = "select review,rate from reviews where product_id='" + Session["product_id"].ToString() + "' and order_id=" + Convert.ToInt64(Session["order_id"]) + " and buyer_id='" + Session["buyer_id"].ToString() + "'";
                    adp.SelectCommand = c.cmd;
                    dt1.Clear();
                    adp.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        if (!Page.IsPostBack)
                        {
                        
                        txtreason.Text = dt1.Rows[0].ItemArray[0].ToString();
                        rad = Convert.ToInt16(dt1.Rows[0].ItemArray[1]);
                        if (rad == 1)
                        {
                            star1.Checked = true;
                        }
                        else if (rad == 2)
                        {
                            star2.Checked = true;
                        }
                        else if (rad == 3)
                        {
                            star3.Checked = true;
                        }
                        else if (rad == 4)
                        {
                            star4.Checked = true;
                        }
                        else if (rad == 5)
                        {
                            star5.Checked = true;
                        }
                    }
                }
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (dt.Rows.Count > 0)
        {
            if (Request.QueryString["action"] != null)
            {
                c.cmd.CommandText = "update product set rate=rate-" + rad+ " where product_id='" + Session["product_id"].ToString() + "'";
                c.cmd.ExecuteNonQuery();
                if (txtreason.Text != "")
                {
                    if (star1.Checked == true)
                    {
                        c.cmd.CommandText = "update product set rate=(rate+1) where product_id='" + Session["product_id"].ToString() + "'";
                        c.cmd.ExecuteNonQuery();
                        c.cmd.CommandText = "update reviews set rate=1,review=@desc where buyer_id='" + Session["buyer_id"].ToString() + "' and product_id='" + Session["product_id"].ToString() + "'and order_id=" + Convert.ToInt64(Session["order_id"]) + "";
                        c.cmd.Parameters.Clear();
                        c.cmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = txtreason.Text;
                        c.cmd.ExecuteNonQuery();
                        Response.Redirect("BuyerProfile.aspx");
                    }
                    else if (star2.Checked == true)
                    {
                        c.cmd.CommandText = "update product set rate=(rate+2) where product_id='" + Session["product_id"].ToString() + "'";
                        c.cmd.ExecuteNonQuery();
                        c.cmd.CommandText = "update reviews set rate=2,review=@desc where buyer_id='" + Session["buyer_id"].ToString() + "' and product_id='" + Session["product_id"].ToString() + "'and order_id=" + Convert.ToInt64(Session["order_id"]) + "";
                        c.cmd.Parameters.Clear();
                        c.cmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = txtreason.Text;
                        c.cmd.ExecuteNonQuery();
                        Response.Redirect("BuyerProfile.aspx");
                    }
                    else if (star3.Checked == true)
                    {
                        c.cmd.CommandText = "update product set rate=(rate+3) where product_id='" + Session["product_id"].ToString() + "'";
                        c.cmd.ExecuteNonQuery();
                        c.cmd.CommandText = "update reviews set rate=3,review=@desc where buyer_id='" + Session["buyer_id"].ToString() + "' and product_id='" + Session["product_id"].ToString() + "'and order_id=" + Convert.ToInt64(Session["order_id"]) + "";
                        c.cmd.Parameters.Clear();
                        c.cmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = txtreason.Text;
                        c.cmd.ExecuteNonQuery();
                        Response.Redirect("BuyerProfile.aspx");
                    }
                    else if (star4.Checked == true)
                    {
                        c.cmd.CommandText = "update product set rate=(rate+4) where product_id='" + Session["product_id"].ToString() + "'";
                        c.cmd.ExecuteNonQuery();
                        c.cmd.CommandText = "update reviews set rate=4,review=@desc where buyer_id='" + Session["buyer_id"].ToString() + "' and product_id='" + Session["product_id"].ToString() + "'and order_id=" + Convert.ToInt64(Session["order_id"]) + "";
                        c.cmd.Parameters.Clear();
                        c.cmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = txtreason.Text;
                        c.cmd.ExecuteNonQuery();
                        Response.Redirect("BuyerProfile.aspx");
                    }
                    else if (star5.Checked == true)
                    {
                        c.cmd.CommandText = "update product set rate=(rate+5) where product_id='" + Session["product_id"].ToString() + "'";
                        c.cmd.ExecuteNonQuery();
                        c.cmd.CommandText = "update reviews set rate=5,review=@desc where buyer_id='" + Session["buyer_id"].ToString() + "' and product_id='" + Session["product_id"].ToString() + "'and order_id=" + Convert.ToInt64(Session["order_id"]) + "";
                        c.cmd.Parameters.Clear();
                        c.cmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = txtreason.Text;
                        c.cmd.ExecuteNonQuery();
                        Response.Redirect("BuyerProfile.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Give rating before the submission')</script>");
                    }

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Write review before you submit')</script>");
                }
            }
            else
            {
                if (txtreason.Text != "")
                {
                    if (star1.Checked == true)
                    {
                        c.cmd.CommandText = "update product set rate=(rate+1),no=no+1 where product_id='" + Session["product_id"].ToString() + "'";
                        c.cmd.ExecuteNonQuery();
                        c.cmd.CommandText = "insert into reviews(buyer_id,product_id,review,order_id,rate) values('"+Session["buyer_id"].ToString()+"','" + Session["product_id"].ToString() + "',@desc," + Convert.ToInt64(Session["order_id"]) + ",1) ";
                        c.cmd.Parameters.Clear();
                        c.cmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = txtreason.Text;
                        c.cmd.ExecuteNonQuery();
                        Response.Redirect("BuyerProfile.aspx");
                    }
                    else if (star2.Checked == true)
                    {
                        c.cmd.CommandText = "update product set rate=(rate+2),no=no+1 where product_id='" + Session["product_id"].ToString() + "'";
                        c.cmd.ExecuteNonQuery();
                        c.cmd.CommandText = "insert into reviews(buyer_id,product_id,review,order_id,rate) values('" + Session["buyer_id"].ToString() + "','" + Session["product_id"].ToString() + "',@desc," + Convert.ToInt64(Session["order_id"]) + ",2) ";
                        c.cmd.Parameters.Clear();
                        c.cmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = txtreason.Text;
                        c.cmd.ExecuteNonQuery();
                        Response.Redirect("BuyerProfile.aspx");
                    }
                    else if (star3.Checked == true)
                    {
                        c.cmd.CommandText = "update product set rate=(rate+3),no=no+1 where product_id='" + Session["product_id"].ToString() + "'";
                        c.cmd.ExecuteNonQuery();
                        c.cmd.CommandText = "insert into reviews(buyer_id,product_id,review,order_id,rate) values('" + Session["buyer_id"].ToString() + "','" + Session["product_id"].ToString() + "',@desc," + Convert.ToInt64(Session["order_id"]) + ",3) ";
                        c.cmd.Parameters.Clear();
                        c.cmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = txtreason.Text;
                        c.cmd.ExecuteNonQuery();
                        Response.Redirect("BuyerProfile.aspx");
                    }
                    else if (star4.Checked == true)
                    {
                        c.cmd.CommandText = "update product set rate=(rate+4),no=no+1 where product_id='" + Session["product_id"].ToString() + "'";
                        c.cmd.ExecuteNonQuery();
                        c.cmd.CommandText = "insert into reviews(buyer_id,product_id,review,order_id,rate) values('" + Session["buyer_id"].ToString() + "','" + Session["product_id"].ToString() + "',@desc," + Convert.ToInt64(Session["order_id"]) + ",4) ";
                        c.cmd.Parameters.Clear();
                        c.cmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = txtreason.Text;
                        c.cmd.ExecuteNonQuery();
                        Response.Redirect("BuyerProfile.aspx");
                    }
                    else if (star5.Checked == true)
                    {
                        c.cmd.CommandText = "update product set rate=(rate+5),no=no+1 where product_id='" + Session["product_id"].ToString() + "'";
                        c.cmd.ExecuteNonQuery();
                        c.cmd.CommandText = "insert into reviews(buyer_id,product_id,review,order_id,rate) values('" + Session["buyer_id"].ToString() + "','" + Session["product_id"].ToString() + "',@desc," + Convert.ToInt64(Session["order_id"]) + ",5) ";
                        c.cmd.Parameters.Clear();
                        c.cmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = txtreason.Text;
                        c.cmd.ExecuteNonQuery();
                        Response.Redirect("BuyerProfile.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Give rating before the submission')</script>");
                    }

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Write review before you submit')</script>");
                }
            }
        }
    }
}

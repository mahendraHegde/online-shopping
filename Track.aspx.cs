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

public partial class Track : System.Web.UI.Page
{
    connect c = new connect();
    SqlDataAdapter adp = new SqlDataAdapter();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    double pin = 0;
    DateTime date = DateTime.Now.Date;
    DateTime est;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["buyer_id"] == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('You must login first')</script>");
            Session["link"] = "BuyerProfile.aspx"; 
            Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
        }
        if (Session["order_id"] == null || Session["product_id"] == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('OOpss!! Something Went Wrong')</script>");
            Response.AddHeader("REFRESH", "3;URL=BuyerProfile.aspx");
        }
        else
        {
            c.cmd.CommandText = "select img1,product.name,check1,check2,check3,check4 from product,order_detail where order_detail.product_id=product.product_id and order_id=" + Convert.ToInt64(Session["order_id"]) + "and order_detail.product_id='" + Session["product_id"].ToString() + "'";
            adp.SelectCommand = c.cmd;
            dt.Clear();
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                img.ImageUrl = dt.Rows[0].ItemArray[0].ToString();
                lblname.Text = dt.Rows[0].ItemArray[1].ToString().ToUpper();
                if (dt.Rows[0].ItemArray[2].ToString() != "")
                {
                    check1.Style.Add("width", "5%");
                    check1.Style.Add("background", "linear-gradient(to left top, red, yellow, red, yellow)");
                    pin = Convert.ToDouble(dt.Rows[0].ItemArray[2]);
                    est = date.AddDays(7);
                }
                if (dt.Rows[0].ItemArray[3].ToString() != "")
                {
                    check1.Style.Add("width", "20%");
                    check1.Style.Add("background", "linear-gradient(to left, red, yellow, red, yellow)");
                    pin = Convert.ToDouble(dt.Rows[0].ItemArray[3]);
                    est = date.AddDays(4);
                }
                if (dt.Rows[0].ItemArray[4].ToString() != "")
                {
                    check1.Style.Add("width", "20%");
                    check2.Style.Add("background", "linear-gradient(to right, red, yellow, red, yellow)");
                    pin = Convert.ToDouble(dt.Rows[0].ItemArray[4]);
                    est = date.AddDays(2);
                }
                if (dt.Rows[0].ItemArray[5].ToString() != "")
                {
                    check1.Style.Add("width", "20%");
                    check3.Style.Add("background", "linear-gradient(to left, red, yellow, red, yellow)");
                    pin = Convert.ToDouble(dt.Rows[0].ItemArray[2]);
                    est = date.AddDays(0);
                }
                c.cmd.CommandText = "select taluk,district,state from pincodes where pin="+pin+"";
                adp.SelectCommand = c.cmd;
                dt1.Clear();
                adp.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    locdiv.InnerHtml = "";
                    locdiv.InnerHtml = "Your Product is @ <br/> Taluk:" + dt1.Rows[0].ItemArray[0].ToString() + "<br/>District:" + dt1.Rows[0].ItemArray[1].ToString() + "<br/>State:" + dt1.Rows[0].ItemArray[2].ToString() + "<br/>Estimated Delivery:" + est.Date.AddHours(18).ToString() + "";
                }
                else
                {
                    locdiv.InnerHtml = "";
                    locdiv.InnerHtml = "Pickup Not Done Yet";
                }
            }
        }
    }
}

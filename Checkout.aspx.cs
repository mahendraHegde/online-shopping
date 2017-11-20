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

public partial class css_Checkout : System.Web.UI.Page
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
    DataTable dt8 = new DataTable();
    DataTable dt9 = new DataTable();
    long log_id = 0;
    public static int  dbtflag = 0;
   public static string payment="no";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["buyer_id"] == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
            Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
        }
        else
        {
            try
            {
                c.cmd.CommandText = "select * from cart where buyer_id='" + Session["buyer_id"].ToString() + "'";
                dt8.Clear();
                adp.SelectCommand = c.cmd;
                adp.Fill(dt8);
                if (dt8.Rows.Count <= 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Your Cart is Empty')</script>");
                    Response.AddHeader("REFRESH", "3;URL=Home.aspx");
                }
                if (!Page.IsPostBack)
                {
                    divfinal.Visible = false;
                    divdebit.Visible = false;
                    divaddress.Visible = false;
                    c.cmd.CommandText = "select * from buyer where buyer_id='" + Session["buyer_id"].ToString() + "'";
                    adp.SelectCommand = c.cmd;
                    dt.Clear();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txtname.Text = dt.Rows[0].ItemArray[1].ToString();
                        txtadress.Text = dt.Rows[0].ItemArray[11].ToString();
                        txtciry.Text = dt.Rows[0].ItemArray[10].ToString();
                        txtpin.Text = dt.Rows[0].ItemArray[12].ToString();
                        txtstate.Text = dt.Rows[0].ItemArray[9].ToString();
                        txtcountry.Text = dt.Rows[0].ItemArray[8].ToString();
                        txtcontact.Text = dt.Rows[0].ItemArray[4].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }


    protected void btncod_Click(object sender, EventArgs e)
    {
        divdebit.Visible = false;
        divaddress.Visible = true;
        divfinal.Visible = false;
        txt4.Text = "3";
        payment = "no";
        dbtflag = 0;
    }
    protected void btndebit_Click(object sender, EventArgs e)
    {
        dbtflag = 1;
        divdebit.Visible = false;
        divaddress.Visible = true;
        divfinal.Visible = false;
        payment = "yes";
    }
    protected void btnconinue_Click(object sender, EventArgs e)
    {
        if (Global.validatepin(txtpin))
        {
            if (Global.validphone(txtcontact))
            {
                if (txtadress.Text != null && txtciry.Text != null && txtcountry.Text != null && txtstate.Text != null && txtname.Text != null)
                {
                    c.cmd.CommandText = "UPDATE buyer SET country = '" + txtcountry.Text + "',state='" + txtstate.Text + "',pin='" + Convert.ToInt64(txtpin.Text) + "',phone='" + Convert.ToInt64(txtcontact.Text) + "',city='" + txtciry.Text + "',address='" + txtadress.Text + "' WHERE(buyer_id = '" + Session["buyer_id"] + "')";
                    c.cmd.ExecuteNonQuery();
                    if (dbtflag == 1)
                    {
                        divdebit.Visible = true;
                        divfinal.Visible = false;
                        txt4.Text = "4";
                        lblname.Text = txtname.Text;
                        lblpin.Text = txtpin.Text;
                        lblcity.Text = txtciry.Text;
                        lblstate.Text = txtstate.Text;
                        lblcontact.Text = txtcontact.Text;
                        lbladdress.Text = txtadress.Text;
                        lblcountry.Text = txtcountry.Text;
                        lblmethod.Text = "Prepaid";
                        lbltot.Text = Session["cart_tot"].ToString();
                    }
                    if (divdebit.Visible == false)
                    {
                        divfinal.Visible = true;
                        txt4.Text = "3";
                        lblname.Text = txtname.Text;
                        lblpin.Text = txtpin.Text;
                        lblcity.Text = txtciry.Text;
                        lblstate.Text = txtstate.Text;
                        lblcontact.Text = txtcontact.Text;
                        lbladdress.Text = txtadress.Text;
                        lblcountry.Text = txtcountry.Text;
                        lblmethod.Text = "COD";
                        lbltot.Text = Session["cart_tot"].ToString();
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Fill Everything')</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Invalid Phone Number')</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Invalid pin')</script>");
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
                txtciry.Text = Global.city;
                txtcountry.Text = "India";
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void btndbtcont_Click(object sender, EventArgs e)
    {
       
        if (txtmm.Text.Length != 2)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Month should contain only 2 digits')</script>");
        }
       else if (txtyy.Text.Length != 2)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Year should only contain 2 digits')</script>");
        }
      else  if (!Global.checkfordigit(txtmm) )
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Month should contain only  digits')</script>");
        }
        else if (Convert.ToInt16(txtmm.Text) < 0 && Convert.ToInt16(txtmm.Text) > 12)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Entered mont is not valid')</script>");
        }
        else if (!Global.checkfordigit(txtyy))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Year should contain only  digits')</script>");
        }
        else if (Convert.ToInt16(txtyy.Text) <Convert.ToInt16(DateTime.Now.Year.ToString().Substring(2,2)))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Yor Card is Out of Date')</script>");
        }
        else if (Convert.ToInt16(txtyy.Text) == Convert.ToInt16(DateTime.Now.Year.ToString().Substring(2, 2)) && Convert.ToInt16(txtmm.Text) <= DateTime.Now.Month)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Yor Card is Out of Date')</script>");
        }
        else if (!Global.validatecard(txtcardno))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Invalid Card Number')</script>");
        }
        else if (Global.validatecard(txtcardno))
        {
            divfinal.Visible = true;
            txt4.Text = "4";
            payment = "yes";
        }
    }
    protected void btncompleteorder_Click(object sender, EventArgs e)
    {
        try
        {
            c.cmd.CommandText = "select * from cart where buyer_id='" + Session["buyer_id"].ToString() + "'";
            adp.SelectCommand = c.cmd;
            dt5.Clear();
            adp.Fill(dt5);
            if (dt5.Rows.Count > 0)
            {
                int qty = 0, q1 = 0, q2 = 0, shipping = 0;
                int lenght = 0;
                long tot = 0;

                dt2.Clear();
                dt3.Clear();
                dt2 = (DataTable)Global.getcart(Session["buyer_id"].ToString());
                c.cmd.CommandText = "SELECT product_id, seller_id,price,name FROM product WHERE (product_id IN (SELECT product_id FROM  cart))";
                adp.SelectCommand = c.cmd;
                adp.Fill(dt3);
                dt4.Clear();
                c.cmd.CommandText = "SELECT qty FROM product WHERE (product_id IN (SELECT  product_id FROM cart WHERE  (buyer_id = '" + Session["buyer_id"].ToString() + "')))";
                adp.SelectCommand = c.cmd;
                adp.Fill(dt4);
                for (int k = 0; k < dt2.Rows.Count; k++)
                {
                    tot += Convert.ToInt64(dt2.Rows[k].ItemArray[4]);
                }
                if (tot < 1000)
                {
                    shipping = 100;
                }
                c.cmd.CommandText = "SELECT  orders.order_id, orders.log_id FROM orders  where (orders.order_id =(SELECT MAX(order_id)FROM orders ))";
                adp.SelectCommand = c.cmd;
                dt6.Clear();
                adp.Fill(dt6);
                c.cmd.CommandText = "select max(log_id),min(log_id) from logistic";
                adp.SelectCommand = c.cmd;
                dt9.Clear();
                adp.Fill(dt9);
                    if (dt6.Rows.Count > 0&&dt9.Rows.Count>0)
                    {
                        log_id = Convert.ToInt64(dt6.Rows[0].ItemArray[1]);
                        log_id++;
                        if (log_id > Convert.ToInt64(dt9.Rows[0].ItemArray[0]))
                        {
                            log_id = Convert.ToInt64(dt9.Rows[0].ItemArray[1]);
                        }
                    }
                else
                {
                    c.cmd.CommandText = "select min(log_id) from logistic";
                    adp.SelectCommand = c.cmd;
                    dt7.Clear();
                    adp.Fill(dt7);
                    if (dt7.Rows.Count > 0)
                    {
                        log_id = Convert.ToInt64(dt7.Rows[0].ItemArray[0]);
                    }
                }
                c.cmd.CommandText = "insert into orders(buyer_id,log_id,shipping,total,date,payment) values('" + Session["buyer_id"].ToString() + "',"+log_id+"," + shipping + "," + tot + ",@date,'" + payment + "')";
                c.cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
                c.cmd.ExecuteNonQuery();
                c.cmd.CommandText = "select order_id,total from orders where buyer_id='" + Session["buyer_id"].ToString() + "'and order_id in(select max(order_id)from orders)";
                adp.SelectCommand = c.cmd;
                dt1.Clear();
                adp.Fill(dt1);
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    c.cmd.CommandText = "INSERT INTO order_detail (order_id,name, product_id, seller_id, qty, total,status) VALUES (" + Convert.ToInt64(dt1.Rows[0].ItemArray[0]) + ",'" + dt3.Rows[i].ItemArray[3].ToString() + "' ,'" + dt3.Rows[i].ItemArray[0].ToString() + "', '" + dt3.Rows[i].ItemArray[1].ToString() + "'," + Convert.ToInt16(dt2.Rows[i].ItemArray[3]) + "," + Convert.ToInt16(dt2.Rows[i].ItemArray[3]) * Convert.ToInt64(dt3.Rows[i].ItemArray[2]) + ",'placed')";
                    c.cmd.ExecuteNonQuery();
                    q1 = Convert.ToInt16(dt4.Rows[i].ItemArray[0]);
                    q2 = Convert.ToInt16(dt2.Rows[i].ItemArray[3]);
                    qty = q1 - q2;
                    c.cmd.CommandText = "update product set qty=" + qty + " where product_id='" + dt2.Rows[i].ItemArray[2].ToString() + "'";
                    c.cmd.ExecuteNonQuery();
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Order Placed Successfully')</script>");
                Session["order_id"] = dt1.Rows[0].ItemArray[0];
                Session["payment"] = payment;
                c.cmd.CommandText = "delete from cart where buyer_id='" + Session["buyer_id"].ToString() + "'";
                c.cmd.ExecuteNonQuery();
                Session["product_id"] = null;
                Response.AddHeader("REFRESH", "3;URL=Bill.aspx");
            }
            else
            {
                Response.Redirect("Cart.aspx");
            }
        }
        catch (SqlException ex)
        {
            if (ex.Number == 2627)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('OOPs!! something went wrong Please Try again')</script>");
                Response.AddHeader("REFRESH", "3;URL=Cart.aspx");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void logout_Click(object sender, EventArgs e)
    {

        Session["buyer_id"] = null;
        Response.Redirect("Home.aspx");
    }

}

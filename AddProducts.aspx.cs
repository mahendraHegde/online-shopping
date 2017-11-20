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
using System.IO;
using System.Collections.Generic;
using global;

public partial class SellerLogin : System.Web.UI.Page
{
    connect c = new connect();
    SqlDataAdapter adp = new SqlDataAdapter();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt4 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["seller_id"] == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
            Session["slink"] = "AddProducts.aspx";
            Response.AddHeader("REFRESH", "3;URL=SeLoLogReg.aspx?val=login");
        }
        else
        {
            try
            {
                if (!Page.IsPostBack)
                {
                c.cmd.CommandText = "select cat_name from category ";
                adp.SelectCommand = c.cmd;
                dt2.Clear();
                adp.Fill(dt2);
               
                    ddcat.Items.Clear();
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        ddcat.Items.Add(dt2.Rows[i].ItemArray[0].ToString());
                    }
                    if (Request.QueryString["product_id"] != null)
                    {
                        header.InnerHtml = "Update Product";
                        c.cmd.CommandText = "select * from product where product_id='" + Request.QueryString["product_id"] + "'";
                        adp.SelectCommand = c.cmd;
                        dt3.Clear();
                        adp.Fill(dt3);
                        if (dt3.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt2.Rows.Count; i++)
                            {
                                if (dt2.Rows[i].ItemArray[0].ToString() == dt3.Rows[0].ItemArray[2].ToString())
                                {
                                    ddcat.SelectedIndex = i;
                                    break;
                                }
                            }
                            txtprodname.Text = dt3.Rows[0].ItemArray[1].ToString();
                            txtqty.Text = dt3.Rows[0].ItemArray[3].ToString();
                            txtprice.Text = dt3.Rows[0].ItemArray[4].ToString();
                            txtbrand.Text = dt3.Rows[0].ItemArray[5].ToString();
                            txtcolor.Text = dt3.Rows[0].ItemArray[6].ToString();
                            txtdescription.Text = dt3.Rows[0].ItemArray[8].ToString();
                            txtweight.Text = dt3.Rows[0].ItemArray[7].ToString();
                            btnadd.Text = "Update";
                        }
                    }
                    else
                    {
                        header.InnerHtml = "Add a Product";
                    }
                }
                c.cmd.CommandText = "select product_id from product";
                adp.SelectCommand = c.cmd;
                DateTime date = new DateTime();
                date = DateTime.Now;
                adp.Fill(dt);
                for (int i = 1; i <= 9; i++)
                {
                    c.cmd.CommandText = "update product set rate='" + 4 + "'where product_id='PROD" + i + "' ";
                    c.cmd.ExecuteNonQuery();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Error occured");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        string temps, path1="", fileName,path2="", path3="", id = "PROD";
        int temp, tmp, lenght = 0, flag = 0;
        DateTime date = new DateTime();
        date = DateTime.Now;
        string sellerid = "0", keyword = "";
        keyword += txtprodname.Text + ddcat.Text + txtbrand.Text + txtcolor.Text + txtdescription.Text + txtkey.Text;
            if (!Global.checkfordigit(txtprice))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Price should contain only digits')</script>");
                flag = 1;
            }
        if (flag == 0)
        {
                if (!Global.checkfordigit(txtweight))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Weight should contain only digits')</script>");
                    flag = 1;
                }
            }
        if (flag == 0)
        {
                if (!Global.checkfordigit(txtqty))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Quantity should contain only digits')</script>");
                    flag = 1;
                }
            }
            if (!img1.HasFile && flag == 0 && Request.QueryString["product_id"] == null)
             {
                 Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('please choose Image1 For your Product')</script>");
                 flag = 1;
             }
             else if (img1.HasFile && flag == 0 && !Global.checkimgtype(img1))
             {
                 Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('You Can Only Upload Images(Image1 Has Different File type)')</script>");
                 flag = 1;
             }
           if (!img2.HasFile && flag == 0 && Request.QueryString["product_id"] == null)
             {
                 Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('please choose Image2 For your Product')</script>");
                 flag = 1;
             }
             else if (img2.HasFile && flag == 0 && !Global.checkimgtype(img2))
             {
                 Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('You Can Only Upload Images(Image2 Has Different File type)')</script>");
                 flag = 1;
             }
             if (!img3.HasFile && flag == 0 && Request.QueryString["product_id"] == null)
             {
                 Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('please choose Image3 For your Product')</script>");
                 flag = 1;
             }
             else if (img3.HasFile && flag == 0 && !Global.checkimgtype(img3))
             {
                 Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('You Can Only Upload Images(Image3 Has Different File type)')</script>");
                 flag = 1;
             }
        if (flag == 0)
        {
            try
            {
                if (Request.QueryString["product_id"] != null)
                {
                    string physical, path, p1, p2, p3;
                    c.cmd.CommandText = "select img1,img2,img3 from product where product_id='" + Request.QueryString["product_id"].ToString() + "'";
                    adp.SelectCommand = c.cmd;
                    dt4.Clear();
                    adp.Fill(dt4);
                    if (dt4.Rows.Count > 0)
                    {
                        physical = Server.MapPath("~/");

                        path = dt4.Rows[0].ItemArray[0].ToString();
                        path = path.Substring(2, path.Length - 2);
                        p1 = physical + path;

                        path = dt4.Rows[0].ItemArray[1].ToString();
                        path = path.Substring(2, path.Length - 2);
                        p2 = physical + path;

                        path = dt4.Rows[0].ItemArray[2].ToString();
                        path = path.Substring(2, path.Length - 2);
                        p3 = physical + path;

                        if (img1.HasFile && img2.HasFile && img3.HasFile)
                        {
                            if (System.IO.File.Exists(p1))
                            {
                                System.IO.File.Delete(p1);
                            }
                            if (System.IO.File.Exists(p2))
                            {
                                System.IO.File.Delete(p2);
                            }
                            if (System.IO.File.Exists(p3))
                            {
                                System.IO.File.Delete(p3);
                            }
                            fileName = Path.GetFileName(img1.PostedFile.FileName);
                            img1.PostedFile.SaveAs(Server.MapPath("~/products/") + fileName);
                            path1 = "~/products/" + fileName;

                            fileName = Path.GetFileName(img2.PostedFile.FileName);
                            img2.PostedFile.SaveAs(Server.MapPath("~/products/") + fileName);
                            path2 = "~/products/" + fileName;

                            fileName = Path.GetFileName(img3.PostedFile.FileName);
                            img3.PostedFile.SaveAs(Server.MapPath("~/products/") + fileName);
                            path3 = "~/products/" + fileName;

                            c.cmd.CommandText = "update product set name='" + txtprodname.Text + "',category='" + ddcat.SelectedItem.Text + "',qty=" + Convert.ToInt16(txtqty.Text) + ",price=" + Convert.ToDecimal(txtprice.Text) + ",brand='" + txtbrand.Text + "',color='" + txtcolor.Text + "',weight=" + Convert.ToInt16(txtweight.Text) + ",keyword='" + keyword + "',description='" + txtdescription.Text + "',img1='" + path1 + "',img2='" + path2 + "',img3='" + path3 + "' where product_id='" + Request.QueryString["product_id"].ToString() + "'";
                            c.cmd.ExecuteNonQuery();
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Product Updated Successfully')</script>");
                            Response.AddHeader("REFRESH", "3;URL=SellerDash.aspx");
                        }
                        else if (img1.HasFile && img2.HasFile && !img3.HasFile)
                        {

                            if (System.IO.File.Exists(p1))
                            {
                                System.IO.File.Delete(p1);
                            }
                            if (System.IO.File.Exists(p2))
                            {
                                System.IO.File.Delete(p2);
                            }
                            fileName = Path.GetFileName(img1.PostedFile.FileName);
                            img1.PostedFile.SaveAs(Server.MapPath("~/products/") + fileName);
                            path1 = "~/products/" + fileName;

                            fileName = Path.GetFileName(img2.PostedFile.FileName);
                            img2.PostedFile.SaveAs(Server.MapPath("~/products/") + fileName);
                            path2 = "~/products/" + fileName;

                            c.cmd.CommandText = "update product set name='" + txtprodname.Text + "',category='" + ddcat.SelectedItem.Text + "',qty=" + Convert.ToInt16(txtqty.Text) + ",price=" + Convert.ToDecimal(txtprice.Text) + ",brand='" + txtbrand.Text + "',color='" + txtcolor.Text + "',weight=" + Convert.ToInt16(txtweight.Text) + ",keyword='" + keyword + "',description='" + txtdescription.Text + "',img1='" + path1 + "',img2='" + path2 + "' where product_id='" + Request.QueryString["product_id"].ToString() + "'";
                            c.cmd.ExecuteNonQuery();
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Product Updated Successfully')</script>");
                            Response.AddHeader("REFRESH", "3;URL=SellerDash.aspx");
                        }
                        else if (img1.HasFile && !img2.HasFile && img3.HasFile)
                        {
                            if (System.IO.File.Exists(p1))
                            {
                                System.IO.File.Delete(p1);
                            }
                            if (System.IO.File.Exists(p3))
                            {
                                System.IO.File.Delete(p3);
                            }
                            fileName = Path.GetFileName(img1.PostedFile.FileName);
                            img1.PostedFile.SaveAs(Server.MapPath("~/products/") + fileName);
                            path1 = "~/products/" + fileName;

                            fileName = Path.GetFileName(img3.PostedFile.FileName);
                            img3.PostedFile.SaveAs(Server.MapPath("~/products/") + fileName);
                            path3 = "~/products/" + fileName;

                            c.cmd.CommandText = "update product set name='" + txtprodname.Text + "',category='" + ddcat.SelectedItem.Text + "',qty=" + Convert.ToInt16(txtqty.Text) + ",price=" + Convert.ToDecimal(txtprice.Text) + ",brand='" + txtbrand.Text + "',color='" + txtcolor.Text + "',weight=" + Convert.ToInt16(txtweight.Text) + ",keyword='" + keyword + "',description='" + txtdescription.Text + "',img1='" + path1 + "',img3='" + path3 + "' where product_id='" + Request.QueryString["product_id"].ToString() + "'";
                            c.cmd.ExecuteNonQuery();
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Product Updated Successfully')</script>");
                            Response.AddHeader("REFRESH", "3;URL=SellerDash.aspx");
                        }
                        else if (!img1.HasFile && img2.HasFile && img3.HasFile)
                        {

                            if (System.IO.File.Exists(p2))
                            {
                                System.IO.File.Delete(p2);
                            }
                            if (System.IO.File.Exists(p3))
                            {
                                System.IO.File.Delete(p3);
                            }
                            fileName = Path.GetFileName(img2.PostedFile.FileName);
                            img2.PostedFile.SaveAs(Server.MapPath("~/products/") + fileName);
                            path2 = "~/products/" + fileName;

                            fileName = Path.GetFileName(img3.PostedFile.FileName);
                            img3.PostedFile.SaveAs(Server.MapPath("~/products/") + fileName);
                            path3 = "~/products/" + fileName;

                            c.cmd.CommandText = "update product set name='" + txtprodname.Text + "',category='" + ddcat.SelectedItem.Text + "',qty=" + Convert.ToInt16(txtqty.Text) + ",price=" + Convert.ToDecimal(txtprice.Text) + ",brand='" + txtbrand.Text + "',color='" + txtcolor.Text + "',weight=" + Convert.ToInt16(txtweight.Text) + ",keyword='" + keyword + "',description='" + txtdescription.Text + "',img2='" + path2 + "',img3='" + path3 + "' where product_id='" + Request.QueryString["product_id"].ToString() + "'";
                            c.cmd.ExecuteNonQuery();
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Product Updated Successfully')</script>");
                            Response.AddHeader("REFRESH", "3;URL=SellerDash.aspx");
                        }
                        else if (img1.HasFile && (!img2.HasFile) && (!img3.HasFile))
                        {
                            if (System.IO.File.Exists(p1))
                            {
                                System.IO.File.Delete(p1);
                            }

                            fileName = Path.GetFileName(img1.PostedFile.FileName);
                            img1.PostedFile.SaveAs(Server.MapPath("~/products/") + fileName);
                            path1 = "~/products/" + fileName;

                            c.cmd.CommandText = "update product set name='" + txtprodname.Text + "',category='" + ddcat.SelectedItem.Text + "',qty=" + Convert.ToInt16(txtqty.Text) + ",price=" + Convert.ToDecimal(txtprice.Text) + ",brand='" + txtbrand.Text + "',color='" + txtcolor.Text + "',weight=" + Convert.ToInt16(txtweight.Text) + ",keyword='" + keyword + "',description='" + txtdescription.Text + "',img1='"+path1+"' where product_id='" + Request.QueryString["product_id"].ToString() + "'";
                            c.cmd.ExecuteNonQuery();
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Product Updated Successfully')</script>");
                            Response.AddHeader("REFRESH", "3;URL=SellerDash.aspx");
                        }
                        else if ((!img1.HasFile) && img2.HasFile && (!img3.HasFile))
                        {
                            if (System.IO.File.Exists(p2))
                            {
                                System.IO.File.Delete(p2);
                            }

                            fileName = Path.GetFileName(img2.PostedFile.FileName);
                            img2.PostedFile.SaveAs(Server.MapPath("~/products/") + fileName);
                            path2 = "~/products/" + fileName;

                            c.cmd.CommandText = "update product set name='" + txtprodname.Text + "',category='" + ddcat.SelectedItem.Text + "',qty=" + Convert.ToInt16(txtqty.Text) + ",price=" + Convert.ToDecimal(txtprice.Text) + ",brand='" + txtbrand.Text + "',color='" + txtcolor.Text + "',weight=" + Convert.ToInt16(txtweight.Text) + ",keyword='" + keyword + "',description='" + txtdescription.Text + "',img2='" + path2 + "' where product_id='" + Request.QueryString["product_id"].ToString() + "'";
                            c.cmd.ExecuteNonQuery();
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Product Updated Successfully')</script>");
                            Response.AddHeader("REFRESH", "3;URL=SellerDash.aspx");
                        }
                        else if ((!img1.HasFile) && (!img2.HasFile) && img3.HasFile)
                        {

                            if (System.IO.File.Exists(p3))
                            {
                                System.IO.File.Delete(p3);
                            }
                            fileName = Path.GetFileName(img3.PostedFile.FileName);
                            img3.PostedFile.SaveAs(Server.MapPath("~/products/") + fileName);
                            path3 = "~/products/" + fileName;

                            c.cmd.CommandText = "update product set name='" + txtprodname.Text + "',category='" + ddcat.SelectedItem.Text + "',qty=" + Convert.ToInt16(txtqty.Text) + ",price=" + Convert.ToDecimal(txtprice.Text) + ",brand='" + txtbrand.Text + "',color='" + txtcolor.Text + "',weight=" + Convert.ToInt16(txtweight.Text) + ",keyword='" + keyword + "',description='" + txtdescription.Text + "',img3='" + path3 + "' where product_id='" + Request.QueryString["product_id"].ToString() + "'";
                            c.cmd.ExecuteNonQuery();
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Product Updated Successfully')</script>");
                            Response.AddHeader("REFRESH", "3;URL=SellerDash.aspx");
                        }
                        else if (!img1.HasFile && !img2.HasFile && !img3.HasFile)
                        {
                            c.cmd.CommandText = "update product set name='" + txtprodname.Text + "',category='" + ddcat.SelectedItem.Text + "',qty=" + Convert.ToInt16(txtqty.Text) + ",price=" + Convert.ToDecimal(txtprice.Text) + ",brand='" + txtbrand.Text + "',color='" + txtcolor.Text + "',weight=" + Convert.ToInt16(txtweight.Text) + ",keyword='" + keyword + "',description='" + txtdescription.Text + "' where product_id='" + Request.QueryString["product_id"].ToString() + "'";
                            c.cmd.ExecuteNonQuery();
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Product Updated Successfully')</script>");
                            Response.AddHeader("REFRESH", "3;URL=SellerDash.aspx");
                        }
                    }
                    else
                    {
                        c = new connect();
                        c.cmd.CommandText = "SELECT product_id FROM product WHERE(date IN(SELECT MAX(date) FROM product))";
                        dt.Clear();
                        adp.SelectCommand = c.cmd;
                        adp.Fill(dt);
                        if (dt.Rows.Count <= 0)
                        {
                            id = "PROD1";
                        }
                        else
                        {
                            temps = Convert.ToString(dt.Rows[0].ItemArray[0]);
                            temp = Convert.ToInt16(temps.Substring(4, temps.Length - 4));
                            tmp = temp;
                            while (tmp > 0)
                            {
                                tmp /= 10;
                                lenght++;
                            }
                            temp += 1;
                            id += temp;
                        }
                        if (img1.HasFile)
                        {
                            fileName = Path.GetFileName(img1.PostedFile.FileName);
                            img1.PostedFile.SaveAs(Server.MapPath("~/products/") + fileName);
                            path1 = "~/products/" + fileName;
                        }
                        if (img2.HasFile)
                        {
                            fileName = Path.GetFileName(img2.PostedFile.FileName);
                            img2.PostedFile.SaveAs(Server.MapPath("~/products/") + fileName);
                            path2 = "~/products/" + fileName;
                        }
                        if (img3.HasFile)
                        {
                            fileName = Path.GetFileName(img3.PostedFile.FileName);
                            img3.PostedFile.SaveAs(Server.MapPath("~/products/") + fileName);
                            path3 = "~/products/" + fileName;
                        }
                        c.cmd.CommandText = "insert into product(product_id,name,category,qty,price,brand,color,weight,description,seller_id,keyword,img1,img2,img3,date) values('" + id + "','" + txtprodname.Text + "','" + ddcat.SelectedItem.Text.ToString() + "'," + Convert.ToInt16(txtqty.Text) + "," + Convert.ToDecimal(txtprice.Text) + ",'" + txtbrand.Text + "','" + txtcolor.Text + "'," + Convert.ToInt64(txtweight.Text) + ",'" + txtdescription.Text + "','" + sellerid + "','" + keyword + "','" + path1 + "','" + path2 + "','" + path3 + "',@date)";
                        c.cmd.Parameters.Clear();
                        c.cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
                        c.cmd.ExecuteNonQuery();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Product Added Successfully')</script>");
                        Response.AddHeader("REFRESH", "3;URL=SellerDash.aspx");
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('OOOps!! Something Went Wrong')</script>");
                    Response.AddHeader("REFRESH", "3;URL=AddProducts.aspx");
                }
            }
            catch (Exception)
            { 
                throw;
            }
        }
    }
}

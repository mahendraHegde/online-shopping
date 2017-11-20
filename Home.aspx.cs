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
public partial class Home : System.Web.UI.Page
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
     SqlDataAdapter adp1 = new SqlDataAdapter();
     SqlDataAdapter adp2 = new SqlDataAdapter();
    int tmpflag = 0;
    long tmpcount=0;
    protected void Page_Load(object sender, EventArgs e)
    {  
        try
        {    
            /*DateTime t = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day+1,0,0,0);
            Response.Cookies["user"].Value ="hello";
            Response.Cookies["user"].Expires = t;*/
            string ip = Request.UserHostAddress;
            c.cmd.CommandText = "select ip,count from temp";
            adp.SelectCommand = c.cmd;
            dt7.Clear();
            adp.Fill(dt7);
            if (dt7.Rows.Count > 0)
            {
                tmpcount = Convert.ToInt64(dt7.Rows[dt7.Rows.Count-1].ItemArray[1]);
                for (int i = 0; i < dt7.Rows.Count; i++)
                {
                    if (ip == dt7.Rows[i].ItemArray[0].ToString())
                    {
                        tmpflag = 1;
                        break;
                    }
                }
                if (tmpflag != 1)
                {
                    tmpcount++;
                    c.cmd.CommandText = "insert into temp(ip) values(@ip,@count) ";
                    c.cmd.Parameters.Clear();
                    c.cmd.Parameters.Add("@ip", SqlDbType.NVarChar).Value = ip;
                    c.cmd.Parameters.Add("@count", SqlDbType.BigInt).Value = tmpcount;
                    c.cmd.ExecuteNonQuery();
                }
            }
            else
            {
                c.cmd.CommandText = "insert into temp(ip,count) values(@ip,"+1+") ";
                c.cmd.Parameters.Clear();
                c.cmd.Parameters.Add("@ip", SqlDbType.NVarChar).Value = ip;
                c.cmd.ExecuteNonQuery();
            }
            int cat_count;
            c.cmd.CommandText = "select cat_name from category ";
            adp.SelectCommand = c.cmd;
            dt2.Clear();
            adp.Fill(dt2);
            cat_count = dt2.Rows.Count;
            if (!Page.IsPostBack)
            {
                ddcatlist.Items.Clear();
                ddcatlist.Items.Add("All");
                for (int i = 1; i < dt2.Rows.Count; i++)
                {
                    ddcatlist.Items.Add(dt2.Rows[i - 1].ItemArray[0].ToString());
                }
            }
            HtmlAnchor []a = new HtmlAnchor[cat_count];
            HtmlGenericControl[] li = new HtmlGenericControl[cat_count];
            for (int i = 0; i < cat_count;i++)
            {
                li[i] = new HtmlGenericControl("li");
                a[i] = new HtmlAnchor();
                li[i].InnerHtml =dt2.Rows[i].ItemArray[0].ToString();
                a[i].ServerClick += new EventHandler(view_cats);
                a[i].HRef = "ProductList.aspx";
                a[i].Attributes.Add("cat_name", dt2.Rows[i].ItemArray[0].ToString());
                catul.Controls.Add(a[i]);
                a[i].Controls.Add(li[i]);
            }
                images();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    c.cnn.Close();
                }
                if (Convert.ToString(Session["buyer_id"]) == "")
        {
            userlogin.Visible = false;
            user.Visible = true;
            lblitemcount.Text = "0";
            lblamt.Text = "RS:00";
        }
        else
        {   
            long tot = 0;
            user.Visible = false;
            userlogin.Visible = true;
            c.cmd.CommandText = "SELECT * FROM cart WHERE (buyer_id = '"+Session["buyer_id"].ToString()+"')";
                adp.SelectCommand = c.cmd;
                dt3.Clear();
                adp.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {
                    lblitemcount.Text = dt3.Rows.Count.ToString();
                    for (int k = 0; k < dt3.Rows.Count; k++)
                    {
                        tot += Convert.ToInt64(dt3.Rows[k].ItemArray[4]);
                    }
                    lblamt.Text = "RS:" + tot;
                }
                else 
                {
                    lblitemcount.Text = "0";
                    lblamt.Text = "RS:00";
                }
        }
        
    }

    void view_cats(object sender, EventArgs e)
    {
        HtmlAnchor a = (HtmlAnchor)sender;
        c.cmd.CommandText = "select * from product where category='" + a.Attributes["cat_name"].ToString() + "'";
        adp.SelectCommand = c.cmd;
        dt5.Clear();
        adp.Fill(dt5);
        Session["dt"] = dt5;
        Session["dt1"] = dt5;
       
       Response.Redirect("ProductList.aspx");
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void logout_Click(object sender, EventArgs e)
    {

        Session["buyer_id"] = null;
        userlogin.Visible = false;
        user.Visible = true;
        Response.Redirect("Home.aspx");
    }
    void mainslider()
    {
        HtmlGenericControl[] divlbl = new HtmlGenericControl[5];
        HtmlGenericControl ul = new HtmlGenericControl("ul");
        HtmlGenericControl descript = new HtmlGenericControl("ul");
        HtmlGenericControl[] li = new HtmlGenericControl[5];
        HtmlAnchor[] a= new HtmlAnchor[5];
        Image []img = new Image[5];
        //System.Web.UI.WebControls.Label[] lbl = new System.Web.UI.WebControls.Label[5];
         Random rand=new Random();
        for (int i = 0; i < 5; i++)
        {
            c.cmd.CommandText = "select * from product where product_id='PROD"+Convert.ToString(i+1)+"'";
            adp.SelectCommand = c.cmd;
            dt8.Clear();
            adp.Fill(dt8);
            if (dt8.Rows.Count > 0)
            {
                li[i] = new HtmlGenericControl("li");
                a[i] = new HtmlAnchor();
                img[i] = new Image();
                divlbl[i] = new HtmlGenericControl("div");
                //lbl[i] = new System.Web.UI.WebControls.Label();
                img[i].CssClass = "img";
                divlbl[i].Attributes.Add("class", "description");
                a[i].Attributes.Add("product_id",dt8.Rows[0].ItemArray[0].ToString());
                a[i].ServerClick += new EventHandler(SlideInner_ServerClick);
                img[i].ImageUrl = dt8.Rows[0].ItemArray[11].ToString();
                divlbl[i].InnerHtml = Convert.ToString(dt8.Rows[0].ItemArray[1]).ToUpper() + "<br/>@ Just " + Convert.ToString(dt8.Rows[0].ItemArray[4]) + "<br/>Brand : " + dt8.Rows[0].ItemArray[5].ToString().ToUpper();
                a[i].Controls.Add(img[i]);
                li[i].Controls.Add(a[i]);
                li[i].Controls.Add(divlbl[i]);
                ul.Controls.Add(li[i]);
               
            }
        }
        slideinner.Controls.Add(ul);
    }

    void SlideInner_ServerClick(object sender, EventArgs e)
    {
        HtmlAnchor a = (HtmlAnchor)sender;
        Session["product_id"] = a.Attributes["product_id"].ToString();
        Response.Redirect("~\\View.aspx");
    }
    protected void images()
    {
        mainslider();
        string temps;
        int id,loop;
        ImageButton[] im = new ImageButton[35];
        System.Web.UI.WebControls.Label[] lbl = new System.Web.UI.WebControls.Label[35];
        for (int i = 0; i < 35; i++)
        {
            im[i] = new ImageButton();
            im[i].CssClass = "img1";
            im[i].Click += new ImageClickEventHandler(call);
            lbl[i] = new System.Web.UI.WebControls.Label();
            lbl[i].Width =0;
            lbl[i].CssClass = "description1";
        }
        ImageButton b = new ImageButton();
        aimg1.Controls.Add(im[0]);
        aimg2.Controls.Add(im[1]);
        aimg3.Controls.Add(im[2]);
        aimg4.Controls.Add(im[3]);
        aimg5.Controls.Add(im[4]);
        aimg6.Controls.Add(im[5]);
        aimg7.Controls.Add(im[6]);
        aimg8.Controls.Add(im[7]);
        aimg9.Controls.Add(im[8]);
        aimg10.Controls.Add(im[9]);

        aimg1.Controls.Add(lbl[0]);
        aimg2.Controls.Add(lbl[1]);
        aimg3.Controls.Add(lbl[2]);
        aimg4.Controls.Add(lbl[3]);
        aimg5.Controls.Add(lbl[4]);
        aimg6.Controls.Add(lbl[5]);
        aimg7.Controls.Add(lbl[6]);
        aimg8.Controls.Add(lbl[7]);
        aimg9.Controls.Add(lbl[8]);
        aimg10.Controls.Add(lbl[9]);

        aimg11.Controls.Add(im[10]);
        aimg12.Controls.Add(im[11]);
        aimg13.Controls.Add(im[12]);
        aimg14.Controls.Add(im[13]);
        aimg15.Controls.Add(im[14]);
        aimg16.Controls.Add(im[15]);
        aimg17.Controls.Add(im[16]);
        aimg18.Controls.Add(im[17]);
        aimg19.Controls.Add(im[18]);
        aimg20.Controls.Add(im[19]);

        aimg11.Controls.Add(lbl[10]);
        aimg12.Controls.Add(lbl[11]);
        aimg13.Controls.Add(lbl[12]);
        aimg14.Controls.Add(lbl[13]);
        aimg15.Controls.Add(lbl[14]);
        aimg16.Controls.Add(lbl[15]);
        aimg17.Controls.Add(lbl[16]);
        aimg18.Controls.Add(lbl[17]);
        aimg19.Controls.Add(lbl[18]);
        aimg20.Controls.Add(lbl[19]);

        aimg21.Controls.Add(im[20]);
        aimg22.Controls.Add(im[21]);
        aimg23.Controls.Add(im[22]);
        aimg24.Controls.Add(im[23]);
        aimg25.Controls.Add(im[24]);
        aimg26.Controls.Add(im[25]);
        aimg27.Controls.Add(im[26]);
        aimg28.Controls.Add(im[27]);
        aimg29.Controls.Add(im[28]);
        aimg30.Controls.Add(im[29]);

        aimg21.Controls.Add(lbl[20]);
        aimg22.Controls.Add(lbl[21]);
        aimg23.Controls.Add(lbl[22]);
        aimg24.Controls.Add(lbl[23]);
        aimg25.Controls.Add(lbl[24]);
        aimg26.Controls.Add(lbl[25]);
        aimg27.Controls.Add(lbl[26]);
        aimg28.Controls.Add(lbl[27]);
        aimg29.Controls.Add(lbl[28]);
        aimg30.Controls.Add(lbl[29]);

        c.cmd.CommandText = "SELECT TOP (10) * FROM product ORDER BY date DESC";
        dt.Clear();
        adp.SelectCommand = c.cmd;
        adp.Fill(dt);
        temps = dt.Rows[0].ItemArray[0].ToString();
        loop = 0;
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                im[i].ImageUrl = Convert.ToString(dt.Rows[i].ItemArray[11]);
                im[i].Attributes["name"] = Convert.ToString(dt.Rows[i].ItemArray[0]);
                lbl[i].Text = lbl[loop].Text.ToUpper();
                lbl[i].Text = Convert.ToString(dt.Rows[i].ItemArray[1]).ToUpper() + "<br/>@ Just " + Convert.ToString(dt.Rows[i].ItemArray[4]);
            }
        }
        c.cmd.CommandText = "SELECT distinct * FROM product WHERE((rate/no) >= 4) ";
        adp.SelectCommand = c.cmd;
        dt.Clear();
        adp.Fill(dt);
        loop = 0;
        if (dt.Rows.Count > 0)
        {
            for (int i = 10; i <20; i++)
            {
                im[i].ImageUrl = Convert.ToString(dt.Rows[loop].ItemArray[11]);
                im[i].Attributes["name"] = dt.Rows[loop].ItemArray[0].ToString();               
                lbl[i].Text = Convert.ToString(dt.Rows[loop].ItemArray[1]).ToUpper() + "<br/>@ Just " + Convert.ToString(dt.Rows[loop].ItemArray[4]);
                loop++;
            }
        }
      
        c.cmd.CommandText = "select count(*) from product";
        adp.SelectCommand = c.cmd;
        dt.Clear();
        adp.Fill(dt1);
        Random r = new Random();
        int rand, count = Convert.ToInt16(dt1.Rows[0].ItemArray[0]);
        loop = 20;
        int[] a = new int[10] {0,0,0,0,0,0,0,0,0,0};
        int z = 0,tmpflag=0;
       while(loop<=29)
       {
           tmpflag = 0;
            rand = Convert.ToInt16(r.Next(0, count-1));
            foreach (int temp in a)
            {
                if (temp == rand)
                {
                    tmpflag = 1;
                    break;
                }
            }
            if (tmpflag == 0)
            {
                a[z] = rand;
                z++;
                c.cmd.CommandText = "select * from product where product_id='PROD" + rand + "'";
                adp.SelectCommand = c.cmd;
                dt.Clear();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (!Page.IsPostBack)
                    {
                        im[loop].Attributes["name"] = dt.Rows[0].ItemArray[0].ToString();
                        im[loop].ImageUrl = dt.Rows[0].ItemArray[11].ToString();
                        lbl[loop].Text = Convert.ToString(dt.Rows[0].ItemArray[1]).ToUpper() + "<br/>@ Just " + Convert.ToString(dt.Rows[0].ItemArray[4]);
                    }
                    loop++;
                }
            }
        }
    }
    protected void call(object sender, EventArgs e)
    {
       ImageButton s = (ImageButton)sender;
       string z = s.Attributes["name"].ToString();
       Session["product_id"] = z;
        Response.Redirect("~\\View.aspx");
    }
    protected void btnsearch_click(object sender, EventArgs e)
    {
        /*int word_count = 0;
        char p = '%';
        txtsearch.Text = txtsearch.Text.Trim();
        for (int i = 0; i < txtsearch.Text.Length; i++)
        {
            if (txtsearch.Text.Substring(i, 1) == " ")
            {
                word_count++;
            }
        }
        word_count++;
        MessageBox.Show(word_count.ToString());*/
        if (ddcatlist.SelectedItem.Text.ToString() == "All")
        {
            c.cmd.CommandText = "select * from product where keyword like'%" + txtsearch.Text.ToString() + "%'";
        }
        else
        {
            c.cmd.CommandText = "select * from product where keyword like'%" + txtsearch.Text.ToString() + "%' and category='" + ddcatlist.SelectedItem.Text.ToString() + "'";
        }
        adp.SelectCommand = c.cmd;
        dt4.Clear();
        adp.Fill(dt4);
        Session["dt"] = dt4;
        Session["dt1"] = dt4;
        Response.Redirect("ProductList.aspx");

    }
    protected void checkout_Click(object sender, EventArgs e)
    {
        long tot=0;
        if (Session["buyer_id"] == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msgbox", "<script> message('Please Login First')</script>");
            Session["link"] = "Cart.aspx"; 
            Response.AddHeader("REFRESH", "3;URL=UserLogReg.aspx?val=login");
        }
        else
        {
            dt6 = (DataTable)Global.getcart(Session["buyer_id"].ToString());
            for (int k = 0; k < dt6.Rows.Count; k++)
            {
                tot += Convert.ToInt64(dt6.Rows[k].ItemArray[4]);
            } 
            if (tot < 1000)
            {
                tot += 100;
            }
            Session["cart_tot"] = tot.ToString();
            Response.Redirect("Checkout.aspx");
        }
    }
}

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

public partial class Help : System.Web.UI.Page
{
    connect c = new connect();
    SqlDataAdapter adp = new SqlDataAdapter();
    DataTable dt = new DataTable();
    int loop = 0,loop1=0;
    string id = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["utype"] != null)
        {
            if (Request.QueryString["utype"].ToString() == "buyer")
            {
                if (Session["buyer_id"] != null)
                { 
                    id = Session["buyer_id"].ToString();
                    c.cmd.CommandText = "select message,response,date,date1 from help where id='" + Session["buyer_id"].ToString() + "' and utype='buyer' order by date";
                    adp.SelectCommand = c.cmd;
                    dt.Clear();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        loop=0;
                        loop1 = 0;
                        HtmlGenericControl[] div = new HtmlGenericControl[dt.Rows.Count * 4];
                        System.Web.UI.WebControls.Label[] l = new System.Web.UI.WebControls.Label[dt.Rows.Count * 2];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            div[loop] = new HtmlGenericControl("div");
                            l[loop1] = new System.Web.UI.WebControls.Label();
                            l[loop1].CssClass = "lbldate";
                            div[loop].Attributes.Add("class", "divmessageouter");
                            chatdiv.Controls.Add(div[loop]);
                            loop++;

                            div[loop] = new HtmlGenericControl("div");
                            div[loop].Attributes.Add("class", "divtri");
                            div[loop - 1].Controls.Add(div[loop]);
                            div[loop] = new HtmlGenericControl("div");
                            div[loop].Attributes.Add("class", "divmessage");
                            div[loop].InnerHtml = dt.Rows[i].ItemArray[0].ToString() + "<br/>";
                            l[loop1].Text = dt.Rows[i].ItemArray[2].ToString();
                            div[loop].Controls.Add(l[loop1]);
                            div[loop - 1].Controls.Add(div[loop]);
                            loop++;
                            loop1++;
                            
                            div[loop] = new HtmlGenericControl("div");
                            l[loop1] = new System.Web.UI.WebControls.Label();
                            l[loop1].CssClass = "lbldate1";
                            div[loop].Attributes.Add("class", "divresponseouter");
                            chatdiv.Controls.Add(div[loop]);
                            if (dt.Rows[i].ItemArray[1].ToString()== "")
                            {
                                div[loop].Visible = false;
                            }
                            loop++;

                            div[loop] = new HtmlGenericControl("div");
                            div[loop].Attributes.Add("class", "divtri1");
                            div[loop - 1].Controls.Add(div[loop]);
                            div[loop] = new HtmlGenericControl("div");
                            div[loop].Attributes.Add("class", "divresponse");
                            div[loop].InnerHtml = dt.Rows[i].ItemArray[1].ToString()+"<br/>";
                            l[loop1].Text = dt.Rows[i].ItemArray[3].ToString();
                            div[loop].Controls.Add(l[loop1]);
                            div[loop - 1].Controls.Add(div[loop]);
                            loop++;
                            loop1++;
                        }
                    }
                }
                else
                {
                    Response.Redirect("UserLogReg.aspx?val=login");
                }
            }
            else if (Request.QueryString["utype"].ToString() == "seller")
            {
                if (Session["seller_id"] != null)
                {
                    id = Session["seller_id"].ToString();
                    c.cmd.CommandText = "select message,response,date,date1 from help where id='" + Session["seller_id"].ToString() + "' and utype='seller' order by date";
                    adp.SelectCommand = c.cmd;
                    dt.Clear();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        loop = 0;
                        loop1 = 0;
                        HtmlGenericControl[] div = new HtmlGenericControl[dt.Rows.Count * 4];
                        System.Web.UI.WebControls.Label[] l = new System.Web.UI.WebControls.Label[dt.Rows.Count * 2];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            div[loop] = new HtmlGenericControl("div");
                            l[loop1] = new System.Web.UI.WebControls.Label();
                            l[loop1].CssClass = "lbldate";
                            div[loop].Attributes.Add("class", "divmessageouter");
                            chatdiv.Controls.Add(div[loop]);
                            loop++;

                            div[loop] = new HtmlGenericControl("div");
                            div[loop].Attributes.Add("class", "divtri");
                            div[loop - 1].Controls.Add(div[loop]);
                            div[loop] = new HtmlGenericControl("div");
                            div[loop].Attributes.Add("class", "divmessage");
                            div[loop].InnerHtml = dt.Rows[i].ItemArray[0].ToString() + "<br/>";
                            l[loop1].Text = dt.Rows[i].ItemArray[2].ToString();
                            div[loop].Controls.Add(l[loop1]);
                            div[loop - 1].Controls.Add(div[loop]);
                            loop++;
                            loop1++;

                            div[loop] = new HtmlGenericControl("div");
                            l[loop1] = new System.Web.UI.WebControls.Label();
                            l[loop1].CssClass = "lbldate1";
                            div[loop].Attributes.Add("class", "divresponseouter");
                            chatdiv.Controls.Add(div[loop]);
                            if (dt.Rows[i].ItemArray[1].ToString() == "")
                            {
                                div[loop].Visible = false;
                            }
                            loop++;

                            div[loop] = new HtmlGenericControl("div");
                            div[loop].Attributes.Add("class", "divtri1");
                            div[loop - 1].Controls.Add(div[loop]);
                            div[loop] = new HtmlGenericControl("div");
                            div[loop].Attributes.Add("class", "divresponse");
                            div[loop].InnerHtml = dt.Rows[i].ItemArray[1].ToString() + "<br/>";
                            l[loop1].Text = dt.Rows[i].ItemArray[3].ToString();
                            div[loop].Controls.Add(l[loop1]);
                            div[loop - 1].Controls.Add(div[loop]);
                            loop++;
                            loop1++;
                        }
                    }
                }
                else
                {
                    Session["slink"] = "Help.aspx?utype=seller";
                    Response.Redirect("SeLoLogReg.aspx?val=login");
                }
            }
            else if (Request.QueryString["utype"].ToString() == "logistic")
            {
                if (Session["log_id"] != null)
                {
                    id = Session["log_id"].ToString();
                    c.cmd.CommandText = "select message,response,date,date1 from help where id='" + Session["log_id"].ToString() + "' and utype='logistic' order by date";
                    adp.SelectCommand = c.cmd;
                    dt.Clear();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        loop = 0;
                        loop1 = 0;
                        HtmlGenericControl[] div = new HtmlGenericControl[dt.Rows.Count * 4];
                        System.Web.UI.WebControls.Label[] l = new System.Web.UI.WebControls.Label[dt.Rows.Count * 2];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            div[loop] = new HtmlGenericControl("div");
                            l[loop1] = new System.Web.UI.WebControls.Label();
                            l[loop1].CssClass = "lbldate";
                            div[loop].Attributes.Add("class", "divmessageouter");
                            chatdiv.Controls.Add(div[loop]);
                            loop++;

                            div[loop] = new HtmlGenericControl("div");
                            div[loop].Attributes.Add("class", "divtri");
                            div[loop - 1].Controls.Add(div[loop]);
                            div[loop] = new HtmlGenericControl("div");
                            div[loop].Attributes.Add("class", "divmessage");
                            div[loop].InnerHtml = dt.Rows[i].ItemArray[0].ToString() + "<br/>";
                            l[loop1].Text = dt.Rows[i].ItemArray[2].ToString();
                            div[loop].Controls.Add(l[loop1]);
                            div[loop - 1].Controls.Add(div[loop]);
                            loop++;
                            loop1++;

                            div[loop] = new HtmlGenericControl("div");
                            l[loop1] = new System.Web.UI.WebControls.Label();
                            l[loop1].CssClass = "lbldate1";
                            div[loop].Attributes.Add("class", "divresponseouter");
                            chatdiv.Controls.Add(div[loop]);
                            if (dt.Rows[i].ItemArray[1].ToString() == "")
                            {
                                div[loop].Visible = false;
                            }
                            loop++;

                            div[loop] = new HtmlGenericControl("div");
                            div[loop].Attributes.Add("class", "divtri1");
                            div[loop - 1].Controls.Add(div[loop]);
                            div[loop] = new HtmlGenericControl("div");
                            div[loop].Attributes.Add("class", "divresponse");
                            div[loop].InnerHtml = dt.Rows[i].ItemArray[1].ToString() + "<br/>";
                            l[loop1].Text = dt.Rows[i].ItemArray[3].ToString();
                            div[loop].Controls.Add(l[loop1]);
                            div[loop - 1].Controls.Add(div[loop]);
                            loop++;
                            loop1++;
                        }
                    }
                }
                else
                {
                    Session["llink"] = "Help.aspx?utype=logistic";
                    Response.Redirect("LogisticLogReg.aspx?val=login");
                }
            }
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }
    protected void btnsend_Click(object sender, EventArgs e)
    {
        if (txtText.Text != "")
        {
            c.cmd.CommandText = "insert into help(id,utype,message,date) values('"+id+"','"+Request.QueryString["utype"].ToString()+"',@message,@date)";
            c.cmd.Parameters.Clear();
            c.cmd.Parameters.Add("@message", SqlDbType.NVarChar).Value = txtText.Text;
            c.cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
            c.cmd.ExecuteNonQuery();
            Response.Redirect("Help.aspx?utype="+Request.QueryString["utype"].ToString()+ "");
        }
    }
}

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
using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms;
using System.Data.SqlClient;
using global;

public partial class Report : System.Web.UI.Page
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
    DataTable dt10 = new DataTable();
    DataTable dt11 = new DataTable();
    DataTable dt12 = new DataTable();
    DataTable dt13= new DataTable();
    DataTable dt14 = new DataTable();
    DataTable dt15 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin_id"] == null)
        {
            Response.Redirect("AdminDash.aspx");
        }
            if (!Page.IsPostBack)
            {
                divcommission.Visible = false;
                divsales.Visible = false;
                divseller.Visible = false;
                divlogistic.Visible = false;
            }
    }
    protected void ddmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            c.cmd.CommandText = "select * from shoppie where year(date)=" + Convert.ToInt32(ddyear.SelectedItem.Text) + " and month(date)=" + monthtonumber(ddmonth.SelectedItem.Text) + "";
            adp.SelectCommand = c.cmd;
            dt.Clear();
            adp.Fill(dt);
            CrystalReportViewer1.RefreshReport();
            ReportDocument rept = new ReportDocument();
            rept.Load(Server.MapPath("report1.rpt"));
            rept.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = rept;
            CrystalReportViewer1.RefreshReport();
        }
        catch (FormatException)
        { }
    }
    protected void ddyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            c.cmd.CommandText = "select * from shoppie where year(date)=" + Convert.ToInt32(ddyear.SelectedItem.Text) + "";
            adp.SelectCommand = c.cmd;
            dt3.Clear();
            adp.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                ReportDocument rept = new ReportDocument();
                rept.Load(Server.MapPath("report1.rpt"));
                rept.SetDataSource(dt3);
                CrystalReportViewer1.ReportSource = rept;
                CrystalReportViewer1.RefreshReport();
            }
            c.cmd.CommandText = "select distinct DATENAME(month,date) from shoppie where year(date)=" + Convert.ToInt32(ddyear.SelectedItem.Text) + "";
            c.cmd.Parameters.Clear();
            adp.SelectCommand = c.cmd;
            dt2.Clear();
            adp.Fill(dt2);
            ddmonth.Items.Clear();
            if (dt2.Rows.Count > 0)
            {
                ddmonth.Items.Add("Select Month");
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    ddmonth.Items.Add(dt2.Rows[i].ItemArray[0].ToString());
                }
            }
        }
        catch (FormatException)
        { }
    }
    int monthtonumber(string s)
    {
        string s1 = s.ToLower();
        switch (s1)
        {
            case "january": return 1;
            case "february": return 2;
            case "march": return 3;
            case "april": return 4;
            case "may": return 5;
            case "june": return 6;
            case "july": return 7;
            case "august": return 8;
            case "september": return 9;
            case "october": return 10;
            case "november": return 11;
            case "december": return 12;
        }
        return 0;
    }
    protected void btncommission_Click(object sender, EventArgs e)
    {
        divcommission.Visible = true;
        divsales.Visible = false;
        divseller.Visible = false;
        divlogistic.Visible = false;
        c.cmd.CommandText = "select distinct year(date) from shoppie";
        adp.SelectCommand = c.cmd;
        dt1.Clear();
        adp.Fill(dt1);
        ddyear.Items.Clear();
        ddyear.Items.Add("Select Year");
        if (dt1.Rows.Count > 0)
        {
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                ddyear.Items.Add(dt1.Rows[i].ItemArray[0].ToString());
            }
        }
    }
    protected void btnsales_Click(object sender, EventArgs e)
    {
        divcommission.Visible = false;
        divsales.Visible = true;
        divseller.Visible = false;
        divlogistic.Visible = false;

        c.cmd.CommandText = "select distinct year(date) from orders";
        adp.SelectCommand = c.cmd;
        dt4.Clear();
        adp.Fill(dt4);
        ddyearsales.Items.Clear();
        ddyearsales.Items.Add("Select Year");
        if (dt4.Rows.Count > 0)
        {
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                ddyearsales.Items.Add(dt4.Rows[i].ItemArray[0].ToString());
            }
        }
    }
    protected void btnseller_Click(object sender, EventArgs e)
    {
        divcommission.Visible = false;
        divsales.Visible = false;
        divseller.Visible = true;
        divlogistic.Visible = false;

        c.cmd.CommandText = "select distinct year(date) from seller_pay";
        adp.SelectCommand = c.cmd;
        dt8.Clear();
        adp.Fill(dt8);
        ddyearseller.Items.Clear();
        ddyearseller.Items.Add("Select Year");
        if (dt8.Rows.Count > 0)
        {
            for (int i = 0; i < dt8.Rows.Count; i++)
            {
                ddyearseller.Items.Add(dt8.Rows[i].ItemArray[0].ToString());
            }
        }
    }
    protected void btnlogistic_Click(object sender, EventArgs e)
    {
        divcommission.Visible = false;
        divsales.Visible = false;
        divseller.Visible = false;
        divlogistic.Visible = true;

        c.cmd.CommandText = "select distinct year(date) from logistic_pay";
        adp.SelectCommand = c.cmd;
        dt12.Clear();
        adp.Fill(dt12);
        ddyearlogistic.Items.Clear();
        ddyearlogistic.Items.Add("Select Year");
        if (dt12.Rows.Count > 0)
        {
            for (int i = 0; i < dt12.Rows.Count; i++)
            {
                ddyearlogistic.Items.Add(dt12.Rows[i].ItemArray[0].ToString());
            }
        }
    }
    protected void ddmonthsales_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            c.cmd.CommandText = "select * from orders where year(date)=" + Convert.ToInt32(ddyearsales.SelectedItem.Text) + " and month(date)=" + monthtonumber(ddmonthsales.SelectedItem.Text) + "";
            adp.SelectCommand = c.cmd;
            dt7.Clear();
            adp.Fill(dt7);
            ReportDocument rept = new ReportDocument();
            rept.Load(Server.MapPath("sales.rpt"));
            rept.SetDataSource(dt7);
            CrystalReportsales.ReportSource = rept;
            CrystalReportsales.RefreshReport();
        }
        catch (FormatException)
        { }
    }
    protected void ddyearsales_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            c.cmd.CommandText = "select * from orders where year(date)=" + Convert.ToInt32(ddyearsales.SelectedItem.Text) + "";
            adp.SelectCommand = c.cmd;
            dt5.Clear();
            adp.Fill(dt5);
            if (dt5.Rows.Count > 0)
            {
                ReportDocument rept = new ReportDocument();
                rept.Load(Server.MapPath("sales.rpt"));
                rept.SetDataSource(dt5);
                CrystalReportsales.ReportSource = rept;
                CrystalReportsales.RefreshReport();
            }
            c.cmd.CommandText = "select distinct DATENAME(month,date) from orders where year(date)=" + Convert.ToInt32(ddyearsales.SelectedItem.Text) + "";
            c.cmd.Parameters.Clear();
            adp.SelectCommand = c.cmd;
            dt6.Clear();
            adp.Fill(dt6);
            ddmonthsales.Items.Clear();
            if (dt6.Rows.Count > 0)
            {
                ddmonthsales.Items.Add("Select Month");
                for (int i = 0; i < dt6.Rows.Count; i++)
                {
                    ddmonthsales.Items.Add(dt6.Rows[i].ItemArray[0].ToString());
                }
            }
        }
        catch (FormatException)
        { }
    }
    protected void ddmonthseller_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            c.cmd.CommandText = "select distinct * from seller,seller_pay where seller.seller_id=seller_pay.seller_id and year(seller_pay.date)=" + Convert.ToInt32(ddyearseller.SelectedItem.Text) + " and month(seller_pay.date)=" + monthtonumber(ddmonthseller.SelectedItem.Text) + "";
            adp.SelectCommand = c.cmd;
            dt11.Clear();
            adp.Fill(dt11);
            ReportDocument rept = new ReportDocument();
            rept.Load(Server.MapPath("seller.rpt"));
            rept.SetDataSource(dt11);
            CrystalReportseller.ReportSource = rept;
            CrystalReportseller.SelectionFormula = "{seller_pay.date} >=dateserial(" + Convert.ToInt32(ddyearseller.SelectedItem.Text) + "," + monthtonumber(ddmonthseller.SelectedItem.Text) + " ,1)and {seller_pay.date}<dateserial(" + Convert.ToInt32(ddyearseller.SelectedItem.Text) + "," + monthtonumber(ddmonthseller.SelectedItem.Text) + "+1 ,1)";
            CrystalReportseller.RefreshReport();

        }
        catch (FormatException)
        { }
    }
    protected void ddyearseller_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            c.cmd.CommandText = "select  * from seller_pay,seller where seller.seller_id=seller_pay.seller_id and year(seller_pay.date)=" + Convert.ToInt32(ddyearseller.SelectedItem.Text) + "";
            adp.SelectCommand = c.cmd;
            dt9.Clear();
            adp.Fill(dt9);
            CrystalReportseller.ReportSource = null;
            if (dt9.Rows.Count > 0)
            {
                ReportDocument rept = new ReportDocument();
                rept.Load(Server.MapPath("seller.rpt"));
                rept.SetDataSource(dt9);
                CrystalReportseller.ReportSource = rept;
                CrystalReportseller.RefreshReport();
            }
            c.cmd.CommandText = "select distinct DATENAME(month,date) from seller_pay where year(date)=" + Convert.ToInt32(ddyearseller.SelectedItem.Text) + "";
            c.cmd.Parameters.Clear();
            adp.SelectCommand = c.cmd;
            dt10.Clear();
            adp.Fill(dt10);
            ddmonthseller.Items.Clear();
            if (dt10.Rows.Count > 0)
            {

                ddmonthseller.Items.Add("Select Month");
                for (int i = 0; i < dt10.Rows.Count; i++)
                {
                    ddmonthseller.Items.Add(dt10.Rows[i].ItemArray[0].ToString());
                }
            }
        }
        catch (FormatException)
        { }
    }
    protected void ddmonthlogistic_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            c.cmd.CommandText = "select distinct * from logistic,logistic_pay where logistic.log_id=logistic_pay.log_id and year(logistic_pay.date)=" + Convert.ToInt32(ddyearlogistic.SelectedItem.Text) + " and month(logistic_pay.date)=" + monthtonumber(ddmonthlogistic.SelectedItem.Text) + "";
            adp.SelectCommand = c.cmd;
            dt15.Clear();
            adp.Fill(dt15);
            ReportDocument rept = new ReportDocument();
            rept.Load(Server.MapPath("logistic.rpt"));
            rept.SetDataSource(dt15);
            CrystalReportlogistic.ReportSource = rept;
            CrystalReportlogistic.RefreshReport();
        }
        catch (FormatException)
        { }
    }
    protected void ddyearlogistic_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            c.cmd.CommandText = "select * from logistic_pay,logistic where logistic.log_id=logistic_pay.log_id and year(logistic_pay.date)=" + Convert.ToInt32(ddyearlogistic.SelectedItem.Text) + "";
            adp.SelectCommand = c.cmd;
            dt13.Clear();
            adp.Fill(dt13);
            if (dt13.Rows.Count > 0)
            {
                ReportDocument rept = new ReportDocument();
                rept.Load(Server.MapPath("logistic.rpt"));
                rept.SetDataSource(dt13);
                CrystalReportlogistic.ReportSource = rept;
                CrystalReportlogistic.RefreshReport();
            }
            c.cmd.CommandText = "select distinct DATENAME(month,date) from logistic_pay where year(date)=" + Convert.ToInt32(ddyearlogistic.SelectedItem.Text) + "";
            c.cmd.Parameters.Clear();
            adp.SelectCommand = c.cmd;
            dt14.Clear();
            adp.Fill(dt14);
            ddmonthlogistic.Items.Clear();
            if (dt14.Rows.Count > 0)
            {

                ddmonthlogistic.Items.Add("Select Month");
                for (int i = 0; i < dt14.Rows.Count; i++)
                {
                    ddmonthlogistic.Items.Add(dt14.Rows[i].ItemArray[0].ToString());
                }
            }
        }
        catch (FormatException)
        { }
    }
}

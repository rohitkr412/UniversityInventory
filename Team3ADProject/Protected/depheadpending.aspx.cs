﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team3ADProject.Code;
using System.Web.UI.DataVisualization.Charting;
using System.Web.Security;

//Sruthi
namespace Team3ADProject.Protected
{
    public partial class depheadpendingm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string dept = getmethoddepartment();//to get the department
                var q = BusinessLogic.ViewPendingRequests(dept); // to get the pending the requests for that department
                GridView1.DataSource = q.ToList();
                GridView1.DataBind();
                int b3 = BusinessLogic.getbudgetbydept(dept); //to get the budget for the department for that particular month
                Label5.Text = String.Format($"{b3:c2}");
                Session["budgetallocated"] = b3;
                int b4 = BusinessLogic.getspentbudgetbydept(dept); // to get the budget spent for the department for that particular month
                Label6.Text = String.Format($"{b4:c2}");
                Session["budgetspent"] = b4;
                Label3.Text = (Convert.ToDouble(b4) / Convert.ToDouble(b3) * 100).ToString() + "%";
                generatechartdata(b3, b4); // to generate the pie chart
            }
            catch (Exception x)
            {
                Response.Write(x.Message);
            }

        }

        public string getmethoddepartment()
        {
            int employeeid = Convert.ToInt32(Session["Employee"]);
            string user = BusinessLogic.GetUserID(employeeid);
            string dept = BusinessLogic.getdepartment(user);//to get the department
            return dept;
        }


        //To redirect to pendingdetails page
        public void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            HiddenField hd = (HiddenField)b.FindControl("HiddenField1");
            string s = hd.Value;
            Response.Redirect("~/protected/pendingdetails?Id=" + s.TrimEnd());

        }

		// generating the chart data based on budget spent and allocated
		public void generatechartdata(int budget, int spent)
        {
            if(spent == 0)
            {
                Series series = Chart1.Series["Series1"];
                series.Points.AddXY("Remaining",budget);
            }
            else if(spent > budget)
            {
                Series series = Chart1.Series["Series1"];
                series.Points.AddXY("Consumed", spent);
            }
            else
            {
                Series series = Chart1.Series["Series1"];
                series.Points.AddXY("Consumed", spent);
                series.Points.AddXY("Remaining", budget - spent);
            }
           
        }

    }
}
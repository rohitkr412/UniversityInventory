﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team3ADProject.Code;
using Team3ADProject.Model;

namespace Team3ADProject.Protected
{
    public partial class PendingPODetails : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Session["po"] = id;
            if (!IsPostBack)
            {
                GenerateGrid();
            }
        }

        protected void GenerateGrid()
        {
            int id = (int)Session["po"];
            GridView1.DataSource = BusinessLogic.getpurchaseorderdetail(id);
            GridView1.DataBind();
            purchase_order p = BusinessLogic.getpurchaseorder(id);
            supplier s = BusinessLogic.getSupplierNameforPurchaseorder(id);
            employee d = BusinessLogic.GetEmployee(p.employee_id);
            Label5.Text = id.ToString();
            Label4.Text = s.supplier_name;
            Label7.Text = s.supplier_id;
            Label9.Text = p.purchase_order_date.ToString("yyyy/MM/dd");
            Label11.Text = p.purchase_order_status;
            Label13.Text = d.employee_name;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int r = GridView1.Rows.Count;
            for (int i = 0; i < r; i++)
            {
                Button b = (Button)GridView1.Rows[i].FindControl("AcceptItem");
                TextBox t1 = (TextBox)GridView1.Rows[i].FindControl("TextBox1");
                TextBox t2 = (TextBox)GridView1.Rows[i].FindControl("TextBox2");
                HiddenField hd2 = (HiddenField)GridView1.Rows[i].FindControl("HiddenField2");
                string s = hd2.Value;
                if(s == "Accepted")
                {
                    b.Enabled = false;
                    b.CssClass = "btn btn-success disabled";
                    b.Text = "Accepted";
                    t1.ReadOnly = true;
                    t1.BackColor = Color.Silver;
                    t2.ReadOnly = true;
                    t2.BackColor = Color.Silver;
                }
                else
                {
                    b.Enabled = true;
                    b.CssClass = "btn btn-success";
                    b.Text = "Accept Item";
                    t1.ReadOnly = false;
                    t1.BackColor = Color.White;
                    t2.ReadOnly = false;
                    t2.BackColor = Color.White;
                }
            }
        }

        protected void AcceptItem_Click(object sender, EventArgs e)
        {
            int po_id = (int)Session["po"];
            Button b = (Button)sender;
            TextBox t1 = (TextBox)b.FindControl("TextBox1");
            TextBox t2 = (TextBox)b.FindControl("TextBox2");
            HiddenField hd1 = (HiddenField)b.FindControl("HiddenField1");
            HiddenField hd2 = (HiddenField)b.FindControl("HiddenField3");
            int order_quantity = Convert.ToInt32(hd2.Value);
            string item = hd1.Value;
            int accept_quantity = Convert.ToInt32(t1.Text);
            string remark = t2.Text;
            if (accept_quantity <= 0) 
            {
                Response.Write("Please enter quantity");
            }
            else if (accept_quantity > order_quantity)
            {
                Response.Write("Received quantity cannot be greater than ordered quantity");
            }
            else
            {
                BusinessLogic.acceptitemfromsupplier(po_id, item, accept_quantity, remark);
                GenerateGrid();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Protected/ViewPOHistory.aspx");
        }
    }
}
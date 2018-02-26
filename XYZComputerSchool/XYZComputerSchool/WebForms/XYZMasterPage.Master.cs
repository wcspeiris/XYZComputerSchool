﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class XYZMasterPage : System.Web.UI.MasterPage
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedInUser"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                lblLoggedinUser.Text = Session["loggedInUser"].ToString();

                int userLevel = Convert.ToInt32(Session["userLevel"]);

                if (userLevel == 2)
                {
                    students.Visible = false;
                    lecturers.Visible = false;
                    courses.Visible = false;
                    modules.Visible = false;
                }
            }
            ClassExam resetDataSet = new ClassExam();
            resetDataSet.ResetDataSet();
        }

    }
}
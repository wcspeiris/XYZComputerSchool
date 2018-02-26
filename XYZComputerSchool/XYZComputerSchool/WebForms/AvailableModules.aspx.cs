using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class AvailableModules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedInUser"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;
                lblloggedInStudent.Text = Session["loggedInUser"].ToString();
                ClassModules availableModules = new ClassModules();
                availableModules.LoadStudentAvailableModules(GridViewAvailbleModules, lblloggedInStudent);
            }
            
        }

        protected void GridViewAvailbleModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblModuleName.Text = GridViewAvailbleModules.SelectedRow.Cells[2].Text;

            Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;
            ClassModules countAttempts = new ClassModules();
            countAttempts.CountModuleAttempts(lblAttemptsTaken, lblloggedInStudent, GridViewAvailbleModules);

            if (lblAttemptsTaken.Text == "3")
            {
                btnBeginExam.Enabled = false;
                lblMsg01.Text = "Maximum attempt are reached for the selected module ";
                lblMsg02.Text = "";
            }
            else
            {
                btnBeginExam.Enabled = true;
                lblMsg01.Text = "You are about to begin the exam for the module ";
                lblMsg02.Text = ". Once started the process cannot be stopped until the completing the Exam successfully. Do you want to continue?";
            }
        }

        protected void btnBeginExam_Click(object sender, EventArgs e)
        {
            if (GridViewAvailbleModules.SelectedIndex >= 0)
            {
                Session["selectedModule"] = GridViewAvailbleModules.SelectedRow.Cells[1].Text;
                Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;

                Session["btn01Color"] = "btn btn-default btn-circle";
                Session["btn02Color"] = "btn btn-default btn-circle";
                Session["btn03Color"] = "btn btn-default btn-circle";
                Session["btn04Color"] = "btn btn-default btn-circle";
                Session["btn05Color"] = "btn btn-default btn-circle";
                Session["btn06Color"] = "btn btn-default btn-circle";
                Session["btn07Color"] = "btn btn-default btn-circle";
                Session["btn08Color"] = "btn btn-default btn-circle";
                Session["btn09Color"] = "btn btn-default btn-circle";
                Session["btn10Color"] = "btn btn-default btn-circle";
                Session["btn11Color"] = "btn btn-default btn-circle";
                Session["btn12Color"] = "btn btn-default btn-circle";
                Session["btn13Color"] = "btn btn-default btn-circle";
                Session["btn14Color"] = "btn btn-default btn-circle";
                Session["btn15Color"] = "btn btn-default btn-circle";

                Session["rbListQuestion01"] = -1;
                Session["rbListQuestion02"] = -1;
                Session["rbListQuestion03"] = -1;
                Session["rbListQuestion04"] = -1;
                Session["rbListQuestion05"] = -1;
                Session["rbListQuestion06"] = -1;
                Session["rbListQuestion07"] = -1;
                Session["rbListQuestion08"] = -1;
                Session["rbListQuestion09"] = -1;
                Session["rbListQuestion10"] = -1;
                Session["rbListQuestion11"] = -1;
                Session["rbListQuestion12"] = -1;
                Session["rbListQuestion13"] = -1;
                Session["rbListQuestion14"] = -1;
                Session["rbListQuestion15"] = -1;

                Session["questionAttempt"] = Convert.ToInt32(lblAttemptsTaken.Text) + 1;
                
                ClassExam selectAndRecord = new ClassExam();
                selectAndRecord.SelectRandomExamQuestions(Session["selectedModule"].ToString(), lblloggedInStudent);
                selectAndRecord.RecordAttempt(lblloggedInStudent.Text, Session["selectedModule"].ToString(), (int)Session["questionAttempt"]);
                Response.Redirect("QuestionPage01.aspx");
            }
        }

        protected void GridViewAvailbleModules_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;
            lblloggedInStudent.Text = Session["loggedInUser"].ToString();
            ClassModules availableModules = new ClassModules();
            availableModules.LoadStudentAvailableModules(GridViewAvailbleModules, lblloggedInStudent);
            GridViewAvailbleModules.PageIndex = e.NewPageIndex;
            GridViewAvailbleModules.DataBind();
        }
    }
}
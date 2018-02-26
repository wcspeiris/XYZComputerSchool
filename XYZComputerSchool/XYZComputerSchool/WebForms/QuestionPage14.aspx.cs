using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class QuestionPage14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;
                lblloggedInStudent.Text = Session["loggedInUser"].ToString();
                Session["btn14Color"] = "btn btn-primary btn-circle";
                int pageIndex = 13;
                ClassExam loadData = new ClassExam();
                loadData.LoadExamQuestions(lblQuestion14, rbListQuestion14, pageIndex, hf14, hfCorrectAns14);
                rbListQuestion14.SelectedIndex = Convert.ToInt32(Session["rbListQuestion14"]);

                string studentId = Session["loggedInUser"].ToString();
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion14.SelectedIndex + 1;
                string selectedModuleId = Session["selectedModule"].ToString();
                int correctAnswer = Convert.ToInt32(hfCorrectAns14.Value);
                loadData.ReduceExamMarks(studentId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }
        }

        protected void btnGotoPrevious_Click(object sender, EventArgs e)
        {
            if (rbListQuestion14.SelectedIndex == -1)
            {
                Session["btn14Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn14Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf14.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion14.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns14.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage13.aspx");
        }

        protected void btnMarkForReview_Click(object sender, EventArgs e)
        {
            Session["rbListQuestion14"] = -1;
            Session["btn14Color"] = "btn btn-warning btn-circle";
            Response.Redirect("QuestionPage15.aspx");
        }

        protected void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            if (rbListQuestion14.SelectedIndex == -1)
            {
                Session["btn14Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn14Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf14.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion14.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns14.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage15.aspx");
        }

        protected void rbListQuestion14_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["rbListQuestion14"] = rbListQuestion14.SelectedIndex;
        }
    }
}
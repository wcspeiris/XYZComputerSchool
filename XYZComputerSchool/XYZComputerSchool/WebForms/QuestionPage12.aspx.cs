using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class QuestionPage12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;
                lblloggedInStudent.Text = Session["loggedInUser"].ToString();
                Session["btn12Color"] = "btn btn-primary btn-circle";
                int pageIndex = 11;
                ClassExam loadData = new ClassExam();
                loadData.LoadExamQuestions(lblQuestion12, rbListQuestion12, pageIndex, hf12, hfCorrectAns12);
                rbListQuestion12.SelectedIndex = Convert.ToInt32(Session["rbListQuestion12"]);

                string studentId = Session["loggedInUser"].ToString();
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion12.SelectedIndex + 1;
                string selectedModuleId = Session["selectedModule"].ToString();
                int correctAnswer = Convert.ToInt32(hfCorrectAns12.Value);
                loadData.ReduceExamMarks(studentId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }
        }

        protected void btnGotoPrevious_Click(object sender, EventArgs e)
        {
            if (rbListQuestion12.SelectedIndex == -1)
            {
                Session["btn12Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn12Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf12.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion12.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns12.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage11.aspx");
        }

        protected void btnMarkForReview_Click(object sender, EventArgs e)
        {
            Session["rbListQuestion12"] = -1;
            Session["btn12Color"] = "btn btn-warning btn-circle";
            Response.Redirect("QuestionPage13.aspx");
        }

        protected void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            if (rbListQuestion12.SelectedIndex == -1)
            {
                Session["btn12Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn12Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf12.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion12.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns12.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage13.aspx");
        }

        protected void rbListQuestion12_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["rbListQuestion12"] = rbListQuestion12.SelectedIndex;
        }
    }
}
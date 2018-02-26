using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class QuestionPage15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;
                lblloggedInStudent.Text = Session["loggedInUser"].ToString();
                Session["btn15Color"] = "btn btn-primary btn-circle";
                int pageIndex = 14;
                ClassExam loadData = new ClassExam();
                loadData.LoadExamQuestions(lblQuestion15, rbListQuestion15, pageIndex, hf15, hfCorrectAns15);
                rbListQuestion15.SelectedIndex = Convert.ToInt32(Session["rbListQuestion15"]);

                string studentId = Session["loggedInUser"].ToString();
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion15.SelectedIndex + 1;
                string selectedModuleId = Session["selectedModule"].ToString();
                int correctAnswer = Convert.ToInt32(hfCorrectAns15.Value);
                loadData.ReduceExamMarks(studentId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }
        }

        protected void btnGotoPrevious_Click(object sender, EventArgs e)
        {
            if (rbListQuestion15.SelectedIndex == -1)
            {
                Session["btn15Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn15Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf15.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion15.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns15.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage14.aspx");
        }

        protected void btnMarkForReview_Click(object sender, EventArgs e)
        {
            Session["rbListQuestion15"] = -1;
            Session["btn15Color"] = "btn btn-warning btn-circle";
            Response.Redirect("ExamComplete.aspx");
        }

        protected void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            if (rbListQuestion15.SelectedIndex == -1)
            {
                Session["btn15Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn15Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf15.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion15.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns15.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("ExamComplete.aspx");
        }

        protected void rbListQuestion15_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["rbListQuestion15"] = rbListQuestion15.SelectedIndex;
        }
    }
}
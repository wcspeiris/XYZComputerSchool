using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class QuestionPage06 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;
                lblloggedInStudent.Text = Session["loggedInUser"].ToString();
                Session["btn06Color"] = "btn btn-primary btn-circle";
                int pageIndex = 5;
                ClassExam loadData = new ClassExam();
                loadData.LoadExamQuestions(lblQuestion06, rbListQuestion06, pageIndex, hf06, hfCorrectAns06);
                rbListQuestion06.SelectedIndex = Convert.ToInt32(Session["rbListQuestion06"]);

                string studentId = Session["loggedInUser"].ToString();
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion06.SelectedIndex + 1;
                string selectedModuleId = Session["selectedModule"].ToString();
                int correctAnswer = Convert.ToInt32(hfCorrectAns06.Value);
                loadData.ReduceExamMarks(studentId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }
        }

        protected void btnGotoPrevious_Click(object sender, EventArgs e)
        {
            if (rbListQuestion06.SelectedIndex == -1)
            {
                Session["btn06Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn06Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf06.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion06.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns06.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage05.aspx");
        }

        protected void btnMarkForReview_Click(object sender, EventArgs e)
        {
            Session["rbListQuestion06"] = -1;
            Session["btn06Color"] = "btn btn-warning btn-circle";
            Response.Redirect("QuestionPage07.aspx");
        }

        protected void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            if (rbListQuestion06.SelectedIndex == -1)
            {
                Session["btn06Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn06Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf06.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion06.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns06.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage07.aspx");
        }

        protected void rbListQuestion06_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["rbListQuestion06"] = rbListQuestion06.SelectedIndex;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class QuestionPage02 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;
                lblloggedInStudent.Text = Session["loggedInUser"].ToString();
                Session["btn02Color"] = "btn btn-primary btn-circle";
                int pageIndex = 1;
                ClassExam loadData = new ClassExam();
                loadData.LoadExamQuestions(lblQuestion02, rbListQuestion02, pageIndex, hf02, hfCorrectAns02);
                rbListQuestion02.SelectedIndex = Convert.ToInt32(Session["rbListQuestion02"]);

                string studentId = Session["loggedInUser"].ToString();
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion02.SelectedIndex + 1;
                string selectedModuleId = Session["selectedModule"].ToString();
                int correctAnswer = Convert.ToInt32(hfCorrectAns02.Value);
                loadData.ReduceExamMarks(studentId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }          
        }

        protected void btnGotoPrevious_Click(object sender, EventArgs e)
        {
            if (rbListQuestion02.SelectedIndex == -1)
            {
                Session["btn02Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn02Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf02.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion02.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns02.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage01.aspx");
        }

        protected void btnMarkForReview_Click(object sender, EventArgs e)
        {
            Session["rbListQuestion02"] = -1;
            Session["btn02Color"] = "btn btn-warning btn-circle";
            Response.Redirect("QuestionPage03.aspx");
        }

        protected void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            if (rbListQuestion02.SelectedIndex == -1)
            {
                Session["btn02Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn02Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf02.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion02.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns02.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage03.aspx");
        }

        protected void rbListQuestion02_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["rbListQuestion02"] = rbListQuestion02.SelectedIndex;
        }
    }
}
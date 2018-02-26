using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class QuestionPage05 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;
                lblloggedInStudent.Text = Session["loggedInUser"].ToString();
                Session["btn05Color"] = "btn btn-primary btn-circle";
                int pageIndex = 4;
                ClassExam loadData = new ClassExam();
                loadData.LoadExamQuestions(lblQuestion05, rbListQuestion05, pageIndex, hf05, hfCorrectAns05);
                rbListQuestion05.SelectedIndex = Convert.ToInt32(Session["rbListQuestion05"]);

                string studentId = Session["loggedInUser"].ToString();
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion05.SelectedIndex + 1;
                string selectedModuleId = Session["selectedModule"].ToString();
                int correctAnswer = Convert.ToInt32(hfCorrectAns05.Value);
                loadData.ReduceExamMarks(studentId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }
        }

        protected void btnGotoPrevious_Click(object sender, EventArgs e)
        {
            if (rbListQuestion05.SelectedIndex == -1)
            {
                Session["btn05Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn05Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf05.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion05.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns05.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage04.aspx");
        }

        protected void btnMarkForReview_Click(object sender, EventArgs e)
        {
            Session["rbListQuestion05"] = -1;
            Session["btn05Color"] = "btn btn-warning btn-circle";
            Response.Redirect("QuestionPage06.aspx");
        }

        protected void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            if (rbListQuestion05.SelectedIndex == -1)
            {
                Session["btn05Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn05Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf05.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion05.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns05.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage06.aspx");
        }

        protected void rbListQuestion05_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["rbListQuestion05"] = rbListQuestion05.SelectedIndex;
        }
    }
}
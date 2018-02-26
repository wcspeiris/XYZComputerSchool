using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class QuestionPage04 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;
                lblloggedInStudent.Text = Session["loggedInUser"].ToString();
                Session["btn04Color"] = "btn btn-primary btn-circle";
                int pageIndex = 3;
                ClassExam loadData = new ClassExam();
                loadData.LoadExamQuestions(lblQuestion04, rbListQuestion04, pageIndex, hf04, hfCorrectAns04);
                rbListQuestion04.SelectedIndex = Convert.ToInt32(Session["rbListQuestion04"]);

                string studentId = Session["loggedInUser"].ToString();
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion04.SelectedIndex + 1;
                string selectedModuleId = Session["selectedModule"].ToString();
                int correctAnswer = Convert.ToInt32(hfCorrectAns04.Value);
                loadData.ReduceExamMarks(studentId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }
        }

        protected void btnGotoPrevious_Click(object sender, EventArgs e)
        {
            if (rbListQuestion04.SelectedIndex == -1)
            {
                Session["btn04Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn04Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf04.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion04.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns04.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage03.aspx");
        }

        protected void btnMarkForReview_Click(object sender, EventArgs e)
        {
            Session["rbListQuestion04"] = -1;
            Session["btn04Color"] = "btn btn-warning btn-circle";
            Response.Redirect("QuestionPage05.aspx");
        }

        protected void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            if (rbListQuestion04.SelectedIndex == -1)
            {
                Session["btn04Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn04Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf04.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion04.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns04.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage05.aspx");
        }

        protected void rbListQuestion04_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["rbListQuestion04"] = rbListQuestion04.SelectedIndex;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class QuestionPage07 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;
                lblloggedInStudent.Text = Session["loggedInUser"].ToString();
                Session["btn07Color"] = "btn btn-primary btn-circle";
                int pageIndex = 6;
                ClassExam loadData = new ClassExam();
                loadData.LoadExamQuestions(lblQuestion07, rbListQuestion07, pageIndex, hf07, hfCorrectAns07);
                rbListQuestion07.SelectedIndex = Convert.ToInt32(Session["rbListQuestion07"]);

                string studentId = Session["loggedInUser"].ToString();
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion07.SelectedIndex + 1;
                string selectedModuleId = Session["selectedModule"].ToString();
                int correctAnswer = Convert.ToInt32(hfCorrectAns07.Value);
                loadData.ReduceExamMarks(studentId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }
        }

        protected void btnGotoPrevious_Click(object sender, EventArgs e)
        {
            if (rbListQuestion07.SelectedIndex == -1)
            {
                Session["btn07Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn07Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf07.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion07.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns07.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage06.aspx");
        }

        protected void btnMarkForReview_Click(object sender, EventArgs e)
        {
            Session["rbListQuestion07"] = -1;
            Session["btn07Color"] = "btn btn-warning btn-circle";
            Response.Redirect("QuestionPage08.aspx");
        }

        protected void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            if (rbListQuestion07.SelectedIndex == -1)
            {
                Session["btn07Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn07Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf07.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion07.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns07.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage08.aspx");
        }

        protected void rbListQuestion07_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["rbListQuestion07"] = rbListQuestion07.SelectedIndex;
        }
    }
}
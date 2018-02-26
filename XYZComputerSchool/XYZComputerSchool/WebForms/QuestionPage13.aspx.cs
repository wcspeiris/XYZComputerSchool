using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class QuestionPage13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;
                lblloggedInStudent.Text = Session["loggedInUser"].ToString();
                Session["btn13Color"] = "btn btn-primary btn-circle";
                int pageIndex = 12;
                ClassExam loadData = new ClassExam();
                loadData.LoadExamQuestions(lblQuestion13, rbListQuestion13, pageIndex, hf13, hfCorrectAns13);
                rbListQuestion13.SelectedIndex = Convert.ToInt32(Session["rbListQuestion13"]);

                string studentId = Session["loggedInUser"].ToString();
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion13.SelectedIndex + 1;
                string selectedModuleId = Session["selectedModule"].ToString();
                int correctAnswer = Convert.ToInt32(hfCorrectAns13.Value);
                loadData.ReduceExamMarks(studentId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }
        }

        protected void btnGotoPrevious_Click(object sender, EventArgs e)
        {
            if (rbListQuestion13.SelectedIndex == -1)
            {
                Session["btn13Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn13Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf13.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion13.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns13.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage12.aspx");
        }

        protected void btnMarkForReview_Click(object sender, EventArgs e)
        {
            Session["rbListQuestion13"] = -1;
            Session["btn13Color"] = "btn btn-warning btn-circle";
            Response.Redirect("QuestionPage14.aspx");
        }

        protected void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            if (rbListQuestion13.SelectedIndex == -1)
            {
                Session["btn13Color"] = "btn btn-danger btn-circle";
            }
            else
            {
                Session["btn13Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf13.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion13.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns13.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage14.aspx");
        }

        protected void rbListQuestion13_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["rbListQuestion13"] = rbListQuestion13.SelectedIndex;
        }
    }
}
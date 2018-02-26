﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class QuestionPage01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;
                lblloggedInStudent.Text = Session["loggedInUser"].ToString();                
                Session["btn01Color"] = "btn btn-primary btn-circle";
                int pageIndex = 0;
                ClassExam loadData = new ClassExam();
                loadData.LoadExamQuestions(lblQuestion01, rbListQuestion01, pageIndex, hf01, hfCorrectAns01);
                rbListQuestion01.SelectedIndex = Convert.ToInt32(Session["rbListQuestion01"]);

                string studentId = Session["loggedInUser"].ToString();
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion01.SelectedIndex + 1;
                string selectedModuleId = Session["selectedModule"].ToString();
                int correctAnswer = Convert.ToInt32(hfCorrectAns01.Value);
                loadData.ReduceExamMarks(studentId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }          
        }

        protected void btnSaveAndNext_Click(object sender, EventArgs e)
        {            
            if (rbListQuestion01.SelectedIndex == -1)
            {
                Session["btn01Color"] = "btn btn-danger btn-circle";                
            }
            else
            {                
                Session["btn01Color"] = "btn btn-success btn-circle";
                string studentId = Session["loggedInUser"].ToString();
                string questionId = hf01.Value;
                int questionAttempt = Convert.ToInt32(Session["questionAttempt"]);
                int providedAnswer = rbListQuestion01.SelectedIndex + 1;
                int correctAnswer = Convert.ToInt32(hfCorrectAns01.Value);
                string selectedModuleId = Session["selectedModule"].ToString();
                ClassExam record = new ClassExam();
                record.RecordExamAnswers(studentId, questionId, questionAttempt, providedAnswer, selectedModuleId, correctAnswer);
            }

            Response.Redirect("QuestionPage02.aspx");            
        }

        protected void btnMarkForReview_Click(object sender, EventArgs e)
        {
            Session["rbListQuestion01"] = -1;
            Session["btn01Color"] = "btn btn-warning btn-circle";
            Response.Redirect("QuestionPage02.aspx");
        }

        protected void rbListQuestion01_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["rbListQuestion01"] = rbListQuestion01.SelectedIndex;
        }
    }
}
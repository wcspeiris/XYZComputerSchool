using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class ObtainedGrades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedInUser"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;
                lblloggedInStudent.Text = Session["loggedInUser"].ToString();
                ClassStudents loadObtainedGrades = new ClassStudents();
                loadObtainedGrades.LoadStudentGradesToStudentGrade(GridViewStudentObtainedGrades, lblloggedInStudent);
                loadObtainedGrades.CalculateStudentAverageScore(GridViewStudentObtainedGrades, lblAverageScore);
            }
        }

        protected void GridViewStudentObtainedGrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            string studentId = Session["loggedInUser"].ToString();
            string moduleId = GridViewStudentObtainedGrades.SelectedRow.Cells[1].Text;
            string attempt = GridViewStudentObtainedGrades.SelectedRow.Cells[3].Text;
            ClassExam examPaper = new ClassExam();
            examPaper.ViewExamPaper(studentId, moduleId, attempt, panelDataView);
        }

        protected void GridViewStudentObtainedGrades_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Label lblloggedInStudent = this.Master.FindControl("lblLoggedInUser") as Label;
            lblloggedInStudent.Text = Session["loggedInUser"].ToString();
            ClassStudents loadObtainedGrades = new ClassStudents();
            loadObtainedGrades.LoadStudentGradesToStudentGrade(GridViewStudentObtainedGrades, lblloggedInStudent);
            GridViewStudentObtainedGrades.PageIndex = e.NewPageIndex;
            GridViewStudentObtainedGrades.DataBind();
        }
    }
}
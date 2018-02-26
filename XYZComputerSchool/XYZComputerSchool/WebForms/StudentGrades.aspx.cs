using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class StudentGrades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ClassStudents loadDetails = new ClassStudents();
                loadDetails.LoadStudentDetailsToStudentGrade(GridViewStudents);
            }
        }

        protected void GridViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassStudents loadGradeDetails = new ClassStudents();
            loadGradeDetails.LoadStudentGradesToStudentGrade(GridViewStudents, GridViewStudentModules);
        }

        protected void GridViewStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClassStudents loadDetails = new ClassStudents();
            loadDetails.LoadStudentDetailsToStudentGrade(GridViewStudents);
            GridViewStudents.PageIndex = e.NewPageIndex;
            GridViewStudents.DataBind();
        }

        protected void GridViewStudentModules_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClassStudents loadGradeDetails = new ClassStudents();
            loadGradeDetails.LoadStudentGradesToStudentGrade(GridViewStudents, GridViewStudentModules);
            GridViewStudentModules.PageIndex = e.NewPageIndex;
            GridViewStudentModules.DataBind();
        }

        protected void GridViewStudentModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            string studentId = GridViewStudents.SelectedRow.Cells[1].Text;
            string moduleId = GridViewStudentModules.SelectedRow.Cells[1].Text;
            string attempt = GridViewStudentModules.SelectedRow.Cells[3].Text;
            ClassExam viewExamPaper = new ClassExam();
            viewExamPaper.ViewExamPaper(studentId, moduleId, attempt, panelDataView);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;
using XYZComputerSchool.Database;

namespace XYZComputerSchool.WebForms
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {                                
            ClassStudents generateId = new ClassStudents();
            txAddStudentId.Text = generateId.GenerateStudentId();                      
        }

        protected void btnAddStudentSubmit_Click(object sender, EventArgs e)
        {
            Label lblAddedBy = this.Master.FindControl("lblLoggedInUser") as Label;
            ClassStudents addStudent = new ClassStudents();
            addStudent.AddNewStudent(this, lblAddedBy, lblAddAlert);
            string messageString = txAddFirstName.Text + " " + txAddLastName.Text + " has successfully registered. Student ID is " + txAddStudentId.Text;
            ClientScript.RegisterStartupScript(this.GetType(), "Successful", "alert('" + messageString + "'); window.location='Students.aspx';", true);
        }

        protected void GridViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            txUpdateStudentId.Text = GridViewStudents.SelectedRow.Cells[1].Text;
            txUpdateFirstName.Text = GridViewStudents.SelectedRow.Cells[2].Text;
            txUpdateLastName.Text = GridViewStudents.SelectedRow.Cells[3].Text;
            txUpdateAddress.Text = GridViewStudents.SelectedRow.Cells[4].Text;
            txUpdateContactNo.Text = GridViewStudents.SelectedRow.Cells[5].Text;            
            txUpdateDOB.Text = GridViewStudents.SelectedRow.Cells[6].Text;
            ddUpdateEnrollingCourse.Text = GridViewStudents.SelectedRow.Cells[7].Text;
            txUpdateEmail.Text = GridViewStudents.SelectedRow.Cells[8].Text;            
        }

        protected void btnUpdateStudentSubmit_Click(object sender, EventArgs e)
        {
            ClassStudents updateStudent = new ClassStudents();
            updateStudent.UpdateStudent(this);
            string messageString = txUpdateFirstName.Text + " " + txUpdateLastName.Text + " has successfully updated.";
            ClientScript.RegisterStartupScript(this.GetType(), "Successful", "alert('" + messageString + "'); window.location='Students.aspx';", true);
        }

        protected void btnStudentSearch_Click(object sender, EventArgs e)
        {
            ClassStudents searchStudent = new ClassStudents();
            searchStudent.SearchStudent(ddStudentSearch, txStudentSearch, GridViewStudents);
        }

        protected void GridViewStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClassStudents searchStudent = new ClassStudents();
            searchStudent.SearchStudent(ddStudentSearch, txStudentSearch, GridViewStudents);
            GridViewStudents.PageIndex = e.NewPageIndex;
            GridViewStudents.DataBind();
        }
    }
}
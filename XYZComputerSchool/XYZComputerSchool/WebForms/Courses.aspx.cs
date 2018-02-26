using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class Courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            ClassCourses generateCourseId = new ClassCourses();
            txAddCourseId.Text = generateCourseId.GenerateCourseId();
        }

        protected void btnAddCourseSubmit_Click(object sender, EventArgs e)
        {
            Label lblAddedBy = this.Master.FindControl("lblLoggedInUser") as Label;
            ClassCourses addCourse = new ClassCourses();
            addCourse.AddNewCourse(this, lblAddedBy);
            string messageString = txAddCourseName.Text + " has successfully registered. Course ID is " + txAddCourseId.Text;
            ClientScript.RegisterStartupScript(this.GetType(), "Successful", "alert('" + messageString + "'); window.location='Courses.aspx';", true);
        }

        protected void GridViewCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            txUpdateCourseId.Text = GridViewCourses.SelectedRow.Cells[1].Text;
            txUpdateCourseName.Text = GridViewCourses.SelectedRow.Cells[2].Text;
            ddUpdateCourseDuration.Text = GridViewCourses.SelectedRow.Cells[3].Text;
            txUpdateCourseFee.Text = GridViewCourses.SelectedRow.Cells[4].Text + ".00";

            lblDeleteCourseId.Text = GridViewCourses.SelectedRow.Cells[1].Text;
            lblDeleteCourseName.Text = GridViewCourses.SelectedRow.Cells[2].Text;
        }

        protected void btnUpdateCourseSubmit_Click(object sender, EventArgs e)
        {
            ClassCourses updateCourse = new ClassCourses();
            updateCourse.UpdateCourse(this);
            string messageString = txUpdateCourseName.Text + " has successfully updated.";
            ClientScript.RegisterStartupScript(this.GetType(), "Successful", "alert('" + messageString + "'); window.location='Courses.aspx';", true);
        }        

        protected void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblDeleteCourseId.Text))
            {
                ClassCourses deleteCourse = new ClassCourses();
                deleteCourse.DeleteCourse(this);
                string messageString = lblDeleteCourseId.Text + " " + lblDeleteCourseName.Text + " has successfully deleted.";
                ClientScript.RegisterStartupScript(this.GetType(), "Successful", "alert('" + messageString + "'); window.location='Courses.aspx';", true);
            }
        }

        protected void btnCourseSearch_Click(object sender, EventArgs e)
        {
            ClassCourses searchCourse = new ClassCourses();
            searchCourse.SearchCourse(ddSearch, txCourseSearch, GridViewCourses);
        }

        protected void GridViewCourses_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClassCourses searchCourse = new ClassCourses();
            searchCourse.SearchCourse(ddSearch, txCourseSearch, GridViewCourses);
            GridViewCourses.PageIndex = e.NewPageIndex;
            GridViewCourses.DataBind();
        }
    }
}
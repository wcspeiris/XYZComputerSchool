using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYZComputerSchool.Classes;

namespace XYZComputerSchool.WebForms
{
    public partial class XYZExamPaper : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedInUser"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                lblLoggedinUser.Text = Session["loggedInUser"].ToString();

                btn01.CssClass = Session["btn01Color"].ToString();
                btn02.CssClass = Session["btn02Color"].ToString();
                btn03.CssClass = Session["btn03Color"].ToString();
                btn04.CssClass = Session["btn04Color"].ToString();
                btn05.CssClass = Session["btn05Color"].ToString();
                btn06.CssClass = Session["btn06Color"].ToString();
                btn07.CssClass = Session["btn07Color"].ToString();
                btn08.CssClass = Session["btn08Color"].ToString();
                btn09.CssClass = Session["btn09Color"].ToString();
                btn10.CssClass = Session["btn10Color"].ToString();
                btn11.CssClass = Session["btn11Color"].ToString();
                btn12.CssClass = Session["btn12Color"].ToString();
                btn13.CssClass = Session["btn13Color"].ToString();
                btn14.CssClass = Session["btn14Color"].ToString();
                btn15.CssClass = Session["btn15Color"].ToString();
            }          
        }        
    }
}
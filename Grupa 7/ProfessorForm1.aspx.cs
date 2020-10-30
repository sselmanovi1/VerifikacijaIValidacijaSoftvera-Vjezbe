using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ooad2020E_schedule
{
    public partial class LecturesForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgBtnLeft_Click(object sender, EventArgs e)
        {
            Response.Redirect("LecturesFormProf.aspx");
        }

        protected void imgBtnRight_Click(object sender, EventArgs e)
        {
            Response.Redirect("TutorialsFormProf.aspx");
        }
    }
}
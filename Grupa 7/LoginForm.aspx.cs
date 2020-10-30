using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ooad2020E_schedule
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            incorrectLabel.Visible = false;
        }

        protected void signInBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source = LOCALHOST\\SQLEXPRESS; Initial Catalog = EScheduleDB; Integrated Security = True"))
            {
                sqlCon.Open();
                string queryProf = "SELECT COUNT(1) FROM tblProfessors WHERE username=@username AND password=@password";
                SqlCommand sqlCmd = new SqlCommand(queryProf, sqlCon);
                sqlCmd.Parameters.AddWithValue("@username", userameTextBox.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@password", passwordTextBox.Text.Trim());
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if(count == 1)
                {
                    if (userameTextBox.Text.Trim().Equals("admin"))
                    {
                        Session["username"] = userameTextBox.Text.Trim();
                        Response.Redirect("AdministratorForm.aspx");
                    }
                    else {
                        Session["username"] = userameTextBox.Text.Trim();
                        Response.Redirect("ProfessorForm1.aspx");
                    }
                }
                else
                {
                    incorrectLabel.Visible = true;
                }
            }
        }
    }
}
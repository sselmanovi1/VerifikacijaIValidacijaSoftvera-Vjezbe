using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ooad2020E_schedule
{
    public partial class TutorialsFormProf : System.Web.UI.Page
    {
        public int counter = 1;
        public int max = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            RadioButtonListDays.Enabled = false;
            RadioButtonListTimes.Enabled = false;
            RadioButtonListClassrooms.Enabled = false;
            numberOfFinishedLabel.Visible = false;
            btnNext.Visible = false;
            System.Diagnostics.Debug.WriteLine("Load " + counter);
        }


        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void saveNumberBtn_Click(object sender, EventArgs e)
        {
            String selectedCourse = selectCourseListView.SelectedValue.ToString();
            String selectedNumber = textBoxNumber.Text;
            int n;
            bool isNumeric = int.TryParse(selectedNumber, out n);
            if (selectedCourse != "" && isNumeric)
            {
                saveNumberBtn.Enabled = false;
                textBoxNumber.Enabled = false;
                selectCourseListView.Enabled = false;
                RadioButtonListDays.Enabled = true;
                RadioButtonListTimes.Enabled = true;
                RadioButtonListClassrooms.Enabled = true;
                numberOfFinishedLabel.Visible = true;
                btnNext.Visible = true;
                numberOfFinishedLabel.Text = counter + "/" + textBoxNumber.Text.ToString();
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if(btnNext.Text == "Finish")
            {
                Response.Redirect("ProfessorResultsForm.aspx");
            }
            enableing();
        }

        public void enableing()
        {
            String currentNumberString = numberOfFinishedLabel.Text.ToString();
            char numberChar = currentNumberString[0];
            char maxChar = currentNumberString[2];
            int currentNumber = numberChar - '0' + 1;
            int max = maxChar - '0';
            saveNumberBtn.Enabled = false;
            textBoxNumber.Enabled = false;
            selectCourseListView.Enabled = false;
            RadioButtonListDays.Enabled = true;
            RadioButtonListTimes.Enabled = true;
            RadioButtonListClassrooms.Enabled = true;
            numberOfFinishedLabel.Visible = true;
            btnNext.Visible = true;
            numberOfFinishedLabel.Text = currentNumber + "/" + textBoxNumber.Text.ToString();
            System.Diagnostics.Debug.WriteLine("counter " + counter + "max" + max);
            if (max == currentNumber)
            {
                btnNext.Text = "Finish";
            }
        }


    }
}
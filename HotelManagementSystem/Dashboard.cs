using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class Dashboard : Form
    {
        // FormInfo class
        public class FormInfo
        {
            public string FormName { get; set; }
            public Func<Form> FormFactory { get; set; }

            public FormInfo(string formName, Func<Form> formFactory)
            {
                FormName = formName;
                FormFactory = formFactory;
            }
        }

        // Array for FormInfo objects
        private FormInfo[] forms;

        public Dashboard()
        {
            InitializeComponent();
            InitializeForms();
        }

        private void InitializeForms()
        {
            forms = new FormInfo[]
            {
                new FormInfo("Booking", () => new Booking()),
                new FormInfo("Room", () => new Room()),
                new FormInfo("Guest", () => new Guest())
            };
        }

        private void ShowForm(string formName)
        {
            var formInfo = forms.FirstOrDefault(f => f.FormName == formName);
            if (formInfo != null)
            {
                var formInstance = formInfo.FormFactory();
                formInstance.Show();
            }
            else
            {
                MessageBox.Show($"Form {formName} not found.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowForm("Booking");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowForm("Room");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowForm("Guest");
        }
    }
}

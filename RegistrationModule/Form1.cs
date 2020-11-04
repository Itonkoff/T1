using RegistrationModule.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationModule
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            foreach(Form form in Application.OpenForms)
            {
                if (form.Text.Equals("Students"))
                {
                    IsOpen = true;
                    form.Focus();
                    break;
                }
            }

            if (!IsOpen)
            {
                Students studentsForm = new Students();
                studentsForm.MdiParent = this;
                studentsForm.Show();
            }
        }
    }
}

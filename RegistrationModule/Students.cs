using Microsoft.EntityFrameworkCore;
using RegistrationModule.Contexts;
using RegistrationModule.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RegistrationModule {
    public partial class Students : Form {
        private DatabaseContext db;
        private int selectedStudentId;
        private List<Student> students;
        private Student selectedStudent;
        private Bitmap image;


        public Students()
        {
            InitializeComponent();
            db = new DatabaseContext();
            students = new List<Student>();
        }

        private void Students_Load(object sender, System.EventArgs e)
        {
            loadStudentInformation();

            cb_program.DataSource = db.Program.ToList();
            cb_program.ValueMember = "Id";
            cb_program.DisplayMember = "Name";

            cb_academic_lvl.DataSource = db.AcademicLevel.ToList();
            cb_academic_lvl.ValueMember = "Id";
            cb_academic_lvl.DisplayMember = "Value";
        }

        private void loadStudentInformation()
        {
            List<Student> students = db.Students.ToList();
            dgv_students.DataSource = students;
        }

        private void bn_gen_RegNumber_Click(object sender, System.EventArgs e)
        {
            tb_reg_number.Text = Guid.NewGuid().ToString();
        }

        private void dgv_students_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedStudentId = int.Parse(dgv_students.Rows[e.RowIndex].Cells[0].Value.ToString());
            selectedStudent = db.Students
                .Include(s=>s.StudentProgramNavigation)
                .Include(s => s.AcademicLevelNavigation)
                .Where(s=>s.Id == selectedStudentId)
                .FirstOrDefault();

            if (selectedStudent != null) {
                tb_name.Text = selectedStudent.FirstName;
                tb_surname.Text = selectedStudent.LastName;
                tb_national_id.Text = selectedStudent.NationalId;
                tb_phy_address.Text = selectedStudent.PhysicalAddress;
                cb_program.SelectedItem = selectedStudent.StudentProgramNavigation;
                cb_academic_lvl.SelectedItem = selectedStudent.AcademicLevelNavigation;
                chb_registered.Checked = selectedStudent.Registered;
                tb_reg_number.Text = selectedStudent.RegNumber.ToString();
            }
        }

        private void bn_add_Click(object sender, EventArgs e)
        {
            var selectedProgram = (StudentProgram) cb_program.SelectedItem;
            var selectedAcademicLevel = (AcademicLevel) cb_academic_lvl.SelectedItem;
            var regNumber = new Guid(tb_reg_number.Text);
            try
            {
                if(selectedStudent == null)
                {
                    selectedStudent = new Student();
                }
                selectedStudent.FirstName = tb_name.Text;
                selectedStudent.LastName = tb_surname.Text;
                selectedStudent.NationalId = tb_national_id.Text;
                selectedStudent.PhysicalAddress = tb_phy_address.Text;
                selectedStudent.Program = selectedProgram.Id;
                selectedStudent.AcademicLevel = selectedAcademicLevel.Id;
                selectedStudent.Registered = chb_registered.Checked;
                selectedStudent.RegNumber = regNumber;

                db.Update(selectedStudent);
                db.SaveChanges();
                
                loadStudentInformation();
                MessageBox.Show("Saved", "Student Reg", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Student Reg", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Clear();
        }

        private void bn_clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            selectedStudent = null;
            tb_name.Clear();
            tb_surname.Clear();
            tb_national_id.Clear();
            tb_phy_address.Clear();
            tb_reg_number.Clear();
            chb_registered.Checked = false;
        }

        private void bn_print_Click(object sender, EventArgs e)
        {
            CostructStudentId();
        }

        private void CostructStudentId()
        {
            if (selectedStudent != null)
            {
                rtb_card.Clear();
                rtb_card.AppendText("Tel One Center for Learning\n");
                rtb_card.AppendText("================================\n");
                rtb_card.AppendText($"{selectedStudent.FirstName.ToUpper()} {selectedStudent.LastName.ToUpper()}\n");
                rtb_card.AppendText($"{selectedStudent.StudentProgramNavigation.Name}\n");
                rtb_card.AppendText($"LEVEL: {selectedStudent.AcademicLevelNavigation.Value}\n");
                rtb_card.AppendText("\n\n\n\n\n\n================================\n");
                QRCoder.QRCode qRCode = GenerateQRCode(selectedStudent.RegNumber.ToString());
                image = qRCode.GetGraphic(2);
                

                printPreviewDialog1.ShowDialog(this);
            }
        }

        private QRCoder.QRCode GenerateQRCode(string v)
        {
            QRCoder.QRCodeGenerator QRG = new QRCoder.QRCodeGenerator();
            QRCoder.QRCodeData qRCodeData = QRG.CreateQrCode(v, QRCoder.QRCodeGenerator.ECCLevel.H);
            QRCoder.QRCode qRCode = new QRCoder.QRCode(qRCodeData);
            return qRCode;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(rtb_card.Text, new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(0, 0));
            e.Graphics.DrawImage(image, new Point(50,100));
        }

        private void btn_print_card_Click(object sender, EventArgs e)
        {
            CostructStudentId();
            printDocument1.Print();
        }
    }

}
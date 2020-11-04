using System.ComponentModel;

namespace RegistrationModule {
    partial class Students {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Students));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_print_card = new System.Windows.Forms.Button();
            this.rtb_card = new System.Windows.Forms.RichTextBox();
            this.bn_print = new System.Windows.Forms.Button();
            this.bn_gen_RegNumber = new System.Windows.Forms.Button();
            this.bn_clear = new System.Windows.Forms.Button();
            this.cb_academic_lvl = new System.Windows.Forms.ComboBox();
            this.cb_program = new System.Windows.Forms.ComboBox();
            this.chb_registered = new System.Windows.Forms.CheckBox();
            this.bn_add = new System.Windows.Forms.Button();
            this.tb_reg_number = new System.Windows.Forms.TextBox();
            this.tb_phy_address = new System.Windows.Forms.TextBox();
            this.tb_national_id = new System.Windows.Forms.TextBox();
            this.tb_surname = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_students = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_students)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_print_card);
            this.panel1.Controls.Add(this.rtb_card);
            this.panel1.Controls.Add(this.bn_print);
            this.panel1.Controls.Add(this.bn_gen_RegNumber);
            this.panel1.Controls.Add(this.bn_clear);
            this.panel1.Controls.Add(this.cb_academic_lvl);
            this.panel1.Controls.Add(this.cb_program);
            this.panel1.Controls.Add(this.chb_registered);
            this.panel1.Controls.Add(this.bn_add);
            this.panel1.Controls.Add(this.tb_reg_number);
            this.panel1.Controls.Add(this.tb_phy_address);
            this.panel1.Controls.Add(this.tb_national_id);
            this.panel1.Controls.Add(this.tb_surname);
            this.panel1.Controls.Add(this.tb_name);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgv_students);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 494);
            this.panel1.TabIndex = 0;
            // 
            // btn_print_card
            // 
            this.btn_print_card.Location = new System.Drawing.Point(610, 461);
            this.btn_print_card.Name = "btn_print_card";
            this.btn_print_card.Size = new System.Drawing.Size(96, 29);
            this.btn_print_card.TabIndex = 11;
            this.btn_print_card.Text = "Print Card";
            this.btn_print_card.UseVisualStyleBackColor = true;
            this.btn_print_card.Click += new System.EventHandler(this.btn_print_card_Click);
            // 
            // rtb_card
            // 
            this.rtb_card.Location = new System.Drawing.Point(349, 496);
            this.rtb_card.Name = "rtb_card";
            this.rtb_card.Size = new System.Drawing.Size(294, 191);
            this.rtb_card.TabIndex = 10;
            this.rtb_card.Text = "";
            this.rtb_card.Visible = false;
            // 
            // bn_print
            // 
            this.bn_print.Location = new System.Drawing.Point(488, 461);
            this.bn_print.Name = "bn_print";
            this.bn_print.Size = new System.Drawing.Size(116, 29);
            this.bn_print.TabIndex = 9;
            this.bn_print.Text = "Preview Card";
            this.bn_print.UseVisualStyleBackColor = true;
            this.bn_print.Click += new System.EventHandler(this.bn_print_Click);
            // 
            // bn_gen_RegNumber
            // 
            this.bn_gen_RegNumber.Location = new System.Drawing.Point(918, 408);
            this.bn_gen_RegNumber.Name = "bn_gen_RegNumber";
            this.bn_gen_RegNumber.Size = new System.Drawing.Size(32, 29);
            this.bn_gen_RegNumber.TabIndex = 8;
            this.bn_gen_RegNumber.Text = "...";
            this.bn_gen_RegNumber.UseVisualStyleBackColor = true;
            this.bn_gen_RegNumber.Click += new System.EventHandler(this.bn_gen_RegNumber_Click);
            // 
            // bn_clear
            // 
            this.bn_clear.Location = new System.Drawing.Point(388, 461);
            this.bn_clear.Name = "bn_clear";
            this.bn_clear.Size = new System.Drawing.Size(94, 29);
            this.bn_clear.TabIndex = 7;
            this.bn_clear.Text = "Clear";
            this.bn_clear.UseVisualStyleBackColor = true;
            this.bn_clear.Click += new System.EventHandler(this.bn_clear_Click);
            // 
            // cb_academic_lvl
            // 
            this.cb_academic_lvl.FormattingEnabled = true;
            this.cb_academic_lvl.Location = new System.Drawing.Point(684, 338);
            this.cb_academic_lvl.Name = "cb_academic_lvl";
            this.cb_academic_lvl.Size = new System.Drawing.Size(266, 28);
            this.cb_academic_lvl.TabIndex = 6;
            // 
            // cb_program
            // 
            this.cb_program.FormattingEnabled = true;
            this.cb_program.Location = new System.Drawing.Point(684, 300);
            this.cb_program.Name = "cb_program";
            this.cb_program.Size = new System.Drawing.Size(266, 28);
            this.cb_program.TabIndex = 6;
            // 
            // chb_registered
            // 
            this.chb_registered.AutoSize = true;
            this.chb_registered.Location = new System.Drawing.Point(684, 376);
            this.chb_registered.Name = "chb_registered";
            this.chb_registered.Size = new System.Drawing.Size(18, 17);
            this.chb_registered.TabIndex = 5;
            this.chb_registered.UseVisualStyleBackColor = true;
            // 
            // bn_add
            // 
            this.bn_add.Location = new System.Drawing.Point(288, 461);
            this.bn_add.Name = "bn_add";
            this.bn_add.Size = new System.Drawing.Size(94, 29);
            this.bn_add.TabIndex = 3;
            this.bn_add.Text = "Save";
            this.bn_add.UseVisualStyleBackColor = true;
            this.bn_add.Click += new System.EventHandler(this.bn_add_Click);
            // 
            // tb_reg_number
            // 
            this.tb_reg_number.Enabled = false;
            this.tb_reg_number.Location = new System.Drawing.Point(684, 410);
            this.tb_reg_number.Name = "tb_reg_number";
            this.tb_reg_number.Size = new System.Drawing.Size(228, 27);
            this.tb_reg_number.TabIndex = 2;
            // 
            // tb_phy_address
            // 
            this.tb_phy_address.Location = new System.Drawing.Point(164, 413);
            this.tb_phy_address.Name = "tb_phy_address";
            this.tb_phy_address.Size = new System.Drawing.Size(266, 27);
            this.tb_phy_address.TabIndex = 2;
            // 
            // tb_national_id
            // 
            this.tb_national_id.Location = new System.Drawing.Point(164, 373);
            this.tb_national_id.Name = "tb_national_id";
            this.tb_national_id.Size = new System.Drawing.Size(266, 27);
            this.tb_national_id.TabIndex = 2;
            // 
            // tb_surname
            // 
            this.tb_surname.Location = new System.Drawing.Point(164, 338);
            this.tb_surname.Name = "tb_surname";
            this.tb_surname.Size = new System.Drawing.Size(266, 27);
            this.tb_surname.TabIndex = 2;
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(164, 300);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(266, 27);
            this.tb_name.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(520, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Academic level";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(520, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Program";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(520, 373);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Registered";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(520, 413);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Reg Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 413);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Physical address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 373);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "National id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Surname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // dgv_students
            // 
            this.dgv_students.AllowUserToAddRows = false;
            this.dgv_students.AllowUserToDeleteRows = false;
            this.dgv_students.AllowUserToResizeRows = false;
            this.dgv_students.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_students.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_students.Location = new System.Drawing.Point(11, 11);
            this.dgv_students.MultiSelect = false;
            this.dgv_students.Name = "dgv_students";
            this.dgv_students.RowHeadersWidth = 51;
            this.dgv_students.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_students.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_students.Size = new System.Drawing.Size(978, 255);
            this.dgv_students.TabIndex = 0;
            this.dgv_students.Text = "dataGridView2";
            this.dgv_students.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_students_CellContentClick);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(164, 300);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(255, 27);
            this.textBox2.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(520, 300);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Academic level";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(520, 338);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "Program";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(520, 373);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 20);
            this.label11.TabIndex = 1;
            this.label11.Text = "Registered";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(520, 413);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "Reg Number";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 413);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 20);
            this.label13.TabIndex = 1;
            this.label13.Text = "Physical address";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 373);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 20);
            this.label14.TabIndex = 1;
            this.label14.Text = "National id";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 338);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 20);
            this.label15.TabIndex = 1;
            this.label15.Text = "Surname";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 300);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 20);
            this.label16.TabIndex = 1;
            this.label16.Text = "Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 11);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(978, 255);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(164, 300);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(255, 27);
            this.textBox3.TabIndex = 2;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 494);
            this.Controls.Add(this.panel1);
            this.Name = "Students";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Students";
            this.Load += new System.EventHandler(this.Students_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_students)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_students;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox tb_surname;
        private System.Windows.Forms.TextBox tb_reg_number;
        private System.Windows.Forms.TextBox tb_phy_address;
        private System.Windows.Forms.TextBox tb_national_id;
        private System.Windows.Forms.Button bn_add;
        private System.Windows.Forms.CheckBox chb_registered;
        private System.Windows.Forms.ComboBox cb_academic_lvl;
        private System.Windows.Forms.ComboBox cb_program;
        private System.Windows.Forms.Button bn_clear;
        private System.Windows.Forms.Button bn_gen_RegNumber;
        private System.Windows.Forms.Button bn_print;
        private System.Windows.Forms.RichTextBox rtb_card;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btn_print_card;
    }
}
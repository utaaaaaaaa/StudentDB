using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnStudentRegister_Click(object sender, EventArgs e)
        {
            Form2 studentRegisterForm = new Form2();
            studentRegisterForm.ShowDialog();
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            Form3 teacherForm = new Form3();
            teacherForm.ShowDialog();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            Form4 attendanceForm = new Form4();
            attendanceForm.ShowDialog();
        }

        private void btnShowAttendance_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }
    }
}

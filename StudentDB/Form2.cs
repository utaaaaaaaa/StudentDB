using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentDB
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Add student to database
            string connectionString = "Data Source=DESKTOP-9PFJ9LL\\SQLEXPRESS02;Initial Catalog=studentdb;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO info_tad (studentid, studentname, studemail, studmobile) VALUES (@studentid, @studentname, @studemail, @studmobile)", connection);
                command.Parameters.AddWithValue("@studentid", txtStudentID.Text);
                command.Parameters.AddWithValue("@studentname", txtStudentName.Text);
                command.Parameters.AddWithValue("@studemail", txtStudentEmail.Text);
                command.Parameters.AddWithValue("@studmobile", txtStudentMobile.Text);
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Student added successfully!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Update student in database
            if (int.TryParse(txtStudentID.Text, out int studentID))
            {
                string connectionString = "Data Source=DESKTOP-9PFJ9LL\\SQLEXPRESS02;Initial Catalog=studentdb;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE info_tad SET studentname = @studentname, studemail = @studemail, studmobile = @studmobile WHERE studentid = @studentid", connection);
                    command.Parameters.AddWithValue("@studentid", studentID);
                    command.Parameters.AddWithValue("@studentname", txtStudentName.Text);
                    command.Parameters.AddWithValue("@studemail", txtStudentEmail.Text);
                    command.Parameters.AddWithValue("@studmobile", txtStudentMobile.Text);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Student updated successfully!");
            }
            else
            {
                MessageBox.Show("Invalid student ID");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Delete student from database
            if (int.TryParse(txtStudentID.Text, out int studentID))
            {
                string connectionString = "Data Source=DESKTOP-9PFJ9LL\\SQLEXPRESS02;Initial Catalog=studentdb;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM info_tad WHERE studentid = @studentid", connection);
                    command.Parameters.AddWithValue("@studentid", studentID);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Student deleted successfully!");
            }
            else
            {
                MessageBox.Show("Invalid student ID");
            }
        }
    }
}

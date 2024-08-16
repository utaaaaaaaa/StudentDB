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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Update teacher in database
            string connectionString = "Data Source=DESKTOP-9PFJ9LL\\SQLEXPRESS02;Initial Catalog=studentdb;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Teacher_tad SET teachname = @teachname, teachemail = @teachemail WHERE teachid = @teachid", connection);
                command.Parameters.AddWithValue("@teachid", txtTeacherID.Text);
                command.Parameters.AddWithValue("@teachname", txtTeacherName.Text);
                command.Parameters.AddWithValue("@teachemail", txtTeacherEmail.Text);
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Teacher updated successfully!");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Add teacher to database
            string connectionString = "Data Source=DESKTOP-9PFJ9LL\\SQLEXPRESS02;Initial Catalog=studentdb;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Teacher_tad (teachid, teachname, teachemail) VALUES (@teachid, @teachname, @teachemail)", connection);
                command.Parameters.AddWithValue("@teachid", txtTeacherID.Text);
                command.Parameters.AddWithValue("@teachname", txtTeacherName.Text);
                command.Parameters.AddWithValue("@teachemail", txtTeacherEmail.Text);
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Teacher added successfully!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Delete teacher from database
            string connectionString = "Data Source=DESKTOP-9PFJ9LL\\SQLEXPRESS02;Initial Catalog=studentdb;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Teacher_tad WHERE teachid = @teachid", connection);
                command.Parameters.AddWithValue("@teachid", txtTeacherID.Text);
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Teacher deleted successfully!");
        }
    }
}

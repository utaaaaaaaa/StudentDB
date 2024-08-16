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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentDB
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Load students from database
            string connectionString = "Data Source=DESKTOP-9PFJ9LL\\SQLEXPRESS02;Initial Catalog=studentdb;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM info_tad", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                txtStudentID.Text = row.Cells[0].Value.ToString();
                txtStudentName.Text = row.Cells[1].Value.ToString();
                txtStudentEmail.Text = row.Cells[2].Value.ToString();
                txtStudentMobile.Text = row.Cells[3].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Update attendance in database    
            // Update attendance in database    
            string connectionString = "Data Source=DESKTOP-9PFJ9LL\\SQLEXPRESS02;Initial Catalog=studentdb;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE attendance_tad SET attendance = @attendance WHERE studentid = @studentid", connection);
                command.Parameters.AddWithValue("@studentid", txtStudentID.Text);
                command.Parameters.AddWithValue("@attendance", txtAttendance.Text);
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Attendance updated successfully!");
        }
        private void txtStudentMobile_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

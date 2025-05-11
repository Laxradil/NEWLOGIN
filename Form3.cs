using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace simplelogin
{
    public partial class Classform : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6ETLC0S\SQLEXPRESS;AttachDbFilename=D:\simplelogin\loginData.mdf;Integrated Security=True");
        public Classform()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadSchedule();

            string loggedInUser = UserSession.GetUsername();
            label6.Text = loggedInUser;
            label6.TextAlign = ContentAlignment.TopLeft;
            label6.Font = new Font("Segoe UI", 15, FontStyle.Bold);
        }
        private void Classform_Load(object sender, EventArgs e)
        {
              
         }
    
        private void LoadSchedule()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6ETLC0S\SQLEXPRESS;AttachDbFilename=D:\simplelogin\loginData.mdf;Integrated Security=True")
            {
                string query = "SELECT * FROM Schedule";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvSchedule.DataSource = table;
                // Hide the Id column
                if (dgvSchedule.Columns.Contains("Id"))
                {
                    dgvSchedule.Columns["Id"].Visible = false;
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Menuform sForm = new Menuform();
            sForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Uploadform lForm = new Uploadform();
            lForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Classform Cform = new Classform();
            Cform.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void Class_TextChanged(object sender, EventArgs e)
        {

        }

        private void Day_TextChanged(object sender, EventArgs e)
        {

        }

        private void Oras_TextChanged(object sender, EventArgs e)
        {

        }

        private void Teacher_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6ETLC0S\SQLEXPRESS;AttachDbFilename=D:\simplelogin\loginData.mdf;Integrated Security=True"))
            {
                string query = "INSERT INTO Schedule (ClassName, Day, Time, Teacher) VALUES (@ClassName, @Day, @Time, @Teacher)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ClassName", txtClassName.Text);
                    cmd.Parameters.AddWithValue("@Day", txtDay.Text);
                    cmd.Parameters.AddWithValue("@Time", txtTime.Text);
                    cmd.Parameters.AddWithValue("@Teacher", txtTeacher.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                {
                    if (!string.IsNullOrWhiteSpace(txtClassName.Text) &&
                        !string.IsNullOrWhiteSpace(txtDay.Text) &&
                        !string.IsNullOrWhiteSpace(txtTime.Text) &&
                        !string.IsNullOrWhiteSpace(txtTeacher.Text))

                        txtClassName.Clear();
                    txtDay.Clear();
                    txtTime.Clear();
                    txtTeacher.Clear();

                    txtClassName.Focus();
                }


            }

            MessageBox.Show("Schedule added.");
            LoadSchedule();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvSchedule.SelectedRows[0].Cells["Id"].Value);
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\brion\Documents\simplelogin\loginData.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string query = "DELETE FROM Schedule WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                MessageBox.Show("Schedule removed.");
                LoadSchedule();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}


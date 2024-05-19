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

namespace HotelManagementSystem
{
    public partial class Guest : Form
    {
        public Guest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=hoteldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into guestab values(@Id,@Name,@Age,@Phone,@Address)", con);
            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Name", textBox2.Text);
            cnn.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@Phone", textBox4.Text);
            cnn.Parameters.AddWithValue("@Address", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=hoteldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from guestab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please provide the ID of the record to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=hoteldb;Integrated Security=True"))
            {
                con.Open();

                StringBuilder updateQuery = new StringBuilder("UPDATE guestab SET ");
                List<string> updateColumns = new List<string>();

              
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    updateColumns.Add("Name = @Name");
                }

                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    updateColumns.Add("Age = @Age");
                }

                if (!string.IsNullOrEmpty(textBox4.Text))
                {
                    updateColumns.Add("Phone = @Phone");
                }

                if (!string.IsNullOrEmpty(textBox5.Text))
                {
                    updateColumns.Add("Address = @Address");
                }

                
                updateQuery.Append(string.Join(",", updateColumns));
                updateQuery.Append(" WHERE Id = @Id");

                using (SqlCommand cmd = new SqlCommand(updateQuery.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));

                    if (!string.IsNullOrEmpty(textBox2.Text))
                    {
                        cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                    }

                    if (!string.IsNullOrEmpty(textBox3.Text))
                    {
                        cmd.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));
                    }

                    if (!string.IsNullOrEmpty(textBox4.Text))
                    {
                        cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
                    }

                    if (!string.IsNullOrEmpty(textBox5.Text))
                    {
                        cmd.Parameters.AddWithValue("@Address", textBox5.Text);
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No records updated. Please check if the provided ID exists.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=hoteldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from guestab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}

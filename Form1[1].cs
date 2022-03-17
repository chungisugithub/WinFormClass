using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
// https://www.youtube.com/watch?v=q1G1-gwbk5s
namespace WinFormCRUD
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        int tempID;
        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Server=DESKTOP-MSTKBUJ\SQLEXPRESS01;Database=StudentsInfo;User Id=sa;Password=1234;");
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void display()
        {
            SqlDataAdapter sqlAdapter = new SqlDataAdapter("Select * from Student", connection);
            DataTable dt = new DataTable();
            sqlAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            display();
        }

        private void button3_Click(object sender, EventArgs e)
        {   // 입력버튼
            SqlCommand cmd;
            connection.Open();
            string sqlQuery = "Insert into Student (Name, Age, Location, Gender) Values(@p1, @p2, @p3, @p4) ";

            cmd = new SqlCommand(sqlQuery, connection);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", int.Parse(tbAge.Text));
            cmd.Parameters.AddWithValue("@p3", textBox2.Text);
            cmd.Parameters.AddWithValue("@p4", comboBox1.Text);

            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
            display();
            MessageBox.Show("입력되었습니다.");
        }

        private void button1_Click(object sender, EventArgs e)
        {   //삭제
            SqlCommand cmd;
            connection.Open();
            for(int i=0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow delRow = dataGridView1.Rows[i];
                if(delRow.Selected == true)
                {
                    string sqlQuery = "Delete from Student where id = " +
                        dataGridView1.Rows[i].Cells[4].Value + "";
                    cmd = new SqlCommand(sqlQuery, connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }

            connection.Close();
            display();
            MessageBox.Show("입력되었습니다.");
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                tempID = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());

                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                tbAge.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {   // 수정
            SqlCommand cmd;
            connection.Open();
            string sqlQuery = "update Student set Name = @p1, Age = @p2, Location = @p3, Gender = @p4 where id = '" + tempID + "'";

            cmd = new SqlCommand(sqlQuery, connection);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", int.Parse(tbAge.Text));
            cmd.Parameters.AddWithValue("@p3", textBox2.Text);
            cmd.Parameters.AddWithValue("@p4", comboBox1.Text);

            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
            display();
            clearFields();
            MessageBox.Show("수정되었습니다..");

        }

        private void clearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            tbAge.Clear();
            comboBox1.Text = "";
        }
    }
}

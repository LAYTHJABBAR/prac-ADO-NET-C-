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

namespace practice_Ado
{
    
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost\sqlexpress01;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into student values('" + txtName.Text + "','" + txtCity.Text + "','" + txtCountry.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Entered Correctly");
               
            }
            catch(Exception ex)
            {
                MessageBox.Show("data enterd is wrong " + ex.Message , ex.GetType().ToString());
            }
            con.Close();
            disp_data();
        }
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Student";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtaGrid.DataSource = dt;
            con.Close();

          }

        private void Form1_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from student where name ='"+txtName.Text+"' ";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Deleted Correctly");

            }
            catch (Exception ex)
            {
                MessageBox.Show("data Deleted is wrong " + ex.Message, ex.GetType().ToString());
            }
            con.Close();
            disp_data();
        }
    }


}

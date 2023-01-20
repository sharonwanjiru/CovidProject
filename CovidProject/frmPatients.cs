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

namespace CovidProject
{
    public partial class frmPatients : Form
    {
        public frmPatients()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmPatients_Load(object sender, EventArgs e)
        {

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtIdNo.Text = "";
            txtCountry.Text = "";
            dtpDOB.Value = DateTime.Today;
            cmbGender.SelectedIndex = 0;
            chkIsActive.Checked = true;
            txtName.Focus();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Trim()=="")
            {
                MessageBox.Show("Please Enter Patient Name");
                txtName.Focus();
                return;
            }
            if(txtIdNo.Text.Trim()=="")
            {
                MessageBox.Show("Please Enter Id Number");
                txtIdNo.Focus();
                return;

            }
            // database Connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-V6NGFAO\SQLEXPRESS; Initial Catalog = CovidPatients;Integrated Security=True;";
           
            conn.Open();
            //code
            int val = 0; 
            if (chkIsActive.Checked) val = 1;
            string sql = " ";

            sql = "INSERT INTO tblPatients(Name, IdNo,DOB,Gender,Country,IsActive)VALUES('" + txtName.Text + "'," + txtIdNo.Text + ",'" + dtpDOB.Value.ToString("yyyyMMdd") + "','" + cmbGender.Text + "','" + txtCountry.Text + "'," + val + ")";


            //sql = "INSERT INTO tblPatients(Name, IdNo,DOB,Gender,Country,IsActive)VALUES('"+ txtName.Text + "','" + txtIdNo.Text + "','"+dtpDOB.Value.ToString("yyyyMMdd")+"','" + cmbGender.Text + "','" + txtCountry.Text + "', "+ val +",)";

            SqlCommand comm = new SqlCommand(sql, conn);
            comm.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Process Completed");


        }
    }
}

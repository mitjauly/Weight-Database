using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeightDatabase
{
    public partial class mainform : Form
    {
        string dp = "System.Data.SqlClient";
        string cnStr = @"Data Source=MMM\sqlexpress;Initial Catalog=WeightsDatabase;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        DbProviderFactory df;
        SqlConnection cn;
        public mainform()
        {


            SqlConnection cn = new SqlConnection(cnStr);
            cn.ConnectionString = cnStr;
            cn.Open();

        }

        private void button1_Click(object sender, EventArgs e)
        {
       
            using (SqlConnection cn = new SqlConnection(cnStr))
            { 
                cn.ConnectionString = cnStr;
            cn.Open();

            using (SqlCommand AddUsr = new SqlCommand("AddUser", cn))
            { 
                AddUsr.CommandType = CommandType.StoredProcedure;
            AddUsr.Parameters.Add(new SqlParameter("@FIO", SqlDbType.NVarChar, 50));
            AddUsr.Parameters["@FIO"].Value = textBox1.Text;
            AddUsr.Parameters.Add(new SqlParameter("@Height", SqlDbType.Float, 50));
            AddUsr.Parameters["@Height"].Value = float.Parse(textBox2.Text);
            AddUsr.ExecuteNonQuery();
            cn.Close();
            this.usersTableAdapter.Fill(this.weightsDatabaseDataSet.users);
        }
    }

        }

        private void mainform_FormClosed(object sender, FormClosedEventArgs e)
        {

          
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "weightsDatabaseDataSet1.WeView". При необходимости она может быть перемещена или удалена.
            this.weViewTableAdapter.Fill(this.weightsDatabaseDataSet1.WeView);

            // TODO: данная строка кода позволяет загрузить данные в таблицу "weightsDatabaseDataSet.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.weightsDatabaseDataSet.users);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
            usersTableAdapter.Update(weightsDatabaseDataSet.users);
            Validate();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(cnStr))
            {
                cn.ConnectionString = cnStr;
                cn.Open();

                using (SqlCommand AddMS = new SqlCommand("AddWeight", cn))
                { 
                AddMS.CommandType = CommandType.StoredProcedure;
                float usrid = (float)Convert.ToDouble(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
                float hghts = (float)Convert.ToDouble(dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString());
                AddMS.Parameters.Add(new SqlParameter("@User", SqlDbType.NVarChar, 50));
                AddMS.Parameters["@User"].Value = usrid;
                AddMS.Parameters.Add(new SqlParameter("@Weight", SqlDbType.Float, 50));
                AddMS.Parameters["@Weight"].Value = float.Parse(textBox3.Text);
                AddMS.Parameters.Add(new SqlParameter("@MassIndex", SqlDbType.Float, 50));
                AddMS.Parameters["@MassIndex"].Value = float.Parse(textBox3.Text) / (Math.Pow(hghts / 100, 2));
                AddMS.ExecuteNonQuery();
                cn.Close();
            }
            }
            this.weViewTableAdapter.Fill(this.weightsDatabaseDataSet1.WeView);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(cnStr))
            { 
                cn.ConnectionString = cnStr;
            cn.Open();
            DataTable dt = new DataTable();
            SqlCommand cm = cn.CreateCommand();
            cm.CommandText = @"SELECT measurement.Id,users.FIO, Weight,users.Height, MassIndex
                                FROM measurement 
                                INNER JOIN users ON users.id = UsrID 
                                WHERE MassIndex>30";

            SqlDataAdapter aaa = new SqlDataAdapter(cm);
            aaa.Fill(dt);
         
            dataGridView3.DataSource = dt;
            cn.Close();
           }
        }

        private void bindingSource1_CurrentChanged_1(object sender, EventArgs e)
        {

        }
    }
}

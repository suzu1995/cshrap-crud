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

namespace master
{
    public partial class SearchUpdate : Form
    {
        public SearchUpdate()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)


        {
            string txtid = this.txtid.Text;

            if (string.IsNullOrEmpty(txtid))
            {
                MessageBox.Show("商品コードが未入力です。", "", MessageBoxButtons.OK);
                return;
            }

            string constr = "Data Source=DESKTOP-JBH4QJM\\SQLEXPRESS;Initial Catalog=Staff;Integrated Security=True";

            SqlConnection con = new SqlConnection(constr);


            try
            {
                con.Open();

                string sqlstr = @"SELECT Product_Name,Product_Val,insert_date FROM M_Product WHERE Product_ID =  @id ";
                SqlCommand com = new SqlCommand(sqlstr, con);

                SqlParameter paramid = new SqlParameter( "@id" , SqlDbType.VarChar, 8);
                paramid.Value = txtid;
                com.Parameters.Add(paramid);
                com.Prepare();

                SqlDataReader sdr = com.ExecuteReader();
                if (sdr.Read())
                {

                    string name = (string)sdr["Product_Name"];
                    string val = (string)sdr["Product_Val"];
                    string date = (string)sdr["insert_date"];

                    textBox2.Text += string.Format("{0}", name.Trim());
                    textBox3.Text += string.Format("{0}", val.Trim());
                    textBox4.Text += string.Format("{0}", date.Trim());

                }

                else
                {
                    MessageBox.Show("該当する商品が見つかりません。", "", MessageBoxButtons.OK);
                    return;
                }
            }
            finally
            {
                con.Close();
            }
        }

    }
}
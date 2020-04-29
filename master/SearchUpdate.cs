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
                MessageBox.Show("商品コードが未入力です。");
                return;
            }

            string constr = "Data Source=DESKTOP-JBH4QJM\\SQLEXPRESS;Initial Catalog=Product;Integrated Security=True";

            SqlConnection con = new SqlConnection(constr);


            try
            {
                con.Open();

                string sql = "SELECT Product_ID,Product_name,Product_Val,insert_date FROM M_Product WHERE Product_ID =  @id ";
                SqlCommand com = new SqlCommand(sql, con);

                SqlParameter paramid = new SqlParameter( "@id" , SqlDbType.VarChar, 8);
                paramid.Value = txtid;
                com.Parameters.Add(paramid);
                com.Prepare();

                SqlDataReader sdr = com.ExecuteReader();
                if (sdr.Read())
                {

                    string name = (string)sdr["Product_Name"];
                    long val = (long)sdr["Product_Val"];
                    DateTime date = (DateTime)sdr["insert_date"];

                    textBox2.Text += string.Format("{0}", name);
                    textBox3.Text += string.Format("{0}", val);
                    textBox4.Text += string.Format("{0}", date);

                }

                else
                {
                    MessageBox.Show("該当する商品が見つかりません。");
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
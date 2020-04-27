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
            string constr = "Data Source=DESKTOP-JBH4QJM\\SQLEXPRESS;Initial Catalog=Staff;Integrated Security=True";

            SqlConnection con = new SqlConnection(constr);


            try
            {
                con.Open();

                string sqlstr = "@SELECT * FROM M_Product WHERE Product_Name AND Product_Val AND insert_date ";
                SqlCommand com = new SqlCommand(sqlstr, con);
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read() == true)
                {
                    string name = (string)sdr["Product_Name"];
                    string val = (string)sdr["Product_Val"];
                    string date = (string)sdr["insert_date"];

                    textBox2.Text += string.Format("{0}", name.Trim());
                    textBox3.Text += string.Format("{0}", val.Trim());
                    textBox4.Text += string.Format("{0}", date.Trim());

                }
            }
            finally
            {
                con.Close();
            }
        }

    }
}
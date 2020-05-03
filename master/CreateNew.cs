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
    public partial class CreateNew : Form
    {
        public CreateNew()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)

        {

            string txtcreateid = this.txtcreateid.Text;

            string txtcreatename = this.txtcreatename.Text;

            string txtcreaateval = this.txtcreateval.Text;
            txtcreateval.MaxLength = 8;
           

            DateTime dt = DateTime.Now;

            if (string.IsNullOrEmpty(txtcreateid))
            {
                MessageBox.Show("商品コードが未入力です。");
                return;
            }

            string constr = "Data Source=DESKTOP-JBH4QJM\\SQLEXPRESS;Initial Catalog=Product;Integrated Security=True";

            SqlConnection con = new SqlConnection(constr);

            try
            {
                con.Open();

                string sql = "INSERT INTO M_Product(Product_ID, Product_Name, Product_Val,insert_date) VALUES(@id, @name, @val,@date)"
                               + " SELECT Product_ID,Product_Name,Product_Val,insert_date FROM M_Product"
                               +" WHERE NOT EXISTS(SELECT Product_ID FROM M_Product)";
                SqlCommand com = new SqlCommand(sql, con);

                SqlParameter paramid = new SqlParameter("@id", SqlDbType.VarChar, 8);
                paramid.Value = txtcreateid;
                com.Parameters.Add(paramid);

                SqlParameter paramname = new SqlParameter("@name", SqlDbType.VarChar, 50);
                paramname.Value = txtcreatename;
                com.Parameters.Add(paramname);

                SqlParameter paramval = new SqlParameter("@val", SqlDbType.BigInt);
                paramval.Value = this.txtcreateval.Text;
                paramval.ToString();
                com.Parameters.Add(paramval);

                SqlParameter paramdate = new SqlParameter("@date", SqlDbType.Date);
                paramdate.Value = dt;
                com.Parameters.Add(paramdate);

                com.Prepare();

                

                com.ExecuteNonQuery();
                MessageBox.Show("完了しました");

            }
            catch (Exception ex)
            {
                MessageBox.Show("既にその商品コードは使用されています。");
            }

            finally
            {
                con.Close();
            }
        }

        private void txtcreateval_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();

            Main_menu main = new Main_menu();

            main.ShowDialog();
        }
    }
}
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
            //テキストボックスのオブジェクト化
            string txtcreateid = this.txtcreateid.Text;

            string txtcreatename = this.txtcreatename.Text;

            string txtcreaateval = this.txtcreateval.Text;
            txtcreateval.MaxLength = 8;
           
            //現在日時
            DateTime dt = DateTime.Now;

            //商品コード未入力の場合
            if (string.IsNullOrEmpty(txtcreateid))
            {
                MessageBox.Show("商品コードが未入力です。");
                return;
            }
            //接続文字列
            string constr = "Data Source=DESKTOP-JBH4QJM\\SQLEXPRESS;Initial Catalog=Product;Integrated Security=True";

            SqlConnection con = new SqlConnection(constr);

            try
            {
                con.Open();　　//接続開始

                //ID、名前、値段、日付の挿入
                string sql = "INSERT INTO M_Product(Product_ID, Product_Name, Product_Val,insert_date) VALUES(@id, @name, @val, getdate())";

                SqlCommand com = new SqlCommand(sql, con);

                //パラメータ化
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

                

                com.Prepare();

                

                com.ExecuteNonQuery();
                MessageBox.Show("完了しました");

            }
            catch (Exception)　//重複がある場合
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
            //メインメニューに戻る
            this.Close();
            this.Hide();
            Main_menu main = new Main_menu();

            main.ShowDialog();
        }
    }
}
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void passtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void btnlogin_Click(object sender, EventArgs e)


        {
            string id = Idtxt.Text;
            string pw = passtxt.Text;

            //接続文字列の取得
            string constr = "Data Source=DESKTOP-JBH4QJM\\SQLEXPRESS;Initial Catalog=Staff;Integrated Security=True";

            //DB接続の準備
            SqlConnection con = new SqlConnection(constr);



            try
            {
                //DB接続開始
                con.Open();

                //実行したいSQL文に引数を与えてSqlオブジェクトの作成

                string slc = @"select * from M_Staff WHERE Staff_ID=@sqlid AND Staff_Password=@sqlpw";
                SqlCommand com = new SqlCommand(slc, con);

                //idのSqlパラメータの作成
                SqlParameter paramid = com.CreateParameter();
                paramid.ParameterName = "@sqlid";
                paramid.SqlDbType = SqlDbType.VarChar;
                paramid.Direction = ParameterDirection.Input;
                com.Parameters.Add(paramid);

                //passwordのSqlパラメーターの作成
                SqlParameter parampsw= com.CreateParameter();
                parampsw.ParameterName = "@sqlpw";
                parampsw.SqlDbType = SqlDbType.VarChar;
                parampsw.Direction = ParameterDirection.Input;
                com.Parameters.Add(parampsw);

                //staffIDとpasswordの読み取り
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read() == true)
                {
             
                      //ひとまずDBが読み取りできてログインできるかどうか
                   if (id == @sqlid && pw == @sqlpw)
                    {
                        MessageBox.Show("成功", "ログイン", MessageBoxButtons.OK); 
                    }
                }
               
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                con.Dispose();
                con.Close();
            }

           

    }
    }
}


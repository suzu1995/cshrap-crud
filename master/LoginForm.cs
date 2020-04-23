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
            string constr = @"Data Source = JBH4QJM\SQLEXPRESS; Initial Catalog = Staff; Integrated Security = True";

            //DB接続の準備
            SqlConnection con = new SqlConnection(constr);



            try
            {
                //DB接続開始
                con.Open();

                //実行したいSQL文に引数を与えてSqlオブジェクトの作成
                string slc = "select * from M_Stuff";
                SqlCommand com = new SqlCommand(slc, con);

                //staffIDとpasswordの読み取り
                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read() == true)
                {
                    string Id = (string)sdr["Staff_ID"];
                    string Psw = (string)sdr["Staff_Password"];
                    if (id == Id && pw == Psw)
                    {
                        MessageBox.Show("成功", "ログイン", MessageBoxButtons.OK); 
                    }
                }
               
            }

            catch (Exception)
            {

            }
            finally
            {

                con.Dispose();
                con.Close();
            }

           

    }
    }
}


﻿using System;
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
            string txtid = Idtxt.Text;
            string txtpw = passtxt.Text;

            //接続文字列の取得
            string constr = "Data Source=DESKTOP-JBH4QJM\\SQLEXPRESS;Initial Catalog=Staff;Integrated Security=True";

            //DB接続の準備
            SqlConnection con = new SqlConnection(constr);



            try
            {
                //DB接続開始
                con.Open();

                //実行したいSQL文に引数を与えてSqlオブジェクトの作成

                string slc = @"select count (*) from M_Staff where Staff_ID=@id AND Staff_Password=@pw";
                SqlCommand com = new SqlCommand(slc, con);




                //stringなので文字列として準備して実行する必要がある

                //idのSqlパラメータの作成
                SqlParameter paramid = new SqlParameter("@id", SqlDbType.VarChar);
                paramid.Value = "TES0010021";


                //passwordのSqlパラメーターの作成
                SqlParameter parampw = new SqlParameter("@pw", SqlDbType.VarChar);
                parampw.Value = "password";

                com.Parameters.Add(paramid);
                com.Parameters.Add(parampw);




                int num = (int)com.ExecuteScalar();


                //条件分岐
                
                    if (num > 1)

                    {
                    MessageBox.Show("成功", "ログイン", MessageBoxButtons.OK);
                    }

                    else if (string.IsNullOrEmpty(txtid)&&string.IsNullOrEmpty(txtpw))
                    {
                        MessageBox.Show("社員IDおよびパスワードが未入力です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else if (string.IsNullOrEmpty(txtid))
                    {
                        MessageBox.Show("社員IDが未入力です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else if (string.IsNullOrEmpty(txtpw))
                    {
                        MessageBox.Show("パスワードが未入力です。", "エラー", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show
                            ("社員IDもしくはパスワードが間違っているためログインできません。再度入力してください。" +
                            "", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
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


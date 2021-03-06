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
            //テキストボックスオブジェクト化
            string txtid = this.Idtxt.Text;
            string txtpw = this.passtxt.Text;

            //未入力の処理
            //パスワード・IDともに未入力
            if (string.IsNullOrEmpty(txtid) && string.IsNullOrEmpty(txtpw))
            {
                MessageBox.Show("社員IDおよびパスワードが未入力です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //ID未入力
            else if (string.IsNullOrEmpty(txtid))
            {
                MessageBox.Show("社員IDが未入力です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //パスワード未入力
            else if (string.IsNullOrEmpty(txtpw))

            {
                MessageBox.Show("パスワードが未入力です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            //接続文字列の取得
            string constr = "Data Source=DESKTOP-JBH4QJM\\SQLEXPRESS;Initial Catalog=Staff;Integrated Security=True";



            //DB接続の準備
           
                SqlConnection con = new SqlConnection(constr);





            try
            {      
                //DB接続開始
                con.Open();

                //実行したいSQL文に引数を与えてSqlオブジェクトの作成

               //IDとパスワードのレコード件数を取得
                string sql = "SELECT COUNT (*) FROM M_Staff WHERE Staff_ID= @id AND Staff_Password = @pw ";
                      


                SqlCommand com = new SqlCommand(sql, con);

                //IDとパスワードのパラメータ化
                SqlParameter paramid = new SqlParameter( "@id" , SqlDbType.VarChar, 10);
                paramid.Value = txtid;
                
                SqlParameter parampw = new SqlParameter( "@pw" , SqlDbType.VarChar, 10);
                parampw.Value = txtpw;

                com.Parameters.Add(paramid);
                com.Parameters.Add(parampw);
                com.Prepare();

               

                //入力されたIDとパスワードがレコードに存在するか読み取る
                int num = (int)com.ExecuteScalar();

                //条件分岐
                //件数なし
                if (num == 0)

                {
                    MessageBox.Show
                             ("社員IDもしくはパスワードが間違っているためログインできません。再度入力してください。" +
                             "", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                   //レコード件数あり
                    else
                    {
                    this.Hide();　　//画面を閉じる

                    Main_menu main = new Main_menu();
                    // メインメニューを表示
                    main.ShowDialog();
                   

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


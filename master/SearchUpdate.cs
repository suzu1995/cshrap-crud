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

        private void txtdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)　//検索画面


        {
            string txtid = this.txtid.Text;　　//IDオブジェクト化
            //IDが未入力の表示
            if (string.IsNullOrEmpty(txtid))
            {
                MessageBox.Show("商品コードが未入力です。");
                return;
            }

            //DBの接続文字列
            string constr = "Data Source=DESKTOP-JBH4QJM\\SQLEXPRESS;Initial Catalog=Product;Integrated Security=True";

            SqlConnection con = new SqlConnection(constr);


            try
            {
                con.Open();  //SQLとの接続開始

                //@idのID、Name、Val、Dateを取得
                string sql = "SELECT Product_ID,Product_name,Product_Val,insert_date FROM M_Product WHERE Product_ID =  @id ";
                SqlCommand com = new SqlCommand(sql, con);

                //IDのパラメータ化
                SqlParameter paramid = new SqlParameter( "@id" , SqlDbType.VarChar, 8);
                paramid.Value = txtid;
                com.Parameters.Add(paramid);
                com.Prepare();

                //DBの読み取り
                SqlDataReader sdr = com.ExecuteReader();
                if (sdr.Read())　　//もし読み込めたら、、、
                {
                    string id = (string)sdr["Product_ID"];　　　　　//それぞれのテキストボックスに値を表示
                    string name = (string)sdr["Product_Name"];
                    long val = (long)sdr["Product_Val"];
                    DateTime date = (DateTime)sdr["insert_date"];

                    //テキストボックスのオブジェクト
                    txtid = id;　　　　
                    txtname.Text = name;
                    txtval.Text = val.ToString();
                    txtdate.Text = date.ToString("yyyy/MM/dd");

                }

                else
                {　　//IDが見つからなかった場合
                    MessageBox.Show("該当する商品が見つかりません。");
                    return;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void clearForm(bool clearAll)
        {


            // 入力欄をクリア
            this.txtname.Text = "";
            this.txtval.Text = "";
            this.txtdate.Text = "";
            if (clearAll)
            {
                // 検索条件欄も
                this.txtid.Text = "";
            }
        }

            private void button2_Click(object sender, EventArgs e)　//更新画面
        {
            string txtid = this.txtid.Text;　　　　//テキストボックスのオブジェクト化
            string txtname = this.txtname.Text;
            string txtval = this.txtval.Text;
            string txtdate = this.txtdate.Text;

            //接続文字列
            string constr = "Data Source=DESKTOP-JBH4QJM\\SQLEXPRESS;Initial Catalog=Product;Integrated Security=True";

            SqlConnection con = new SqlConnection(constr);


            try
            {
                con.Open();　//DB接続開始

                //IDをもとに名前、値段、日付を更新するSQL文
                string sql = "UPDATE M_Product SET Product_name = @name,Product_Val= @val,insert_date = @date" +
                             "  WHERE Product_ID =  @id ";
                SqlCommand com = new SqlCommand(sql, con);

                //ID、名前、値段、日付それぞれパラメータ化
                SqlParameter paramid = new SqlParameter("@id", SqlDbType.VarChar, 8);
                paramid.Value = txtid;
               

                SqlParameter paramname = new SqlParameter("@name", SqlDbType.VarChar, 50);
                paramname.Value = txtname;
                
                

                SqlParameter paramval = new SqlParameter("@val", SqlDbType.BigInt);
                paramval.Value = txtval;
               
                

                SqlParameter paramdate = new SqlParameter("@date", SqlDbType.Date);
                paramdate.Value = txtdate;
               

                com.Parameters.Add(paramid);
                com.Parameters.Add(paramname);
                com.Parameters.Add(paramval);
                com.Parameters.Add(paramdate);

                com.Prepare(); 

                //DB読み取り
                com.ExecuteNonQuery();
               
                {
                    DateTime dt = DateTime.Now;　　　　　　//現在の日付（年月日）での更新
                    txtdate += dt.ToString("d") + "/r/n";
                    this.clearForm(true);　　　　　　　　　//入力項目の削除


                    MessageBox.Show("完了しました。");
                   
                    return;

                }

               
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //戻るボタン
            this.Close();
            this.Hide();
            Main_menu main = new Main_menu();
           
            main.ShowDialog();
        }
    }
    }

       
    
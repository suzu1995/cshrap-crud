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
                    string id = (string)sdr["Product_ID"];
                    string name = (string)sdr["Product_Name"];
                    long val = (long)sdr["Product_Val"];
                    DateTime date = (DateTime)sdr["insert_date"];


                    txtid = id;
                    txtname.Text = name;
                    txtval.Text = val.ToString();
                    txtdate.Text = date.ToString("yyyy/MM/dd");

                }

                else
                {
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

            private void button2_Click(object sender, EventArgs e)
        {
            string txtid = this.txtid.Text;
            string txtname = this.txtname.Text;
            string txtval = this.txtval.Text;
            string txtdate = this.txtdate.Text;

            string constr = "Data Source=DESKTOP-JBH4QJM\\SQLEXPRESS;Initial Catalog=Product;Integrated Security=True";

            SqlConnection con = new SqlConnection(constr);


            try
            {
                con.Open();

                string sql = "UPDATE M_Product SET Product_name = @name,Product_Val= @val,insert_date = @date" +
                             "  WHERE Product_ID =  @id ";
                SqlCommand com = new SqlCommand(sql, con);

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

                com.ExecuteNonQuery();
               
                {
                    DateTime dt = DateTime.Now;
                    txtdate += dt.ToString("d") + "/r/n";
                    this.clearForm(true);


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

    }
    }

       
    
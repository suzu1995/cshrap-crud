using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace master
{
    public partial class Main_menu : Form
    {
        public Main_menu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            // 検索画面のインスタンスを生成
            SearchUpdate search = new SearchUpdate();
            // 検索画面を表示
            search.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            // 検索画面のインスタンスを生成
           CreateNew create= new CreateNew();
            // 検索画面を表示
            create.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}

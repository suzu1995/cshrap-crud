namespace master
{
    partial class CreateNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcreateid = new System.Windows.Forms.TextBox();
            this.txtcreatename = new System.Windows.Forms.TextBox();
            this.txtcreateval = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品コード";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "商品名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "単価";
            // 
            // txtcreateid
            // 
            this.txtcreateid.Location = new System.Drawing.Point(102, 22);
            this.txtcreateid.Name = "txtcreateid";
            this.txtcreateid.Size = new System.Drawing.Size(131, 19);
            this.txtcreateid.TabIndex = 3;
            // 
            // txtcreatename
            // 
            this.txtcreatename.Location = new System.Drawing.Point(102, 47);
            this.txtcreatename.Name = "txtcreatename";
            this.txtcreatename.Size = new System.Drawing.Size(131, 19);
            this.txtcreatename.TabIndex = 4;
            // 
            // txtcreateval
            // 
            this.txtcreateval.Location = new System.Drawing.Point(102, 72);
            this.txtcreateval.Name = "txtcreateval";
            this.txtcreateval.Size = new System.Drawing.Size(131, 19);
            this.txtcreateval.TabIndex = 5;
            this.txtcreateval.TextChanged += new System.EventHandler(this.txtcreateval_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "新規登録";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(153, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "戻る";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CreateNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 140);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtcreateval);
            this.Controls.Add(this.txtcreatename);
            this.Controls.Add(this.txtcreateid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateNew";
            this.Text = "商品マスタメンテナンス";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcreateid;
        private System.Windows.Forms.TextBox txtcreatename;
        private System.Windows.Forms.TextBox txtcreateval;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
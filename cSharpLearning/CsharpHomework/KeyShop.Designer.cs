
namespace MagicTower
{
    partial class KeyShop
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.yellow_key = new System.Windows.Forms.Button();
            this.blue_key = new System.Windows.Forms.Button();
            this.red_key = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlText;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.125F);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(89, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(498, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择您要购买的物品：";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // yellow_key
            // 
            this.yellow_key.BackColor = System.Drawing.SystemColors.ControlText;
            this.yellow_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.yellow_key.ForeColor = System.Drawing.SystemColors.Control;
            this.yellow_key.Location = new System.Drawing.Point(99, 175);
            this.yellow_key.Name = "yellow_key";
            this.yellow_key.Size = new System.Drawing.Size(487, 64);
            this.yellow_key.TabIndex = 1;
            this.yellow_key.Text = "黄钥匙                   10金币/个";
            this.yellow_key.UseVisualStyleBackColor = false;
            this.yellow_key.Click += new System.EventHandler(this.yellow_key_Click);
            // 
            // blue_key
            // 
            this.blue_key.BackColor = System.Drawing.SystemColors.ControlText;
            this.blue_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.blue_key.ForeColor = System.Drawing.SystemColors.Control;
            this.blue_key.Location = new System.Drawing.Point(99, 303);
            this.blue_key.Name = "blue_key";
            this.blue_key.Size = new System.Drawing.Size(487, 64);
            this.blue_key.TabIndex = 2;
            this.blue_key.Text = "蓝钥匙                   50金币/个";
            this.blue_key.UseVisualStyleBackColor = false;
            this.blue_key.Click += new System.EventHandler(this.blue_key_Click);
            // 
            // red_key
            // 
            this.red_key.BackColor = System.Drawing.SystemColors.ControlText;
            this.red_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.red_key.ForeColor = System.Drawing.SystemColors.Control;
            this.red_key.Location = new System.Drawing.Point(99, 437);
            this.red_key.Name = "red_key";
            this.red_key.Size = new System.Drawing.Size(487, 64);
            this.red_key.TabIndex = 3;
            this.red_key.Text = "红钥匙                   100金币/个";
            this.red_key.UseVisualStyleBackColor = false;
            this.red_key.Click += new System.EventHandler(this.red_key_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.125F);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(689, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 57);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlText;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(100, 571);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(487, 64);
            this.button1.TabIndex = 5;
            this.button1.Text = "退出商店";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.125F);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(689, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 57);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // KeyShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1142, 724);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.red_key);
            this.Controls.Add(this.blue_key);
            this.Controls.Add(this.yellow_key);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KeyShop";
            this.ShowInTaskbar = false;
            this.Text = "商店";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form6_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button yellow_key;
        private System.Windows.Forms.Button blue_key;
        private System.Windows.Forms.Button red_key;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
    }
}
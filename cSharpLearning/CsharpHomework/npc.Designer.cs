namespace MagicTower
{
    partial class npc
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
            this.button_LeveUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Attack = new System.Windows.Forms.Button();
            this.button_defence = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_LeveUp
            // 
            this.button_LeveUp.BackColor = System.Drawing.SystemColors.ControlText;
            this.button_LeveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_LeveUp.ForeColor = System.Drawing.SystemColors.Control;
            this.button_LeveUp.Location = new System.Drawing.Point(58, 181);
            this.button_LeveUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_LeveUp.Name = "button_LeveUp";
            this.button_LeveUp.Size = new System.Drawing.Size(602, 67);
            this.button_LeveUp.TabIndex = 0;
            this.button_LeveUp.Text = "提升一级（需要100点）";
            this.button_LeveUp.UseVisualStyleBackColor = false;
            this.button_LeveUp.Click += new System.EventHandler(this.LevelUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.125F);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(50, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(713, 114);
            this.label1.TabIndex = 4;
            this.label1.Text = "你好，英雄的人类，只要你有足够\r\n的经验，我就可以让你变得更强大：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button_Attack
            // 
            this.button_Attack.BackColor = System.Drawing.SystemColors.ControlText;
            this.button_Attack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_Attack.ForeColor = System.Drawing.SystemColors.Control;
            this.button_Attack.Location = new System.Drawing.Point(58, 290);
            this.button_Attack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Attack.Name = "button_Attack";
            this.button_Attack.Size = new System.Drawing.Size(602, 67);
            this.button_Attack.TabIndex = 5;
            this.button_Attack.Text = "增加攻击5（需要30点）";
            this.button_Attack.UseVisualStyleBackColor = false;
            this.button_Attack.Click += new System.EventHandler(this.Attack);
            // 
            // button_defence
            // 
            this.button_defence.BackColor = System.Drawing.SystemColors.ControlText;
            this.button_defence.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_defence.ForeColor = System.Drawing.SystemColors.Control;
            this.button_defence.Location = new System.Drawing.Point(58, 398);
            this.button_defence.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_defence.Name = "button_defence";
            this.button_defence.Size = new System.Drawing.Size(602, 67);
            this.button_defence.TabIndex = 6;
            this.button_defence.Text = "增加防御5（需要30点）";
            this.button_defence.UseVisualStyleBackColor = false;
            this.button_defence.Click += new System.EventHandler(this.Defence);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ControlText;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button4.ForeColor = System.Drawing.SystemColors.Control;
            this.button4.Location = new System.Drawing.Point(58, 507);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(602, 67);
            this.button4.TabIndex = 7;
            this.button4.Text = "离开";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // npc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(740, 643);
            this.ControlBox = false;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button_defence);
            this.Controls.Add(this.button_Attack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_LeveUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "npc";
            this.ShowInTaskbar = false;
            this.Text = "npc";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.npc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_LeveUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Attack;
        private System.Windows.Forms.Button button_defence;
        private System.Windows.Forms.Button button4;
    }
}
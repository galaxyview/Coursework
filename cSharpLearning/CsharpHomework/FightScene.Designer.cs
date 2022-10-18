
namespace MagicTower
{
    partial class FightScene
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_MonsterBlood = new System.Windows.Forms.Label();
            this.label_MonsterAttack = new System.Windows.Forms.Label();
            this.label_MonsterDefence = new System.Windows.Forms.Label();
            this.label_HeroBlood = new System.Windows.Forms.Label();
            this.label_HeroAttack = new System.Windows.Forms.Label();
            this.label_HeroDefence = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox_Detail = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(44, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
       
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::MagicTower.Properties.Resources._1_67;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(703, 54);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 128);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("楷体", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(63, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 43);
            this.label1.TabIndex = 2;
            this.label1.Text = "怪物";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("楷体", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(701, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 43);
            this.label2.TabIndex = 3;
            this.label2.Text = "勇士";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Gabriola", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(416, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 128);
            this.label3.TabIndex = 4;
            this.label3.Text = "vs";
           
            // 
            // label_MonsterBlood
            // 
            this.label_MonsterBlood.BackColor = System.Drawing.Color.Transparent;
            this.label_MonsterBlood.Font = new System.Drawing.Font("等线", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_MonsterBlood.ForeColor = System.Drawing.Color.White;
            this.label_MonsterBlood.Location = new System.Drawing.Point(226, 54);
            this.label_MonsterBlood.Name = "label_MonsterBlood";
            this.label_MonsterBlood.Size = new System.Drawing.Size(184, 31);
            this.label_MonsterBlood.TabIndex = 5;
            this.label_MonsterBlood.Text = "生命值：";
            // 
            // label_MonsterAttack
            // 
            this.label_MonsterAttack.BackColor = System.Drawing.Color.Transparent;
            this.label_MonsterAttack.Font = new System.Drawing.Font("等线", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_MonsterAttack.ForeColor = System.Drawing.Color.White;
            this.label_MonsterAttack.Location = new System.Drawing.Point(226, 124);
            this.label_MonsterAttack.Name = "label_MonsterAttack";
            this.label_MonsterAttack.Size = new System.Drawing.Size(184, 31);
            this.label_MonsterAttack.TabIndex = 6;
            this.label_MonsterAttack.Text = "攻击力:";
            // 
            // label_MonsterDefence
            // 
            this.label_MonsterDefence.BackColor = System.Drawing.Color.Transparent;
            this.label_MonsterDefence.Font = new System.Drawing.Font("等线", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_MonsterDefence.ForeColor = System.Drawing.Color.White;
            this.label_MonsterDefence.Location = new System.Drawing.Point(226, 197);
            this.label_MonsterDefence.Name = "label_MonsterDefence";
            this.label_MonsterDefence.Size = new System.Drawing.Size(184, 31);
            this.label_MonsterDefence.TabIndex = 7;
            this.label_MonsterDefence.Text = "防御力:";
            // 
            // label_HeroBlood
            // 
            this.label_HeroBlood.BackColor = System.Drawing.Color.Transparent;
            this.label_HeroBlood.Font = new System.Drawing.Font("等线", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_HeroBlood.ForeColor = System.Drawing.Color.White;
            this.label_HeroBlood.Location = new System.Drawing.Point(507, 54);
            this.label_HeroBlood.Name = "label_HeroBlood";
            this.label_HeroBlood.Size = new System.Drawing.Size(167, 31);
            this.label_HeroBlood.TabIndex = 8;
            this.label_HeroBlood.Text = ":生命值";
            this.label_HeroBlood.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_HeroAttack
            // 
            this.label_HeroAttack.BackColor = System.Drawing.Color.Transparent;
            this.label_HeroAttack.Font = new System.Drawing.Font("等线", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_HeroAttack.ForeColor = System.Drawing.Color.White;
            this.label_HeroAttack.Location = new System.Drawing.Point(513, 124);
            this.label_HeroAttack.Name = "label_HeroAttack";
            this.label_HeroAttack.Size = new System.Drawing.Size(161, 31);
            this.label_HeroAttack.TabIndex = 9;
            this.label_HeroAttack.Text = ":攻击力";
            this.label_HeroAttack.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_HeroDefence
            // 
            this.label_HeroDefence.BackColor = System.Drawing.Color.Transparent;
            this.label_HeroDefence.Font = new System.Drawing.Font("等线", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_HeroDefence.ForeColor = System.Drawing.Color.White;
            this.label_HeroDefence.Location = new System.Drawing.Point(513, 197);
            this.label_HeroDefence.Name = "label_HeroDefence";
            this.label_HeroDefence.Size = new System.Drawing.Size(161, 31);
            this.label_HeroDefence.TabIndex = 10;
            this.label_HeroDefence.Text = ":防御力";
            this.label_HeroDefence.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox_Detail
            // 
            this.textBox_Detail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.textBox_Detail.ForeColor = System.Drawing.Color.White;
            this.textBox_Detail.Location = new System.Drawing.Point(71, 266);
            this.textBox_Detail.Multiline = true;
            this.textBox_Detail.Name = "textBox_Detail";
            this.textBox_Detail.Size = new System.Drawing.Size(760, 72);
            this.textBox_Detail.TabIndex = 12;
            // 
            // FightScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MagicTower.Properties.Resources._1_166;
            this.ClientSize = new System.Drawing.Size(881, 343);
            this.Controls.Add(this.textBox_Detail);
            this.Controls.Add(this.label_HeroDefence);
            this.Controls.Add(this.label_HeroAttack);
            this.Controls.Add(this.label_HeroBlood);
            this.Controls.Add(this.label_MonsterDefence);
            this.Controls.Add(this.label_MonsterAttack);
            this.Controls.Add(this.label_MonsterBlood);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FightScene";
            this.Text = "FightScene";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FightScene_FormClosed);
            this.Load += new System.EventHandler(this.FightScene_Load);
         
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_MonsterBlood;
        private System.Windows.Forms.Label label_MonsterAttack;
        private System.Windows.Forms.Label label_MonsterDefence;
        private System.Windows.Forms.Label label_HeroBlood;
        private System.Windows.Forms.Label label_HeroAttack;
        private System.Windows.Forms.Label label_HeroDefence;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox_Detail;
    }
}
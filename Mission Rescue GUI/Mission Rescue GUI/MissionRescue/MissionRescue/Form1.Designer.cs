
namespace MissionRescue
{
    partial class Form1
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
            this.gameLoop = new System.Windows.Forms.Timer(this.components);
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.healthLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.livesLabel = new System.Windows.Forms.Label();
            this.rEnemyHealthL = new System.Windows.Forms.Label();
            this.vEnemyHealthL = new System.Windows.Forms.Label();
            this.hEnemyHealthL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gameLoop
            // 
            this.gameLoop.Enabled = true;
            this.gameLoop.Interval = 50;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick_Tick);
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.ScoreLabel.Font = new System.Drawing.Font("Bookman Old Style", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.ScoreLabel.Location = new System.Drawing.Point(12, 550);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(129, 31);
            this.ScoreLabel.TabIndex = 0;
            this.ScoreLabel.Text = "Score: 0";
            // 
            // healthLabel
            // 
            this.healthLabel.AutoSize = true;
            this.healthLabel.BackColor = System.Drawing.Color.Transparent;
            this.healthLabel.Font = new System.Drawing.Font("Bookman Old Style", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthLabel.ForeColor = System.Drawing.Color.White;
            this.healthLabel.Location = new System.Drawing.Point(1080, 550);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(219, 38);
            this.healthLabel.TabIndex = 1;
            this.healthLabel.Text = "Health: 100";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::MissionRescue.Properties.Resources.heart;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(963, 550);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 35);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // livesLabel
            // 
            this.livesLabel.AutoSize = true;
            this.livesLabel.BackColor = System.Drawing.Color.Transparent;
            this.livesLabel.Font = new System.Drawing.Font("Bookman Old Style", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.livesLabel.ForeColor = System.Drawing.Color.White;
            this.livesLabel.Location = new System.Drawing.Point(841, 550);
            this.livesLabel.Name = "livesLabel";
            this.livesLabel.Size = new System.Drawing.Size(122, 31);
            this.livesLabel.TabIndex = 3;
            this.livesLabel.Text = "Lives: 3";
            // 
            // rEnemyHealthL
            // 
            this.rEnemyHealthL.AutoSize = true;
            this.rEnemyHealthL.BackColor = System.Drawing.Color.Transparent;
            this.rEnemyHealthL.Font = new System.Drawing.Font("Bookman Old Style", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rEnemyHealthL.ForeColor = System.Drawing.Color.White;
            this.rEnemyHealthL.Location = new System.Drawing.Point(396, 550);
            this.rEnemyHealthL.Name = "rEnemyHealthL";
            this.rEnemyHealthL.Size = new System.Drawing.Size(210, 31);
            this.rEnemyHealthL.TabIndex = 4;
            this.rEnemyHealthL.Text = "R-Health: 100";
            // 
            // vEnemyHealthL
            // 
            this.vEnemyHealthL.AutoSize = true;
            this.vEnemyHealthL.BackColor = System.Drawing.Color.Transparent;
            this.vEnemyHealthL.Font = new System.Drawing.Font("Bookman Old Style", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vEnemyHealthL.ForeColor = System.Drawing.Color.White;
            this.vEnemyHealthL.Location = new System.Drawing.Point(182, 550);
            this.vEnemyHealthL.Name = "vEnemyHealthL";
            this.vEnemyHealthL.Size = new System.Drawing.Size(208, 31);
            this.vEnemyHealthL.TabIndex = 5;
            this.vEnemyHealthL.Text = "V-Health: 100";
            // 
            // hEnemyHealthL
            // 
            this.hEnemyHealthL.AutoSize = true;
            this.hEnemyHealthL.BackColor = System.Drawing.Color.Transparent;
            this.hEnemyHealthL.Font = new System.Drawing.Font("Bookman Old Style", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hEnemyHealthL.ForeColor = System.Drawing.Color.White;
            this.hEnemyHealthL.Location = new System.Drawing.Point(612, 550);
            this.hEnemyHealthL.Name = "hEnemyHealthL";
            this.hEnemyHealthL.Size = new System.Drawing.Size(212, 31);
            this.hEnemyHealthL.TabIndex = 6;
            this.hEnemyHealthL.Text = "H-Health: 100";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1367, 610);
            this.Controls.Add(this.hEnemyHealthL);
            this.Controls.Add(this.vEnemyHealthL);
            this.Controls.Add(this.rEnemyHealthL);
            this.Controls.Add(this.livesLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.healthLabel);
            this.Controls.Add(this.ScoreLabel);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(1217, 636);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label healthLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label livesLabel;
        private System.Windows.Forms.Label rEnemyHealthL;
        private System.Windows.Forms.Label vEnemyHealthL;
        private System.Windows.Forms.Label hEnemyHealthL;
    }
}


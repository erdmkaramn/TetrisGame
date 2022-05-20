namespace Tetris
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
            this.label3 = new System.Windows.Forms.Label();
            this.sonrakiPicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cercevePictureBx = new System.Windows.Forms.PictureBox();
            this.puanLbl = new System.Windows.Forms.Label();
            this.puanTimer = new System.Windows.Forms.Timer(this.components);
            this.baslatBtn = new System.Windows.Forms.Button();
            this.yenidenBaslatBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sonrakiPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cercevePictureBx)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(467, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Gelecek Taş:";
            // 
            // sonrakiPicture
            // 
            this.sonrakiPicture.BackColor = System.Drawing.SystemColors.Menu;
            this.sonrakiPicture.Location = new System.Drawing.Point(455, 382);
            this.sonrakiPicture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sonrakiPicture.Name = "sonrakiPicture";
            this.sonrakiPicture.Size = new System.Drawing.Size(176, 144);
            this.sonrakiPicture.TabIndex = 7;
            this.sonrakiPicture.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(430, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Puanınız:";
            // 
            // cercevePictureBx
            // 
            this.cercevePictureBx.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cercevePictureBx.Location = new System.Drawing.Point(21, 30);
            this.cercevePictureBx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cercevePictureBx.Name = "cercevePictureBx";
            this.cercevePictureBx.Size = new System.Drawing.Size(403, 496);
            this.cercevePictureBx.TabIndex = 4;
            this.cercevePictureBx.TabStop = false;
            // 
            // puanLbl
            // 
            this.puanLbl.AutoSize = true;
            this.puanLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.puanLbl.ForeColor = System.Drawing.SystemColors.Desktop;
            this.puanLbl.Location = new System.Drawing.Point(528, 30);
            this.puanLbl.Name = "puanLbl";
            this.puanLbl.Size = new System.Drawing.Size(0, 25);
            this.puanLbl.TabIndex = 6;
            // 
            // puanTimer
            // 
            this.puanTimer.Interval = 1000;
            this.puanTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // baslatBtn
            // 
            this.baslatBtn.Location = new System.Drawing.Point(455, 73);
            this.baslatBtn.Margin = new System.Windows.Forms.Padding(4);
            this.baslatBtn.Name = "baslatBtn";
            this.baslatBtn.Size = new System.Drawing.Size(143, 132);
            this.baslatBtn.TabIndex = 9;
            this.baslatBtn.Text = "Oyunu Başlat";
            this.baslatBtn.UseVisualStyleBackColor = true;
            this.baslatBtn.Click += new System.EventHandler(this.baslatBtn_Click);
            // 
            // yenidenBaslatBtn
            // 
            this.yenidenBaslatBtn.Location = new System.Drawing.Point(455, 213);
            this.yenidenBaslatBtn.Margin = new System.Windows.Forms.Padding(4);
            this.yenidenBaslatBtn.Name = "yenidenBaslatBtn";
            this.yenidenBaslatBtn.Size = new System.Drawing.Size(143, 133);
            this.yenidenBaslatBtn.TabIndex = 10;
            this.yenidenBaslatBtn.Text = "Oyunu Yenile";
            this.yenidenBaslatBtn.UseVisualStyleBackColor = true;
            this.yenidenBaslatBtn.Click += new System.EventHandler(this.yenidenBaslatBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 538);
            this.Controls.Add(this.yenidenBaslatBtn);
            this.Controls.Add(this.baslatBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sonrakiPicture);
            this.Controls.Add(this.puanLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cercevePictureBx);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris";
            ((System.ComponentModel.ISupportInitialize)(this.sonrakiPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cercevePictureBx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox sonrakiPicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox cercevePictureBx;
        private System.Windows.Forms.Label puanLbl;
        private System.Windows.Forms.Timer puanTimer;
        private System.Windows.Forms.Button baslatBtn;
        private System.Windows.Forms.Button yenidenBaslatBtn;
    }
}


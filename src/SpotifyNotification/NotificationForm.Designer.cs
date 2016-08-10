namespace SpotifyNotification
{
    partial class NotificationForm
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
            this.lbl_artist = new System.Windows.Forms.Label();
            this.lbl_song = new System.Windows.Forms.Label();
            this.pic_logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_artist
            // 
            this.lbl_artist.AutoSize = true;
            this.lbl_artist.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_artist.ForeColor = System.Drawing.Color.White;
            this.lbl_artist.Location = new System.Drawing.Point(60, 13);
            this.lbl_artist.Name = "lbl_artist";
            this.lbl_artist.Size = new System.Drawing.Size(61, 17);
            this.lbl_artist.TabIndex = 0;
            this.lbl_artist.Text = "lbl_artist";
            this.lbl_artist.Click += new System.EventHandler(this.UI_Click);
            // 
            // lbl_song
            // 
            this.lbl_song.AutoSize = true;
            this.lbl_song.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_song.ForeColor = System.Drawing.Color.White;
            this.lbl_song.Location = new System.Drawing.Point(60, 30);
            this.lbl_song.Name = "lbl_song";
            this.lbl_song.Size = new System.Drawing.Size(56, 17);
            this.lbl_song.TabIndex = 1;
            this.lbl_song.Text = "lbl_song";
            this.lbl_song.Click += new System.EventHandler(this.UI_Click);
            // 
            // pic_logo
            // 
            this.pic_logo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_logo.Image = global::SpotifyNotification.Properties.Resources.Logo1;
            this.pic_logo.Location = new System.Drawing.Point(10, 10);
            this.pic_logo.Name = "pic_logo";
            this.pic_logo.Size = new System.Drawing.Size(40, 40);
            this.pic_logo.TabIndex = 2;
            this.pic_logo.TabStop = false;
            this.pic_logo.Click += new System.EventHandler(this.pic_logo_Click);
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(368, 60);
            this.Controls.Add(this.pic_logo);
            this.Controls.Add(this.lbl_song);
            this.Controls.Add(this.lbl_artist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NotificationForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "artist - song";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.NotificationForm_Shown);
            this.Click += new System.EventHandler(this.UI_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_artist;
        private System.Windows.Forms.Label lbl_song;
        private System.Windows.Forms.PictureBox pic_logo;

    }
}


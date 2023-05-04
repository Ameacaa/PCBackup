namespace C__Backup
{
    partial class BackupDialog
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
            this.prgsBackup = new System.Windows.Forms.ProgressBar();
            this.prgsActual = new System.Windows.Forms.ProgressBar();
            this.txtFromDir = new System.Windows.Forms.Label();
            this.txtToDir = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // prgsBackup
            // 
            this.prgsBackup.Location = new System.Drawing.Point(16, 165);
            this.prgsBackup.Name = "prgsBackup";
            this.prgsBackup.Size = new System.Drawing.Size(560, 10);
            this.prgsBackup.TabIndex = 1;
            // 
            // prgsActual
            // 
            this.prgsActual.Location = new System.Drawing.Point(16, 146);
            this.prgsActual.Name = "prgsActual";
            this.prgsActual.Size = new System.Drawing.Size(278, 10);
            this.prgsActual.TabIndex = 3;
            // 
            // txtFromDir
            // 
            this.txtFromDir.AutoSize = true;
            this.txtFromDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDir.Location = new System.Drawing.Point(13, 13);
            this.txtFromDir.Margin = new System.Windows.Forms.Padding(4);
            this.txtFromDir.Name = "txtFromDir";
            this.txtFromDir.Size = new System.Drawing.Size(112, 18);
            this.txtFromDir.TabIndex = 2;
            this.txtFromDir.Text = "From Directory:";
            // 
            // txtToDir
            // 
            this.txtToDir.AutoSize = true;
            this.txtToDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToDir.Location = new System.Drawing.Point(13, 39);
            this.txtToDir.Margin = new System.Windows.Forms.Padding(4);
            this.txtToDir.Name = "txtToDir";
            this.txtToDir.Size = new System.Drawing.Size(94, 18);
            this.txtToDir.TabIndex = 5;
            this.txtToDir.Text = "To Directory:";
            // 
            // txtInfo
            // 
            this.txtInfo.AutoSize = true;
            this.txtInfo.Location = new System.Drawing.Point(13, 65);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtInfo.MaximumSize = new System.Drawing.Size(560, 74);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(44, 18);
            this.txtInfo.TabIndex = 6;
            this.txtInfo.Text = "Infos:\r\n";
            // 
            // BackupDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(584, 187);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.txtToDir);
            this.Controls.Add(this.prgsActual);
            this.Controls.Add(this.txtFromDir);
            this.Controls.Add(this.prgsBackup);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BackupDialog";
            this.Text = "BackupDialog";
            this.Load += new System.EventHandler(this.BackupDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar prgsBackup;
        private System.Windows.Forms.ProgressBar prgsActual;
        private System.Windows.Forms.Label txtFromDir;
        private System.Windows.Forms.Label txtToDir;
        private System.Windows.Forms.Label txtInfo;
    }
}
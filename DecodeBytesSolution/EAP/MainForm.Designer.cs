namespace EAP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bgWorker = new System.ComponentModel.BackgroundWorker();
            progressBarItem = new ProgressBar();
            btn_download = new Button();
            SuspendLayout();
            // 
            // bgWorker
            // 
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
            // 
            // progressBarItem
            // 
            progressBarItem.Location = new Point(126, 58);
            progressBarItem.Name = "progressBarItem";
            progressBarItem.Size = new Size(463, 30);
            progressBarItem.TabIndex = 0;
            // 
            // btn_download
            // 
            btn_download.Location = new Point(290, 214);
            btn_download.Name = "btn_download";
            btn_download.Size = new Size(167, 38);
            btn_download.TabIndex = 1;
            btn_download.Text = "Download";
            btn_download.UseVisualStyleBackColor = true;
            btn_download.Click += btn_download_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_download);
            Controls.Add(progressBarItem);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgWorker;
        private ProgressBar progressBarItem;
        private Button btn_download;
    }
}

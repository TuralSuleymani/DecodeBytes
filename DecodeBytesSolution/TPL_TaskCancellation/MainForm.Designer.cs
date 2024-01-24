namespace TPL_TaskCancellation
{
    partial class MainForm
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
            btn_start = new Button();
            btn_cancel = new Button();
            rcbx_text = new RichTextBox();
            SuspendLayout();
            // 
            // btn_start
            // 
            btn_start.Location = new Point(140, 62);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(154, 32);
            btn_start.TabIndex = 0;
            btn_start.Text = "Start";
            btn_start.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(140, 141);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(154, 32);
            btn_cancel.TabIndex = 1;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            // 
            // rcbx_text
            // 
            rcbx_text.Location = new Point(345, 63);
            rcbx_text.Name = "rcbx_text";
            rcbx_text.Size = new Size(400, 280);
            rcbx_text.TabIndex = 2;
            rcbx_text.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 413);
            Controls.Add(rcbx_text);
            Controls.Add(btn_cancel);
            Controls.Add(btn_start);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainForm";
            Text = "MainForm";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_start;
        private Button btn_cancel;
        private RichTextBox rcbx_text;
    }
}

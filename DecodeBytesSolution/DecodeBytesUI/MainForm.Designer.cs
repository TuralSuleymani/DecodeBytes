namespace DecodeBytes.WinForm
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
            grbx_bank = new GroupBox();
            btn_reload = new Button();
            SuspendLayout();
            // 
            // grbx_bank
            // 
            grbx_bank.Location = new Point(29, 38);
            grbx_bank.Name = "grbx_bank";
            grbx_bank.Size = new Size(743, 400);
            grbx_bank.TabIndex = 0;
            grbx_bank.TabStop = false;
            grbx_bank.Text = "Bank Providers";
            // 
            // btn_reload
            // 
            btn_reload.Location = new Point(625, 3);
            btn_reload.Name = "btn_reload";
            btn_reload.Size = new Size(122, 37);
            btn_reload.TabIndex = 1;
            btn_reload.Text = "Reload";
            btn_reload.UseVisualStyleBackColor = true;
            btn_reload.Click += btn_reload_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_reload);
            Controls.Add(grbx_bank);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainForm";
            Text = "DecodeBytesUI";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grbx_bank;
        private Button btn_reload;
    }
}

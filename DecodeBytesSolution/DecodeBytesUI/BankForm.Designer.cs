namespace DecodeBytes.WinForm
{
    partial class BankForm
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
            btn_addToBalance = new Button();
            txbx_cardNumber = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txbx_amount = new TextBox();
            btn_checkBalance = new Button();
            SuspendLayout();
            // 
            // btn_addToBalance
            // 
            btn_addToBalance.Location = new Point(185, 191);
            btn_addToBalance.Name = "btn_addToBalance";
            btn_addToBalance.Size = new Size(159, 35);
            btn_addToBalance.TabIndex = 0;
            btn_addToBalance.Text = "Add to balance";
            btn_addToBalance.UseVisualStyleBackColor = true;
            btn_addToBalance.Click += btn_addToBalance_Click;
            // 
            // txbx_cardNumber
            // 
            txbx_cardNumber.Location = new Point(227, 52);
            txbx_cardNumber.Name = "txbx_cardNumber";
            txbx_cardNumber.Size = new Size(159, 23);
            txbx_cardNumber.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(144, 60);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 2;
            label1.Text = "Card number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(144, 110);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 4;
            label2.Text = "Amount";
            // 
            // txbx_amount
            // 
            txbx_amount.Location = new Point(227, 102);
            txbx_amount.Name = "txbx_amount";
            txbx_amount.Size = new Size(159, 23);
            txbx_amount.TabIndex = 3;
            // 
            // btn_checkBalance
            // 
            btn_checkBalance.Location = new Point(406, 40);
            btn_checkBalance.Name = "btn_checkBalance";
            btn_checkBalance.Size = new Size(108, 35);
            btn_checkBalance.TabIndex = 5;
            btn_checkBalance.Text = "Check Balance";
            btn_checkBalance.UseVisualStyleBackColor = true;
            btn_checkBalance.Click += btnCheckBalance_Click;
            // 
            // BankForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 254);
            Controls.Add(btn_checkBalance);
            Controls.Add(label2);
            Controls.Add(txbx_amount);
            Controls.Add(label1);
            Controls.Add(txbx_cardNumber);
            Controls.Add(btn_addToBalance);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "BankForm";
            Text = "BankForm";
            Load += BankForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_addToBalance;
        private TextBox txbx_cardNumber;
        private Label label1;
        private Label label2;
        private TextBox txbx_amount;
        private Button btn_checkBalance;
    }
}
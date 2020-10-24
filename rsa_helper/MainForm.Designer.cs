namespace rsa_helper
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.firstKeyTextBox = new System.Windows.Forms.MaskedTextBox();
            this.secondKeyTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioEncrypt = new System.Windows.Forms.RadioButton();
            this.radioDecrypt = new System.Windows.Forms.RadioButton();
            this.input = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.TextBox();
            this.processButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(94, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(40, 0, 40, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Алгоритм RSA";
            // 
            // firstKeyTextBox
            // 
            this.firstKeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstKeyTextBox.Location = new System.Drawing.Point(234, 69);
            this.firstKeyTextBox.Mask = "00000";
            this.firstKeyTextBox.Name = "firstKeyTextBox";
            this.firstKeyTextBox.Size = new System.Drawing.Size(56, 29);
            this.firstKeyTextBox.TabIndex = 1;
            this.firstKeyTextBox.ValidatingType = typeof(int);
            this.firstKeyTextBox.TextChanged += new System.EventHandler(this.HandleChangeFirstKey);
            // 
            // secondKeyTextBox
            // 
            this.secondKeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondKeyTextBox.Location = new System.Drawing.Point(234, 105);
            this.secondKeyTextBox.Mask = "00000";
            this.secondKeyTextBox.Name = "secondKeyTextBox";
            this.secondKeyTextBox.Size = new System.Drawing.Size(56, 29);
            this.secondKeyTextBox.TabIndex = 2;
            this.secondKeyTextBox.ValidatingType = typeof(int);
            this.secondKeyTextBox.TextChanged += new System.EventHandler(this.HandleChangeSecondKey);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(96, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Первый ключ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(96, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Второй ключ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "(Например, [53;299] и [5;299])";
            // 
            // radioEncrypt
            // 
            this.radioEncrypt.AutoSize = true;
            this.radioEncrypt.Checked = true;
            this.radioEncrypt.Location = new System.Drawing.Point(94, 166);
            this.radioEncrypt.Name = "radioEncrypt";
            this.radioEncrypt.Size = new System.Drawing.Size(95, 17);
            this.radioEncrypt.TabIndex = 6;
            this.radioEncrypt.TabStop = true;
            this.radioEncrypt.Text = "Зашифровать";
            this.radioEncrypt.UseVisualStyleBackColor = true;
            this.radioEncrypt.CheckedChanged += new System.EventHandler(this.HandleSwitchProcessType);
            // 
            // radioDecrypt
            // 
            this.radioDecrypt.AutoSize = true;
            this.radioDecrypt.Location = new System.Drawing.Point(189, 166);
            this.radioDecrypt.Name = "radioDecrypt";
            this.radioDecrypt.Size = new System.Drawing.Size(101, 17);
            this.radioDecrypt.TabIndex = 7;
            this.radioDecrypt.Text = "Расшифровать";
            this.radioDecrypt.UseVisualStyleBackColor = true;
            this.radioDecrypt.CheckedChanged += new System.EventHandler(this.HandleSwitchProcessType);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(41, 216);
            this.input.Multiline = true;
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(138, 154);
            this.input.TabIndex = 0;
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(211, 216);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(133, 154);
            this.output.TabIndex = 0;
            // 
            // processButton
            // 
            this.processButton.BackColor = System.Drawing.Color.PaleGreen;
            this.processButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.processButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.processButton.Location = new System.Drawing.Point(100, 387);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(190, 38);
            this.processButton.TabIndex = 8;
            this.processButton.Text = "Зашифровать";
            this.processButton.UseVisualStyleBackColor = false;
            this.processButton.Click += new System.EventHandler(this.HandleClickProcessButton);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Исходный текст";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Результат";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // help
            // 
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(65, 20);
            this.help.Text = "Справка";
            this.help.Click += new System.EventHandler(this.HandleClickHelp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 441);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.input);
            this.Controls.Add(this.output);
            this.Controls.Add(this.radioDecrypt);
            this.Controls.Add(this.radioEncrypt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.secondKeyTextBox);
            this.Controls.Add(this.firstKeyTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "RSA";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox firstKeyTextBox;
        private System.Windows.Forms.MaskedTextBox secondKeyTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioEncrypt;
        private System.Windows.Forms.RadioButton radioDecrypt;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem help;
    }
}


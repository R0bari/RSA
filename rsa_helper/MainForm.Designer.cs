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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.processButton = new System.Windows.Forms.Button();
            this.input = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.TextBox();
            this.radioDecrypt = new System.Windows.Forms.RadioButton();
            this.radioEncrypt = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.secondKeyTextBox = new System.Windows.Forms.MaskedTextBox();
            this.firstKeyTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.generateButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.dTextBox = new System.Windows.Forms.TextBox();
            this.eTextBox = new System.Windows.Forms.TextBox();
            this.nTextBox = new System.Windows.Forms.TextBox();
            this.mTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.qTextBox = new System.Windows.Forms.MaskedTextBox();
            this.pTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.help});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(73, 24);
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
            // tabs
            // 
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(384, 441);
            this.tabs.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Moccasin;
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.processButton);
            this.tabPage1.Controls.Add(this.input);
            this.tabPage1.Controls.Add(this.output);
            this.tabPage1.Controls.Add(this.radioDecrypt);
            this.tabPage1.Controls.Add(this.radioEncrypt);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.secondKeyTextBox);
            this.tabPage1.Controls.Add(this.firstKeyTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.menuStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(376, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Шифр";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(282, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Результат";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Исходный текст";
            // 
            // processButton
            // 
            this.processButton.BackColor = System.Drawing.Color.PaleGreen;
            this.processButton.Enabled = false;
            this.processButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.processButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.processButton.Location = new System.Drawing.Point(38, 357);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(303, 38);
            this.processButton.TabIndex = 8;
            this.processButton.Text = "Зашифровать";
            this.processButton.UseVisualStyleBackColor = false;
            this.processButton.Click += new System.EventHandler(this.HandleClickProcessButton);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(38, 197);
            this.input.Multiline = true;
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(138, 154);
            this.input.TabIndex = 6;
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(208, 197);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(133, 154);
            this.output.TabIndex = 7;
            // 
            // radioDecrypt
            // 
            this.radioDecrypt.AutoSize = true;
            this.radioDecrypt.Location = new System.Drawing.Point(208, 161);
            this.radioDecrypt.Name = "radioDecrypt";
            this.radioDecrypt.Size = new System.Drawing.Size(101, 17);
            this.radioDecrypt.TabIndex = 4;
            this.radioDecrypt.Text = "Расшифровать";
            this.radioDecrypt.UseVisualStyleBackColor = true;
            this.radioDecrypt.CheckedChanged += new System.EventHandler(this.HandleSwitchProcessType);
            // 
            // radioEncrypt
            // 
            this.radioEncrypt.AutoSize = true;
            this.radioEncrypt.Checked = true;
            this.radioEncrypt.Location = new System.Drawing.Point(81, 161);
            this.radioEncrypt.Name = "radioEncrypt";
            this.radioEncrypt.Size = new System.Drawing.Size(95, 17);
            this.radioEncrypt.TabIndex = 3;
            this.radioEncrypt.TabStop = true;
            this.radioEncrypt.Text = "Зашифровать";
            this.radioEncrypt.UseVisualStyleBackColor = true;
            this.radioEncrypt.CheckedChanged += new System.EventHandler(this.HandleSwitchProcessType);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "(Например, [7477;3379] и [13;3379])\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(95, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "Второй ключ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(95, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Первый ключ";
            // 
            // secondKeyTextBox
            // 
            this.secondKeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondKeyTextBox.Location = new System.Drawing.Point(233, 108);
            this.secondKeyTextBox.Mask = "00000";
            this.secondKeyTextBox.Name = "secondKeyTextBox";
            this.secondKeyTextBox.Size = new System.Drawing.Size(56, 29);
            this.secondKeyTextBox.TabIndex = 2;
            this.secondKeyTextBox.ValidatingType = typeof(int);
            this.secondKeyTextBox.TextChanged += new System.EventHandler(this.HandleChangeSecondKey);
            // 
            // firstKeyTextBox
            // 
            this.firstKeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstKeyTextBox.Location = new System.Drawing.Point(233, 72);
            this.firstKeyTextBox.Mask = "00000";
            this.firstKeyTextBox.Name = "firstKeyTextBox";
            this.firstKeyTextBox.Size = new System.Drawing.Size(56, 29);
            this.firstKeyTextBox.TabIndex = 1;
            this.firstKeyTextBox.ValidatingType = typeof(int);
            this.firstKeyTextBox.TextChanged += new System.EventHandler(this.HandleChangeFirstKey);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(93, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(40, 0, 40, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Алгоритм RSA";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Moccasin;
            this.tabPage2.Controls.Add(this.generateButton);
            this.tabPage2.Controls.Add(this.resultLabel);
            this.tabPage2.Controls.Add(this.dTextBox);
            this.tabPage2.Controls.Add(this.eTextBox);
            this.tabPage2.Controls.Add(this.nTextBox);
            this.tabPage2.Controls.Add(this.mTextBox);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.qTextBox);
            this.tabPage2.Controls.Add(this.pTextBox);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(376, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Генерация ключей";
            // 
            // generateButton
            // 
            this.generateButton.BackColor = System.Drawing.Color.PaleGreen;
            this.generateButton.Enabled = false;
            this.generateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateButton.Location = new System.Drawing.Point(38, 355);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(303, 38);
            this.generateButton.TabIndex = 34;
            this.generateButton.Text = "Сгенерировать";
            this.generateButton.UseVisualStyleBackColor = false;
            this.generateButton.Click += new System.EventHandler(this.HandleGenerateClick);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultLabel.Location = new System.Drawing.Point(34, 316);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(108, 24);
            this.resultLabel.TabIndex = 33;
            this.resultLabel.Text = "Результат:";
            // 
            // dTextBox
            // 
            this.dTextBox.Location = new System.Drawing.Point(223, 221);
            this.dTextBox.Name = "dTextBox";
            this.dTextBox.ReadOnly = true;
            this.dTextBox.Size = new System.Drawing.Size(71, 20);
            this.dTextBox.TabIndex = 32;
            // 
            // eTextBox
            // 
            this.eTextBox.Location = new System.Drawing.Point(223, 194);
            this.eTextBox.Name = "eTextBox";
            this.eTextBox.ReadOnly = true;
            this.eTextBox.Size = new System.Drawing.Size(71, 20);
            this.eTextBox.TabIndex = 31;
            // 
            // nTextBox
            // 
            this.nTextBox.Location = new System.Drawing.Point(71, 220);
            this.nTextBox.Name = "nTextBox";
            this.nTextBox.ReadOnly = true;
            this.nTextBox.Size = new System.Drawing.Size(71, 20);
            this.nTextBox.TabIndex = 30;
            // 
            // mTextBox
            // 
            this.mTextBox.Location = new System.Drawing.Point(71, 194);
            this.mTextBox.Name = "mTextBox";
            this.mTextBox.ReadOnly = true;
            this.mTextBox.Size = new System.Drawing.Size(71, 20);
            this.mTextBox.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(196, 216);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 24);
            this.label16.TabIndex = 28;
            this.label16.Text = "d";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(196, 189);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 24);
            this.label15.TabIndex = 27;
            this.label15.Text = "e";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(39, 216);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 24);
            this.label14.TabIndex = 26;
            this.label14.Text = "n";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(39, 189);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 24);
            this.label13.TabIndex = 25;
            this.label13.Text = "m";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(34, 258);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(238, 40);
            this.label12.TabIndex = 24;
            this.label12.Text = "[e; n] - открытая пара ключей, \r\n[d; n] - закрытая пара ключей";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(109, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(259, 80);
            this.label11.TabIndex = 23;
            this.label11.Text = "1. m = (p -1) * (q - 1)\r\n2. n = p * q\r\n3. e - такое, что (e ⋅ d) mod (m) = 1\r\n4. " +
    "d - Взаимнопростое с m\r\n";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(11, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 24);
            this.label9.TabIndex = 22;
            this.label9.Text = "q";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(11, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 24);
            this.label10.TabIndex = 21;
            this.label10.Text = "p";
            // 
            // qTextBox
            // 
            this.qTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qTextBox.Location = new System.Drawing.Point(38, 131);
            this.qTextBox.Mask = "00000";
            this.qTextBox.Name = "qTextBox";
            this.qTextBox.Size = new System.Drawing.Size(56, 29);
            this.qTextBox.TabIndex = 20;
            this.qTextBox.ValidatingType = typeof(int);
            this.qTextBox.TextChanged += new System.EventHandler(this.HandleChangeQ);
            // 
            // pTextBox
            // 
            this.pTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pTextBox.Location = new System.Drawing.Point(38, 96);
            this.pTextBox.Mask = "00000";
            this.pTextBox.Name = "pTextBox";
            this.pTextBox.Size = new System.Drawing.Size(56, 29);
            this.pTextBox.TabIndex = 19;
            this.pTextBox.ValidatingType = typeof(int);
            this.pTextBox.TextChanged += new System.EventHandler(this.HandleChangeP);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(115, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Генерация ключей";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(93, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(40, 0, 40, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 31);
            this.label7.TabIndex = 1;
            this.label7.Text = "Алгоритм RSA";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 441);
            this.Controls.Add(this.tabs);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "RSA";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem help;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.RadioButton radioDecrypt;
        private System.Windows.Forms.RadioButton radioEncrypt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox secondKeyTextBox;
        private System.Windows.Forms.MaskedTextBox firstKeyTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox qTextBox;
        private System.Windows.Forms.MaskedTextBox pTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.TextBox dTextBox;
        private System.Windows.Forms.TextBox eTextBox;
        private System.Windows.Forms.TextBox nTextBox;
        private System.Windows.Forms.TextBox mTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
    }
}


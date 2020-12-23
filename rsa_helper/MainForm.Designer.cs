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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.decryptedText = new System.Windows.Forms.TextBox();
            this.encryptedText = new System.Windows.Forms.TextBox();
            this.Исходный = new System.Windows.Forms.Label();
            this.qTextBox = new System.Windows.Forms.TextBox();
            this.pTextBox = new System.Windows.Forms.TextBox();
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
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.secondKeyTextBox = new System.Windows.Forms.TextBox();
            this.firstKeyTextBox = new System.Windows.Forms.TextBox();
            this.maxBlockSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.maxBlockSizeInfo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.processButton = new System.Windows.Forms.Button();
            this.input = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.loadFromFile = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxBlockSize)).BeginInit();
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
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(665, 457);
            this.tabs.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Moccasin;
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.decryptedText);
            this.tabPage2.Controls.Add(this.encryptedText);
            this.tabPage2.Controls.Add(this.Исходный);
            this.tabPage2.Controls.Add(this.qTextBox);
            this.tabPage2.Controls.Add(this.pTextBox);
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
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(657, 431);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Получатель";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PaleGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(371, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(257, 38);
            this.button1.TabIndex = 41;
            this.button1.Text = "Расшифровать";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.HandleClickDecryptButton);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(371, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Расшифрованный текст";
            // 
            // decryptedText
            // 
            this.decryptedText.Location = new System.Drawing.Point(371, 221);
            this.decryptedText.Multiline = true;
            this.decryptedText.Name = "decryptedText";
            this.decryptedText.Size = new System.Drawing.Size(257, 115);
            this.decryptedText.TabIndex = 39;
            // 
            // encryptedText
            // 
            this.encryptedText.Location = new System.Drawing.Point(371, 80);
            this.encryptedText.Multiline = true;
            this.encryptedText.Name = "encryptedText";
            this.encryptedText.Size = new System.Drawing.Size(257, 97);
            this.encryptedText.TabIndex = 38;
            // 
            // Исходный
            // 
            this.Исходный.AutoSize = true;
            this.Исходный.Location = new System.Drawing.Point(368, 64);
            this.Исходный.Name = "Исходный";
            this.Исходный.Size = new System.Drawing.Size(89, 13);
            this.Исходный.TabIndex = 37;
            this.Исходный.Text = "Исходный текст";
            // 
            // qTextBox
            // 
            this.qTextBox.Location = new System.Drawing.Point(71, 104);
            this.qTextBox.Multiline = true;
            this.qTextBox.Name = "qTextBox";
            this.qTextBox.Size = new System.Drawing.Size(244, 35);
            this.qTextBox.TabIndex = 36;
            this.qTextBox.TextChanged += new System.EventHandler(this.HandleChangeQ);
            // 
            // pTextBox
            // 
            this.pTextBox.Location = new System.Drawing.Point(71, 61);
            this.pTextBox.Multiline = true;
            this.pTextBox.Name = "pTextBox";
            this.pTextBox.Size = new System.Drawing.Size(244, 32);
            this.pTextBox.TabIndex = 35;
            this.pTextBox.TextChanged += new System.EventHandler(this.HandleChangeP);
            // 
            // generateButton
            // 
            this.generateButton.BackColor = System.Drawing.Color.PaleGreen;
            this.generateButton.Enabled = false;
            this.generateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateButton.Location = new System.Drawing.Point(38, 355);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(277, 38);
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
            this.dTextBox.Location = new System.Drawing.Point(71, 259);
            this.dTextBox.Multiline = true;
            this.dTextBox.Name = "dTextBox";
            this.dTextBox.ReadOnly = true;
            this.dTextBox.Size = new System.Drawing.Size(244, 32);
            this.dTextBox.TabIndex = 32;
            // 
            // eTextBox
            // 
            this.eTextBox.Location = new System.Drawing.Point(71, 221);
            this.eTextBox.Multiline = true;
            this.eTextBox.Name = "eTextBox";
            this.eTextBox.ReadOnly = true;
            this.eTextBox.Size = new System.Drawing.Size(244, 32);
            this.eTextBox.TabIndex = 31;
            // 
            // nTextBox
            // 
            this.nTextBox.Location = new System.Drawing.Point(71, 183);
            this.nTextBox.Multiline = true;
            this.nTextBox.Name = "nTextBox";
            this.nTextBox.ReadOnly = true;
            this.nTextBox.Size = new System.Drawing.Size(244, 32);
            this.nTextBox.TabIndex = 30;
            // 
            // mTextBox
            // 
            this.mTextBox.Location = new System.Drawing.Point(71, 145);
            this.mTextBox.Multiline = true;
            this.mTextBox.Name = "mTextBox";
            this.mTextBox.ReadOnly = true;
            this.mTextBox.Size = new System.Drawing.Size(244, 32);
            this.mTextBox.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(39, 259);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 24);
            this.label16.TabIndex = 28;
            this.label16.Text = "d";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(39, 221);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 24);
            this.label15.TabIndex = 27;
            this.label15.Text = "e";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(39, 183);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 24);
            this.label14.TabIndex = 26;
            this.label14.Text = "n";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(39, 145);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 24);
            this.label13.TabIndex = 25;
            this.label13.Text = "m";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(39, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 24);
            this.label9.TabIndex = 22;
            this.label9.Text = "q";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(39, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 24);
            this.label10.TabIndex = 21;
            this.label10.Text = "p";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(115, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Генерация ключей";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(93, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(40, 0, 40, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 31);
            this.label7.TabIndex = 1;
            this.label7.Text = "Алгоритм RSA";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Moccasin;
            this.tabPage1.Controls.Add(this.loadFromFile);
            this.tabPage1.Controls.Add(this.secondKeyTextBox);
            this.tabPage1.Controls.Add(this.firstKeyTextBox);
            this.tabPage1.Controls.Add(this.maxBlockSize);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.maxBlockSizeInfo);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.processButton);
            this.tabPage1.Controls.Add(this.input);
            this.tabPage1.Controls.Add(this.output);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.menuStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(657, 431);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Отправитель";
            // 
            // secondKeyTextBox
            // 
            this.secondKeyTextBox.Location = new System.Drawing.Point(61, 86);
            this.secondKeyTextBox.Multiline = true;
            this.secondKeyTextBox.Name = "secondKeyTextBox";
            this.secondKeyTextBox.Size = new System.Drawing.Size(556, 40);
            this.secondKeyTextBox.TabIndex = 29;
            // 
            // firstKeyTextBox
            // 
            this.firstKeyTextBox.Location = new System.Drawing.Point(61, 40);
            this.firstKeyTextBox.Multiline = true;
            this.firstKeyTextBox.Name = "firstKeyTextBox";
            this.firstKeyTextBox.Size = new System.Drawing.Size(556, 40);
            this.firstKeyTextBox.TabIndex = 28;
            // 
            // maxBlockSize
            // 
            this.maxBlockSize.Location = new System.Drawing.Point(378, 161);
            this.maxBlockSize.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxBlockSize.Name = "maxBlockSize";
            this.maxBlockSize.Size = new System.Drawing.Size(120, 20);
            this.maxBlockSize.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(175, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Выберите размер блока:";
            // 
            // maxBlockSizeInfo
            // 
            this.maxBlockSizeInfo.AutoSize = true;
            this.maxBlockSizeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxBlockSizeInfo.Location = new System.Drawing.Point(175, 138);
            this.maxBlockSizeInfo.Name = "maxBlockSizeInfo";
            this.maxBlockSizeInfo.Size = new System.Drawing.Size(232, 20);
            this.maxBlockSizeInfo.TabIndex = 25;
            this.maxBlockSizeInfo.Text = "Максимальный размер блока";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(367, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Результат";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 187);
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
            this.processButton.Location = new System.Drawing.Point(38, 363);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(579, 38);
            this.processButton.TabIndex = 8;
            this.processButton.Text = "Зашифровать";
            this.processButton.UseVisualStyleBackColor = false;
            this.processButton.Click += new System.EventHandler(this.HandleClickProcessButton);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(38, 203);
            this.input.Multiline = true;
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(271, 154);
            this.input.TabIndex = 6;
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(370, 203);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(247, 154);
            this.output.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(34, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(34, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "e";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(89, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(40, 0, 40, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Алгоритм RSA";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // loadFromFile
            // 
            this.loadFromFile.Location = new System.Drawing.Point(38, 158);
            this.loadFromFile.Name = "loadFromFile";
            this.loadFromFile.Size = new System.Drawing.Size(121, 23);
            this.loadFromFile.TabIndex = 30;
            this.loadFromFile.Text = "Загрузить из файла";
            this.loadFromFile.UseVisualStyleBackColor = true;
            this.loadFromFile.Click += new System.EventHandler(this.HandleClickLoadFromFile);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 457);
            this.Controls.Add(this.tabs);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "RSA";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxBlockSize)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
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
        private System.Windows.Forms.NumericUpDown maxBlockSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label maxBlockSizeInfo;
        private System.Windows.Forms.TextBox pTextBox;
        private System.Windows.Forms.TextBox secondKeyTextBox;
        private System.Windows.Forms.TextBox firstKeyTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox decryptedText;
        private System.Windows.Forms.TextBox encryptedText;
        private System.Windows.Forms.Label Исходный;
        private System.Windows.Forms.TextBox qTextBox;
        private System.Windows.Forms.Button loadFromFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}


using System;
using System.Numerics;
using System.Windows.Forms;
using RsaCypher;
using RsaCypher.BitSequenceLib;

namespace rsa_helper
{
    public partial class MainForm : Form
    {
        private readonly RSA _rsaCypher = new RSA();
        public MainForm()
        {
            InitializeComponent();
        }

        private void HandleChangeFirstKey(object sender, EventArgs e)
        {
            if (firstKeyTextBox.Text == "")
            {
                DisableProcessButton();
                return;
            }
            try
            {
                _rsaCypher.FirstPartOpenKey = BigInteger.Parse(firstKeyTextBox.Text);
                _rsaCypher.FirstPartClosedKey = BigInteger.Parse(firstKeyTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Wrong format!");
                firstKeyTextBox.Clear();
            }
            if (IsProcessFormValid())
            {
                EnableProcessButton();
            }
        }
       
        private void HandleChangeSecondKey(object sender, EventArgs e)
        {
            if (secondKeyTextBox.Text == "")
            {
                ChangeMaxBlockSize(1);
                DisableProcessButton();
                return;
            }
            try
            {
                _rsaCypher.SecondPartKey = BigInteger.Parse(secondKeyTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Wrong format!");
                secondKeyTextBox.Clear();
            }
            ChangeMaxBlockSize((int)Math.Sqrt(new BitSequence(_rsaCypher.SecondPartKey).Bits.Count) - 1);

            if (IsProcessFormValid())
            {
                EnableProcessButton();
            }
        }

        private void HandleClickProcessButton(object sender, EventArgs e)
        {
            if (firstKeyTextBox.Text == string.Empty || secondKeyTextBox.Text == string.Empty)
            {
                return;
            }
            output.Text = _rsaCypher.EncyptByBlocks(input.Text, (int)maxBlockSize.Value);
            encryptedText.Text = output.Text;
            tabs.SelectedIndex = 0;
        }

        private void HandleClickHelp(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ShowDialog();
        }

        private void HandleChangeP(object sender, EventArgs e)
        {
            if (pTextBox.Text == "")
            {
                DisableGenerateButton();
                return;
            }
            try
            {
                _rsaCypher.P = BigInteger.Parse(pTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Wrong format!");
                pTextBox.Clear();
            }
            if (IsGenerateFormValid())
            {
                EnableGenerateButton();
            }
        }

        private void HandleChangeQ(object sender, EventArgs e)
        {
            if (qTextBox.Text == "")
            {
                DisableGenerateButton();
                return;
            }
            try
            {
                _rsaCypher.Q = BigInteger.Parse(qTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Wrong format!");
                qTextBox.Clear();
            }
            if (IsGenerateFormValid())
            {
                EnableGenerateButton();
            }
        }
        private void DisableProcessButton() => processButton.Enabled = false;
        private void EnableProcessButton() => processButton.Enabled = true;
        private void DisableGenerateButton() => generateButton.Enabled = false;
        private void EnableGenerateButton() => generateButton.Enabled = true;

        private bool IsProcessFormValid() => firstKeyTextBox.Text != "" && secondKeyTextBox.Text != "";
        private bool IsGenerateFormValid() => pTextBox.Text != "" && qTextBox.Text != "";

        private void HandleGenerateClick(object sender, EventArgs e)
        {
            _rsaCypher.Init();
            mTextBox.Text = _rsaCypher.M.ToString();
            nTextBox.Text = _rsaCypher.SecondPartKey.ToString();
            eTextBox.Text = _rsaCypher.FirstPartOpenKey.ToString();
            dTextBox.Text = _rsaCypher.FirstPartClosedKey.ToString();
            firstKeyTextBox.Text = eTextBox.Text;
            secondKeyTextBox.Text = nTextBox.Text;
            ChangeMaxBlockSize((int)Math.Sqrt(new BitSequence(_rsaCypher.SecondPartKey).Bits.Count) - 1);
            EnableProcessButton();
            tabs.SelectedIndex = 1;
        }

        private void ChangeMaxBlockSize(int maximum)
        {
            maxBlockSizeInfo.Text = "Максимальный размер блока: " + maximum;
            maxBlockSize.Maximum = maximum;
            maxBlockSize.Value = maximum;
        }

        private void HandleClickDecryptButton(object sender, EventArgs e)
        {
            decryptedText.Text = _rsaCypher.DecryptByBlocks(encryptedText.Text);
        }

        private void HandleClickLoadFromFile(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string fileName = openFileDialog.FileName;
            string fileText = System.IO.File.ReadAllText(fileName);
            input.Text = fileText;
        }
    }
}

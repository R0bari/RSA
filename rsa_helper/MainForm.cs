using System;
using System.Windows.Forms;
using RsaCypher;

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
            _rsaCypher.FirstPartOfOpenKey = int.Parse(firstKeyTextBox.Text);
            _rsaCypher.FirstPartOfClosedKey = int.Parse(firstKeyTextBox.Text);
            if (IsProcessFormValid())
            {
                EnableProcessButton();
            }
        }
       
        private void HandleChangeSecondKey(object sender, EventArgs e)
        {
            if (secondKeyTextBox.Text == "")
            {
                DisableProcessButton();
                return;
            }
            _rsaCypher.SecondPartOfKey = int.Parse(secondKeyTextBox.Text);
            if (IsProcessFormValid())
            {
                EnableProcessButton();
            }
        }

        private void HandleSwitchProcessType(object sender, EventArgs e)
        {
            if (radioEncrypt.Checked)
            {
                processButton.Text = "Зашифровать";
            }
            else if (radioDecrypt.Checked)
            {
                processButton.Text = "Расшифровать";
            }
        }

        private void HandleClickProcessButton(object sender, EventArgs e)
        {
            if (firstKeyTextBox.Text == string.Empty || secondKeyTextBox.Text == string.Empty)
            {
                return;
            }
            if (radioEncrypt.Checked)
            {
                output.Text = _rsaCypher.Encrypt(input.Text.ToLower());
            }
            else
            {
                output.Text = _rsaCypher.Decrypt(input.Text);
            }
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
            _rsaCypher.P = int.Parse(pTextBox.Text);
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
            _rsaCypher.Q = int.Parse(qTextBox.Text);
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
            nTextBox.Text = _rsaCypher.SecondPartOfKey.ToString();
            eTextBox.Text = _rsaCypher.FirstPartOfOpenKey.ToString();
            dTextBox.Text = _rsaCypher.FirstPartOfClosedKey.ToString();
        }
    }
}

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
            _rsaCypher.FirstPartOfOpenKey = int.Parse(firstKeyTextBox.Text);
            _rsaCypher.FirstPartOfClosedKey = int.Parse(firstKeyTextBox.Text);
        }

        private void HandleChangeSecondKey(object sender, EventArgs e)
        {
            _rsaCypher.SecondPartOfKey = int.Parse(secondKeyTextBox.Text);
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
                output.Text = _rsaCypher.Encrypt(input.Text);
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
    }
}

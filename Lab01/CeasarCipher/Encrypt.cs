using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CeasarCipher
{
    public partial class Encrypt : Form
    {
        public Encrypt()
        {
            InitializeComponent();
        }

        private string EncryptCaesar(string plaintext, int key)
        {
            string ciphertext = "";

            key = key % 26;
            if (key < 0) key += 26;

            foreach (char c in plaintext)
            {
                if (char.IsUpper(c))
                {
                    ciphertext += (char)(((c - 'A' + key) % 26) + 'A');
                }
                else if (char.IsLower(c))
                {
                    ciphertext += (char)(((c - 'a' + key) % 26) + 'a');
                }
                else
                {
                    ciphertext += c;
                }
            }

            return ciphertext;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string inputPlaintext = rtbPlaintext.Text;
            int encryptKey;

            if (string.IsNullOrWhiteSpace(txtKey.Text) || !int.TryParse(txtKey.Text, out encryptKey))
            {
                MessageBox.Show("Key phải là một số nguyên. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;       
            }

            string resultCiphertext = EncryptCaesar(inputPlaintext, encryptKey);

            rtbEncrypt.Text = resultCiphertext;
        }
    }
}

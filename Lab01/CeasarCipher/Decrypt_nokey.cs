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
    public partial class Decrypt_nokey : Form
    {
        public Decrypt_nokey()
        {
            InitializeComponent();
        }

        private string DecryptCaesar(string ciphertext, int key)
        {
            string plaintext = "";
            key = key % 26;
            if (key < 0) key += 26;

            foreach (char c in ciphertext)
            {
                if (char.IsUpper(c))
                {
                    int shift = (c - 'A' - key) % 26;
                    if (shift < 0) shift += 26;
                    plaintext += (char)('A' + shift);
                }
                else if (char.IsLower(c))
                {
                    int shift = (c - 'a' - key) % 26;
                    if (shift < 0) shift += 26;
                    plaintext += (char)('a' + shift);
                }
                else
                {
                    plaintext += c;
                }
            }
            return plaintext;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string ciphertext = rtbCiphertext.Text;

            string allResults = "";

            for (int k = 0; k <= 25; k++)
            {
                string decryptedText = DecryptCaesar(ciphertext, k);
                allResults += $"[Key {k:D2}]: {decryptedText}\n\n\n";
            }

            rtbPlaintext.Text = allResults;
        }
    }
}

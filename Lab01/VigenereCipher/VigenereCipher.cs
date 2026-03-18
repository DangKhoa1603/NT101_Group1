using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VigenereCipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) //encrypt
        {
            string Plaintext = richTextBox1.Text.ToUpper();
            string Key = textBox1.Text.ToUpper();
            richTextBox2.Text = VigenereEncrypt(Plaintext, Key);
        }

        private void button1_Click(object sender, EventArgs e) //decrypt
        {
            string Ciphertext = richTextBox1.Text.ToUpper();
            string Key = textBox1.Text.ToUpper();
            richTextBox2.Text = VigenereDecrypt(Ciphertext, Key);

        }

        private string VigenereEncrypt(string text, string key)
        {
            string kq = "";
            int KeyIndex = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                if (char.IsLetter(letter))
                {
                    int shift = key[KeyIndex % key.Length] - 'A';
                    char encryptedChar = (char)('A' + (letter - 'A' + shift) % 26);
                    kq += encryptedChar;
                    KeyIndex++;
                }
                else
                {
                    kq += letter;
                }
            }
            return kq;
        }

        private string VigenereDecrypt(string text, string key)
        {
            string result = "";
            int keyIndex = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                if (char.IsLetter(letter))
                {
                    int shift = key[keyIndex % key.Length] - 'A';
                    char decryptedChar = (char)('A' + (letter - 'A' - shift + 26) % 26);
                    result += decryptedChar;
                    keyIndex++;
                }
                else
                {
                    result += letter;
                }
            }
            return result;
        }
    }
}

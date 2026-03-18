using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VigenereCracker
{
    public partial class Cracker : Form
    {
        public Cracker()
        {
            InitializeComponent();
        }

        private readonly double[] englishFrequencies = 
        {
            0.0804, 0.0148, 0.0334, 0.0382, 0.1249, 0.0240, 0.0187, 0.0609, 
            0.0757, 0.0016, 0.0054, 0.0407, 0.0251, 0.0723, 0.0764, 0.0214, 
            0.0012, 0.0628, 0.0651, 0.0928, 0.0273, 0.0105, 0.0168, 0.0023, 
            0.0166, 0.0009                                                  
        };

        private string[] SplitIntoGroups(string text, int length)
        {
            string[] groups = new string[length];
            for (int i = 0; i < length; i++) groups[i] = "";

            for (int i = 0; i < text.Length; i++)
            {
                groups[i % length] += text[i];
            }
            return groups;
        }

        private char FindKeyCharForGroup(string group)
        {
            double minChiSquare = double.MaxValue;
            int bestShift = 0;

            for (int shift = 0; shift < 26; shift++)
            {
                string decryptedTrial = "";
                foreach (char c in group)
                {
                    int decVal = (c - 'A' - shift + 26) % 26;
                    decryptedTrial += (char)(decVal + 'A');
                }

                double chiSquareScore = CalculateChiSquare(decryptedTrial);

                if (chiSquareScore < minChiSquare)
                {
                    minChiSquare = chiSquareScore;
                    bestShift = shift;
                }
            }

            return (char)(bestShift + 'A');
        }

        private double CalculateChiSquare(string text)
        {
            int L = text.Length;
            int[] observedCounts = new int[26];

            foreach (char c in text)
            {
                observedCounts[c - 'A']++;
            }

            double chiSquare = 0;

            for (int i = 0; i < 26; i++)
            {
                double expected = L * englishFrequencies[i];
                if (expected > 0)
                {
                    double observed = observedCounts[i];
                    double diff = observed - expected;
                    chiSquare += (diff * diff) / expected;
                }
            }

            return chiSquare;
        }

        private string DecryptVigenere(string cipherText, string key)
        {
            string plainText = "";
            int keyIndex = 0;

            foreach (char c in cipherText)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    int cipherVal = c - 'A';
                    int keyVal = key[keyIndex % key.Length] - 'A';

                    int plainVal = (cipherVal - keyVal + 26) % 26;
                    plainText += (char)(plainVal + 'A');

                    keyIndex++;
                }
                else if (c >= 'a' && c <= 'z') 
                {
                    int cipherVal = c - 'a';
                    int keyVal = key[keyIndex % key.Length] - 'A'; 

                    int plainVal = (cipherVal - keyVal + 26) % 26;
                    plainText += (char)(plainVal + 'a');

                    keyIndex++;
                }
                else
                {
                    plainText += c; 
                }
            }
            return plainText;
        }
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string cipherText = rtbCiphertext.Text.ToUpper();

            string cleanCipherText = new string(cipherText.Where(c => c >= 'A' && c <= 'Z').ToArray());

            if (cleanCipherText.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập bản mã hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int keyLength = 6;

            string[] groups = SplitIntoGroups(cleanCipherText, keyLength);
            string foundKey = "";

            for (int i = 0; i < keyLength; i++)
            {
                char keyChar = FindKeyCharForGroup(groups[i]);
                foundKey += keyChar;
            }

            txtFoundKey.Text = foundKey;

            string plainText = DecryptVigenere(cipherText, foundKey);

            rtbPlaintext.Text = plainText;
        }
    }
}

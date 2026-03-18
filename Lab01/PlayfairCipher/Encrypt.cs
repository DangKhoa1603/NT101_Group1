using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayfairCipher
{
    public partial class Encrypt : Form
    {
        public Encrypt()
        {
            InitializeComponent();
            this.Load += new EventHandler(Encrypt_Load);
        }

        private void Encrypt_Load(object sender, EventArgs e)
        {
            dgvMatrix.ColumnCount = 5;
            dgvMatrix.RowCount = 5;
            dgvMatrix.AllowUserToAddRows = false;
            dgvMatrix.AllowUserToDeleteRows = false;
            dgvMatrix.ReadOnly = true;
            dgvMatrix.ColumnHeadersVisible = false;
            dgvMatrix.RowHeadersVisible = false;
            dgvMatrix.ScrollBars = ScrollBars.None;
            dgvMatrix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            for (int i = 0; i < 5; i++)
            {
                dgvMatrix.Rows[i].Height = dgvMatrix.Height / 5;
            }
        }

        private char[,] playfairMatrix = new char[5, 5];

        private void GenerateMatrix(string key)
        {
            string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            string keyString = key.ToUpper().Replace("J", "I");
            string matrixString = "";

            foreach (char c in keyString)
            {
                if (char.IsLetter(c) && !matrixString.Contains(c))
                {
                    matrixString += c;
                }
            }

            foreach (char c in alphabet)
            {
                if (!matrixString.Contains(c))
                {
                    matrixString += c;
                }
            }

            int index = 0;
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    playfairMatrix[row, col] = matrixString[index];
                    dgvMatrix.Rows[row].Cells[col].Value = matrixString[index].ToString();
                    index++;
                }
            }
        }
        private void GetPosition(char c, out int row, out int col)
        {
            row = -1;
            col = -1;
            for (int r = 0; r < 5; r++)
            {
                for (int cl = 0; cl < 5; cl++)
                {
                    if (playfairMatrix[r, cl] == c)
                    {
                        row = r;
                        col = cl;
                        return;
                    }
                }
            }
        }

        private string FormatInput(string input)
        {
            string cleanInput = "";
            foreach (char c in input.ToUpper())
            {
                if (char.IsLetter(c))
                {
                    cleanInput += (c == 'J' ? 'I' : c);
                }
            }

            string result = "";
            for (int i = 0; i < cleanInput.Length; i += 2)
            {
                result += cleanInput[i];
                if (i + 1 < cleanInput.Length)
                {
                    if (cleanInput[i] == cleanInput[i + 1])
                    {
                        result += 'X'; 
                        i--; 
                    }
                    else
                    {
                        result += cleanInput[i + 1];
                    }
                }
                else
                {
                    result += 'X'; 
                }
            }
            return result;
        }

        private string EncryptPlayfair(string input)
        {
            string formattedInput = FormatInput(input);
            string cipherText = "";

            for (int i = 0; i < formattedInput.Length; i += 2)
            {
                char char1 = formattedInput[i];
                char char2 = formattedInput[i + 1];

                GetPosition(char1, out int r1, out int c1);
                GetPosition(char2, out int r2, out int c2);

                if (r1 == r2) 
                {
                    cipherText += playfairMatrix[r1, (c1 + 1) % 5];
                    cipherText += playfairMatrix[r2, (c2 + 1) % 5];
                }
                else if (c1 == c2) 
                {
                    cipherText += playfairMatrix[(r1 + 1) % 5, c1];
                    cipherText += playfairMatrix[(r2 + 1) % 5, c2];
                }
                else 
                {
                    cipherText += playfairMatrix[r1, c2];
                    cipherText += playfairMatrix[r2, c1];
                }
            }

            return cipherText;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text;
            string plainText = rtbPlaintext.Text;

            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(plainText))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Từ khóa (Key) và Văn bản (Input)!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            GenerateMatrix(key);

            rtbEncrypt.Text = EncryptPlayfair(plainText);
        }
    }
}

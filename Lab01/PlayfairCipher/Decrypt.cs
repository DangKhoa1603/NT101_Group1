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
    public partial class Decrypt : Form
    {
        private char[,] playfairMatrix = new char[5, 5];

        public Decrypt()
        {
            InitializeComponent();
            this.Load += new EventHandler(Decrypt_Load);
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text;
            string cipherText = rtbCiphertext.Text; 

            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(cipherText))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Từ khóa và Bản mã!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GenerateMatrix(key);

            rtbDecrypt.Text = DecryptPlayfair(cipherText);
        }

        private void Decrypt_Load(object sender, EventArgs e)
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

        private string DecryptPlayfair(string input)
        {
            string cleanInput = "";
            foreach (char c in input.ToUpper())
            {
                if (char.IsLetter(c)) cleanInput += c;
            }

            string plainText = "";

            for (int i = 0; i < cleanInput.Length; i += 2)
            {
                char char1 = cleanInput[i];
                char char2 = cleanInput[i + 1];

                GetPosition(char1, out int r1, out int c1);
                GetPosition(char2, out int r2, out int c2);

                if (r1 == r2)
                {
                    plainText += playfairMatrix[r1, (c1 + 4) % 5];
                    plainText += playfairMatrix[r2, (c2 + 4) % 5];
                }
                else if (c1 == c2)
                {
                    plainText += playfairMatrix[(r1 + 4) % 5, c1];
                    plainText += playfairMatrix[(r2 + 4) % 5, c2];
                }
                else
                {
                    plainText += playfairMatrix[r1, c2];
                    plainText += playfairMatrix[r2, c1];
                }
            }
            return plainText;
        }
    }
}

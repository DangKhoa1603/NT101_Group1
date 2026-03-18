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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            Encrypt f = new Encrypt();
            f.Show();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            Decrypt f = new Decrypt();
            f.Show();
        }
    }
}

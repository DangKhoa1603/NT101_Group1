namespace PlayfairCipher
{
    partial class Decrypt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvMatrix = new System.Windows.Forms.DataGridView();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.rtbCiphertext = new System.Windows.Forms.RichTextBox();
            this.rtbDecrypt = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMatrix
            // 
            this.dgvMatrix.AllowUserToAddRows = false;
            this.dgvMatrix.AllowUserToDeleteRows = false;
            this.dgvMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatrix.ColumnHeadersVisible = false;
            this.dgvMatrix.Location = new System.Drawing.Point(19, 161);
            this.dgvMatrix.Name = "dgvMatrix";
            this.dgvMatrix.ReadOnly = true;
            this.dgvMatrix.RowHeadersVisible = false;
            this.dgvMatrix.RowHeadersWidth = 51;
            this.dgvMatrix.RowTemplate.Height = 24;
            this.dgvMatrix.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvMatrix.Size = new System.Drawing.Size(370, 370);
            this.dgvMatrix.TabIndex = 25;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.Location = new System.Drawing.Point(19, 555);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(152, 52);
            this.btnEncrypt.TabIndex = 24;
            this.btnEncrypt.Text = "Decrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(551, 348);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(77, 22);
            this.lbl3.TabIndex = 23;
            this.lbl3.Text = "Decrypt:";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(551, 75);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(97, 22);
            this.lbl4.TabIndex = 22;
            this.lbl4.Text = "Ciphertext:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 22);
            this.label2.TabIndex = 21;
            this.label2.Text = "Key:";
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKey.Location = new System.Drawing.Point(19, 100);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(370, 24);
            this.txtKey.TabIndex = 20;
            // 
            // rtbCiphertext
            // 
            this.rtbCiphertext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCiphertext.Location = new System.Drawing.Point(555, 100);
            this.rtbCiphertext.Name = "rtbCiphertext";
            this.rtbCiphertext.Size = new System.Drawing.Size(496, 234);
            this.rtbCiphertext.TabIndex = 19;
            this.rtbCiphertext.Text = "";
            // 
            // rtbDecrypt
            // 
            this.rtbDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDecrypt.Location = new System.Drawing.Point(555, 373);
            this.rtbDecrypt.Name = "rtbDecrypt";
            this.rtbDecrypt.ReadOnly = true;
            this.rtbDecrypt.Size = new System.Drawing.Size(496, 234);
            this.rtbDecrypt.TabIndex = 18;
            this.rtbDecrypt.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(400, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 38);
            this.label1.TabIndex = 17;
            this.label1.Text = "Playfair - Decrypt";
            // 
            // Decrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 619);
            this.Controls.Add(this.dgvMatrix);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.rtbCiphertext);
            this.Controls.Add(this.rtbDecrypt);
            this.Controls.Add(this.label1);
            this.Name = "Decrypt";
            this.Text = "Decrypt";
            this.Load += new System.EventHandler(this.Decrypt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMatrix;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.RichTextBox rtbCiphertext;
        private System.Windows.Forms.RichTextBox rtbDecrypt;
        private System.Windows.Forms.Label label1;
    }
}
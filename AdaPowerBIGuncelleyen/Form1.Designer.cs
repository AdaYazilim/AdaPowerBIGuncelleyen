namespace AdaPowerBIGuncelleyen
{
    partial class AnaForm
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
            this.txtGuncelenecekDosyaAdi = new System.Windows.Forms.TextBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnDosyaSec = new System.Windows.Forms.Button();
            this.rbGithub = new System.Windows.Forms.RadioButton();
            this.rbDosya = new System.Windows.Forms.RadioButton();
            this.txtGuncelleyenDosyaAdi = new System.Windows.Forms.TextBox();
            this.cmbGithub = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtGuncelenecekDosyaAdi
            // 
            this.txtGuncelenecekDosyaAdi.Location = new System.Drawing.Point(94, 2);
            this.txtGuncelenecekDosyaAdi.Multiline = true;
            this.txtGuncelenecekDosyaAdi.Name = "txtGuncelenecekDosyaAdi";
            this.txtGuncelenecekDosyaAdi.ReadOnly = true;
            this.txtGuncelenecekDosyaAdi.Size = new System.Drawing.Size(572, 66);
            this.txtGuncelenecekDosyaAdi.TabIndex = 0;
            this.txtGuncelenecekDosyaAdi.TabStop = false;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Enabled = false;
            this.btnGuncelle.Location = new System.Drawing.Point(12, 201);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(654, 66);
            this.btnGuncelle.TabIndex = 1;
            this.btnGuncelle.Text = "Seçili Dosyayı Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnDosyaSec
            // 
            this.btnDosyaSec.Location = new System.Drawing.Point(1, 2);
            this.btnDosyaSec.Name = "btnDosyaSec";
            this.btnDosyaSec.Size = new System.Drawing.Size(87, 66);
            this.btnDosyaSec.TabIndex = 1;
            this.btnDosyaSec.Text = "Güncellenecek Dosya Seç";
            this.btnDosyaSec.UseVisualStyleBackColor = true;
            this.btnDosyaSec.Click += new System.EventHandler(this.btnDosyaSec_Click);
            // 
            // rbGithub
            // 
            this.rbGithub.AutoSize = true;
            this.rbGithub.Location = new System.Drawing.Point(12, 101);
            this.rbGithub.Name = "rbGithub";
            this.rbGithub.Size = new System.Drawing.Size(117, 17);
            this.rbGithub.TabIndex = 2;
            this.rbGithub.TabStop = true;
            this.rbGithub.Text = "Githubdan güncelle";
            this.rbGithub.UseVisualStyleBackColor = true;
            this.rbGithub.CheckedChanged += new System.EventHandler(this.rbGithub_CheckedChanged);
            // 
            // rbDosya
            // 
            this.rbDosya.AutoSize = true;
            this.rbDosya.Location = new System.Drawing.Point(12, 130);
            this.rbDosya.Name = "rbDosya";
            this.rbDosya.Size = new System.Drawing.Size(116, 17);
            this.rbDosya.TabIndex = 3;
            this.rbDosya.TabStop = true;
            this.rbDosya.Text = "Dosyadan güncelle";
            this.rbDosya.UseVisualStyleBackColor = true;
            this.rbDosya.CheckedChanged += new System.EventHandler(this.rbDosya_CheckedChanged);
            // 
            // txtGuncelleyenDosyaAdi
            // 
            this.txtGuncelleyenDosyaAdi.Enabled = false;
            this.txtGuncelleyenDosyaAdi.Location = new System.Drawing.Point(134, 129);
            this.txtGuncelleyenDosyaAdi.Multiline = true;
            this.txtGuncelleyenDosyaAdi.Name = "txtGuncelleyenDosyaAdi";
            this.txtGuncelleyenDosyaAdi.ReadOnly = true;
            this.txtGuncelleyenDosyaAdi.Size = new System.Drawing.Size(532, 24);
            this.txtGuncelleyenDosyaAdi.TabIndex = 4;
            this.txtGuncelleyenDosyaAdi.TabStop = false;
            this.txtGuncelleyenDosyaAdi.Click += new System.EventHandler(this.txtGuncelleyenDosyaAdi_Click);
            // 
            // cmbGithub
            // 
            this.cmbGithub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGithub.Enabled = false;
            this.cmbGithub.FormattingEnabled = true;
            this.cmbGithub.Location = new System.Drawing.Point(135, 102);
            this.cmbGithub.Name = "cmbGithub";
            this.cmbGithub.Size = new System.Drawing.Size(531, 21);
            this.cmbGithub.TabIndex = 5;
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 272);
            this.Controls.Add(this.cmbGithub);
            this.Controls.Add(this.txtGuncelleyenDosyaAdi);
            this.Controls.Add(this.rbDosya);
            this.Controls.Add(this.rbGithub);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.txtGuncelenecekDosyaAdi);
            this.Controls.Add(this.btnDosyaSec);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AnaForm";
            this.Text = "Power BI Güncelleyen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnaForm_FormClosing);
            this.Load += new System.EventHandler(this.AnaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGuncelenecekDosyaAdi;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnDosyaSec;
        private System.Windows.Forms.RadioButton rbGithub;
        private System.Windows.Forms.RadioButton rbDosya;
        private System.Windows.Forms.TextBox txtGuncelleyenDosyaAdi;
        private System.Windows.Forms.ComboBox cmbGithub;
    }
}


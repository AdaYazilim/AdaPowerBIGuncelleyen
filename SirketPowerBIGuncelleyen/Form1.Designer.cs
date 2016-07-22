namespace SirketPowerBIGuncelleyen
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
            this.btnGuncelle.Location = new System.Drawing.Point(673, 2);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(90, 66);
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
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 71);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.txtGuncelenecekDosyaAdi);
            this.Controls.Add(this.btnDosyaSec);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AnaForm";
            this.Text = "Power BI Güncelleyen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnaForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGuncelenecekDosyaAdi;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnDosyaSec;
    }
}


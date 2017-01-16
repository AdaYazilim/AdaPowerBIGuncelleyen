using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace AdaPowerBIGuncelleyen
{
    public partial class AnaForm : Form
    {
        private const string KaynakDosya = "kaynak.zip";
        //private bool _guncelDosyaIndirildi = false;
        private readonly string _randomKlasor;

        public AnaForm()
        {
            InitializeComponent();

            _randomKlasor = Guid.NewGuid().ToString();
            DirectoryInfo directory = Directory.CreateDirectory(_randomKlasor);
            //directory.Attributes |= FileAttributes.Hidden;
            Directory.SetCurrentDirectory(_randomKlasor);
        }

        private void btnDosyaSec_Click(object sender, EventArgs e)
        {
            string dosyaAdi = dosyaSec();
            if (dosyaAdi != null)
                txtGuncelenecekDosyaAdi.Text = dosyaAdi;
        }

        private string dosyaSec()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = @"Power BI Files (.pbix)|*.pbix";
            if (fd.ShowDialog() == DialogResult.OK)
                return fd.FileName;
            else
                return null;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string guncellenecekDosya = txtGuncelenecekDosyaAdi.Text;
            if (!dosyaUygun(guncellenecekDosya, "GüncellenecekDosya"))
                return;

            //if (!_guncelDosyaIndirildi)
            //{
                //kaynakDosyayiAyarla();
                //_guncelDosyaIndirildi = true;
            //}

            bool kaynakDosyaAyarlandi = kaynakDosyayiAyarla();
            if (!kaynakDosyaAyarlandi)
            {
                return;
            }

            PowerBiFileModelUpdater pbiFileModelUpdater = new PowerBiFileModelUpdater(KaynakDosya, guncellenecekDosya);
            PowerBiFileModelUpdater.UpdateResult updateResult = pbiFileModelUpdater.Update();
            
            if(updateResult.Success)
                MessageBox.Show("Seçili dosyanın veri modeli güncellendi. Yeni dosya yolu:\n" + updateResult.UpdatedFilePath);
            else
                MessageBox.Show("Güncelleme sırasında hata oluştu. \n" + updateResult.Message);
        }

        private bool dosyaUygun(string dosyaPath, string dosyaAciklama)
        {
            if (string.IsNullOrWhiteSpace(dosyaPath))
            {
                MessageBox.Show(string.Format("Dosya seçmelisiniz: {0}", dosyaAciklama));
                return false;
            }

            if (!File.Exists(dosyaPath))
            {
                MessageBox.Show(string.Format("Dosya bulunamadı: {0}", dosyaAciklama));
                return false;
            }

            return true;
        }

        private bool kaynakDosyayiAyarla()
        {
            if (rbDosya.Checked)
            {
                string dosyaPath = txtGuncelleyenDosyaAdi.Text;
                if (!dosyaUygun(dosyaPath, "KaynakDosya"))
                    return false;

                File.Copy(txtGuncelleyenDosyaAdi.Text, KaynakDosya, true);
            }
            if (rbGithub.Checked)
            {
                KaynakUrlElement seciliUrl = (KaynakUrlElement)cmbGithub.SelectedItem;
                string url = seciliUrl.Url;
                WebClient client = new WebClient();
                client.DownloadFile(url, KaynakDosya);
            }

            return true;
        }

        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Directory.SetCurrentDirectory(Application.StartupPath);
            if (Directory.Exists(_randomKlasor))
                Directory.Delete(_randomKlasor, true);
        }

        private void radioButtonaBasildi()
        {
            btnGuncelle.Enabled = true;
            if (rbDosya.Checked)
            {
                cmbGithub.Enabled = false;
                txtGuncelleyenDosyaAdi.Enabled = true;
            }
            else
            {
                cmbGithub.Enabled = true;
                txtGuncelleyenDosyaAdi.Enabled = false;
            }
        }

        private void rbGithub_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonaBasildi();
        }

        private void rbDosya_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonaBasildi();
        }

        private void txtGuncelleyenDosyaAdi_Click(object sender, EventArgs e)
        {
            string dosyaAdi = dosyaSec();
            if(dosyaAdi!=null)
                txtGuncelleyenDosyaAdi.Text = dosyaAdi;
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            KaynakListesiSection aaa = (KaynakListesiSection)ConfigurationManager.GetSection("KaynakListesi");
            KaynakUrlCollection col = aaa.KaynakUrlItems;
            foreach (KaynakUrlElement kaynak in col)
            {
                cmbGithub.Items.Add(kaynak);
            }
        }
    }
}

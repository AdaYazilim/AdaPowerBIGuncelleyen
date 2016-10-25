using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SirketPowerBIGuncelleyen
{
    public partial class AnaForm : Form
    {
        private const string IndirilenDosya = "guncel.zip";
        private bool _guncelDosyaIndirildi = false;
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
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = @"Power BI Files (.pbix)|*.pbix";
            if (fd.ShowDialog()==DialogResult.OK)
            {
                txtGuncelenecekDosyaAdi.Text = fd.FileName;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string dosyaAdi = txtGuncelenecekDosyaAdi.Text;
            if (!guncellenecekDosyaUygun(dosyaAdi))
                return;

            if (!_guncelDosyaIndirildi)
            {
                guncelDosyayiIndir();
                _guncelDosyaIndirildi = true;
            }

            PowerBiFileModelUpdater pbiFileModelUpdater = new PowerBiFileModelUpdater(IndirilenDosya, dosyaAdi);
            PowerBiFileModelUpdater.UpdateResult updateResult = pbiFileModelUpdater.Update();
            
            if(updateResult.Success)
                MessageBox.Show("Seçili dosyanın veri modeli güncellendi. Yeni dosya yolu:\n" + updateResult.UpdatedFilePath);
            else
                MessageBox.Show("Güncelleme sırasında hata oluştu. \n" + updateResult.Message);
        }

        private bool guncellenecekDosyaUygun(string dosyaPath)
        {
            if (string.IsNullOrWhiteSpace(dosyaPath))
            {
                MessageBox.Show(@"Güncellenecek dosya seçmelisiniz.");
                return false;
            }

            if (!File.Exists(dosyaPath))
            {
                MessageBox.Show(@"Güncellenecek dosya bulunamadı.");
                return false;
            }

            return true;
        }

        private void guncelDosyayiIndir()
        {
            WebClient client = new WebClient();
            client.DownloadFile("https://github.com/AdaYazilim/Ada-Sirket-BI-Yardim/blob/master/%C5%9Eablonlar/U-UD-H.pbix?raw=true", IndirilenDosya);
        }

        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Directory.SetCurrentDirectory(Application.StartupPath);
            if (Directory.Exists(_randomKlasor))
                Directory.Delete(_randomKlasor, true);
        }
    }
}

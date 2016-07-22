using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.IO.Compression;

namespace SirketPowerBIGuncelleyen
{
    public partial class AnaForm : Form
    {
        private const string IndirilenDosya = "guncel.zip";
        private const string GeciciDosya = "geciciDosya";
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

            FileInfo fi = new FileInfo(dosyaAdi);
            string yeniDosyaAdi = fi.Name.Substring(0, fi.Name.Length - 5) + ".zip";
            File.Copy(dosyaAdi, yeniDosyaAdi, true);

            zipiAktar(IndirilenDosya, yeniDosyaAdi);

            string guid = Guid.NewGuid().ToString().Substring(0, 7);
            string yeniPbixDosya = fi.FullName.Substring(0, fi.FullName.Length - 5) + "_" + guid + ".pbix";
            File.Move(yeniDosyaAdi, yeniPbixDosya);

            MessageBox.Show("Seçili dosyanın veri modeli güncellendi. Yeni dosya yolu:\n" + yeniPbixDosya);
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

        private void zipiAktar(string guncelDosya, string guncellenecekDosya)
        {
            using (FileStream guncel = new FileStream(guncelDosya, FileMode.Open))
            using (FileStream guncellenecek = new FileStream(guncellenecekDosya, FileMode.Open))
            using (ZipArchive archiveGuncel = new ZipArchive(guncel, ZipArchiveMode.Read))
            using (ZipArchive archiveGuncellenecek = new ZipArchive(guncellenecek, ZipArchiveMode.Update))
            {
                dosyayiBirZiptenDigerineAktar(archiveGuncel, archiveGuncellenecek, "DataModel");
                dosyayiBirZiptenDigerineAktar(archiveGuncel, archiveGuncellenecek, "DataMashup");
                dosyayiBirZiptenDigerineAktar(archiveGuncel, archiveGuncellenecek, "Metadata");
                dosyayiBirZiptenDigerineAktar(archiveGuncel, archiveGuncellenecek, "DiagramState");
            }
        }

        private void dosyayiBirZiptenDigerineAktar(ZipArchive kaynakArsiv, ZipArchive hedefArsiv, string dosyaAdi)
        {
            ZipArchiveEntry entry = kaynakArsiv.GetEntry(dosyaAdi);
            entry.ExtractToFile(GeciciDosya, true);
            hedefArsiv.GetEntry(dosyaAdi).Delete();
            hedefArsiv.CreateEntryFromFile(GeciciDosya, dosyaAdi, CompressionLevel.NoCompression);
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

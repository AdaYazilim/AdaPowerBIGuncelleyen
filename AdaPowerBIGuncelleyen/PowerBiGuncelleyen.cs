using System;
using System.IO;
using System.IO.Compression;

namespace SirketPowerBIGuncelleyen
{
    public class PowerBiFileModelUpdater
    {
        private const string TempFile = "tempFile";

        private readonly string _sourceFilePath;
        private readonly string _targetFailePath;

        public PowerBiFileModelUpdater(string sourceFilePath, string targetFailePath)
        {
            _sourceFilePath = sourceFilePath;
            _targetFailePath = targetFailePath;
        }

        public UpdateResult Update()
        {
            try
            {
                FileInfo fi = new FileInfo(_targetFailePath);
                if (fi.Extension.ToLowerInvariant() != ".pbix")
                {
                    throw new Exception("Only .pbix files are accepted for source files.");
                }

                string newFileName = fi.Name.Substring(0, fi.Name.Length - 5) + ".zip";
                File.Copy(_targetFailePath, newFileName, true);

                overrideTargetArchive(_sourceFilePath, newFileName);

                string guid = Guid.NewGuid().ToString().Substring(0, 7);
                string newPbixFile = fi.FullName.Substring(0, fi.FullName.Length - 5) + "_" + guid + ".pbix";
                File.Move(newFileName, newPbixFile);

                return new UpdateResult(true, string.Empty, newPbixFile);
            }
            catch (Exception ex)
            {
                return new UpdateResult(false, ex.Message, null);
            }
        }

        private void overrideTargetArchive(string updatedFile, string toBeUpdatedFile)
        {
            using (FileStream updated = new FileStream(updatedFile, FileMode.Open))
            using (FileStream toBeUpdated = new FileStream(toBeUpdatedFile, FileMode.Open))
            using (ZipArchive archiveUpdated = new ZipArchive(updated, ZipArchiveMode.Read))
            using (ZipArchive archiveToBeUpdated = new ZipArchive(toBeUpdated, ZipArchiveMode.Update))
            {
                overrideFileInTargetArchice(archiveUpdated, archiveToBeUpdated, "DataModel");
                overrideFileInTargetArchice(archiveUpdated, archiveToBeUpdated, "DataMashup");
                overrideFileInTargetArchice(archiveUpdated, archiveToBeUpdated, "Metadata");
                overrideFileInTargetArchice(archiveUpdated, archiveToBeUpdated, "DiagramState");
            }
        }

        private void overrideFileInTargetArchice(ZipArchive sourceArchive, ZipArchive targetArchive, string fileName)
        {
            ZipArchiveEntry entry = sourceArchive.GetEntry(fileName);
            entry.ExtractToFile(TempFile, true);
            targetArchive.GetEntry(fileName).Delete();
            targetArchive.CreateEntryFromFile(TempFile, fileName, CompressionLevel.NoCompression);
        }

        public class UpdateResult
        {
            public readonly bool Success;
            public readonly string Message;
            public readonly string UpdatedFilePath;

            internal UpdateResult(bool success, string message, string updatedFilePath)
            {
                Success = success;
                Message = message;
                UpdatedFilePath = updatedFilePath;
            }
        }
    }
}

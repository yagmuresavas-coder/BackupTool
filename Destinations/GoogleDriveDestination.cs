using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupTool.Destinations;

public class  GoogleDrivveDestination : IBackupDestination
{
    public string Name => "Google Drive";

    public void Backup(string sourcePath, string destinationPath)
    {
        // Google Drive API'sini kullanarak yedekleme işlemi burada gerçekleştirilecek.
        // Bu, Google Drive API'sine erişim sağlamak ve dosyaları yüklemek için gerekli kodu içerecektir.
        Console.WriteLine($"Google Drive'a yedekleme işlemi başlatıldı: {sourcePath} -> {destinationPath}");
        // Örnek: GoogleDriveApi.UploadFile(sourcePath, destinationPath);
        Console.WriteLine("Google Drive yedekleme tamamlandı.");
    }



}

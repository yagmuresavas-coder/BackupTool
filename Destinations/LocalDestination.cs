using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupTool.Destinations;

public class LocalDestination : IBackupDestination //sözleşmeyi uyguluyoruz 
{
    public string Name => "Yerel Klasör";
    public void Backup(string sourcePath, string destinationPath)
    {
        CopyDirectory(sourcePath, destinationPath);
        Console.WriteLine($"Yedekleme tamamlandı: {sourcePath} -> {destinationPath}");

    }
    private void CopyDirectory(string sourceDir, string destinationDir)
    {
        // Hedef klasör yoksa oluştur
        if (!Directory.Exists(destinationDir))
        {
            Directory.CreateDirectory(destinationDir);
        }
        // Kaynak klasördeki tüm dosyaları kopyala
        foreach (var file in Directory.GetFiles(sourceDir))
        {
            var destFile = Path.Combine(destinationDir, Path.GetFileName(file));
            File.Copy(file, destFile, true); // true: var olan dosyanın üzerine yaz
        }
        // Kaynak klasördeki tüm alt klasörleri kopyala
        foreach (var dir in Directory.GetDirectories(sourceDir))
        {
            var destSubDir = Path.Combine(destinationDir, Path.GetFileName(dir));
            CopyDirectory(dir, destSubDir); // Rekürsif olarak alt klasörleri kopyala
        }
    }
}   


















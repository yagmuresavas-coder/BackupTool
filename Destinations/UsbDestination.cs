using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupTool.Destinations;

public class UsbDestination : IBackupDestination
{
    public string Name => "USB / Harici Disk";

    public void Backup(string sourcePath, string destinationPath)
    {
        // Bilgisayara bağlı tüm sürücüleri tara, sadece çıkarılabilir olanları al
        var drives = DriveInfo.GetDrives()
            .Where(d => d.DriveType == DriveType.Removable && d.IsReady)
            .ToList();

        // Hiç USB takılı değilse uyar ve çık
        if (drives.Count == 0)
        {
            Console.WriteLine(" Bağlı USB/harici disk bulunamadı.");
            return;
        }

        // Bulunan sürücüleri kullanıcıya listele
        Console.WriteLine("Bağlı sürücüler:");
        for (int i = 0; i < drives.Count; i++)
            Console.WriteLine($"  [{i}] {drives[i].Name} ({drives[i].VolumeLabel})");

        // Kullanıcıdan seçim iste
        Console.Write("Seçiminiz: ");
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice >= drives.Count)
        {
            Console.WriteLine("❌ Geçersiz seçim.");
            return;
        }

        // Seçilen USB'nin içine hedef klasörü oluşturup kopyala
        string usbDest = Path.Combine(drives[choice].Name, destinationPath);
        new LocalDestination().Backup(sourcePath, usbDest); // Kopyalama işini LocalDestination yapıyor
        Console.WriteLine($"✅ USB yedekleme tamamlandı: {usbDest}");
    }
}
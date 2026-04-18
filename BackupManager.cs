using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupTool;

using BackupTool.Destinations;

public class BackupManager
{
    // Tüm yedekleme hedeflerini tutan liste
    private readonly List<IBackupDestination> _destinations;

    // Dışarıdan hedef listesi alıyoruz (Program.cs'den gelecek)
    public BackupManager(List<IBackupDestination> destinations)
    {
        _destinations = destinations;
    }

    public void Run()
    {
        Console.WriteLine(" Yedekleme Aracı ");

        // Kullanıcıdan kaynak klasörü al
        Console.Write("Kaynak klasör yolu: ");
        string source = Console.ReadLine()?.Trim() ?? "";

        // Klasör gerçekten var mı kontrol et
        if (!Directory.Exists(source))
        {
            Console.WriteLine(" Kaynak klasör bulunamadı!");
            return;
        }

        // Kullanıcıdan hedef klasör adını al
        Console.Write("Hedef klasör adı: ");
        string dest = Console.ReadLine()?.Trim() ?? "Yedek";

        // Tüm hedefleri numaralandırarak listele
        Console.WriteLine("\nYedekleme hedefi seçin:");
        for (int i = 0; i < _destinations.Count; i++)
            Console.WriteLine($"  [{i}] {_destinations[i].Name}");

        // Seçimi al ve doğrula
        Console.Write("Seçiminiz: ");
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice >= _destinations.Count)
        {
            Console.WriteLine(" Geçersiz seçim.");
            return;
        }

        // Seçilen hedefin Backup metodunu çalıştır
        Console.WriteLine(" Yedekleme başlıyor...");
        _destinations[choice].Backup(source, dest);
    }
}
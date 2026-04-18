# BackupTool

> Basit, hızlı ve genişletilebilir bir dosya yedekleme aracı. C# ile geliştirilmiştir.

---
# Özellikler

- 📁 **Yerel Klasöre Yedekleme** — İstediğin herhangi bir klasöre kopyalar
- 💿 **USB / Harici Diske Yedekleme** — Bağlı çıkarılabilir diskleri otomatik algılar
- ☁️ **Google Drive Desteği** *(yakında)* — Buluta yedekleme desteği geliyor
- 🔁 **Özyinelemeli Kopyalama** — Alt klasörleriyle birlikte eksiksiz kopyalar
- 🧩 **Genişletilebilir Yapı** — Yeni yedekleme hedefi eklemek tek bir sınıf yazmak kadar kolay

---

##  Kullanılan Teknolojiler

- [C#](https://learn.microsoft.com/tr-tr/dotnet/csharp/) — .NET 8.0
- [Visual Studio 2022](https://visualstudio.microsoft.com/tr/)
- `System.IO` — Dosya ve klasör işlemleri
- `DriveInfo` — USB/harici disk algılama

---

##  Proje Yapısı

```
BackupTool/
├── Program.cs                        # Uygulamanın başlangıç noktası
├── BackupManager.cs                  # Kullanıcı etkileşimi ve yedekleme akışı
├── Destinations/
│   ├── IBackupDestination.cs         # Tüm hedefler için ortak sözleşme (interface)
│   ├── LocalDestination.cs           # Yerel klasöre yedekleme
│   ├── UsbDestination.cs             # USB / harici diske yedekleme
│   └── GoogleDriveDestination.cs     # Google Drive (yakında)
└── Config/
    └── BackupConfig.cs               # Yapılandırma ayarları
```

---

##  Kurulum ve Çalıştırma

### Gereksinimler
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- Windows işletim sistemi (USB algılama için)

### Adımlar

```bash
# Repoyu klonla
git clone https://github.com/kullaniciadiniz/BackupTool.git

# Proje klasörüne gir
cd BackupTool

# Çalıştır
dotnet run
```

---

##  Nasıl Kullanılır?

Programı çalıştırdıktan sonra adımları takip et:

```
===  Yedekleme Aracı ===

Kaynak klasör yolu: C:\Users\Kullanici\Documents\Projelerim
Hedef klasör adı: Yedek_Projelerim

Yedekleme hedefi seçin:
  [0] Yerel Klasör
  [1] USB / Harici Disk
  [2] Google Drive

Seçiminiz: 1

Bağlı sürücüler:
  [0] E:\ (USB DISK)

Seçiminiz: 0

 Yedekleme başlıyor...
 USB yedekleme tamamlandı: E:\Yedek_Projelerim
```

---

##  Yol Haritası

- [x] Yerel klasöre yedekleme
- [x] USB / harici diske yedekleme
- [ ] Google Drive entegrasyonu
- [ ] Zamanlayıcı ile otomatik yedekleme
- [ ] Log dosyası tutma
- [ ] WinForms masaüstü arayüzü

---

## Mimari

Bu proje **interface tabanlı** bir yapı kullanır. `IBackupDestination` arayüzü sayesinde her yedekleme hedefi birbirinden bağımsızdır. Yeni bir hedef eklemek için sadece yeni bir sınıf yazman yeterli — başka hiçbir yere dokunman gerekmez.

```
IBackupDestination (sözleşme)
    ├── LocalDestination
    ├── UsbDestination
    └── GoogleDriveDestination
```

---

## Geliştirici

Bu proje C# öğrenme sürecinde geliştirilmiştir.

---

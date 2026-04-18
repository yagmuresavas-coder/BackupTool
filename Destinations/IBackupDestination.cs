using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupTool.Destinations;

public interface IBackupDestination 
{
   string Name { get; } //Her hedefin bir adı olmalı, böylece kullanıcı hangi hedefe yedekleme yapacağını seçebilir.    

    //her hedef bu methodu uygulamalıdır, böylece yedekleme işlemi her hedef için farklı şekilde gerçekleştirilebilir.

    //sourcePath: Yedeklenecek dosya veya klasörün yolu.
    //destinationPath: Yedeklemenin yapılacağı hedefin yolu. Bu, hedefin türüne bağlı olarak farklı şekilde yorumlanabilir (örneğin, bir bulut depolama hizmeti için bir URL olabilir).
    void Backup(string sourcePath, string destinationPath);

}

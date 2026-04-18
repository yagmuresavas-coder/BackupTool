using BackupTool;
using BackupTool.Destinations;

var destinations = new List<IBackupDestination>
{
    new LocalDestination(),
    new UsbDestination(),
    new GoogleDrivveDestination()
};

var manager = new BackupManager(destinations);
manager.Run();
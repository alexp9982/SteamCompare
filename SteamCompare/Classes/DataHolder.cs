using System.Collections.ObjectModel;

namespace SteamCompare.Classes;

public class DataHolder
{
    public static bool NotificationsEnabled { get; set; }
    
    public static string ApiKey { get; set; }

    public static string User1 { get; set; }

    public static string User2 { get; set; }

    public static ObservableCollection<string> Games = new ObservableCollection<string>();
}
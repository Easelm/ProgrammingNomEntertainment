using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameData
{
    public static string playerName = "Unknown";
    public static int playerLevel = 1;
}

public class SaveLoad
{
    public static void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fs = new FileStream("gamesave.bin", FileMode.Create, FileAccess.Write))
        {
            binaryFormatter.Serialize(fs, GameData.playerName);
            binaryFormatter.Serialize(fs, GameData.playerLevel);
        }
    }

    public static void Load()
    {
        if (!File.Exists("gamesave.bin"))
            return;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fs = new FileStream("gamesave.bin", FileMode.Open, FileAccess.Read))
        {
            GameData.playerName = (string)binaryFormatter.Deserialize(fs);
            GameData.playerLevel = (int)binaryFormatter.Deserialize(fs);
        }
    }
}

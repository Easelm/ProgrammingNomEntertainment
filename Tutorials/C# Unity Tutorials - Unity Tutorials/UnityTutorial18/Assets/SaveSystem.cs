using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameData
{
    public static int SceneIndex;
}

public class SaveSystem
{
    public static void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fs = new FileStream("gamesave.bin", FileMode.Create, FileAccess.Write))
        {
            binaryFormatter.Serialize(fs, GameData.SceneIndex);
        }
    }

    public static void Load()
    {
        if (!File.Exists("gamesave.bin"))
            return;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fs = new FileStream("gamesave.bin", FileMode.Open, FileAccess.Read))
        {
            GameData.SceneIndex = (int)binaryFormatter.Deserialize(fs);
        }
    }
}

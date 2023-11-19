using System.Text.Json;
using ProfileParser.Entities;

namespace ProfileParser.Data;

public class JsonSaveData:ISaveDataStrategy
{
    public void Save(List<User> users)
    {
        var json = JsonSerializer.Serialize(users);

        string fileName = "Data.json";
        
        File.WriteAllText(fileName,json);
    }
}
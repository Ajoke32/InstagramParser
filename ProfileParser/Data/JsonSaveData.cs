using System.Text.Json;
using ProfileParser.Entities;
using ProfileParser.Interfaces;

namespace ProfileParser.Data;

public class JsonSaveData:ISaveDataStrategy
{
    
    public void Save(List<User> data)
    {
        var json = JsonSerializer.Serialize(data);

        string fileName = "Data.json";
        
        File.WriteAllText(fileName,json);
    }

    public async Task SaveAsync(List<User> data)
    {
        var json =JsonSerializer.Serialize(data);

        string fileName = "Data.json";

        await File.WriteAllTextAsync(fileName, json);
    }
}
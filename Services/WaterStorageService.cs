using System;
using System.IO;
using System.Text.Json;
using WaterTracker.Models;

namespace WaterTracker.Services;

public class WaterStorageService
{
    private readonly string _filePath;

    public WaterStorageService()
    {
        string folderPath = Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData);

        _filePath = Path.Combine(folderPath, "waterdata.json");
    }

    public void Save(WaterData data)
    {
        string json = JsonSerializer.Serialize(data);
        File.WriteAllText(_filePath, json);
    }

    public WaterData? Load()
    {
        if (!File.Exists(_filePath))
        {
            return null;
        }

        string json = File.ReadAllText(_filePath);

        return JsonSerializer.Deserialize<WaterData>(json);
    }
}
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

        _filePath = Path.Combine(
            folderPath,
            "waterdata.json");
    }

    public void Save(WaterData data)
    {
        JsonSerializerOptions options =
            new JsonSerializerOptions
            {
                WriteIndented = true
            };

        string json =
            JsonSerializer.Serialize(data, options);

        File.WriteAllText(_filePath, json);
    }

    public WaterData? Load()
    {
        if (!File.Exists(_filePath))
        {
            return null;
        }

        try
        {
            string json =
                File.ReadAllText(_filePath);

            return JsonSerializer.Deserialize<WaterData>(json);
        }
        catch
        {
            return null;
        }
    }
}
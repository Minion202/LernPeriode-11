using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WaterTracker.Models;
using WaterTracker.Services;

namespace WaterTracker.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly WaterStorageService _storageService;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Progress))]
    [NotifyPropertyChangedFor(nameof(ProgressPercent))]
    [NotifyPropertyChangedFor(nameof(WaterHeight))]
    [NotifyPropertyChangedFor(nameof(WaterStatus))]
    private int _waterAmount = 0;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Progress))]
    [NotifyPropertyChangedFor(nameof(ProgressPercent))]
    [NotifyPropertyChangedFor(nameof(WaterHeight))]
    [NotifyPropertyChangedFor(nameof(WaterStatus))]
    private int _dailyGoal = 2000;

    public ObservableCollection<WaterEntry> DrinkEntries { get; } = new();

    public ObservableCollection<DailyHistory> DailyHistories { get; } = new();

    public double Progress
    {
        get
        {
            if (DailyGoal <= 0)
                return 0;

            return (double)WaterAmount / DailyGoal;
        }
    }

    public double ProgressPercent
    {
        get
        {
            return Progress * 100;
        }
    }

    public double WaterHeight
    {
        get
        {
            return Math.Min(Progress * 260, 260);
        }
    }

    public string WaterStatus
    {
        get
        {
            return $"{WaterAmount} / {DailyGoal} ml";
        }
    }

    public MainViewModel()
    {
        _storageService = new WaterStorageService();

        WaterData? savedData = _storageService.Load();

        if (savedData != null)
        {
            DailyGoal = savedData.DailyGoal > 0
                ? savedData.DailyGoal
                : 2000;

            foreach (DailyHistory history in savedData.History
                         .OrderByDescending(h => h.Date))
            {
                DailyHistories.Add(history);
            }

            if (savedData.Date.Date == DateTime.Today)
            {
                WaterAmount = savedData.WaterAmount;

                foreach (WaterEntry entry in savedData.Entries
                             .OrderByDescending(e => e.Time))
                {
                    DrinkEntries.Add(entry);
                }
            }
            else
            {
                ArchivePreviousDay(savedData);

                WaterAmount = 0;
                DrinkEntries.Clear();

                SaveData();
            }
        }
    }

    [RelayCommand]
    private void AddWater250()
    {
        AddWater(250);
    }

    [RelayCommand]
    private void AddWater500()
    {
        AddWater(500);
    }

    private void AddWater(int amount)
    {
        WaterAmount += amount;

        WaterEntry entry = new WaterEntry
        {
            Amount = amount,
            Time = DateTime.Now
        };

        DrinkEntries.Insert(0, entry);

        SaveData();
    }

    [RelayCommand]
    private void DeleteEntry(WaterEntry? entry)
    {
        if (entry == null)
            return;

        if (DrinkEntries.Remove(entry))
        {
            WaterAmount = Math.Max(0, WaterAmount - entry.Amount);

            SaveData();
        }
    }

    [RelayCommand]
    private void SaveDailyGoal()
    {
        if (DailyGoal < 250)
        {
            DailyGoal = 250;
        }

        SaveData();
    }

    [RelayCommand]
    private void ResetWater()
    {
        WaterAmount = 0;
        DrinkEntries.Clear();

        SaveData();
    }

    private void ArchivePreviousDay(WaterData savedData)
    {
        bool hasData =
            savedData.WaterAmount > 0 ||
            savedData.Entries.Count > 0;

        if (!hasData)
            return;

        bool alreadyExists = DailyHistories.Any(
            h => h.Date.Date == savedData.Date.Date);

        if (alreadyExists)
            return;

        DailyHistory history = new DailyHistory
        {
            Date = savedData.Date.Date,
            WaterAmount = savedData.WaterAmount,
            DailyGoal = savedData.DailyGoal
        };

        DailyHistories.Insert(0, history);
    }

    private void SaveData()
    {
        WaterData data = new WaterData
        {
            WaterAmount = WaterAmount,
            DailyGoal = DailyGoal,
            Date = DateTime.Today,
            Entries = DrinkEntries.ToList(),
            History = DailyHistories.ToList()
        };

        _storageService.Save(data);
    }
}
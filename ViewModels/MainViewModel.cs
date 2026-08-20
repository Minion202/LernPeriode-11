using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WaterTracker.Models;
using WaterTracker.Services;

namespace WaterTracker.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly WaterStorageService _storageService;

    [ObservableProperty]
    private int _waterAmount = 0;

    [ObservableProperty]
    private int _dailyGoal = 2000;

    public MainViewModel()
    {
        _storageService = new WaterStorageService();

        WaterData? savedData = _storageService.Load();

        if (savedData != null)
        {
            WaterAmount = savedData.WaterAmount;
            DailyGoal = savedData.DailyGoal;
        }
    }

    [RelayCommand]
    private void AddWater250()
    {
        WaterAmount += 250;
        SaveData();
    }

    [RelayCommand]
    private void AddWater500()
    {
        WaterAmount += 500;
        SaveData();
    }

    private void SaveData()
    {
        WaterData data = new WaterData();

        data.WaterAmount = WaterAmount;
        data.DailyGoal = DailyGoal;
        data.Date = DateTime.Today;

        _storageService.Save(data);
    }
}
using System;

namespace WaterTracker.Models;

public class WaterData
{
    public int WaterAmount { get; set; }
    public int DailyGoal { get; set; }
    public DateTime Date { get; set; }
}
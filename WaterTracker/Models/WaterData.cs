using System;
using System.Collections.Generic;

namespace WaterTracker.Models;

public class WaterData
{
    public int WaterAmount { get; set; }

    public int DailyGoal { get; set; } = 2000;

    public DateTime Date { get; set; }

    public List<WaterEntry> Entries { get; set; } = new();

    public List<DailyHistory> History { get; set; } = new();
}
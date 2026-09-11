using System;

namespace WaterTracker.Models;

public class DailyHistory
{
    public DateTime Date { get; set; }

    public int WaterAmount { get; set; }

    public int DailyGoal { get; set; }

    public string DateText
    {
        get
        {
            return Date.ToString("dd.MM.yyyy");
        }
    }

    public string StatusText
    {
        get
        {
            return $"{WaterAmount} / {DailyGoal} ml";
        }
    }

    public bool GoalReached
    {
        get
        {
            return WaterAmount >= DailyGoal;
        }
    }

    public bool GoalNotReached
    {
        get
        {
            return !GoalReached;
        }
    }
}
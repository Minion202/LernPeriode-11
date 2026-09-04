using System;

namespace WaterTracker.Models;

public class WaterEntry
{
    public int Amount { get; set; }

    public DateTime Time { get; set; }

    public string AmountText
    {
        get
        {
            return $"+{Amount} ml";
        }
    }

    public string TimeText
    {
        get
        {
            return Time.ToString("HH:mm");
        }
    }
}
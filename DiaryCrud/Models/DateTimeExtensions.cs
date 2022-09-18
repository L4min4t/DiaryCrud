using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiaryCrud.Models
{
    public static class DateTimeExtensions
    {
        public static List<DateTime> DatesOfCurrentWeek(this DateTime dt)
        {
            int diff = (7 + (dt.DayOfWeek - DayOfWeek.Monday)) % 7;
            List<DateTime> datesOfCurrentWeek = new List<DateTime>();
            datesOfCurrentWeek.Add(dt.AddDays(-1 * diff).Date);
            for(int i = 1; i < 7; i++) datesOfCurrentWeek.Add(datesOfCurrentWeek[0].AddDays(i));
            return datesOfCurrentWeek;
        }
    }
}
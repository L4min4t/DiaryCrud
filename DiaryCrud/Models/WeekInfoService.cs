using System;
using System.Collections.Generic;
using System.Linq;
using WebGrease.Css.Extensions;

namespace DiaryCrud.Models
{
    public class WeekInfoService
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public WeekInfoDto GetInfo(ApplicationUser user)
        {
            var weekInfo = new WeekInfoDto { CurentDay = DateOnly.FromDateTime(DateTime.Now) };
            var recordsByUser = _context.Records.AsQueryable().Where(r => r.UserId.Equals(user.Id)).ToList();
            var dates = recordsByUser.Select(d => DateOnly.FromDateTime(d.Date).DayOfWeek);
            dates.ForEach(r => weekInfo.Records.Add(r, recordsByUser.Where(d => r.Equals(DateOnly.FromDateTime(d.Date).DayOfWeek)).ToList()));
            return weekInfo;
        }
    }
    public class WeekInfoDto
    {
        public DateOnly CurentDay { get; set; }
        public Dictionary<DayOfWeek, List<Record>> Records { get; set; } = new Dictionary<DayOfWeek, List<Record>>();
    }
}
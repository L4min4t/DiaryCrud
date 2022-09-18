using System;
using System.Collections.Generic;
using System.Linq;

namespace DiaryCrud.Models
{
    public class WeekInfoService
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public WeekInfoDto GetInfo(ApplicationUser user)
        {
            var weekInfo = new WeekInfoDto { CurentDay = DateOnly.FromDateTime(DateTime.Now) };
            var currentDates = DateTime.Now.DatesOfCurrentWeek();
            var recordsByUser = _context.Records.AsQueryable().Where(r => r.UserId.Equals(user.Id)).ToList();
            currentDates.ForEach(dts => weekInfo.Records.Add(dts, recordsByUser.Where(r => r.Date.Equals(dts)).ToList()));
            return weekInfo;
        }

        public void AddRecord(Record record)
        {
            _context.Records.Add(record);
            _context.SaveChanges();
        }

        public void DeleteRecord(int id)
        {
            _context.Records.Remove(_context.Records.Find(id));
            _context.SaveChanges();
        }
        
        public void ChangeRecordsState(int id)
        {
            var record = _context.Records.SingleOrDefault(b => b.Id == id);
            if (record != null)
            {
                record.IsDone = !record.IsDone;
                _context.SaveChanges();
            }

        }

        public void ChangeRecordsText(int id, string text)
        {
            var record = _context.Records.SingleOrDefault(b => b.Id == id);
            if (record != null)
            {
                record.Text = text;
                _context.SaveChanges();
            }

        }
    }
    public class WeekInfoDto
    {
        public DateOnly CurentDay { get; set; }
        public Dictionary<DateTime, List<Record>> Records { get; set; } = new Dictionary<DateTime, List<Record>>();
    }
}
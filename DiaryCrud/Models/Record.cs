using System;
using System.Data.Entity;

namespace DiaryCrud.Models
{
    public class Record
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }
    }
}
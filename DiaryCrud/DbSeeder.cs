using DiaryCrud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DiaryCrud
{
    public class DbSeeder : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var records = new List<Record>
            {
                new Record
                {
                    Text = "aboba",
                    Date = DateTime.Now,
                    UserId = "4287190e-bfcb-4766-9f5d-218aca7259a9",
                    IsDone = true
                },
                new Record
                {
                    Text = "AVTOBA",
                    Date = DateTime.Now.AddDays(1),
                    UserId = "4287190e-bfcb-4766-9f5d-218aca7259a9",
                    IsDone = false
                },
                new Record
                {
                    Text = "BaObaB",
                    Date = DateTime.Now.AddDays(-1),
                    IsDone = false
                }
            };
            records.ForEach(r => context.Records.Add(r));
            context.SaveChanges();
        }
    }
}
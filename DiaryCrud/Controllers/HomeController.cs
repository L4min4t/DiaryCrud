using DiaryCrud.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DiaryCrud.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUserManager _applicationUserManager { get => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var user = await _applicationUserManager.FindByIdAsync(HttpContext.User.Identity.GetUserId());
            if (user != null)
            {
                var weekInfo = new WeekInfoService();
                return View(weekInfo.GetInfo(user)); 
            } else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddRecord(FormCollection fc)
        {
            var user = await _applicationUserManager.FindByIdAsync(HttpContext.User.Identity.GetUserId());
            if (user != null)
            {
                var weekInfo = new WeekInfoService();
                if (!fc["Text"].IsNullOrWhiteSpace())
                {
                    weekInfo.AddRecord(new Record
                    {
                        Date = DateTime.Parse(fc["Date"]),
                        Text = fc["Text"],
                        UserId = user.Id,
                        IsDone = false
                    });
                }
                return View("Index", weekInfo.GetInfo(user));
            }
            else
            {
                return View("Index");
            }
        }

        public async Task<ActionResult> DeleteRecord(int id)
        {
            var user = await _applicationUserManager.FindByIdAsync(HttpContext.User.Identity.GetUserId());
            if (user != null)
            {
                var weekInfo = new WeekInfoService();
                weekInfo.DeleteRecord(id);
                return View("Index", weekInfo.GetInfo(user));
            }
            else
            {
                return View("Index");
            }
        }

        public async Task<ActionResult> ChangeRecordsState(int id)
        {
            var user = await _applicationUserManager.FindByIdAsync(HttpContext.User.Identity.GetUserId());
            if (user != null)
            {
                var weekInfo = new WeekInfoService();
                weekInfo.ChangeRecordsState(id);
                return View("Index", weekInfo.GetInfo(user));
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> ChangeRecordsText(FormCollection fc)
        {
            var user = await _applicationUserManager.FindByIdAsync(HttpContext.User.Identity.GetUserId());
            if (user != null)
            {
                var weekInfo = new WeekInfoService();
                weekInfo.ChangeRecordsText(Int32.Parse(fc["Id"]), fc["RText"]);
                return View("Index", weekInfo.GetInfo(user));
            }
            else
            {
                return View("Index");
            }
        }
    }
}
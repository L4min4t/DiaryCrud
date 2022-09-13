using DiaryCrud.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
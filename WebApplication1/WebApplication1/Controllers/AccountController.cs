using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult DangNhap()
        {
            return View();
        }

		public ActionResult DangKy()
		{
			return View();
		}
	}
}
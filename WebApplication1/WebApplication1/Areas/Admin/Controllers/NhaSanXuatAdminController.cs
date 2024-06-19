using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.BUS;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class NhaSanXuatAdminController : Controller
    {
		// GET: Admin/NhaSanXuatAdmin

		public NhaSanXuatAdminController() { }

		public ActionResult Index()
        {
            var ds = NhaSanXuatBUS.DanhSachAdmin();
            return View(ds);
        }

        // GET: Admin/NhaSanXuatAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/NhaSanXuatAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaSanXuatAdmin/Create
        [HttpPost]
        public ActionResult Create(NhaSanXuat nsx)
        {
            try
            {
                // TODO: Add insert logic here
                //ham them 
                NhaSanXuatBUS.ThemNSX(nsx);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NhaSanXuatAdmin/Edit/5
        public ActionResult Edit(String id)
        {
			var nsx = NhaSanXuatBUS.ChiTietAdmin(id);
			return View(nsx);
		}

        // POST: Admin/NhaSanXuatAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(String id, NhaSanXuat nsx)
        {
            try
            {
                // TODO: Add update logic here
                NhaSanXuatBUS.updateNSX(id, nsx);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

		public ActionResult XoaTamThoi(String id)
		{
			return View(NhaSanXuatBUS.ChiTietAdmin(id));
		}
		// GET: Admin/NhaSanXuatAdmin/Delete/5
		

        // POST: Admin/NhaSanXuatAdmin/Delete/5
        [HttpPost]
        public ActionResult XoaTamThoi(String id, NhaSanXuat nsx)
        {
            try
            {
                // TODO: Add delete logic here
                nsx.TinhTrang = "1";
                //nsx.MaNhaSanXuat = id; // hoac la nhu the nay
                NhaSanXuatBUS.updateNSX(id, nsx); // cho nay nsx no khong co id
				return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        

        [HttpGet]
		public ActionResult Delete(String id)
		{
			try
			{
                // TODO: Add delete logic here
                NhaSanXuatBUS.DeleteNsx(id);
				return RedirectToAction("Index");
			}
			catch(Exception ex)
			{
				return View();
			}
		}
	}
}

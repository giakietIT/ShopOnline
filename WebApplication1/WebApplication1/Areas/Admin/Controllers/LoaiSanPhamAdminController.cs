using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.BUS;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class LoaiSanPhamAdminController : Controller
    {
		public LoaiSanPhamAdminController() { }

		// GET: Admin/LoaiSanPhamAdmin
		public ActionResult Index()
        {
            var db = LoaiSanPhamBUS.DanhSachAdmin();
            return View(db);
        }

        // GET: Admin/LoaiSanPhamAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/LoaiSanPhamAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSanPhamAdmin/Create
        [HttpPost]
        public ActionResult Create(LoaiSanPham lsp)
        {
			try
			{
				// TODO: Add insert logic here
				//ham them 
				LoaiSanPhamBUS.ThemLSP(lsp);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Admin/LoaiSanPhamAdmin/Edit/5
		public ActionResult Edit(String id)
		{
			var lsp = LoaiSanPhamBUS.ChiTietAdmin(id);
			return View(lsp);
		}

		// POST: Admin/NhaSanXuatAdmin/Edit/5
		[HttpPost]
		public ActionResult Edit(String id, LoaiSanPham lsp)
		{
			try
			{
				// TODO: Add update logic here
				LoaiSanPhamBUS.updateLSP(id, lsp);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		public ActionResult XoaTamThoi(String id)
		{
			return View(LoaiSanPhamBUS.ChiTietAdmin(id));
		}
		// GET: Admin/LoaiSanPhamAdmin/Delete/5


		// POST: Admin/LoaiSanPhamAdmin/Delete/5
		[HttpPost]
		public ActionResult XoaTamThoi(String id, LoaiSanPham lsp)
		{
			try
			{
				// TODO: Add delete logic here
				lsp.TinhTrang = "1";
				//nsx.MaNhaSanXuat = id; // hoac la nhu the nay
				LoaiSanPhamBUS.updateLSP(id, lsp); // cho nay nsx no khong co id
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
				LoaiSanPhamBUS.DeleteLSP(id);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return View();
			}
		}
	}
}

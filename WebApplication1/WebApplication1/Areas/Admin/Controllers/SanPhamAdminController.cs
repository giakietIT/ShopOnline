using PetaPoco;
using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.BUS;

namespace WebApplication1.Areas.Admin.Controllers
{
	public partial class SanPhamAdminController : Controller
    {
        // GET: Admin/SanPhamAdmin
        public ActionResult Index()
        {
          
            return View(ShopOnlineBUS.DanhSachAdmin());
        }

        // GET: Admin/SanPhamAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        private CreateSanPhamViewModel CreateDefaultViewModel()
        {
			var vm = new CreateSanPhamViewModel();

			vm.NhaSanXuatList = NhaSanXuatBUS.DanhSach()?.Select(x => new SelectListItem
			{
				Text = x.TenNhaSanXuat,
				Value = x.MaNhaSanXuat
			}) ?? new List<SelectListItem>();

			vm.LoaiSanPhamList = LoaiSanPhamBUS.DanhSach()?.Select(x => new SelectListItem
			{
				Text = x.TenLoaiSanPham,
				Value = x.MaLoaiSanPham
			}) ?? new List<SelectListItem>();

            return vm;
		}

		// GET: Admin/SanPhamAdmin/Create
		public ActionResult Create()
        {
            //ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat");
            //ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham");

            // thy vi dung viewbag, minh dung viewmodel

            

			return View(CreateDefaultViewModel());
        }

		// POST: Admin/SanPhamAdmin/Create
		[HttpPost]
        public ActionResult Create(SanPham sp)
        {
            try
            {
				var hpf = HttpContext.Request.Files[0];
                if (hpf.ContentLength > 0)
                {
					string fileName = sp.MaSanPham + "_main.png";
					string fullPathWithFileName = "/Asset/img/" + fileName;
                    var storePath = Server.MapPath(fullPathWithFileName);
					hpf.SaveAs(storePath);
                    sp.HinhChinh = fullPathWithFileName;

                   // CHO NAY LUU SAI PATH ROI
                   //DOI TI

                    //
				}

                //no ko tra ve duoc cai img ha anh 
                // TODO: Add 1


                var hpf1 = HttpContext.Request.Files[1];
                if (hpf1.ContentLength > 0)
                {
					string fileName = sp.MaSanPham + "_1.png";
					string fullPathWithFileName = "/Asset/img/" + fileName;
					var storePath = Server.MapPath(fullPathWithFileName);
					hpf.SaveAs(storePath);
					sp.Hinh1 = fullPathWithFileName;
				}
                //----------------

                var hpf2 = HttpContext.Request.Files[2];
                if (hpf2.ContentLength > 0)
                {
					string fileName = sp.MaSanPham + "_2.png";
					string fullPathWithFileName = "/Asset/img/" + fileName;
					var storePath = Server.MapPath(fullPathWithFileName);
					hpf.SaveAs(storePath);
					sp.Hinh2 = fullPathWithFileName;
				}
                //----------------

                var hpf3 = HttpContext.Request.Files[3];
                if (hpf3.ContentLength > 0)
                {
					string fileName = sp.MaSanPham + "_3.png";
					string fullPathWithFileName = "/Asset/img/" + fileName;
					var storePath = Server.MapPath(fullPathWithFileName);
					hpf.SaveAs(storePath);
					sp.Hinh3= fullPathWithFileName;
				}
                //----------------

                var hpf4 = HttpContext.Request.Files[4]; //
                if (hpf4.ContentLength > 0)
                {
					string fileName = sp.MaSanPham + "_4.png";
					string fullPathWithFileName = "/Asset/img/" + fileName;
					var storePath = Server.MapPath(fullPathWithFileName);
					hpf.SaveAs(storePath);
					sp.Hinh4= fullPathWithFileName;
				}

                //----------------
                sp.TinhTrang = "0";
                sp.SoLuongDaBan = 0;
				ShopOnlineBUS.ThemSP(sp);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
				// dung bao gio catch ma ko co exception
				// neu co loi no se~ lam` mat' loi khong the trace dc

				TempData["Message"] = ex.Message;
                return View(CreateDefaultViewModel());
            }
        }

        // GET: Admin/SanPhamAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/SanPhamAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/SanPhamAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

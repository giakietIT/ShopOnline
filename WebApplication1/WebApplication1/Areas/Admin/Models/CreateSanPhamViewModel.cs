using ShopOnlineConnection;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication1.Areas.Admin
{
	public class CreateSanPhamViewModel
	{
		public CreateSanPhamViewModel()
		{
			NhaSanXuatList = new List<SelectListItem>();
			LoaiSanPhamList = new List<SelectListItem>();
		}


		public IEnumerable<SelectListItem> NhaSanXuatList { get; set; }
		public string MaNhaSanXuat { get; set; }

		public IEnumerable<SelectListItem> LoaiSanPhamList { get; set; }

		public string MaLoaiSanPham { get; set; }
	}
}

using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.BUS
{
	public class LoaiSanPhamBUS
	{
		//KhachHang
		public static IEnumerable<LoaiSanPham> DanhSach()
		{
			var db = new ShopOnlineConnectionDB();
			return db.Query<LoaiSanPham>("select * from LoaiSanPham where TinhTrang = 0");
		}

		public static IEnumerable<SanPham> ChiTiet(String id)
		{
			var db = new ShopOnlineConnectionDB();
			return db.Query<SanPham>("select * from SanPham where MaLoaiSanPham = '" + id + "'");
		}


		//Admin
		public static void ThemLSP(LoaiSanPham lsp)
		{
			var db = new ShopOnlineConnectionDB();
			db.Insert(lsp);
		}

		public static IEnumerable<LoaiSanPham> DanhSachAdmin()
		{
			var db = new ShopOnlineConnectionDB();
			return db.Query<LoaiSanPham>("select * from LoaiSanPham ");
		}

		public static LoaiSanPham ChiTietAdmin(String id)
		{
			var db = new ShopOnlineConnectionDB();
			return db.SingleOrDefault<LoaiSanPham>("select * from LoaiSanPham where MaLoaiSanPham = '" + id + "'");
		}

		public static void updateLSP(string id, LoaiSanPham lsp)
		{
			var db = new ShopOnlineConnectionDB();

			lsp.MaLoaiSanPham = id; // hoac la nhu the nay

			db.Update("LoaiSanPham", "MaLoaiSanPham", lsp);
		} 

		public static void DeleteLSP(String id)
		{
			var db = new ShopOnlineConnectionDB();
			db.Delete<LoaiSanPham>(new LoaiSanPham{ MaLoaiSanPham= (id) });
		}

		//public static void DeleteLSP(String id, LoaiSanPham lsp)
		//{
		//	var db = new ShopOnlineConnectionDB();
		//	db.Update(id, lsp);
		//}
	}
}
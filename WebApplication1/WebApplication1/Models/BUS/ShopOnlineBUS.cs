using ShopOnlineConnection;
using System;
using System.Collections.Generic;


namespace WebApplication1.Models.BUS
{
	public class ShopOnlineBUS
	{
		public static IEnumerable<SanPham> DanhSach()
		{
			var db = new ShopOnlineConnectionDB();
			return db.Query<SanPham>("select * from SanPham where Gia > 0");
		}

		public static SanPham ChiTiet(String a)
		{
			var db = new ShopOnlineConnectionDB();
			return db.SingleOrDefault<SanPham>("select * from SanPham where MaSanPham = @0", a);
		}

		public static IEnumerable<SanPham> Top4New()
		{
			var db = new ShopOnlineConnectionDB();
			return db.Query<SanPham>("select Top 4 * from SanPham where Gia > 0");
		}

		public static IEnumerable<SanPham> TopHot()
		{
			var db = new ShopOnlineConnectionDB();
			return db.Query<SanPham>("select Top 4 * from SanPham where LuotView > 0");
		}
	}
}
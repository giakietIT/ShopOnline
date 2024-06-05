using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

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

		
	}
}
﻿using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.BUS
{
	public class NhaSanXuatBUS
	{
		//Khach hang
		public static IEnumerable<NhaSanXuat> DanhSach()
		{
			var db = new ShopOnlineConnectionDB();
			return db.Query<NhaSanXuat>("select * from NhaSanXuat where TinhTrang = 0");
		}

		public static IEnumerable<SanPham> ChiTiet(String id)
		{
			var db = new ShopOnlineConnectionDB();
			return db.Query<SanPham>("select * from SanPham where MaNhaSanXuat = '"+ id +"'" );
		}

		//Admin Page
		public static void ThemNSX(NhaSanXuat nsx)
		{
			var db = new ShopOnlineConnectionDB();
			db.Insert(nsx);
		}

		public static IEnumerable<NhaSanXuat> DanhSachAdmin()
		{
			var db = new ShopOnlineConnectionDB();
			return db.Query<NhaSanXuat>("select * from NhaSanXuat ");
		}

		public static NhaSanXuat ChiTietAdmin(String id) 
		{
			var db = new ShopOnlineConnectionDB();
			return db.SingleOrDefault<NhaSanXuat>("select * from NhaSanXuat where MaNhaSanXuat = '" + id + "'");
		}

		public static void updateNSX(string id, NhaSanXuat nsx)
		{
			var db = new ShopOnlineConnectionDB();
			db.Update(id, nsx);
		} 
	}
}
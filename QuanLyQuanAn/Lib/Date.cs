using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.Lib
{
    class Date
    {

		// Hàm kiểm tra năm nhuận
		private static bool laNamNhuan(int nYear)
		{
			if ((nYear % 4 == 0 && nYear % 100 != 0) || nYear % 400 == 0)
			{
				return true;
			}
			return false;

			// <=> return ((nYear % 4 == 0 && nYear % 100 != 0) || nYear % 400 == 0);
		}

			// Hàm trả về số ngày trong tháng thuộc năm cho trước
		private static int tinhSoNgayTrongThang(int nMonth, int nYear)
		{
			int nNumOfDays = 0;

			switch (nMonth)
			{
				case 1:
				case 3:
				case 5:
				case 7:
				case 8:
				case 10:
				case 12:
					nNumOfDays = 31;
					break;
				case 4:
				case 6:
				case 9:
				case 11:
					nNumOfDays = 30;
					break;
				case 2:
					if (laNamNhuan(nYear))
					{
						nNumOfDays = 29;
					}
					else
					{
						nNumOfDays = 28;
					}
					break;
			}

			return nNumOfDays;
		}

		// Hàm kiểm tra ngày dd/mm/yyyy cho trước có phải là ngày hợp lệ
		public static bool laNgayHopLe(int nDay, int nMonth, int nYear)
		{
			// Kiểm tra năm
			if (nYear < 0)
			{
				return false; // Ngày không còn hợp lệ nữa!
			}

			// Kiểm tra tháng
			if (nMonth < 1 || nMonth > 12)
			{
				return false; // Ngày không còn hợp lệ nữa!
			}

			// Kiểm tra ngày
			if (nDay < 1 || nDay > tinhSoNgayTrongThang(nMonth, nYear))
			{
				return false; // Ngày không còn hợp lệ nữa!
			}

			return true; // Trả về trạng thái cuối cùng...
		}
		public static DateTime StringToDate(string value)
		{
			return DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
		}
		public static string DateToString(DateTime dateTime)
		{
			return dateTime.ToString("dd/MM/yyyy");
		}
	}
}

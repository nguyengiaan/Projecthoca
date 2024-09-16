using System;
using System.Security.Cryptography.X509Certificates;

namespace Projecthoca.Models.Enitity
{
    public class Baocaodoanhthuct
    {
            public string SoPhieu { get; set; }
            public DateTime Ngayphieu {get; set;}

            public string Tenmathang { get; set; }

            public string Tenkhachhang{get; set;}

            public string Dienthoai {get; set;}

            public string Masanpham{get;set;}

            public string Tensanpham{get;set;}

            public string Donvitinh{get;set;}

            public int Soluong {get;set;}

            public int DonGia {get;set;}

            public int Tongcong {get;set;}

            public string TenNV {get;set;}
      
    }
}
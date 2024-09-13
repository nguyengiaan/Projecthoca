using System;

namespace Projecthoca.Models.EnitityVM
{
    public class DailyInventory
    {
       public DateTime Date { get; set; }

       public string Ma_danhmuc { get; set; }

         public int SoLuongTon { get; set; }

        public string Ten_danhmuc { get; set; }

        public string Donvitinh {get;set;}
    }
}
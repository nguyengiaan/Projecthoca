using Microsoft.EntityFrameworkCore;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;
using System.Xml.Linq;

namespace Projecthoca.Service.Responser
{
    public class KhuvuccauReponser : IKhuvuccau
    {
        private readonly MyDbcontext _context;

        public KhuvuccauReponser(MyDbcontext context)
        {
            _context = context;
        }
        public async Task<bool> Themkhuvuccau(KhuvuccauVM khuvuccau)
        {
            try
            {
                int nextNumber1 = 1;
                var lastMaDV = await _context.Khuvuccau
                              .OrderByDescending(x => x.Ma_Khuvuccau)
                              .Select(x => x.Ma_Khuvuccau)
                              .FirstOrDefaultAsync();
                int nextNumber = 1;
                if (lastMaDV != null)
                {
                    nextNumber = int.Parse(lastMaDV.Substring(2)) + 1;
                }
                var makv = "KV" + nextNumber.ToString("D4");
                Khuvuccau kv = new Khuvuccau();
                kv.Ma_Khuvuccau = makv;
                kv.Ten_Khuvuccau = khuvuccau.Ten_Khuvuccau;
                kv.Idkhuvuccau = khuvuccau.Idkhuvuccau;
                kv.Ma_hoca = khuvuccau.Ma_hoca;
     
                kv.Trangthai = khuvuccau.Trangthai;
                await _context.Khuvuccau.AddAsync(kv);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<KhuvuccauVM>> Danhsachkhuvuccau(string Ma_hocau)
        {
            try
            {
                var data = await _context.Khuvuccau.Where(x => x.Ma_hoca == Ma_hocau).Select(x => new KhuvuccauVM
                {
                    Ma_Khuvuccau = x.Ma_Khuvuccau,
                    Ten_Khuvuccau = x.Ten_Khuvuccau,
                    Idkhuvuccau = x.Idkhuvuccau,
                    Ma_hoca = x.Ma_hoca,
                    Trangthai = x.Trangthai,
                    Timeout = x.Thuehocas.Select(th => th.Timeout).FirstOrDefault(),

            }).ToListAsync();
                return data;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Themkhachthue(ThuehocaVM thc)
        {
            try
            {
                var kvc = await _context.Khuvuccau.FindAsync(thc.Ma_khuvuccau);
                int nextNumber1 = 1;
                var lastMaDV = await _context.Thuehoca
                              .OrderByDescending(x => x.Ma_thuehoca)
                              .Select(x => x.Ma_thuehoca)
                              .FirstOrDefaultAsync();
                int nextNumber = 1;
                if (lastMaDV != null)
                {
                    nextNumber = int.Parse(lastMaDV.Substring(2)) + 1;
                }
                var mact = "CT" + nextNumber.ToString("D4");
                Thuehoca ct = new Thuehoca();
                ct.Ma_thuehoca = mact;
                ct.Ma_khuvuccau = thc.Ma_khuvuccau;
                ct.Ten_khachhang = thc.Ten_khachhang;
                ct.Ngaycau = thc.Ngaycau;
                ct.Thoigianbatdau = thc.Thoigianbatdau;
                ct.Timeout=new TimeSpan(0, 0, 0);
                ct.trangthai = "Chuabamgio";
                kvc.Trangthai = "Cokhach";
                await _context.Thuehoca.AddAsync(ct);
                await _context.SaveChangesAsync();
                return true;


            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Kiemtrakv(string Ma_khuvuc)
        {
            try
            {
                var data= await _context.Thuehoca.Where(x => x.Ma_khuvuccau == Ma_khuvuc).FirstOrDefaultAsync();
                if (data != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex )
            {
                return false;
            }
        }

        public async Task<TimeSpan> Laythoigian(string Ma_khuvuc)
        {
            try
            {
                var data = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == Ma_khuvuc).FirstOrDefaultAsync();
                if (data != null)
                {
                    return data.Timeout;
                }
                else
                {
                    return TimeSpan.Zero;
                }
            }
            catch(Exception ex)
            {
                return TimeSpan.Zero;
            }
        }

        public async Task<bool> CapnhatTg(string Ma_khuvuc,TimeSpan time)
            
        {
            try
            {
               var data=await _context.Thuehoca.Where(x => x.Ma_khuvuccau == Ma_khuvuc).FirstOrDefaultAsync();
                if (data != null)
                {
                    data.Timeout =time ;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Demthoigian(string maKhuvuc)
        {
            try
            {
                var data = await _context.Thuehoca.FirstOrDefaultAsync(x => x.Ma_khuvuccau == maKhuvuc);
                data.Timeout = data.Timeout.Add(TimeSpan.FromSeconds(1));
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateBamgio(string Ma_khuvuc)
        {
            try
            {
                var data = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == Ma_khuvuc).FirstOrDefaultAsync();
                if (data != null)
                {
                    data.trangthai = "Dabamgio";
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public async Task<bool> KiemtraBamgio(string Ma_khuvuc)
        {
            try
            {
                var data = await _context.Thuehoca.Where(x => x.Ma_khuvuccau == Ma_khuvuc).FirstOrDefaultAsync();
                if (data != null)
                {
                    if (data.trangthai == "Dabamgio")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}

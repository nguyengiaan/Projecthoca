using Microsoft.EntityFrameworkCore;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;

namespace Projecthoca.Service.Responser
{
    public class HocaReponser : IHoca
    {
        private readonly MyDbcontext _context;

        public HocaReponser(MyDbcontext context)
        {
            _context = context;
        }
        public async Task<bool> Themhoca(HocaVM hoca)
        {
            try
            {
                int nextNumber1 = 1;
                var lastMaDV = await _context.Hoca
                              .OrderByDescending(x => x.Ma_hoca)
                              .Select(x => x.Ma_hoca)
                              .FirstOrDefaultAsync();
                int nextNumber = 1;
                if (lastMaDV != null)
                {
                    nextNumber = int.Parse(lastMaDV.Substring(2)) + 1;
                }
                var mahc = "HC" + nextNumber.ToString("D4");
                Hoca hc = new Hoca();
                hc.Ma_hoca = mahc;
                hc.Ten_hoca = hoca.Ten_hoca;
                hc.Id = hoca.Id;
                hc.Kieuhoca = hoca.Kieuhoca;
                await _context.Hoca.AddAsync(hc);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }
    }
}

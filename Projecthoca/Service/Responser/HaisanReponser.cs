using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Models.Entity;
using Projecthoca.Service.Interface;

namespace Projecthoca.Service.Responser
{
    public class HaisanReponser : IHaisan
    {
        private readonly MyDbcontext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HaisanReponser(MyDbcontext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<(List<HaisanVM> ds, int totalPages)> Danhsachhaisan(int page, int pagesize)
        {
           try
           {
                 var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if(page < 1 && pagesize < 1)
            {
                 var haisan1 =await _context.Haisans.Where(x => x.Id == user.Id).Select(x=>new HaisanVM{
                    Ma_haisan = x.Ma_haisan,
                    Ten_haisan = x.Ten_haisan,
                    sokg = x.sokg,
                    Gia = x.Gia
                }).OrderByDescending(x=>x.Ma_haisan)
                         .ToListAsync();
                return (haisan1,0);
            }
                
                var totalItems = _context.Haisans.Count();
                var totalpages = (int)Math.Ceiling(totalItems / (double)pagesize);

                var haisan =await _context.Haisans.Where(x => x.Id == user.Id).Select(x=>new HaisanVM{
                    Ma_haisan = x.Ma_haisan,
                    Ten_haisan = x.Ten_haisan,
                    sokg = x.sokg,
                    Gia = x.Gia
                }).OrderByDescending(x=>x.Ma_haisan)
                         .Skip((page - 1) * pagesize)
                         .Take(pagesize)
                         .ToListAsync();
                return (haisan,totalpages);
           }
           catch(Exception ex)
           {
               return (null,0  );
           }    
        }

        public async Task<HaisanVM> Laythongtinhaisan(int Ma_haisan)
        {
           try
           {
                var data= await _context.Haisans.FirstAsync(x=>x.Ma_haisan == Ma_haisan);
                var haisan = new HaisanVM
                {
                    Ma_haisan = data.Ma_haisan,
                    Ten_haisan = data.Ten_haisan,
                    sokg = data.sokg,
                    Gia = data.Gia
                };
                return haisan;
           }
           catch(Exception ex)
           {
               return null;
           }
        }

        public async Task<bool> Suahaisan(HaisanVM haisan)
        {
           try
           {
               var data= _context.Haisans.First(x=>x.Ma_haisan == haisan.Ma_haisan);
                data.Ten_haisan = haisan.Ten_haisan;
                data.sokg = haisan.sokg;
                data.Gia = haisan.Gia;
                _context.Haisans.Update(data);
               await _context.SaveChangesAsync(); 
                return true;
           }
           catch(Exception ex)
           {
                return false;
           }
        }

        public async Task<bool> Themhaisan(HaisanVM haisan)
        {
           try
           {
                var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
                var user = await _userManager.FindByIdAsync(userId);
                var haisan1 = new Haisan
                {
                     Ten_haisan = haisan.Ten_haisan,
                     sokg = haisan.sokg,
                     Gia = haisan.Gia,
                     Id = user.Id
                };
                _context.Haisans.Add(haisan1);
                await _context.SaveChangesAsync();
                return true;
           }
           catch(Exception ex)
           {
               return false;
           }
        }

        public async Task<bool> Xoahaisan(int Ma_haisan)
        {
           try
           {
                try
                {
                    var data= _context.Haisans.First(x=>x.Ma_haisan == Ma_haisan);
                    _context.Haisans.Remove(data);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
           }
           catch(Exception ex)
           {
               return false;
            }
    }   
}
}
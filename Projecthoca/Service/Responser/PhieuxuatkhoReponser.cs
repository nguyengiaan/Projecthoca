﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;
using System.Runtime.CompilerServices;

namespace Projecthoca.Service.Responser
{
    public class PhieuxuatkhoReponser : IPhieuxuatkho
    {
        private readonly MyDbcontext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public PhieuxuatkhoReponser(MyDbcontext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<(List<PhieuxuatkhoVM> ds, int totalpages)> Danhsachphieu(int page, int pagesize)
        {
            try
            {
                var totalItems = _context.Phieuxuatkhos.Count();
                var totalpages = (int)Math.Ceiling(totalItems / (double)pagesize);
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var px = await _context.Phieuxuatkhos
                         .Where(x => x.Id == user.Id) // Assuming UserId is the correct property
                         .Select(x => new PhieuxuatkhoVM
                         {
                             Ma_phieuxuatkho = x.Ma_phieuxuatkho,
                             Ngayxuat = x.Ngayxuat,
                             Thanhtien = x.Thanhtien,
                             giamgia = x.giamgia,
                             Tongtien = x.Tongtien,
                             Tienmat = x.Tienmat,
                             Chuyenkhoan = x.Chuyenkhoan,
                         })
                         .Skip((page - 1) * pagesize)
                         .Take(pagesize)
                         .ToListAsync();
                return (px, totalpages);
            }
            catch (Exception ex)
            {
                return (null, 0);
            }
        }


        public async Task<bool> Themphieuxuatkho(PhieuxuatkhoVM phieuxuatkho)
        {
            try
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                int nextNumber1 = 1;
                var lastMaDV = await _context.Phieuxuatkhos
                              .OrderByDescending(x => x.Ma_phieuxuatkho)
                              .Select(x => x.Ma_phieuxuatkho)
                              .FirstOrDefaultAsync();
                int nextNumber = 1;
                if (lastMaDV != null)
                {
                    nextNumber = int.Parse(lastMaDV.Substring(2)) + 1;
                }
                var madm = "XK" + nextNumber.ToString("D4");
                var data = new Phieuxuatkho();
                data.Ma_phieuxuatkho = madm;
                data.Ngayxuat = DateTime.Now;
                data.Id = user.Id;
                data.Thanhtien = phieuxuatkho.Thanhtien;
                data.giamgia = phieuxuatkho.giamgia;
                data.Tienmat = phieuxuatkho.Tienmat;
                data.Chuyenkhoan = phieuxuatkho.Chuyenkhoan;
                data.Tongtien = phieuxuatkho.Tongtien;

                await _context.Phieuxuatkhos.AddAsync(data);
                await _context.SaveChangesAsync();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> Xoaphieuxuat(string Ma_phieuxuatkho)
        {
            try
            {
                var data = await _context.Phieuxuatkhos.FindAsync(Ma_phieuxuatkho);
                if (data != null)
                {
                    _context.Phieuxuatkhos.Remove(data);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

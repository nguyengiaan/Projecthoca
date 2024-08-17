using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projecthoca.Data;
using Projecthoca.Models.Enitity;
using Projecthoca.Models.EnitityVM;
using Projecthoca.Service.Interface;
using System.Security.Claims;

namespace Projecthoca.Service.Responser
{
    public class NguoidungReponser : INguoidung
    {
        private readonly MyDbcontext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public NguoidungReponser(MyDbcontext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<Status> Dangkynguoidung(NguoidungVM Nguoidung)
        {
            try
            {
                var Status = new Status();
                int nextNumber1 = 1;
                var lastMaDV = await _context.Nguoidung
                              .OrderByDescending(x => x.Ma_user)
                              .Select(x => x.Ma_user)
                              .FirstOrDefaultAsync();
                int nextNumber = 1;
                if (lastMaDV != null)
                {
                    nextNumber = int.Parse(lastMaDV.Substring(2)) + 1;
                }
                var makh = "TK" + nextNumber.ToString("D4");
                var userExist = await _userManager.FindByNameAsync(Nguoidung.UserName);
                if (userExist != null)
                {
                    Status.StatusCode = 0;
                    Status.Message = "Tên đăng nhập đã tồn tại";
                    return Status;
                }
                var emailExist = await _userManager.FindByEmailAsync(Nguoidung.Email);
                if (emailExist != null)
                {
                    Status.StatusCode = 0;
                    Status.Message = "Email đã tồn tại";
                    return Status;
                }
                var user = new ApplicationUser
                {
                    Ma_user = makh,
                    Hovaten = Nguoidung.hovaten,
                    UserName = Nguoidung.UserName,
                    Email = Nguoidung.Email,
                    PhoneNumber = Nguoidung.Telephone,
                    Diachi = Nguoidung.diachi,
                    Ngaysinh = Nguoidung.Ngaysinh,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var result = await _userManager.CreateAsync(user, Nguoidung.Password);
                if (!result.Succeeded)
                {
                    Status.StatusCode = 0;
                    Status.Message = "Đăng ký thất bại";
                    return Status;
                }
                if (!await _roleManager.RoleExistsAsync(Nguoidung.Role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(Nguoidung.Role));
                }
                if (await _roleManager.RoleExistsAsync(Nguoidung.Role))
                {
                    await _userManager.AddToRoleAsync(user, Nguoidung.Role);
                }
                Status.StatusCode = 1;
                Status.Message = "Đăng ký thành công";
                return Status;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return new Status { StatusCode = 0, Message = ex.Message };
            }
            return new Status { StatusCode = 0, Message = "Đăng ký thất bại" };
        }
        public async Task<Status> Dangnhap(DangnhapVM user)
        {
            try
            {
                var status = new Status();
                var username = await _userManager.FindByNameAsync(user.Taikhoan);
                if (username == null)
                {
                    status.StatusCode = 0;
                    status.Message = "Sai tên người dùng";
                    return status;
                }
                if (!await _userManager.CheckPasswordAsync(username, user.Matkhau))
                {
                    status.StatusCode = 0;
                    status.Message = "Sai mật khẩu";
                    return status;
                }
                var signinResult = await _signInManager.PasswordSignInAsync(user.Taikhoan, user.Matkhau, false, false);
                if (signinResult.Succeeded)
                {
                    var userRole = await _userManager.GetRolesAsync(username);
                    var authClaims = new List<Claim>
                   {
                       new Claim(ClaimTypes.Name, username.Hovaten),
                       new Claim(ClaimTypes.Email, username.Email),
                       new Claim(ClaimTypes.NameIdentifier, username.Id),

                   };
                    foreach (var userRoles in userRole)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRoles));
                    }
                    status.StatusCode = 1;
                    status.Message = "Đăng nhập thành công";
                    return status;
                }

            }
            catch (Exception ex)
            {
                return new Status { StatusCode = 0, Message = ex.Message };
            }
            return new Status { StatusCode = 0, Message = "Đăng nhập thất bại" };
        }
        public async Task<(List<NguoidungVM> ds, int totalpages)> Laydanhsachnguoidung(int page, int pagesize)
        {
            try
            {
                int totalUser = await _context.Nguoidung.CountAsync();
                int totalPages = (int)Math.Ceiling(totalUser / (double)pagesize);
                var data = await _context.Nguoidung
                  .Select(user => new NguoidungVM
                  {
                      Id = user.Id,
                      Ma_user = user.Ma_user,
                      hovaten = user.Hovaten,
                      UserName = user.UserName,
                      Email = user.Email,
                      Telephone = user.PhoneNumber,
                      Password = user.PasswordHash,
                      diachi = user.Diachi,
                      Ngaysinh = user.Ngaysinh,
                  }).Skip((page - 1) * pagesize).Take(pagesize).OrderByDescending(x => x.Ma_user).ToListAsync();
                var userWithRoles = new List<NguoidungVM>();
                foreach (var user in data)
                {
                    var id = await _userManager.FindByIdAsync(user.Id);
                    var roles = await _userManager.GetRolesAsync(id);
                    userWithRoles.Add(new NguoidungVM
                    {
                        Id = user.Id,
                        Ma_user = user.Ma_user,
                        hovaten = user.hovaten,
                        UserName = user.UserName,
                        Email = user.Email,
                        Telephone = user.Telephone,
                        diachi = user.diachi,
                        Password = user.Password,
                        Ngaysinh = user.Ngaysinh,
                        Role = roles.FirstOrDefault(),
                    });
                }
                return (userWithRoles, totalPages);
            }
            catch (Exception ex)
            {
                return (null, 0);
                Console.WriteLine(ex.Message);
            }
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }



    }
}

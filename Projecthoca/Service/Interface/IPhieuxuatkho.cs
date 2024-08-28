using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface IPhieuxuatkho
    {
        public Task<bool> Themphieuxuatkho(PhieuxuatkhoVM phieuxuatkho);

        public Task<(List<PhieuxuatkhoVM> ds, int totalpages)> Danhsachphieu(int page, int pagesize);

        public Task<bool> Xoaphieuxuat(string Ma_phieuxuatkho);

        public Task<(bool ckeck, int tongtienchk, int tongtienmat, int tongthanhtien, int tongtatca)> Tongtientatca();
        public Task<bool> Suaphieuxuatkho(PhieuxuatkhoVM phieuxuatkho);
        public Task<PhieuxuatkhoVM> Xemphieuxuatkho(string Ma_phieuxuatkho); 


        // INTERFACE NHẬP KHO
        public Task<(List<PhieunhapkhoVM> ds, int totalpages)> Danhsachphieunhap(int page, int pagesize);

        public Task<bool> Themphieunhapkho(List<DanhsachhhkhoVM> hanghoa);

        public Task<bool> Xoaphieunhapkho(string Ma_phieunhapkho);
        public Task<List<XemhanghoakhoVM>> Xemphieukho(string Ma_phieunhapkho);

    }
}

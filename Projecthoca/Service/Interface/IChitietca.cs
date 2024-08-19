using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface IChitietca
    {
        public Task<bool> ThemCa(ChitietcaVM chitietca);

        public Task<List<DanhmucVM>> Danhsachdanhmuchs();

        public Task<List<ChitietcaVM>> Laychitietca(string khuvucid);

        public Task<TongsokgVM> Tongsokg(string khuvucid);

        public Task<bool> Xoaca(string machitietca);
    }
}

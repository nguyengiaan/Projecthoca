using Projecthoca.Models.EnitityVM;

namespace Projecthoca.Service.Interface
{
    public interface IChitietca
    {
        public Task<Boolean> ThemCa(ChitietcaVM chitietca);

        public Task<List<DanhmucVM>> Danhsachdanhmuchs();

        public Task<List<ChitietcaVM>> Laychitietca(string khuvucid);

        public Task<TongsokgVM> Tongsokg(string khuvucid);

        public Task<Boolean> Xoaca(string machitietca);
    }
}

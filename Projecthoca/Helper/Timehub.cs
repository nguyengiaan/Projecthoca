using Microsoft.AspNetCore.SignalR;

namespace Projecthoca.Helper
{
    public class Timehub : Hub
    {
        public async Task SendTime(string maKhuvuc)
        {
            await Clients.All.SendAsync("ReceiveTimeUpdate", maKhuvuc);
        }
    }
}

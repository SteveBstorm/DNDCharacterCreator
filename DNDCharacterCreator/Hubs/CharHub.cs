using DNDCharacterCreator.Models;
using Microsoft.AspNetCore.SignalR;

namespace DNDCharacterCreator.Hubs
{
    public class CharHub : Hub
    {
        public async Task NewChar()
        {
            await Clients.All.SendAsync("nouveauPerso");
        }

        public async Task NewMessage(Message message)
        {
            await Clients.All.SendAsync("sendMessage", message);
        }

        public async Task JoinGroup()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "groupe1");
            await Clients.Group("groupe1").SendAsync("messagetogroup", Context.ConnectionId + " has joined");
        }

        public async Task SendToGroup(Message message)
        {
            await Clients.Group("groupe1").SendAsync("messagetogroup", message);
        }
    }
}

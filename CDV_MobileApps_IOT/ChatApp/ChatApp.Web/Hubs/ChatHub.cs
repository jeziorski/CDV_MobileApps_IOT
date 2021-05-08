using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.DTO.Models;
using ChatApp.DTO;

namespace ChatApp.Web.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(UserChatMessage message)
        {
            message.TimeStamp = System.DateTime.Now;
            await Clients.All.SendAsync(Consts.RECEIVE_MESSAGE, message);
            
        }
    }
}

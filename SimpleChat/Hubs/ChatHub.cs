using ChatApplication.Models.Chat;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string message) 
        {
            await this.Clients.All.SendAsync(
                "NewMessage",
                new Message 
                { User = this.Context.User.Identity.Name, Text = message  }
                );   
        }

        public async Task Unsend(string id)
        {
            await Clients.All.SendAsync("Unsend", id);
                 
        }
    }
}

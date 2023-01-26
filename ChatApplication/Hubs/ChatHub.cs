using ChatApplication.Data;
using ChatApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ChatApplication.Hubs
{
    [Authorize]
    public class ChatHub: Hub
    {
        public readonly MvcDbContext _context;

        public ChatHub(MvcDbContext context)
        {
            _context = context;
        }

        public async Task Send(Message message)
        {
            var messageModel = new MessageModel()
            {
                MesTitle = message.MesTitle,
                MesBody = message.MesBody,
            };

            UsersModel user = new UsersModel();
            if (_context.Users.Select(x => x.UserId.ToString()).Contains(Context.User.Identity.Name))
            {
                user = _context.Users.FirstOrDefault(x => x.UserId == int.Parse(Context.User.Identity.Name));
                messageModel.UsersModel = user;
            }

            UsersModel reciever = new UsersModel();
            if (_context.Users.Any(x => x.Name == message.Reciever.Name))
            {
                reciever = _context.Users.FirstOrDefault(x => x.Name == message.Reciever.Name);
                messageModel.Reciever = reciever;
            }
            await _context.Messages.AddAsync(messageModel);
            await _context.SaveChangesAsync();

            SendObject sendObject = new SendObject();
            if (messageModel.Reciever != null)
            {
                sendObject.IsSuccess = true;
                sendObject.MesBody = messageModel.MesBody;
                sendObject.MesTitle = messageModel.MesTitle;
                sendObject.SenderName = messageModel.UsersModel.Name;
                sendObject.RecieverName = messageModel.Reciever.Name;

                if (Context.User.Identity.Name != messageModel.Reciever.UserId.ToString()) // если получатель и текущий пользователь не совпадают
                    await Clients.Group(Context.User.Identity.Name).SendAsync("Receive", JsonSerializer.Serialize(sendObject));
                await Clients.Group(messageModel.Reciever.UserId.ToString()).SendAsync("Receive", JsonSerializer.Serialize(sendObject));
            }
            else
            {
                sendObject.IsSuccess = false;
                sendObject.MesBody = "";
                sendObject.MesTitle = "";
                sendObject.SenderName = "";
                sendObject.RecieverName = "";
                sendObject.IsSuccess = false;
                await Clients.Group(Context.User.Identity.Name).SendAsync("Receive", JsonSerializer.Serialize(sendObject));
            }

        }

        public override async Task OnConnectedAsync()
        {
            string name = Context.User.Identity.Name;
            await Groups.AddToGroupAsync(Context.ConnectionId, name);

            await base.OnConnectedAsync();

            if (_context.Users.Select(x => x.UserId.ToString()).Contains(Context.User.Identity.Name))
            {
                var userModel = _context.Users.FirstOrDefault(x => x.UserId == int.Parse(Context.User.Identity.Name));
                var userMessages = _context.Messages.Where(t => t.Reciever == userModel).Include(p => p.UsersModel);

                SendObject sendObject = new SendObject();
                if (userMessages != null)
                    foreach (var mes in userMessages)
                    {
                        sendObject.IsSuccess = true;
                        sendObject.MesBody = mes.MesBody;
                        sendObject.MesTitle = mes.MesTitle;
                        sendObject.SenderName = mes.UsersModel.Name;
                        sendObject.RecieverName = mes.Reciever.Name;

                        await Clients.Group(Context.User.Identity.Name).SendAsync("Receive", JsonSerializer.Serialize(sendObject));
                    }
            }

        }
    }
}

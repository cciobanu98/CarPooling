using Microsoft.AspNetCore.SignalR;
using System;
using System.Security.Claims;

namespace CarPooling.BussinesLogic.Hubs
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public virtual string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}

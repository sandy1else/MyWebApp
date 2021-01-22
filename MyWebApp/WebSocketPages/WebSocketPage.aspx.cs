using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebApp.WebSocketPages
{
    public partial class WebSocketPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ChatHub ch = new ChatHub();
            ch.Send("Annoymous","Nothinng");
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.broadcastMessage("Admin", "stop the chat");
        }
    }
}
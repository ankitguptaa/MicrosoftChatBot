using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bot_Application.Dialogs
{
    [Serializable]
    public class GeneralDialog : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Hi my name is bot.");
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            var userName = string.Empty;
            var getName = false;
            context.UserData.TryGetValue("Name", out userName);
            context.UserData.TryGetValue<bool>("GetName", out getName);

            if (getName)
            {
                userName = message.Text;
                context.UserData.SetValue("Name", userName);
                context.UserData.SetValue<bool>("GetName", false);
            }

            if (string.IsNullOrWhiteSpace(userName))
            {
                await context.PostAsync("What is your Name?");
                context.UserData.SetValue<bool>("GetName", true);
            }
            else
            {
                await context.PostAsync(String.Format("Hi {0}, how can i help you?", userName));
            }

            context.Wait(MessageReceivedAsync);
        }
    }
}
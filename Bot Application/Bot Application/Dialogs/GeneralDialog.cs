using Bot_Application.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Bot_Application.Dialogs
{
    [LuisModel("70e9d5b3-604b-4357-a195-b0cde71391f9", "2f6fc2999da5443e9e2e7a38f396d80c")]
    [Serializable]
    public class GeneralDialog : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Hi my name is bot.");
            context.Wait(MessageReceivedAsync);
        }

        private static async Task<LUISData> GetEntityFromLUIS(string Query)
        {
            Query = Uri.EscapeDataString(Query);
            LUISData Data = new LUISData();
            using (HttpClient client = new HttpClient())
            {
                string RequestUri = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/70e9d5b3-604b-4357-a195-b0cde71391f9?subscription-key=2f6fc2999da5443e9e2e7a38f396d80c&timezoneOffset=0.0&verbose=true&q=" + Query;
                HttpResponseMessage msg = await client.GetAsync(RequestUri);

                if (msg.IsSuccessStatusCode)
                {
                    var JsonDataResponse = await msg.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<LUISData>(JsonDataResponse);
                }
            }

            return Data;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            var userName = string.Empty;
            var getName = false;
            context.UserData.TryGetValue("Name", out userName);
            context.UserData.TryGetValue<bool>("GetName", out getName);
            LUISData luisEntity = await GetEntityFromLUIS(message.Text);
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
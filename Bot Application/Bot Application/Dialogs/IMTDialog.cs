using Bot_Application.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
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
    public partial class IADialag : LuisDialog<object>
    {
        [LuisIntent("IMTIntro")]
        public async Task IMTIntro(IDialogContext context, LuisResult result)
        {
            string message = $"IMTIntro";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("IMTUpgrades")]
        public async Task IMTUpgrades(IDialogContext context, LuisResult result)
        {
            string message = $"IMTUpgrades";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("IMTDeployments")]
        public async Task IMTDeployments(IDialogContext context, LuisResult result)
        {
            string message = $"IMTDeployments";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("IMTOnboarding")]
        public async Task IMTOnboarding(IDialogContext context, LuisResult result)
        {
            string message = $"IMTOnboarding";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("IMTApproach")]
        public async Task IMTApproach(IDialogContext context, LuisResult result)
        {
            string message = $"IMTApproach";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("IMTSupport")]
        public async Task IMTSupport(IDialogContext context, LuisResult result)
        {
            string message = $"IMTSupport";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }
    }

}
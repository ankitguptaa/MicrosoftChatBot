using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bot_Application.Dialogs
{
    [LuisModel("70e9d5b3-604b-4357-a195-b0cde71391f9", "2f6fc2999da5443e9e2e7a38f396d80c")]
    public partial class IADialag : LuisDialog<object>
    {
        [LuisIntent("RebarIntro")]
        public async Task RebarIntro(IDialogContext context, LuisResult result)
        {
            string message = $"RebarIntro";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("RebarUpgrades")]
        public async Task RebarUpgrades(IDialogContext context, LuisResult result)
        {
            string message = $"RebarUpgrades";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("RebarDeployments")]
        public async Task RebarDeployments(IDialogContext context, LuisResult result)
        {
            string message = $"RebarDeployments";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("RebarOnboarding")]
        public async Task RebarOnboarding(IDialogContext context, LuisResult result)
        {
            string message = $"RebarOnboarding";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("RebarApproach")]
        public async Task RebarApproach(IDialogContext context, LuisResult result)
        {
            string message = $"RebarApproach";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("RebarSupport")]
        public async Task RebarSupport(IDialogContext context, LuisResult result)
        {
            string message = $"RebarSupport";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }
    }
}
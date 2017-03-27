using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;
using Bot_Application.Dialogs;
using Bot_Application.Models;

namespace Bot_Application
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, () => new IADialag());
                var luisData = await GetEntityFromLUIS(activity.Text);
                await DocumentDBRepository<LUISData>.CreateItemAsync(luisData);
                ////ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                ////// calculate something for us to return
                ////int length = (activity.Text ?? string.Empty).Length;

                ////// return our reply to the user
                ////Activity reply = activity.CreateReply($"You sent {activity.Text} which was {length} characters");
                ////await connector.Conversations.ReplyToActivityAsync(reply);
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
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

        public async Task<LUISData> Get(string id)
        {
            LUISData item = await DocumentDBRepository<LUISData>.GetItemAsync(id);
            return item;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}
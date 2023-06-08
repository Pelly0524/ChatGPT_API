using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_API.OpenAI
{
    public class ChatGPT : IChatGPT
    {
        private HttpClient _client = new HttpClient();
        private string _apiUrl;
        private string _systemMessage;
        private List<Prompt> _conversation = new List<Prompt>();

        public IReadOnlyCollection<Prompt> Conversation => _conversation;

        public ChatGPT()
        {
            _apiUrl = ConfigManager.GetAppSetting(ConfigManager.AppSetting.ChatGPT_API_Url);
            _systemMessage = ConfigManager.GetAppSetting(ConfigManager.AppSetting.ChatGPT_SystemMessage_Default);
            Setting_APIKey(ConfigManager.GetAppSetting(ConfigManager.AppSetting.ChatGPT_API_Key));
        }

        #region External Methods

        public string Chat(string userMessage)
        {
            string reply = RequestToGPT(userMessage).Result;
            _conversation.Add(new Prompt { Role = ChatGPT_Role.user, Content = userMessage });
            _conversation.Add(new Prompt { Role = ChatGPT_Role.assistant, Content = reply });

            return reply;
        }

        public string Chat_Single(string userMessage)
        {
            string reply = RequestToGPT(userMessage).Result;

            return reply;
        }

        public void Reset()
        {
            _conversation.Clear();
        }

        public void Setting_APIKey(string apiKey)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        }

        public void Setting_SystemMessage(string message)
        {
            _systemMessage = message;
        }

        #endregion 

        #region Internal Methods

        private async Task<string> RequestToGPT(string prompt)
        {
            try
            {
                string requestBody = FormatRequest(prompt);
                var response = await _client.PostAsync(_apiUrl, new StringContent(requestBody, Encoding.UTF8, "application/json"));
                Task<string> responseContent = response.Content.ReadAsStringAsync();
                dynamic? jsonResponse = JsonConvert.DeserializeObject(responseContent.Result);
                string assistantReply = jsonResponse is null ? "" : jsonResponse.choices[0].message.content;
                return assistantReply;
            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        private string FormatRequest(string prompt)
        {
            string messages = BuildMessages(_conversation, prompt);
            string requestBody = $@"
            {{
                ""model"": ""gpt-3.5-turbo"",
                ""messages"": {messages}
            }}";

            return requestBody;
        }

        private string BuildMessages(List<Prompt> conversation, string currentMessage)
        {
            List<object> messages = new List<object>();
            messages.Add(new { role = ChatGPT_Role.system.ToString(), content = _systemMessage });

            foreach (Prompt message in conversation)
            {
                messages.Add(new { role = message.Role.ToString(), content = message.Content });
            }

            messages.Add(new { role = ChatGPT_Role.user.ToString(), content = currentMessage });

            return JsonConvert.SerializeObject(messages);
        }

        #endregion
    }
}
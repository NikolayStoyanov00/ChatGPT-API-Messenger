using Newtonsoft.Json;

namespace ChatGPT.ApiModels
{
    public class MessageModel
    {
        public MessageModel(string role, string content)
        {
            this.Role = role;
            this.Content = content;
        }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }
}

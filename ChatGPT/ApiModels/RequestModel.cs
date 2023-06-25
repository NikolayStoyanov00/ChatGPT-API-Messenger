using Newtonsoft.Json;
using System.Collections.Generic;

namespace ChatGPT.ApiModels
{
    public class RequestModel
    {
        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("messages")]
        public List<MessageModel> Messages { get; set; }
    }
}

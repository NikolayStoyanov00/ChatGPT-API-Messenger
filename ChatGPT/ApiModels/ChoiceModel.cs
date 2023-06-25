using Newtonsoft.Json;

namespace ChatGPT.ApiModels
{
    public class ChoiceModel
    {
        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("message")]
        public MessageModel Message { get; set; }

        [JsonProperty("finishReason")]
        public string FinishReason { get; set; }
    }
}

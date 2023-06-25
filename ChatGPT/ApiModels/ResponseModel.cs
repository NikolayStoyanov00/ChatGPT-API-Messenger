using Newtonsoft.Json;

namespace ChatGPT.ApiModels
{
    public class ResponseModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("choices")]
        public ChoiceModel[] Choices { get; set; }

        [JsonProperty("usage")]
        public UsageModel Usage { get; set; }
    }
}

using ChatGPT.ApiModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace ChatGPT
{
    public partial class Form1 : Form
    {
        private const string ChatGPTUrl = "https://api.openai.com/v1/chat/completions";
        private const string ChatGPTModel = "gpt-3.5-turbo"; // 3.5 Turbo is the latest version of chat GPT I was able to find, in the future if GPT-4 is available you can change it
        private const string BearerToken = "INSERT YOUR BEARER HERE";

        public static HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();

            client.BaseAddress = new Uri(ChatGPTUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", BearerToken);
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.Enabled = false;

            var questionText = this.questionTextbox.Text;

            var message = new MessageModel("assistant", questionText);
            var requestModel = new RequestModel
            {
                Model = ChatGPTModel,
                Messages = new List<MessageModel> { message }
            };

            var responseMessage = await client
                .PostAsJsonAsync(
                    ChatGPTUrl,
                    requestModel);

            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            var responseModel = JsonConvert.DeserializeObject<ResponseModel>(responseContent);

            if (responseModel.Choices != null)
            {
                this.answerTextbox.Text = string.Join(Environment.NewLine, responseModel?.Choices?.Select(c => c.Message?.Content));
            }
            else
            {
                this.answerTextbox.Text = $"ERROR: {responseContent}";
            }

            button.Enabled = true;
        }
    }
}

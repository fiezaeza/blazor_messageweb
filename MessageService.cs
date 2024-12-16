using RestSharp;
using System.Threading.Tasks;

namespace wamessage
{
    public class MessageService
    {
        private readonly string _baseUrl = "https://waapi.app/api/v1/instances/31507/client/action/send-message";
        private readonly string _token = "57M7LT0IhZy2fWTaBBiIb0C9ZKpHYs3sx7bSQWDH7f5dc48f";

        public async Task<string> SendMessageAsync(string message, string chatId)
        {
            var option = new RestClientOptions(_baseUrl);
            var client = new RestClient(option);
            var request = new RestRequest();

            request.AddHeader("Accept", "application/json");
            request.AddHeader("authorization", $"Bearer {_token}");

            var body = new
            {
                message = message,
                chatId = $"{chatId}@c.us"
            };

            request.AddJsonBody(body);

            var response = await client.PostAsync(request);

            if (response != null)
            {
                return response.Content;
            }
            else
            {
                return "No Message";
            }
        }
    }
}

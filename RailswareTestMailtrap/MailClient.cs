using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp;

namespace RailswareTestMailtrap
{
    public class MailClient
    {
        private readonly string _apiToken;
        private readonly RestClient _restClient;

        public MailClient(string apiToken)
        {
            _apiToken = apiToken;
            _restClient = new RestClient("https://send.api.mailtrap.io/api/send");
        }

        public async Task<RestResponse> SendAsync(string fromName, string fromEmail, string toName, string toEmail, string text, string subject = null, string html = null, string[] attachments = null)
        {
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Authorization", $"Bearer {_apiToken}");
            request.AddHeader("Content-Type", "application/json");

            var requestBody = new
            {
                from = new { name = fromName, email = fromEmail },
                to = new[] { new { name = toName, email = toEmail } },
                subject = subject,
                text = text,
                html = html,
                attachments = attachments
            };
            request.AddJsonBody(requestBody);

            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to send email: {response.ErrorMessage}");
            } 
            return response;
        }
    }
}
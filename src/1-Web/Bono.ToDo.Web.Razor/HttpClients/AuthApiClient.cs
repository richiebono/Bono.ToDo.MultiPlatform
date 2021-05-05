using Bono.ToDo.Web.Razor.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace Bono.ToDo.Web.Razor.HttpClients
{
    public class LoginResult
    {
        public string Token { get; set; }
        public bool Succeeded { get; set; }
        public UserViewModel User { get; set; }
        public LoginResult(UserAuthenticateResponseViewModel response, HttpStatusCode statusCode)
        {
            this.User = response.User;
            this.Token = response.Token;
            this.Succeeded = (statusCode == HttpStatusCode.OK);
        }
    }

    public class AuthApiClient
    {
        private readonly HttpClient _httpClient;        
        public AuthApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }

        public async Task<LoginResult> PostLoginAsync(UserAuthenticateRequestViewModel model)
        {
            try
            {
                var resposta = await _httpClient.PostAsJsonAsync<UserAuthenticateRequestViewModel>("Users/Authenticate", model);
                return new LoginResult(await resposta.Content.ReadAsAsync<UserAuthenticateResponseViewModel>(), resposta.StatusCode);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task PostRegisterAsync(RegisterViewModel model)
        {
            var resposta = await _httpClient.PostAsJsonAsync<RegisterViewModel>("usuarios", model);
            resposta.EnsureSuccessStatusCode();
        }
    }
}

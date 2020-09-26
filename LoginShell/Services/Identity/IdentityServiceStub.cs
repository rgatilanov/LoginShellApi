using System.Collections.Generic;
using System.Text;
using LoginShell.Helpers;
using LoginShell.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LoginShell.Services.Identity
{
    class IdentityServiceStub : IIdentityService
    {
        System.Net.Http.HttpClient client;

        public IdentityServiceStub()
        {
            client = new System.Net.Http.HttpClient();
        }

        public Task Authenticate()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerifyRegistration()
        {
            await Task.Delay(1337);
            return false;
        }
        public string WebAPIUrl
        {
            get; private set;
        }
        public async Task<Login> Login(string username, string password)
        {
            await Task.Delay(1000);
            UserMin _user = new UserMin()
            {
                Nick = username,
                Password = Functions.GetSHA256(password).ToUpper()
            };


            WebAPIUrl = "http://189.254.239.133/LoginAppApi/api/login/autenticar";

            //Con esta Api de ejemplo hice la prueba
            //WebAPIUrl = "https://ej2services.syncfusion.com/production/web-services/api/Orders"; // Set your REST API url here
            var uri = new Uri(WebAPIUrl);
            try
            {
                HttpContent _content = new StringContent(JsonConvert.SerializeObject(_user));
                _content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PostAsync(uri, _content);

                if (response.IsSuccessStatusCode)
                {
                    Login _login = new Login();
                    var content = await response.Content.ReadAsStringAsync();
                    _login = JsonConvert.DeserializeObject<Login>(content);
                    return _login;
                }
            }
            catch (Exception ex)
            {
            }
            return null;


            //return new Login()
            //{
            //    ID = 1,
            //    Name = "Ramón",
            //    Password = password,
            //    Nick = username,
            //    Token = "jajajajejejejijijjojojjujuju"
            //};
        }
    }
}

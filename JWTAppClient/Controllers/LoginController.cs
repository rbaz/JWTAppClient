using JWTAppClient.Models;
using Microsoft.VisualStudio.Services.OAuth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;


namespace JWTAppClient.Controllers
{
    //[Authorize]
    public class LoginController : ApiController
    {
        public LoginController()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> LogIn(AppUser user)
        {
            string apiUrl = WebConfigurationManager.AppSettings["apiUrl"];
            string apiKey = WebConfigurationManager.AppSettings["apiKey"];

            try
            {
                string apiResponse = string.Empty;
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(apiUrl);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync("http://localhost:5000/api/authentificate/login"))
                    {

                        apiResponse = await response.Content.ReadAsStringAsync();
                        //reservationList = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);
                    }
                }
                return apiResponse;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
        //[HttpPost]
        [Route("SignIn")]
        public async Task<IHttpActionResult> PostAsync(AppUser user)
        {
            string apiUrl = WebConfigurationManager.AppSettings["apiUrl"];
            string apiKey = WebConfigurationManager.AppSettings["apiKey"];

            HttpClient httpClient = new HttpClient();

            // Obtain a JWT token.
            StringContent httpContent = new StringContent(@"{ ""userName"": ""user1"", ""password"": ""User1@123"" }", Encoding.UTF8, "application/json");
            //StringContent httpContent = new StringContent(@"{ ""userName"": " + user.Username +"," + "password:" + user.Password +" }", Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://localhost:5000/api/Authenticate/login", httpContent);

            if (HttpContext.Current.User.Identity is ClaimsIdentity identity)
            {
                IEnumerable<Claim> claims = identity.Claims;
                // or
                identity.Name.ToString();

            }

            // Save the token for further requests.
            var token = await response.Content.ReadAsStringAsync();

            // Set the authentication header. 
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return Ok(token);
            //return response;
        }
    }
}



//using JWTAppClient.Models;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using System;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using System.Web.Http;


//namespace JWTAppClient.Controllers
//{
//    public class HomeController : Controller
//    {
//        public readonly HttpClient _httpClient;

//        public async Task<IActionResult> Login()
//        {
//            using (var httpClient = new HttpClient())
//            {
//                using (var response = await httpClient.GetAsync("https://localhost:44324/api/login"))
//                {
//                    string apiResponse = await response.Content.ReadAsStringAsync();

//                }
//            }
//            return;
//        }

//        [HttpGet]
//        private IHttpActionResult GetToken(AppUser user)
//        {
//            var dataUser = JsonConvert.SerializeObject(user);

//            _httpClient.BaseAddress = new Uri("http://localhost:64195/");
//            _httpClient.DefaultRequestHeaders.Accept.Clear();
//            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//            HttpResponseMessage response = _httpClient.GetAsync(
//                "api/login", user);

//            //_httpClient.PostAsync("api/login", dataUser);

//            response.EnsureSuccessStatusCode();

//            // return URI of the created resource.
//            return Ok(response);
//        }
//    }
//}

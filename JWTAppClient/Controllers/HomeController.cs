using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWTAppClient.Controllers
{
    public class HomeController : Controller
    {       
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}


//using JWTAppClient.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http;
//using System.Web.Mvc;

//namespace JWTAppClient.Controllers
//{
//    public class LoginController : ApiController
//    {
//        private readonly HttpClient _client;
//        public const string BasePath = "http://localhost:5000/api/authentificate/login";

//        public LoginController(HttpClient client)
//        {
//            _client = client ?? throw new ArgumentNullException(nameof(client));
//        }

//        public async Task<IHttpActionResult> LoginMe(AppUser user)
//        {
//            var response = await _client.GetAsync(BasePath);

//            return Ok(response);
//        }

//        public async Task<string> LogIn(AppUser user)
//        {
//            string apiResponse = string.Empty;
//            using (var httpClient = new HttpClient())
//            {
//                using (var response = await httpClient.GetAsync("http://localhost:5000/api/authentificate/login/"))
//                {
//                    apiResponse = await response.Content.ReadAsStringAsync();
//                    //reservationList = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);
//                }
//            }
//            return apiResponse;
//        }
//    }
//}



////using JWTAppClient.Models;
////using Microsoft.AspNetCore.Mvc;
////using Newtonsoft.Json;
////using System;
////using System.Net.Http;
////using System.Net.Http.Headers;
////using System.Threading.Tasks;
////using System.Web.Http;


////namespace JWTAppClient.Controllers
////{
////    public class HomeController : Controller
////    {
////        public readonly HttpClient _httpClient;

////        public async Task<IActionResult> Login()
////        {
////            using (var httpClient = new HttpClient())
////            {
////                using (var response = await httpClient.GetAsync("https://localhost:44324/api/login"))
////                {
////                    string apiResponse = await response.Content.ReadAsStringAsync();

////                }
////            }
////            return;
////        }

////        [HttpGet]
////        private IHttpActionResult GetToken(AppUser user)
////        {
////            var dataUser = JsonConvert.SerializeObject(user);

////            _httpClient.BaseAddress = new Uri("http://localhost:64195/");
////            _httpClient.DefaultRequestHeaders.Accept.Clear();
////            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

////            HttpResponseMessage response = _httpClient.GetAsync(
////                "api/login", user);

////            //_httpClient.PostAsync("api/login", dataUser);

////            response.EnsureSuccessStatusCode();

////            // return URI of the created resource.
////            return Ok(response);
////        }
////    }
////}

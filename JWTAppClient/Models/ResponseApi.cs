using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWTAppClient.Models
{
    public class ResponseApi
    {
        public string Token { get; set; }
        public string DateExpiration { get; set; }
    }
}
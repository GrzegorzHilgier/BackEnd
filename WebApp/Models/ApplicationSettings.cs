using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ApplicationSettings
    {
        public string JWT_secret { get; set; }
        public string Client_URL { get; set; }
        public string Token_Expire_Time { get; set; }
    }
}

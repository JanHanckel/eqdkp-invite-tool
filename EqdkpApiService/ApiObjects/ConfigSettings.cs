using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqdkpApiService.ApiObjects
{
    public static class ConfigSettings
    {
        public static string ApiUrl { get; set; }

        public static string UserName { get; set; }

        public static string Password { get; set; }

        public static string PasswordSalt { get; set; }

        public static string SessionID { get; set; }
    }
}

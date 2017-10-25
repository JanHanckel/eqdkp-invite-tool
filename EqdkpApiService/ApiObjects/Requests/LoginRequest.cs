using RestSharp.Serializers;

namespace EqdkpApiService.ApiObjects
{

    [SerializeAs(Name = "request")]
    public class LoginRequest
    {   
        [SerializeAs(Name = "user")]
        public string User { get; set; }

        
        [SerializeAs(Name = "password")]        
        public string Password { get; set; }
    }
}

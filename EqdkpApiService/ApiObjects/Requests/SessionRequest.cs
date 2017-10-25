using RestSharp.Serializers;

namespace EqdkpApiService.ApiObjects
{
    [SerializeAs(Name = "request")]
    class SessionRequest
    {
        [SerializeAs(Name = "sid")]        
        public string SessionID { get; set; }        
    }
}

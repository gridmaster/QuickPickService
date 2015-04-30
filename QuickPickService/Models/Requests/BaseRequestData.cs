using System.Runtime.Serialization;

namespace QuickPickService.Models.Requests
{
    [DataContract]
    public abstract class BaseRequestData
    {
        [DataMember(Name = "Token", EmitDefaultValue = false)]
        public string token;
    }
}

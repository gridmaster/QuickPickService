using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json;

namespace QuickPickService.Models
{
    [DataContract(Name = "ticket")]
    public class Ticket : BaseTicket
    {
        [DataMember(Name="numbers")]
        //[JsonProperty(PropertyName = "numbers")]
        public string numbers { get; set; }

        [DataMember(Name="pBall")]
        //[JsonProperty(PropertyName = "pBall")]
        public int pBall { get; set; }
    }
}
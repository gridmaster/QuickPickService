using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json;

namespace QuickPickService.Models
{
    [DataContract(Name = "tickets")]
    public class Tickets
    {
        [DataMember(Name = "date")]
        //[JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "tickets")]
        //[JsonProperty(PropertyName = "tickets")]
        public List<Ticket> tickets { get; set; }
    }
}
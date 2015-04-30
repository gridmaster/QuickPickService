using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace QuickPickService.Models
{
    public class Tickets : List<Ticket>
    {
        [JsonProperty(PropertyName = "tickets")]
        public List<Ticket> tickets { get; set; }
    }
}
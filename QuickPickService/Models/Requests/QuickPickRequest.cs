using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace QuickPickService.Models.Requests
{
    public class QuickPickRequest: BaseRequestData
    {
        [JsonProperty(PropertyName = "max")]
        public int Max { get; set; }

        [JsonProperty(PropertyName = "max")]
        public int Picks { get; set; }

        [JsonProperty(PropertyName = "max")]
        public int PBMax { get; set; }

        [JsonProperty(PropertyName = "max")]
        public string Faves { get; set; }

        [JsonProperty(PropertyName = "max")]
        public int PBFave { get; set; }

        [JsonProperty(PropertyName = "max")]
        public int Tix { get; set; }
    }
}
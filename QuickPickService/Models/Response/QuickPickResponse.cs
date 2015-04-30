using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace QuickPickService.Models.Response
{
    public sealed class QuickPickResponse : BaseResponseData
    {
        [JsonProperty(PropertyName = "Tickets")]
        public IList<QuickPick> QuickPicks;
    }
}
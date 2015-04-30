using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickPickService.Models
{
    public class QuickPicks : List<QuickPick>
    {
        public List<QuickPick> QuickPick { get; set; }
    }
}
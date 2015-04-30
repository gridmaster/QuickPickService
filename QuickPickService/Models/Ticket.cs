using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickPickService.Models
{
    public class Ticket : BaseTicket
    {

        public int ball1 { get; set; }
        public int ball2 { get; set; }
        public int ball3 { get; set; }
        public int ball4 { get; set; }
        public int ball5 { get; set; }
        public int ball6 { get; set; }
        public int pBall { get; set; }
    }
}
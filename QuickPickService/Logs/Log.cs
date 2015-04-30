using System.Collections.Generic;
using QuickPickService.Models.Context;

namespace QuickPickService.Logs
{
    public class Log : List<LogEvent>
    {
        public int LogId { get; set; }

        public static void WriteLog(LogEvent le)
        {
            var db = new QuickPickContext();

            db.Logs.Add(le);
            db.SaveChanges();
        }
    }
}
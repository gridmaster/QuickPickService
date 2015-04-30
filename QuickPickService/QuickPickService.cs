using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text.RegularExpressions;
using System.Xml;
using Newtonsoft.Json;
using QuickPickService.BulkLoad;
using QuickPickService.Core;
using QuickPickService.Logs;
using QuickPickService.Models;
using QuickPickService.Models.Context;
using QuickPickService.Models.Requests;
using QuickPickService.Models.ViewModels;

namespace QuickPickService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class QuickPickService : IQuickPickService
    {
        private static QuickPickContext db = new QuickPickContext();

        //http://localhost:45667/QuickPicks?max=75&picks=6&tix=5
        //http://localhost:45667/QuickPicks?max=75&picks=5&faves=11,19&pbmax=39&pbfave=4&tix=5
        [WebGet(UriTemplate = "/QuickPicks?max={max}&picks={picks}&pbmax={pbmax}&faves={faves}&pbfave={pbfave}&tix={tix}", ResponseFormat = WebMessageFormat.Json)]
        public string QuickPicks(int max, int picks, int pbmax, string faves, int pbfave, int tix)
        {
            Log.WriteLog(new LogEvent(string.Format("QuickPickService - QuickPicks()"), "Start"));

            Tickets tixs = new Tickets();
            tixs.tickets = new List<Ticket>();

            try
            {
                tix = fixTix(tix);
                faves = fixParam(faves);

                while (tix-- > 0)
                {
                    tixs.tickets.Add(Picks.GetPickObject(max, picks, pbmax, faves, pbfave));
                }

            }
            catch (Exception ex)
            {
                return "Server was not able to process your request " + ex.Message;
            }

            string json = JsonConvert.SerializeObject(tixs.tickets);

            json = json.Replace("\"ball6\":0,", "").Replace(",\"pBall\":0", "").Replace(",\"id\":0", "");

            return json;
        }

        private static int fixTix(int tix)
        {
            if (tix == 0) tix = 1;
            if (tix > 20) tix = 20;
            return tix;
        }

        private static String fixParam(String param)
        {
            if (param == null) param = "";
            return param;
        }

        //[WebGet(UriTemplate = "/QuickPicks", ResponseFormat = WebMessageFormat.Json)]
        //public string QuickPicks(QuickPicks quickPicks)
        //{
        //    Log.WriteLog(new LogEvent(string.Format("QuickPickService - QuickPicks()"), "Start"));
        //    return "{key: hoodoo, value: voodoo}";
        //}

        //[WebInvoke(Method = "POST", UriTemplate = "/LoadDailyIndustries", ResponseFormat = WebMessageFormat.Json)]
        //public string LoadDailyIndustries(BasicRequest basicRequest)
        //{
        //    Log.WriteLog(new LogEvent("QuickPickService - LoadDailyIndustries", "insert"));

        //    string result = string.Empty;

        //    if (basicRequest.token != "bc2afdc0-6f68-497a-9f6c-4e261331c256")
        //    {
        //        result = "You didn't say the magic word!";
        //    }
        //    else
        //    {
        //        var maxCount = IndustryWorks.LoadIndustriesBySector();
        //        var today = DateTime.Now.ToShortDateString();

        //        if (maxCount > 0)
        //        {
        //            var myDate = new LastUpdate();
        //            myDate.Name = "Industries";
        //            myDate.Date = today;
        //            myDate.Count = maxCount;
        //            db.LastUpdates.Add(myDate);
        //            db.SaveChanges();
        //        }
        //    }
        //    return result;
        //}

        [WebGet(UriTemplate = "/Person?id={id}", ResponseFormat = WebMessageFormat.Json)]
        public string GetPerson(int id)
        {
            Person peep = people.SingleOrDefault(p => p.Id == id);
            string json = JsonConvert.SerializeObject(peep);

            return json;
        }

        [WebInvoke(UriTemplate = "Person", RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        public Person InsertPerson(Person[] person)
        {
            return people[2];
        }

        [WebInvoke(UriTemplate = "/Person?id={id}", Method = "PUT")]
        public Person UpdatePerson(int id, Person person)
        {
            return people[1];
        }

        [WebInvoke(UriTemplate = "/Person?id={id}", Method = "DELETE")]
        public void DeletePerson(int id)
        {
        }

        private static void WriteLog(string message)
        {
            using (StreamWriter log = File.AppendText("logs/log.txt"))
            {
                log.Write(DateTime.Now.ToString(CultureInfo.InvariantCulture) + ": " + message + "\r\n");
                log.Flush();
                log.Close();
            }
        }

        #region private objects
        private Person[] people = new Person[]
            {
                new Person
                    {
                        Id = 1,
                        FirstName = "Biff",
                        LastName = "McGillicutty"
                    },
                new Person
                    {
                        Id = 2,
                        FirstName = "Muffy",
                        LastName = "McSplit"
                    },
                new Person
                    {
                        Id = 3,
                        FirstName = "Stan",
                        LastName = "Standard"
                    }
            };

        #endregion private objects

    }
}
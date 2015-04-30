using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickPickService.Models
{
    public class Picks
    {
        private static Random random = new Random();

        public static Ticket GetPickObjectxxx(int max, int picks, String faves)
        {
            string pix = GetPicks(max, picks, faves);
            String[] pixs = pix.Split(',');
            Ticket ticket = new Ticket()
            {
                ball1 = int.Parse(pixs[0]),
                ball2 = int.Parse(pixs[1]),
                ball3 = int.Parse(pixs[2]),
                ball4 = int.Parse(pixs[3]),
                ball5 = int.Parse(pixs[4])
            };
            if (pixs.Length == 6) ticket.ball6 = int.Parse(pixs[5]);

            return ticket;
        }

        public static Ticket GetPickObject(int max, int picks, int pbmax, string faves, int pbfave)
        {
            string pix = GetPicks(max, picks, faves);
            String[] pixs = pix.Split(',');
            Ticket ticket = new Ticket()
            {
                ball1 = int.Parse(pixs[0]),
                ball2 = int.Parse(pixs[1]),
                ball3 = int.Parse(pixs[2]),
                ball4 = int.Parse(pixs[3]),
                ball5 = int.Parse(pixs[4])
            };
            if (pixs.Length == 6) ticket.ball6 = int.Parse(pixs[5]);
            if (pbmax > 0)
            {
                pix = GetPicks(pbmax, 1, pbfave.ToString());
                ticket.pBall = pix == null ? 0 : int.Parse(pix);
            }

            return ticket;
        }

        public static String GetPicks(int max, int picks, String faves)
        {
            List<int> myPix = new List<int>();
            if (faves == "0") faves = "";

            String[] favorites = faves.Split(',');
            int numFaves = 0;

            if (!String.IsNullOrEmpty(faves))
            {
                for (int i = 0; i < favorites.Length; i++)
                {
                    myPix.Add(int.Parse(favorites[i]));
                }
                numFaves = favorites.Length;
            }

            for (int i = numFaves; i < picks; i++)
            {
                int nInt = nextInt(1, max);
                if (myPix.IndexOf(nInt) > -1)
                    i--;
                else
                    myPix.Add(nInt);
            }

            myPix.Sort();

            String json = "";
            for (int i = 0; i < myPix.Count; i++)
            {
                json += myPix[i] + ", ";
            }
            return json.Substring(0, json.Length-2);
        }

        private static int nextInt(int min, int max)
        {
            // nextInt is normally exclusive of the top value,
            // so add 1 to make it inclusive
            return random.Next((max - min) + 1) + min;
        }
    }
}
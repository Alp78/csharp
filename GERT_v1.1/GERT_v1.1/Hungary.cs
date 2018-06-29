using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;

namespace GERT_v1._1
{
    public class Hungary
    {
        public Hungary()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        }
        public static List<string> getRate()
        {
            return getRate(DateTime.Today);
        }

        public static List<string> getRate(DateTime dateParameter)
        {
            string currency = "HUF";
            List<string> stringList = new List<string>();
            List<string> finalList = new List<string>();
            string inputDate = dateParameter.ToString("dd/MM/yyyy", (IFormatProvider)CultureInfo.InvariantCulture);
            string fileDate = dateParameter.ToString("yyyy/MM/dd", (IFormatProvider)CultureInfo.InvariantCulture);
            string httpRequest = @"https://www.mnb.hu/arfolyam-tablazat?query=daily," + inputDate;
            using (WebClient webClient = new WebClient())
            {
                //WebClient webClient = new WebClient();
                string page = webClient.DownloadString(httpRequest);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(page);
                List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table")
                            .Descendants("tr")
                            //.Where(tr => tr.Elements("th").Count() > 1)
                            .Select(tr => tr.Elements("th").Select(td => td.InnerText.Trim()).ToList())
                            .ToList();

                var tablee = doc.DocumentNode.SelectSingleNode("//table")
                            .Descendants("tr")
                            .Where(tr => tr.Elements("th").Count() <= 1)
                                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim().Replace(",", ".")).ToList())
                            .ToList();
                

                if (tablee.Count == 0)
                    return stringList;
                for (int i = 1; i < table[2].Count; i++)
                {
                    if (table[2][i] == "100" && tablee[0][i] != "-")
                    {
                        float divadedValue = float.Parse(tablee[0][i]);
                        tablee[0][i] = Convert.ToString((divadedValue / 100));
                    }
                    stringList.Add(table[0][i] + "," + currency + "," + tablee[0][i] + "," + fileDate);
                }

                foreach (var str in stringList)
                {
                    if (str.Contains("-"))
                    {
                        continue;
                    }
                    else
                    {
                        finalList.Add(str);
                    }
                }

                return finalList;
            }
        }
    }
}

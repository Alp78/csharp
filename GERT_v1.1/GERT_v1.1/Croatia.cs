using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;

namespace GERT_v1._1
{
    class Croatia
    {
        public static List<string> getRate()
        {
            return getRate(DateTime.Today);
        }

        public static List<string> getRate(DateTime dateParameter)
        {
            string currency = "HRK";
            string outputDate = dateParameter.ToString("yyyy/MM/dd", (IFormatProvider)CultureInfo.InvariantCulture);
            string formattedDate = $"g=" + dateParameter.Year.ToString()+ "&m=" + dateParameter.Month.ToString() + "&d=" + dateParameter.Day.ToString();

            string httpRequest = @"http://www.zaba.hr/home/en/exchange-rate-list?" + formattedDate;

            List<string> ratesList = new List<string>();
            List<string> nodesList = new List<string>();
            List<string> finalList = new List<string>();
            string tempRate;
            decimal tempValue;

            using (WebClient webClient = new WebClient())
            {

                String page = webClient.DownloadString(httpRequest);

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(page);

                HtmlAgilityPack.HtmlNode table = doc.DocumentNode.SelectSingleNode("//table");
                HtmlAgilityPack.HtmlNodeCollection nodes = table.SelectNodes("//tr");

                foreach (var node in nodes)
                {
                    nodesList.Clear();
                    currency = node.GetAttributeValue("data-value", "N/A");

                    foreach (var childNode in node.ChildNodes)
                    {
                        nodesList.Add(childNode.InnerHtml.ToString());
                    }


                    for (int i = 0; i < nodesList.Count; i++)
                    {

                        if ((nodesList[5].Contains(',')))
                        {
                            tempRate = nodesList[5].Replace(',', '.');

                            if (nodesList[3] != "1")
                            {
                                tempValue = Math.Round(1/(Convert.ToDecimal(tempRate) / Convert.ToDecimal(nodesList[3])), 9);
                                ratesList.Add($"{currency},HRK,{tempValue.ToString()},{outputDate}");
                            }
                            else
                            {
                                ratesList.Add($"{currency},HRK,{(Math.Round((1/Convert.ToDecimal(tempRate)), 9)).ToString()},{outputDate}");
                            }
                        }
                    }

                }
                List<string> noDupes = ratesList.Distinct().ToList();
                
                for (int i = 0; i < noDupes.Count / 2; i++)
                {
                    finalList.Add(noDupes[i]);
                }
                return finalList;
            }
        }
    }
}
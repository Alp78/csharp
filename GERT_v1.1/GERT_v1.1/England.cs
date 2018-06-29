using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;


namespace GERT_v1._1
{
    public class England
    {
        

        public static List<string> getRate()
        {
            return getRate(DateTime.Today);
        }

        public static List<string> getRate(DateTime dateParameter)
        {
            string currency = "GBP";
            string outputDate = dateParameter.ToString("yyyy/MM/dd", (IFormatProvider)CultureInfo.InvariantCulture);
            string httpRequest;
            string formattedDate = $"TD=" + dateParameter.Day.ToString() + "&TM=" + dateParameter.ToString("MMM") + "&TY=" + dateParameter.Year.ToString() + "&into=" + currency + "&rateview=D";

            if (dateParameter == DateTime.Today)
            {
                httpRequest = @"https://www.bankofengland.co.uk/boeapps/database/Rates.asp";
            }
            else
            {
                httpRequest = @"https://www.bankofengland.co.uk/boeapps/database/Rates.asp?" + formattedDate;
            }
            
            List<string> ratesList = new List<string>();
            List<string> currencyList = new List<string>();
            List<string> finalList = new List<string>();
            List<string> matches = new List<string>();

            
            Regex currencyRegex = new Regex(@"[A-Z]{1}[a-z]{1,}");
            Regex rateRegex = new Regex(@"\s{1,}[0-9]{1,}\.{1}[0-9]{0,}");
            

            IDictionary<string, string> currencyDict = new Dictionary<string, string>()
            {
                {"AUD", "Australian Dollar"},
                {"CAD", "Canadian Dollar"},
                {"CNY", "Chinese Yuan"},
                {"CZK", "Czech Koruna"},
                {"DKK", "Danish Krone"},
                {"EUR", "Euro"},
                {"HKD", "Hong Kong Dollar"},
                {"HUF", "Hungarian Forint"},
                {"INR", "Indian Rupee"},
                {"ILS", "Israeli Shekel"},
                {"JPY", "Japanese Yen"},
                {"MYR", "Malaysian ringgit"},
                {"NZD", "New Zealand Dollar"},
                {"NOK", "Norwegian Krone"},
                {"PLN", "Polish Zloty"},
                {"RUB", "Russian Ruble"},
                {"SAR", "Saudi Riyal"},
                {"SGD", "Singapore Dollar"},
                {"ZAR", "South African Rand"},
                {"KRW", "South Korean Won"},
                {"SEK", "Swedish Krona"},
                {"CHF", "Swiss Franc"},
                {"TWD", "Taiwan Dollar"},
                {"THB", "Thai Baht"},
                {"TRY", "Turkish Lira"},
                {"USD", "US Dollar"}
            };

            using (WebClient webClient = new WebClient())
            {
                MatchCollection matchedRates;
                String page = webClient.DownloadString(httpRequest);

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(page);

                HtmlAgilityPack.HtmlNode table = doc.DocumentNode.SelectSingleNode("//table");
                HtmlAgilityPack.HtmlNodeCollection nodes = table.SelectNodes("//tr");

                currencyList.Clear();
                
                foreach (var node in nodes)
                {
                    foreach (var childNode in node.ChildNodes)
                    {   
                        if (currencyRegex.Match(childNode.InnerText).Success)
                        {
                            foreach (KeyValuePair<string, string> item in currencyDict)
                            {
                                if (childNode.InnerText == item.Value)
                                {
                                    currencyList.Add(item.Key);
                                }
                            }
                        }

                        if (rateRegex.Match(childNode.InnerText).Success)
                        {
                            matchedRates = rateRegex.Matches(childNode.InnerText);
                            foreach (Match match in matchedRates)
                            {
                                matches.Add(match.Value.ToString());
                            }
                        }
                    }
                }

                for (int i = 0; i < matches.Count; i += 3)
                {
                    ratesList.Add(Math.Round(1 / (Convert.ToDecimal(matches[i])), 9).ToString());
                }

                for (int i = 0; i < currencyList.Count; i++)
                {
                    finalList.Add($"{currencyList[i]},GBP,{ratesList[i]},{outputDate}");
                }
                
                return finalList;
            }

        }
    }
}

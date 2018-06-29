using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;

namespace GERT_v1._1
{
    public class Czech
    {
        public Czech()
        {
        }
        public static List<string> getRate()
        {
            return getRate(DateTime.Today);
        }

        public static List<string> getRate(DateTime dateParameter)
        {
            List<string> stringList = new List<string>();
            string str1 = "CZK";
            string str2 = "";
            string str3 = "";
            using (WebClient webClient = new WebClient())
            {
                string date = dateParameter.ToString("dd.MM.yyyy", (IFormatProvider)CultureInfo.InvariantCulture);
                string address = "http://www.cnb.cz/en/financial_markets/foreign_exchange_market/exchange_rate_fixing/daily.txt?date=" + date;
                int num = 1;
                try
                {
                    using (Stream stream = webClient.OpenRead(address))
                    {
                        using (StreamReader streamReader = new StreamReader(stream))
                        {
                            string str4;
                            while ((str4 = streamReader.ReadLine()) != null)
                            {
                                if (num == 1)
                                {
                                    DateTime result;
                                    if (!DateTime.TryParseExact(str4.Substring(0, 11), "dd.MMM yyyy", (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                                        return (List<string>)null;
                                    str2 = result.ToString("yyyy/MM/dd", (IFormatProvider)CultureInfo.InvariantCulture);
                                    str3 = result.ToString("yyyyMMdd", (IFormatProvider)CultureInfo.InvariantCulture);
                                }
                                if (num > 2)
                                {
                                    string[] strArray = str4.Split('|');
                                    string str5 = strArray[3];
                                    if (!(str5 == "XDR"))
                                    {
                                        Decimal result1;
                                        int result2;
                                        if (!Decimal.TryParse(strArray[4], NumberStyles.Number, (IFormatProvider)CultureInfo.InvariantCulture, out result1) || !int.TryParse(strArray[2], NumberStyles.None, (IFormatProvider)CultureInfo.InvariantCulture, out result2))
                                            return (List<string>)null;
                                        string str6 = (result1 / (Decimal)result2).ToString("0.########", (IFormatProvider)CultureInfo.InvariantCulture);
                                        stringList.Add(str5 + "," + str1 + "," + str6 + "," + str2);
                                    }
                                    else
                                        continue;
                                }
                                ++num;
                            }
                        }
                    }
                }
                catch (Exception ex) when (ex is WebException || ex is ArgumentNullException)
                {
                    return (List<string>)null;
                }
            }
            return stringList;
        }
    }
}

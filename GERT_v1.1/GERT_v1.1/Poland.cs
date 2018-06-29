using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security;
using System.Xml;
using System.Xml.Linq;

namespace GERT_v1._1
{
    public class Poland
    {
        public Poland()
        {
        }

        public static List<string> getRate() {
            CultureInfo cultureInfo = new CultureInfo("pl-PL");
            List<string> stringList = new List<string>();
            string uri = "http://www.nbp.pl/kursy/xml/LastA.xml";
            XDocument xdocument;
            try
            {
                xdocument = XDocument.Load(uri);
            }
            catch (Exception ex) when (ex is XmlException || ex is ArgumentNullException || ex is InvalidOperationException || ex is SecurityException)
            {
                return (List<string>)null;
            }
            XElement xelement = xdocument.Element((XName)"tabela_kursow");
            DateTime result1;
            if (!DateTime.TryParseExact(xelement.Element((XName)"data_publikacji").Value, "yyyy-MM-dd", (IFormatProvider)cultureInfo, DateTimeStyles.None, out result1))
                return (List<string>)null;
            string str1 = result1.ToString("yyyy/MM/dd", (IFormatProvider)CultureInfo.InvariantCulture);
            string str2 = result1.ToString("yyyyMMdd", (IFormatProvider)CultureInfo.InvariantCulture);
            string str3 = "PLN";
            foreach (XElement element in xelement.Elements((XName)"pozycja"))
            {
                string str4 = element.Element((XName)"kod_waluty").Value;
                if (!(str4 == "XDR"))
                {
                    Decimal result2;
                    int result3;
                    if (!Decimal.TryParse(element.Element((XName)"kurs_sredni").Value, NumberStyles.Number, (IFormatProvider)cultureInfo, out result2) || !int.TryParse(element.Element((XName)"przelicznik").Value, NumberStyles.None, (IFormatProvider)cultureInfo, out result3))
                        return (List<string>)null;
                    string str5 = (result2 / (Decimal)result3).ToString("0.########", (IFormatProvider)CultureInfo.InvariantCulture);
                    stringList.Add(str4 + "," + str3 + "," + str5 + "," + str1);
                }
            }
            return stringList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security;
using System.Xml;
using System.Xml.Linq;

namespace GERT_v1._1
{
    public class Russia
    {
        public Russia()
        {
        }

        public static List<string> getRate() {
            CultureInfo cultureInfo = new CultureInfo("ru-RU");
            List<string> stringList = new List<string>();
            XDocument xdocument;
            try
            {
                xdocument = XDocument.Load("http://www.cbr.ru/scripts/XML_daily_eng.asp");
            }
            catch (Exception ex) when (ex is XmlException || ex is ArgumentNullException || ex is InvalidOperationException || ex is SecurityException)
            {
                return (List<string>)null;
            }
            XElement xelement = xdocument.Element((XName)"ValCurs");
            DateTime result1;
            if (!DateTime.TryParseExact(xelement.Attribute((XName)"Date").Value, "dd.MM.yyyy", (IFormatProvider)cultureInfo, DateTimeStyles.None, out result1))
                return (List<string>)null;
            string str1 = result1.ToString("yyyy/MM/dd", (IFormatProvider)CultureInfo.InvariantCulture);
            string str2 = result1.ToString("yyyyMMdd", (IFormatProvider)CultureInfo.InvariantCulture);
            string str3 = "RUB";
            foreach (XElement element in xelement.Elements())
            {
                string str4 = element.Element((XName)"CharCode").Value;
                if (!(str4 == "XDR"))
                {
                    Decimal result2;
                    int result3;
                    if (!Decimal.TryParse(element.Element((XName)"Value").Value, NumberStyles.Number, (IFormatProvider)cultureInfo, out result2) || !int.TryParse(element.Element((XName)"Nominal").Value, NumberStyles.None, (IFormatProvider)cultureInfo, out result3))
                        return (List<string>)null;
                    string str5 = (result2 / (Decimal)result3).ToString("0.########", (IFormatProvider)CultureInfo.InvariantCulture);
                    stringList.Add(str4 + "," + str3 + "," + str5 + "," + str1);
                }
            }
            return stringList;
        }
    }
}

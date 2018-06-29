using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace GERT_v1._1
{
    public class Euro
    {
        public Euro()
        {
        }

        public static List<string> getRate()
        {
            return getRate(DateTime.Today);
        }

        public static List<string> getRate(DateTime dateParameter)
        {
            string formattedDate = dateParameter.ToString("yyyy-MM-dd", (IFormatProvider)CultureInfo.InvariantCulture);
            string fileDate = dateParameter.ToString("yyyy/MM/dd", (IFormatProvider)CultureInfo.InvariantCulture);
            String xmlPath = "http://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist.xml";

            List<string> stringList = new List<string>();

            XmlTextReader xmlReader = new XmlTextReader(xmlPath);

            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.GetAttribute("time") == formattedDate))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    XmlNode masterNode = xmlDoc.ReadNode(xmlReader);

                    foreach (XmlNode node in masterNode)
                    {
                        stringList.Add($"{node.Attributes[0].Value},EUR,{Math.Round((1/Convert.ToDecimal(node.Attributes[1].Value)), 9).ToString()},{fileDate}");
                    }

                }
            }
            return stringList;
        }
    }
}

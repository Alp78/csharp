using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace GERT_v1._1
{
    class Romania
    {
        public static List<string> getRate()
        {
            return getRate(DateTime.Today);
        }

        public static List<string> getRate(DateTime dateParameter)
        {

            string formattedDate = dateParameter.ToString("yyyy_M_d", (IFormatProvider)CultureInfo.InvariantCulture);
            string outputDate = dateParameter.ToString("yyyy/MM/dd", (IFormatProvider)CultureInfo.InvariantCulture);

            string httpRequest = @"http://www.bnr.ro/files/xml/curs_" + formattedDate + ".xml";

            XmlDocument xmlDoc = new XmlDocument();
            List<string> rateList = new List<string>();
            try
            {
                xmlDoc.Load(httpRequest);
            } catch(Exception)
            {
                return rateList;
            }

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("Rate");

            foreach (XmlNode xmlNode in nodeList)
            {
                rateList.Add(xmlNode.Attributes["currency"].Value + "," + "RON," + xmlNode.InnerXml + "," + outputDate);
            }

            return rateList;
        }
    }
}

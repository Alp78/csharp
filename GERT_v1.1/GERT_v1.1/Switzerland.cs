using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace GERT_v1._1
{
    class Switzerland
    {
        public static List<string> getRate()
        {
            return getRate(DateTime.Today);
        }

        public static List<string> getRate(DateTime dateParameter)
        {
        
            string outputDate = dateParameter.ToString("yyyy/MM/dd", (IFormatProvider)CultureInfo.InvariantCulture);
            
            string date = dateParameter.ToString("dd.MM.yyyy", (IFormatProvider)CultureInfo.InvariantCulture);
            string formattedDate = dateParameter.ToString("yyyyMMdd", (IFormatProvider)CultureInfo.InvariantCulture);

            String xmlPath = $"http://www.pwebapps.ezv.admin.ch/apps/rates/rate/getxml?activeSearchType=userDefinedDay&d={formattedDate}";

            XmlTextReader xmlReader = new XmlTextReader(xmlPath);
            List<string> ratesList = new List<string>();
            while (xmlReader.Read())
            {

                XmlDocument xmlDoc = new XmlDocument();
                XmlNode masterNode = xmlDoc.ReadNode(xmlReader);

                string currency = String.Empty;
                string rate = String.Empty;
                decimal factor = 0;
                int length = 0;

                foreach (XmlNode node in masterNode)
                {
                    if (node.Name == "devise")
                    {
                        currency = node.Attributes[0].Value.ToUpper();

                        foreach (XmlNode childNode in node.ChildNodes)
                        {
                            if (childNode.Name == "waehrung")
                            {
                                length = childNode.InnerText.Length;
                                factor = Convert.ToDecimal(childNode.InnerText.Substring(0, length - 3));
                            }

                            if (childNode.Name == "kurs")
                            {
                                if (factor != 1)
                                {
                                    rate = Math.Round(((Convert.ToDecimal(childNode.InnerText) / factor)), 9).ToString();
                                }
                                else
                                {
                                    rate = childNode.InnerText;
                                }
                            }

                        }

                        ratesList.Add($"{currency},CHF,{rate},{outputDate}");
                    }
                }
            }
            return ratesList;
        }
    }
}

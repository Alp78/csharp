using System;
using System.Collections.Generic;
using System.Globalization;

namespace GERT_v1._1
{
    public class ConsoleV
    {
        string[] args;
        public ConsoleV(string[] args)
        {
            this.args = args;
        }
        public List<string> run(out string currency, out string date) {
            currency = null;
            date = null;
            string currencyParameter = null;
            DateTime dateParameter;
            if (args.Length == 0)
            {
                InteractiveInput(out currencyParameter, out dateParameter);
            }
            else if (!ParseArguments(args, out currencyParameter, out dateParameter))
            {
                Console.WriteLine("Invalid parameters.");
                return null;
            }
            List<string> stringList = new List<string>();
            while (stringList.Count == 0)
            {
                switch (currencyParameter.ToLower())
                {
                    case "gbp":
                        stringList = England.getRate(dateParameter);
                        break;
                    case "czk":
                        stringList = Czech.getRate(dateParameter);
                        break;
                    case "rub":
                        stringList = Russia.getRate();
                        break;
                    case "pln":
                        stringList = Poland.getRate();
                        break;
                    case "huf":
                        stringList = Hungary.getRate(dateParameter);
                        break;
                    case "eur":
                        stringList = Euro.getRate(dateParameter);
                        break;
                    case "hrk":
                        stringList = Croatia.getRate(dateParameter);
                        break;
                    case "chf":
                        stringList = Switzerland.getRate(dateParameter);
                        break;
                    case "rom":
                        stringList = Romania.getRate(dateParameter);
                        break;
                    default:
                        Console.WriteLine("Invalid currency parameter.");
                        return null;
                }
                dateParameter = dateParameter.AddDays(-1);
            }
            currency = currencyParameter.ToLower();
            date = (dateParameter.AddDays(1).ToString("yyyyMMdd"));
            return stringList;
        }
        private bool ParseArguments(string[] args, out string currencyParameter, out DateTime dateParameter)
        {
            currencyParameter = (string)null;
            dateParameter = DateTime.Today;
            switch (args.Length)
            {
                case 1:
                    currencyParameter = args[0];
                    break;
                case 2:
                    currencyParameter = args[0];
                    DateTime result1;
                    if (!DateTime.TryParseExact(args[1], "dd/MM/yyyy", (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.None, out result1) || result1.Year < 2010)
                        return false;
                    dateParameter = result1;
                    break;
                default:
                    return false;
            }
            return true;
        }

        private void InteractiveInput(out string currencyParameter, out DateTime dateParameter)
        {
            currencyParameter = (string)null;
            dateParameter = DateTime.Today;
            bool flag1 = false;
            bool flag2 = false;
            Console.Write("Enter an available currency (eur|chf|gbp|czk|pln|rub|huf|rom|hrk): ");
            while (!flag1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string str = Console.ReadLine();
                Console.ResetColor();
                Console.WriteLine("");
                if (new List<string>()
        {
          "czk",
          "pln",
          "rub",
          "huf",
          "eur",
          "rom",
          "chf",
          "hrk",
          "gbp"
        }.Contains(str.ToLower()))
                {
                    currencyParameter = str;
                    flag1 = true;
                }
                else
                    Console.Write("Invalid input. Please, try again. (eur|chf|gbp|czk|pln|rub|huf|rom|hrk): ");
            }
            if ((currencyParameter == "rub") || (currencyParameter == "pln"))
                return;
            Console.Write("Enter a date for historical rates (dd/mm/yyyy), or press Enter without a date to get the latest rates: ");
            while (!flag2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string s = Console.ReadLine();
                Console.ResetColor();
                Console.WriteLine("");
                if (s == "")
                {
                    dateParameter = DateTime.Today;
                    flag2 = true;
                    Console.WriteLine("");
                }
                else
                {
                    DateTime result;
                    if (!DateTime.TryParseExact(s, "dd/MM/yyyy", (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                        Console.WriteLine("Invalid input. Please, try again. (dd/mm/yyyy)");
                    else if (result.Year < 2010)
                    {
                        Console.WriteLine("Choose a date more recent that 2009. (dd/mm/yyyy)");
                    }
                    else
                    {
                        dateParameter = result;
                        flag2 = true;
                    }
                }
            }
        }
    }
}

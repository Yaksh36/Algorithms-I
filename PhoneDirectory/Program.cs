using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PhoneDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /* string s = "/ 156 Alphand_St.\n 133, Green, Rd. <E Kustur> NY-56423 ;+1-541-914-3010!\n";
             Phone(s, "1-541-754-3010");*/
            PhoneDirTests.test1();
        }

        public static string Phone(string strng, string num)
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            string address = "";
            string name = "";
            string phone = "";
            string[] lines = strng.Split(Environment.NewLine.ToCharArray());
            string namePattern = @"<(.*?)>";
            string phonePattern = @"(\d{1,2})?-\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}";

            foreach (string l in lines)
            {
                if (l != "")
                {
                    string line = l;
                    Match nameMatch = Regex.Match(line, namePattern);
                    Match phoneMatch = Regex.Match(line, phonePattern);

                    if (nameMatch.Success)
                        name = nameMatch.Groups[1].Captures[0].ToString();
                    if (phoneMatch.Success)
                        phone = phoneMatch.Value;
                    // Console.WriteLine(phone);
                    //remove phone number from the string
                    line = Regex.Replace(line, "[+]" + phone, "");

                    //remove name from the string
                    line = Regex.Replace(line, namePattern, "");

                    //assign the rest of the string as the address
                    address = line;
                    address = Regex.Replace(address, @"[\/;$*:?]", "").Trim();
                    address = Regex.Replace(address, @"[_]", " ");
                    address = Regex.Replace(address, @"\s{2,}", " ");

                    if (phoneBook.ContainsKey(phone))
                    {
                        phoneBook[phone] = String.Format("Error => Too many people: {0}",phone);
                    }
                    else
                    {
                        string value = String.Format("Phone => {0}, Name => {1}, Address => {2}", phone, name, address);
                        phoneBook.Add(phone, value);

                    }

                    Console.WriteLine(phoneBook[phone]);

                }
            }
            string result = "";
            if (phoneBook.ContainsKey(num))
            {
                result = phoneBook[num];
            }
            else
            {
                result = String.Format("Error => Not found: {0}", num);
            }

            return result;
        }
    }

    [TestFixture]
    public static class PhoneDirTests
    {

        static string dr = "/+1-541-754-3010 156 Alphand_St. <J Steeve>\n 133, Green, Rd. <E Kustur> NY-56423 ;+1-541-914-3010\n"
        + "+1-541-984-3012 <P Reed> /PO Box 530; Pollocksville, NC-28573\n :+1-321-512-2222 <Paul Dive> Sequoia Alley PQ-67209\n"
        + "+1-741-984-3090 <Peter Reedgrave> _Chicago\n :+1-921-333-2222 <Anna Stevens> Haramburu_Street AA-67209\n"
        + "+1-111-544-8973 <Peter Pan> LA\n +1-921-512-2222 <Wilfrid Stevens> Wild Street AA-67209\n"
        + "<Peter Gone> LA ?+1-121-544-8974 \n <R Steell> Quora Street AB-47209 +1-481-512-2222\n"
        + "<Arthur Clarke> San Antonio $+1-121-504-8974 TT-45120\n <Ray Chandler> Teliman Pk. !+1-681-512-2222! AB-47209,\n"
        + "<Sophia Loren> +1-421-674-8974 Bern TP-46017\n <Peter O'Brien> High Street +1-908-512-2222; CC-47209\n"
        + "<Anastasia> +48-421-674-8974 Via Quirinal Roma\n <P Salinger> Main Street, +1-098-512-2222, Denver\n"
        + "<C Powel> *+19-421-674-8974 Chateau des Fosses Strasbourg F-68000\n <Bernard Deltheil> +1-498-512-2222; Mount Av.  Eldorado\n"
        + "+1-099-500-8000 <Peter Crush> Labrador Bd.\n +1-931-512-4855 <William Saurin> Bison Street CQ-23071\n"
        + "<P Salinge> Main Street, +1-098-512-2222, Denve\n" + "<P Salinge> Main Street, +1-098-512-2222, Denve\n";

        private static void testing(string actual, string expected)
        {
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public static void test1()
        {
            Console.WriteLine("Phone");
            testing(Program.Phone(dr, "48-421-674-8974"), "Phone => 48-421-674-8974, Name => Anastasia, Address => Via Quirinal Roma");
            testing(Program.Phone(dr, "1-921-512-2222"), "Phone => 1-921-512-2222, Name => Wilfrid Stevens, Address => Wild Street AA-67209");
            testing(Program.Phone(dr, "1-908-512-2222"), "Phone => 1-908-512-2222, Name => Peter O'Brien, Address => High Street CC-47209");
            testing(Program.Phone(dr, "1-541-754-3010"), "Phone => 1-541-754-3010, Name => J Steeve, Address => 156 Alphand St.");
            testing(Program.Phone(dr, "1-121-504-8974"), "Phone => 1-121-504-8974, Name => Arthur Clarke, Address => San Antonio TT-45120");
            testing(Program.Phone(dr, "1-498-512-2222"), "Phone => 1-498-512-2222, Name => Bernard Deltheil, Address => Mount Av. Eldorado");
            testing(Program.Phone(dr, "1-098-512-2222"), "Error => Too many people: 1-098-512-2222");
            testing(Program.Phone(dr, "5-555-555-5555"), "Error => Not found: 5-555-555-5555");

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IsomorphicStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application Start ----------------");
            Console.WriteLine();

            //Read all the lines
            string[] lines = File.ReadAllLines("C:/Users/Yaksh Patel/Downloads/IsomorphInput1.txt");

            Dictionary<string, List<string>> exactIsomorphsDictionary = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> looseIsomorphsDictionary = new Dictionary<string, List<string>>();
            List<string> nonIsomorphs = new List<string>();

            foreach (string word in lines)
            {
                //Exact Isomporh
                string isomoprh = ExactIsomorphic(word);
                if (exactIsomorphsDictionary.ContainsKey(isomoprh))
                {
                    exactIsomorphsDictionary[isomoprh].Add(word);
                }
                else
                {
                    exactIsomorphsDictionary[isomoprh] = new List<string>();
                    exactIsomorphsDictionary[isomoprh].Add(word);
                }

                //looseIsomorph
                string looseIsomoprh = LooseIsomorphic(word);
                if (looseIsomorphsDictionary.ContainsKey(looseIsomoprh))
                {
                    looseIsomorphsDictionary[looseIsomoprh].Add(word);
                }
                else
                {
                    looseIsomorphsDictionary[looseIsomoprh] = new List<string>();
                    looseIsomorphsDictionary[looseIsomoprh].Add(word);
                }

            }
            //===============RESULT==============//
            StringBuilder exactStringBuilder = new StringBuilder();
            exactStringBuilder.AppendLine("Exact Isomorphs");
            //Exact Isomorph Result
            foreach (KeyValuePair<string, List<string>> pair in exactIsomorphsDictionary)
            {
                if (pair.Value.Count > 1)
                {
                    pair.Value.Sort();
                    string isomorphsWordsList = string.Join(" ", pair.Value);
                    exactStringBuilder.AppendLine(pair.Key + ": " + isomorphsWordsList);
                }
            }

            exactStringBuilder.AppendLine();

            exactStringBuilder.AppendLine("Loose Isomorphs");
            //Loose Isomporh Result
            foreach (KeyValuePair<string, List<string>> pair in looseIsomorphsDictionary)
            {
                if (pair.Value.Count > 1)
                {
                    pair.Value.Sort();
                    string isomorphsWordsList = string.Join(" ", pair.Value);
                    exactStringBuilder.AppendLine(pair.Key + ": " + isomorphsWordsList);
                }
            }

            exactStringBuilder.AppendLine();

            exactStringBuilder.AppendLine("Non-isomorphs");
            //Non Isomorphs
            foreach (KeyValuePair<string, List<string>> pair in looseIsomorphsDictionary)
            {
                if (pair.Value.Count == 1)
                {
                    pair.Value.Sort();
                    string isomorphsWordsList = string.Join(" ", pair.Value);
                    exactStringBuilder.Append(isomorphsWordsList + " ");
                }
            }
            Console.WriteLine(exactStringBuilder.ToString());

            writeOutputFile(exactStringBuilder.ToString());
        }

        private static void writeOutputFile(string text)
        {
            File.WriteAllText("C:/Users/Yaksh Patel/Downloads/output.txt", text);
        }

        private static string ExactIsomorphic(string word)
        {
            Dictionary<char, int> wordDictionary = new Dictionary<char, int>();
            string isometricString = "";
            int index = -1;
            foreach(char c in word)
            {
                if (wordDictionary.ContainsKey(c))
                {
                    isometricString += wordDictionary[c];
                }
                else
                {
                    index++;
                    wordDictionary[c] = index;
                    isometricString += index;
                }
            }
            return isometricString;
        }

        private static string LooseIsomorphic(string word)
        {
            Dictionary<char, int> wordDictionary = new Dictionary<char, int>();

            foreach (char c in word)
            {
                if (wordDictionary.ContainsKey(c))
                {
                    wordDictionary[c] = wordDictionary[c] + 1;
                }
                else
                {
                    wordDictionary[c] = 1;
                }
            }

            var list  = wordDictionary.OrderBy(pair => pair.Value).Select(pair=>pair.Value).ToList();
            return string.Join("", list);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace Report
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionaryLevels = new Dictionary<string, int>();
            string[] levels = { "|INFO|", "|WARN|", "|ERROR|" };
            using (StreamReader sr = new StreamReader("..\\..\\..\\TestProject\\bin\\Debug\\FileSystem.log"))
            {
                string logLine;
                while ((logLine = sr.ReadLine()) != null)
                {
                    foreach (string level in levels)
                    {
                        if (logLine.Contains(level))
                        {
                            if (dictionaryLevels.ContainsKey(level))
                                ++dictionaryLevels[level];
                            else
                                dictionaryLevels[level] = 1;
                        }
                        if (level == "|ERROR|" && logLine.Contains(level))
                            Console.WriteLine(logLine);
                    }
                }
            }

            foreach (var p in dictionaryLevels)
                Console.WriteLine("{0} : {1}", p.Key, p.Value);

            Console.ReadKey();
        }       
    }
}

using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Module4HomeWork
{
    class task1
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        List<string> list = new List<string>();

        public void AddToDictionary()
        {
            int counter = 0;
            string line;

            StreamReader file = new StreamReader(@"..//..//text.txt");
            while ((line = file.ReadLine()) != null)
            {
                dictionary.Add(counter.ToString(), line);
                counter++;
            }

            file.Close();
        }

        public string SearchStringInDictinory(string str)
        {
            string value = "";
            return (dictionary.TryGetValue(str, out value) ? value : "no such line");
        }

        public void AddToList()
        {
            int counter = 0;
            string line;

            StreamReader file = new StreamReader(@"..//..//text.txt");
            while ((line = file.ReadLine()) != null)
            {
                list.Add(line);
                counter++;
            }

            file.Close();
        }

        public string SearchStringInList(string str)
        {
            return list.Find(x => x==str);
        }
    }
}

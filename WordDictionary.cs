using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class WordDictionary
    {
        private List<string> list;
        public WordDictionary()
        {
            list = new List<string>();
        }

        public void AddWord(string word)
        {
            list.Add(word);
        }

        public bool Search(string word)
        {
            var filteredWords = list.FindAll(x => x.Length == word.Length);
            return (filteredWords != null) ? true : false;
        }
    }
}

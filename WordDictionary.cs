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
            if (filteredWords.Count == 0) return false;
            bool[] wordMatch  = new bool[word.Length];
            for (int i = 0; i < word.Length;i++)
            {
                if (word[i] == '.')
                {
                    wordMatch[i] = true;
                    continue;
                }
                else
                {
                    for (int j = 0; j < filteredWords.Count; j++)
                    {
                        if (filteredWords[j][i] == word[i])
                        {
                            wordMatch[i] = true;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < wordMatch.Length; i++)
                if (wordMatch[i] == false) return false;
            return true;
        }
    }
}

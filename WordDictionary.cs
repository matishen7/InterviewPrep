using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class WordDictionary
    {
        private TrieNode root;

        public WordDictionary()
        {
            root = new TrieNode();
        }

        public void AddWord(string word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                if (!node.Children.ContainsKey(c))
                {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];
            }
            node.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            return SearchHelper(word, root);
        }

        private bool SearchHelper(string word, TrieNode node)
        {
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (c == '.')
                {
                    foreach (var child in node.Children.Values)
                    {
                        if (SearchHelper(word.Substring(i + 1), child))
                        {
                            return true;
                        }
                    }
                    return false; // No matching child found for '.'
                }
                else if (!node.Children.ContainsKey(c))
                {
                    return false; // Character not found
                }
                node = node.Children[c];
            }
            return node.IsEndOfWord;
        }
    }

    public class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();
            public bool IsEndOfWord { get; set; }
        }
    }

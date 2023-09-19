
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;
WordDictionary wordDictionary = new WordDictionary();
wordDictionary.AddWord("bad");
wordDictionary.AddWord("dad");
wordDictionary.AddWord("mad");
wordDictionary.Search("pa"); // return False
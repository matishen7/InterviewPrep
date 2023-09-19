
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;
WordDictionary wordDictionary = new WordDictionary();
wordDictionary.AddWord("at");
wordDictionary.AddWord("and");
wordDictionary.AddWord("an");
wordDictionary.AddWord("add"); // return False
wordDictionary.Search("."); // return False
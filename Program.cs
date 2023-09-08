
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;
MyQueue myQueue= new MyQueue();
myQueue.Push(1);
myQueue.Push(2);
myQueue.Push(3);
Console.WriteLine(myQueue.Pop());
Console.WriteLine(myQueue.Pop());
Console.WriteLine(myQueue.Pop());
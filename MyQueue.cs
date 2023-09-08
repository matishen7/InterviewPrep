using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MyQueue
    {
        private Stack<int> queue;
        private Stack<int> temp;

        public MyQueue()
        {
            queue = new Stack<int>();
            temp = new Stack<int>();
        }

        public void Push(int x)
        {
            if (queue.Count == 0) queue.Push(x);
            else
            {
                while (queue.Count > 0)
                {
                    var t = queue.Pop();
                    temp.Push(t);
                }

                queue.Push(x);
                while (temp.Count > 0)
                {
                    var q = temp.Pop();
                    queue.Push(q);
                }
            }
        }

        public int Pop()
        {
            if (queue.Count != 0)
                return queue.Pop();
            else throw new Exception("Queue is empty!");
        }

        public int Peek()
        {
            return queue.Peek();
        }

        public bool Empty()
        {
            return (queue.Count == 0) ? true : false;
        }
    }
}

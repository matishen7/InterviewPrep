namespace ConsoleApp1
{
    internal static class StackProblems
    {

        public static int CalPoints(string[] operations)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < operations.Length; i++)
            {
                if (operations[i].Equals("C")) stack.Pop();
                else if (operations[i].Equals("D"))
                {
                    int op;
                    if (stack.Count != 0)
                    {
                        op = stack.Peek();
                        op *= 2;
                        stack.Push(op);
                    }
                }
                else if (operations[i].Equals("+"))
                {
                    int s = 0, count = 0, j = 0;
                    while (count < 2)
                    {
                        s += stack.ElementAt(j);
                        j++;
                        count++;
                    }
                    stack.Push(s);

                }
                else
                    stack.Push(Int32.Parse(operations[i]));
            }
            int sum = 0;
            while (stack.Count > 0)
                sum += stack.Pop();
            return sum;

        }
        public static int MinLength(string s)
        {
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {

                if (s[i] == 'B' && stack.Count != 0)
                {
                    var lastcc = stack.Peek();
                    if (lastcc == 'A')
                        stack.Pop();
                    else stack.Push(s[i]);
                }

                else if (s[i] == 'D' && stack.Count != 0)
                {
                    var lastcc = stack.Peek();
                    if (lastcc == 'C')
                        stack.Pop();
                    else stack.Push(s[i]);
                }

                else stack.Push(s[i]);
            }

            return stack.Count;

        }

        public static string RemoveDuplicates(string s)
        {
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {

                if (stack.Count != 0)
                {
                    var lastChar = stack.Peek();
                    if (lastChar == s[i]) stack.Pop();
                    else stack.Push(s[i]);
                }
                else stack.Push(s[i]);
            }
            string result = "";
            while (stack.Count != 0)
            {
                result = stack.Pop() + result;
            };
            return result;
        }
    }
}
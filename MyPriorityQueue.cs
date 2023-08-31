using System;
using System.Collections.Generic;
namespace ConsoleApp1;
class MyPriorityQueue<TItem, TPriority>
{
    private List<(TItem item, TPriority priority)> data;
    private Comparison<TPriority> comparison;

    public MyPriorityQueue(Comparison<TPriority> comparison)
    {
        this.data = new List<(TItem, TPriority)>();
        this.comparison = comparison;
    }

    public void Enqueue(TItem item, TPriority priority)
    {
        data.Add((item, priority));
        int currentIndex = data.Count - 1;

        while (currentIndex > 0)
        {
            int parentIndex = (currentIndex - 1) / 2;

            if (comparison(data[currentIndex].priority, data[parentIndex].priority) >= 0)
                break;

            (TItem tempItem, TPriority tempPriority) = data[currentIndex];
            data[currentIndex] = data[parentIndex];
            data[parentIndex] = (tempItem, tempPriority);

            currentIndex = parentIndex;
        }
    }

    public bool TryDequeue(out TItem item, out TPriority priority)
    {
        if (data.Count == 0)
        {
            item = default(TItem);
            priority = default(TPriority);
            return false;
        }

        (TItem frontItem, TPriority frontPriority) = data[0];
        int lastIndex = data.Count - 1;
        data[0] = data[lastIndex];
        data.RemoveAt(lastIndex);

        int currentIndex = 0;
        while (true)
        {
            int leftChildIndex = 2 * currentIndex + 1;
            int rightChildIndex = 2 * currentIndex + 2;
            int smallestChildIndex = -1;

            if (leftChildIndex < data.Count)
            {
                smallestChildIndex = leftChildIndex;
                if (rightChildIndex < data.Count && comparison(data[rightChildIndex].priority, data[leftChildIndex].priority) < 0)
                {
                    smallestChildIndex = rightChildIndex;
                }
            }

            if (smallestChildIndex >= 0 && comparison(data[smallestChildIndex].priority, data[currentIndex].priority) < 0)
            {
                (TItem tempItem, TPriority tempPriority) = data[currentIndex];
                data[currentIndex] = data[smallestChildIndex];
                data[smallestChildIndex] = (tempItem, tempPriority);

                currentIndex = smallestChildIndex;
            }
            else
            {
                break;
            }
        }

        item = frontItem;
        priority = frontPriority;
        return true;
    }

    public int Count
    {
        get { return data.Count; }
    }
}

//class Program
//{
//    static void Main(string[] args)
//    {
//        // Example usage with integers as both items and priorities
//        PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>((a, b) => a.CompareTo(b));
//        priorityQueue.Enqueue(3, 0);
//        priorityQueue.Enqueue(1, 60);
//        priorityQueue.Enqueue(4, 2);
//        priorityQueue.Enqueue(2, 1);

//        Console.WriteLine("Priority Queue:");
//        while (priorityQueue.TryDequeue(out int item, out int priority))
//        {
//            Console.WriteLine($"Popped Item : {item}. Priority Was : {priority}");
//        }
//    }
//}

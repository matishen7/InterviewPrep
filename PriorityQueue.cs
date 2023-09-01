using System;
using System.Collections.Generic;
namespace ConsoleApp1;
class PriorityQueue<T>
{
    private List<T> data;
    private Comparison<T> comparison;

    public PriorityQueue(Comparison<T> comparison)
    {
        this.data = new List<T>();
        this.comparison = comparison;
    }

    public T GetElementAt(int index)
    {
        return data[index];
    }

    public void Enqueue(T item)
    {
        data.Add(item);
        int currentIndex = data.Count - 1;

        while (currentIndex > 0)
        {
            int parentIndex = (currentIndex - 1) / 2;

            if (comparison(data[currentIndex], data[parentIndex]) >= 0)
                break;

            T temp = data[currentIndex];
            data[currentIndex] = data[parentIndex];
            data[parentIndex] = temp;

            currentIndex = parentIndex;
        }
    }

    public T Dequeue()
    {
        if (data.Count == 0)
            throw new InvalidOperationException("Priority queue is empty.");

        T frontItem = data[0];
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
                if (rightChildIndex < data.Count && comparison(data[rightChildIndex], data[leftChildIndex]) < 0)
                {
                    smallestChildIndex = rightChildIndex;
                }
            }

            if (smallestChildIndex >= 0 && comparison(data[smallestChildIndex], data[currentIndex]) < 0)
            {
                T temp = data[currentIndex];
                data[currentIndex] = data[smallestChildIndex];
                data[smallestChildIndex] = temp;

                currentIndex = smallestChildIndex;
            }
            else
            {
                break;
            }
        }

        return frontItem;
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
//        // Example usage with integers
//        PriorityQueue<int> priorityQueue = new PriorityQueue<int>((a, b) => b.CompareTo(a)); // Reversed comparison logic
//        priorityQueue.Enqueue(3);
//        priorityQueue.Enqueue(1);
//        priorityQueue.Enqueue(4);

//        Console.WriteLine("Priority Queue:");
//        while (priorityQueue.Count > 0)
//        {
//            int item = priorityQueue.Dequeue();
//            Console.WriteLine(item);
//        }
//    }
//}

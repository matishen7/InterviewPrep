using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;
public class MyHeap
{
    private int[] elements = new int[] { };
    private int index = 0;
    public MyHeap()
    {
        elements = new int[] { };
    }

    public MyHeap(int[] el)
    {
        this.elements = el;
        index = elements.Length;
    }

    public MyHeap(int size)
    {
        elements = new int[size];
    }

    private void swap(int[] elements, int targetIdx, int sourceIdx)
    {
        int temp = elements[sourceIdx];
        elements[sourceIdx] = elements[targetIdx];
        elements[targetIdx] = temp;
    }

    private void HeapifyWhenInsert(int idx)// Big O O(logN)
    {

        var parentIndex = (int)Math.Floor((idx - 1) / 2.0);
        while (elements[parentIndex] > elements[idx])
        {
            swap(elements, parentIndex, idx);
            idx = parentIndex;
            parentIndex = (int)Math.Floor((idx - 1) / 2.0);
            if (parentIndex < 0) break;
        }
    }

    private void ResizeWhenInsert()
    {
        var newElements = new int[elements.Length + 1];
        elements.CopyTo(newElements, 0);
        elements = newElements;
    }
    public int Size()
    {
        return elements.Length;
    }
    public void Insert(int value)
    {
        if (elements.Length == 0)
        {
            elements = new int[1];
            elements[index++] = value;
        }
        else
        {
            if (index >= elements.Length)
                ResizeWhenInsert();
            elements[index] = value;
            HeapifyWhenInsert(index);
            index++;
        }

    }

    public int GetElementAt(int index)
    {
        return elements[index];
    }
}
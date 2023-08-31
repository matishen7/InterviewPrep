
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using static ConsoleApp1.BST;

MedianFinder medianFinder = new MedianFinder();
List<double> results = new List<double>();

string[] commands = new string[]
{
            "MedianFinder", "addNum", "findMedian", "addNum", "findMedian",
            "addNum", "findMedian", "addNum", "findMedian", "addNum",
            "findMedian", "addNum", "findMedian", "addNum", "findMedian",
            "addNum", "findMedian", "addNum", "findMedian", "addNum",
            "findMedian", "addNum", "findMedian"
};

int[] values = new int[]
{
            0, 6, 0, 10, 0, 2, 0, 6, 0, 5, 0, 0, 0, 6, 0, 3, 0, 1, 0, 0, 0, 0, 0
};

for (int i = 0; i < commands.Length; i++)
{
    if (commands[i] == "MedianFinder")
    {
        medianFinder = new MedianFinder();
        results.Add(0);
    }
    else if (commands[i] == "addNum")
    {
        medianFinder.AddNum(values[i]);
        results.Add(0);
    }
    else if (commands[i] == "findMedian")
    {
        double median = medianFinder.FindMedian();
        results.Add(median);
    }
}

foreach (var result in results)
{
    Console.WriteLine(result);
}


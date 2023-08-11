
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using static ConsoleApp1.BST;

string s = "AB";
Console.WriteLine(TitleToNumber(s));

static bool SameTree(Node node1, Node node2)
{
    var bst = new BST();
    var list1 = bst.BFS(node1);
    var list2 = bst.BFS(node2);
    return SameList(list1, list2);
}

static bool SameList(List<int> list1, List<int> list2)
{
    if (list1.Count != list2.Count) return false;
    for (int i = 0; i < list1.Count; i++)
        if (list1[i] != list2[i]) return false;
    return true;
}

static int TitleToNumber(string columnTitle)
{
    var dic = new Dictionary<char, int>()
    {
        { 'A', 1},
        { 'B', 2},
        { 'C', 3},
        { 'D', 4},
        { 'E', 5},
        { 'F', 6},
        { 'G', 7},
        { 'H', 8},
        { 'I', 9},
        { 'J', 10},
        { 'K', 11},
        { 'L', 12},
        { 'M', 13},
        { 'N', 14},
        { 'O', 15},
        { 'P', 16},
        { 'Q', 17},
        { 'R', 18},
        { 'S', 19},
        { 'T', 20},
        { 'U', 21},
        { 'V', 22},
        { 'W', 23},
        { 'X', 24},
        { 'Y', 25},
        { 'Z', 26},
    };
    int result = 0;

    for (int i = 0; i < columnTitle.Length; i++)
    {
        int t = columnTitle.Length - i;
        int k = 1;
        while (t > 1)
        {
            k *= 26;
            t--;
        }
        result += k * dic[columnTitle[i]];
    }
    return result;
}

static string Convert(string s, int numRows)
{
    int colNum = (int)Math.Ceiling(s.Length / 2.0);
    char[,] matrix = new char[numRows, colNum];
    int index = 0;
    int currRow = 0;
    int currCol = 0;
    bool diag = false;
    while (index < s.Length)
    {

        if (currRow == numRows)
        {
            currRow -= 2; ;
            currCol++;
            matrix[currRow, currCol] = s[index];
            index++;
            diag = true;
        }
        else if (currRow < numRows && diag == false)
        {
            currRow++;
            matrix[currRow - 1, currCol] = s[index];
            index++;
        }
        else if (diag)
        {
            while (currRow > 0)
            {
                currRow--;
                currCol++;
                matrix[currRow, currCol] = s[index];
                index++;
            }

            diag = false;
            currRow++;
        }



        PrintArray(matrix);
    }
    Console.WriteLine(index);
    return s;

}

static void PrintArray(char[,] matrix)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);
    Console.WriteLine("------------");
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            if (matrix[row, col] != '\0') Console.Write(matrix[row, col]); else Console.Write('*');
        }
        Console.WriteLine();
    }
}
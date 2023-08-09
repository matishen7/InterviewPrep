
using System.ComponentModel.DataAnnotations;

string s = "PAYPALISHIRINGHERE"; int rows = 4;
Console.WriteLine(Convert(s, rows));

static string Convert(string s, int numRows)
{
    int colNum = (int)Math.Ceiling(s.Length / 2.0);
    char[,] matrix = new char[numRows, colNum];
    int index = 0;
    int currRow = 0;
    int currCol = 0;
    bool diag = false;
    while (index < s.Length - 1)
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
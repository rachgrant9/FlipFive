using System;
using System.Collections.Generic;
using System.Linq;

namespace FlipFive
{
  public class Utilities
  {
    const int XMax = 3;
    const int YMax = 3;

    public static string CreateStringFromArray(char[,] array)
    {
      string newString = "";
      foreach (var letter in array)
      {
        newString += letter;
      }

      return newString;
    }

    public static Char[,] CreateOuputGrid(List<string> input)

    {
      var grid = new Char[3, 3];
      var rows = input.Take(3).ToArray();
      // for each row
      for (int row = 0; row < YMax; row++)
      {
        // for each square in a row
        for (int sqr = 0; sqr < XMax; sqr++)
        {
          var value = Convert.ToChar(rows[row].Substring(sqr, 1));
          grid[sqr, row] = value;
        }
      }
      return grid;
    }

    public static List<string> GetInput(int numberPuzzles)
    {
      string line;
      List<string> input = new List<string>();
      var puzzleLines = numberPuzzles * YMax;

      for (int i = 0; i < puzzleLines; i++)
      {
        line = Console.ReadLine();
        input.Add(line);
      }

      return input;
    }
  }
}

using System;
using static FlipFive.Utilities;

namespace FlipFive
{
  class Program
  {
    static void Main(string[] args)
    {
      var numberPuzzles = Convert.ToInt32(Console.ReadLine());
      var inputList = GetInput(numberPuzzles);
      var emptyGrid = new Char[,] { { '.', '.', '.' }, { '.', '.', '.' }, { '.', '.', '.' } };

      for (int puzzleNumber = 1; puzzleNumber <= numberPuzzles; puzzleNumber++)
      {
        var expectedOutput = CreateOuputGrid(inputList);
        var expectedString = CreateStringFromArray(expectedOutput);

        var moves = new MakeMove(expectedString);
        moves.MakeFirstMove(emptyGrid);

        while (moves.Clicks == 0)
        {
          moves.ReAttemptClicks();
        }

        Console.WriteLine(Convert.ToString(moves.Clicks));

        // remove puzzle from input when an answer is reached
        inputList.RemoveRange(0, 3);
      }
    }
  }
}
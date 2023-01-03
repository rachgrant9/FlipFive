using System;
using System.Collections.Generic;
using static FlipFive.Utilities;

namespace FlipFive
{
  public class MakeMove
  {
    public int Clicks;
    List<Char[,]> AttemptedPatterns;
    public string ExpectedOutput;
    const int XMax = 3;
    const int YMax = 3;

    public MakeMove(string expectedOutput)
    {
      Clicks = 0;
      AttemptedPatterns = new List<char[,]>();
      ExpectedOutput = expectedOutput;
    }

    public void ReAttemptClicks()
    {
      var newGrid = new Char[,] { { '.', '.', '.' }, { '.', '.', '.' }, { '.', '.', '.' } };
      var secondAttempts = new List<Char[,]>();
      foreach (var grid in AttemptedPatterns)
      {
        for (int x = 0; x < XMax; x++)
        {
          for (int y = 0; y < YMax; y++)
          {
            var outputGrid = ClickSquare(grid, newGrid, x, y);
            string gridString = CreateStringFromArray(outputGrid);
            secondAttempts.Add(outputGrid);
            if (gridString == ExpectedOutput)
            {
              Clicks++;
            }
          }
        }
      }
    }

    public void MakeFirstMove(Char[,] initialGrid)
    {
      for (int x = 0; x < XMax; x++)
      {
        for (int y = 0; y < YMax; y++)
        {
          var newGrid = new Char[,] { { '.', '.', '.' }, { '.', '.', '.' }, { '.', '.', '.' } };
          var outputGrid = ClickSquare(initialGrid, newGrid, x, y);
          string grid = CreateStringFromArray(outputGrid);
          AttemptedPatterns.Add(outputGrid);
          if (grid == ExpectedOutput)
          {
            Clicks++;
          }
        }
      }
    }

    public static Char[,] ClickSquare(Char[,] initialGrid, Char[,] newGrid, int sqrX, int sqrY)
    {
      // find square to click and change the colour
      var square = initialGrid[sqrX, sqrY];
      var newColour = InvertColour(square);

      newGrid[sqrX, sqrY] = newColour;

      // then change the neighbours as appropriate
      if (sqrX == 0 && sqrY == 0)
      {
        var newColourBelow = InvertColour(initialGrid[sqrX, sqrY + 1]);
        newGrid[sqrX, sqrY + 1] = newColourBelow;

        var newColourRight = InvertColour(initialGrid[sqrX + 1, sqrY]);
        newGrid[sqrX + 1, sqrY] = newColourRight;
      }
      else if (sqrX == 1 && sqrY == 0)
      {
        var newColourBelow = InvertColour(initialGrid[sqrX, sqrY + 1]);
        newGrid[sqrX, sqrY + 1] = newColourBelow;

        var newColourRight = InvertColour(initialGrid[sqrX + 1, sqrY]);
        newGrid[sqrX + 1, sqrY] = newColourRight;

        var newColourLeft = InvertColour(initialGrid[sqrX - 1, sqrY]);
        newGrid[sqrX - 1, sqrY] = newColourLeft;
      }
      else if (sqrX == 2 && sqrY == 0)
      {
        var newColourBelow = InvertColour(initialGrid[sqrX, sqrY + 1]);
        newGrid[sqrX, sqrY + 1] = newColourBelow;

        var newColourLeft = InvertColour(initialGrid[sqrX - 1, sqrY]);
        newGrid[sqrX - 1, sqrY] = newColourLeft;
      }
      else if (sqrX == 0 && sqrY == 1)
      {
        var newColourAbove = InvertColour(initialGrid[sqrX, sqrY - 1]);
        newGrid[sqrX, sqrY - 1] = newColourAbove;

        var newColourBelow = InvertColour(initialGrid[sqrX, sqrY + 1]);
        newGrid[sqrX, sqrY + 1] = newColourBelow;

        var newColourRight = InvertColour(initialGrid[sqrX + 1, sqrY]);
        newGrid[sqrX + 1, sqrY] = newColourRight;
      }
      else if (sqrX == 1 && sqrY == 1)
      {
        var newColourAbove = InvertColour(initialGrid[sqrX, sqrY - 1]);
        newGrid[sqrX, sqrY - 1] = newColourAbove;

        var newColourBelow = InvertColour(initialGrid[sqrX, sqrY + 1]);
        newGrid[sqrX, sqrY + 1] = newColourBelow;

        var newColourLeft = InvertColour(initialGrid[sqrX - 1, sqrY]);
        newGrid[sqrX - 1, sqrY] = newColourLeft;

        var newColourRight = InvertColour(initialGrid[sqrX + 1, sqrY]);
        newGrid[sqrX + 1, sqrY] = newColourRight;
      }
      else if (sqrX == 2 && sqrY == 1)
      {
        var newColourAbove = InvertColour(initialGrid[sqrX, sqrY - 1]);
        newGrid[sqrX, sqrY - 1] = newColourAbove;

        var newColourBelow = InvertColour(initialGrid[sqrX, sqrY + 1]);
        newGrid[sqrX, sqrY + 1] = newColourBelow;

        var newColourLeft = InvertColour(initialGrid[sqrX - 1, sqrY]);
        newGrid[sqrX - 1, sqrY] = newColourLeft;
      }
      else if (sqrX == 0 && sqrY == 2)
      {
        var newColourAbove = InvertColour(initialGrid[sqrX, sqrY - 1]);
        newGrid[sqrX, sqrY - 1] = newColourAbove;

        var newColourRight = InvertColour(initialGrid[sqrX + 1, sqrY]);
        newGrid[sqrX + 1, sqrY] = newColourRight;
      }
      else if (sqrX == 1 && sqrY == 2)
      {
        var newColourAbove = InvertColour(initialGrid[sqrX, sqrY - 1]);
        newGrid[sqrX, sqrY - 1] = newColourAbove;

        var newColourRight = InvertColour(initialGrid[sqrX + 1, sqrY]);
        newGrid[sqrX + 1, sqrY] = newColourRight;

        var newColourLeft = InvertColour(initialGrid[sqrX - 1, sqrY]);
        newGrid[sqrX - 1, sqrY] = newColourLeft;
      }
      else if (sqrX == 2 && sqrY == 2)
      {
        var newColourAbove = InvertColour(initialGrid[sqrX, sqrY - 1]);
        newGrid[sqrX, sqrY - 1] = newColourAbove;

        var newColourLeft = InvertColour(initialGrid[sqrX - 1, sqrY]);
        newGrid[sqrX - 1, sqrY] = newColourLeft;
      }
      return newGrid;
    }

    public static char InvertColour(char currentValue)
    {
      char newColour = '*';
      if (currentValue == '*')
      {
        newColour = '.';
      }

      return newColour;
    }


  }
}
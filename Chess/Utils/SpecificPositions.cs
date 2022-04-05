using Chess2Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Utils
{
  public class SpecificPositions
  {
    public string Color { get; set; }
    public List<Pawn> Positions { get; set; }
    public Board SpecificsBoard { get; set; }
    public int Weight { get; set; }

    public void GenerateSpecificsBoard()
    {
      SpecificsBoard = Chess2Utils.GenerateBoardFormPawnList(Positions);
    }
  }
}

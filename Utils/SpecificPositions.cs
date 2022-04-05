using Chess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
  public class SpecificPositions
  {
    public string Color { get; set; }
    public List<Pawn> Positions { get; set; }
    public int? Score { get; set; }
  }
}

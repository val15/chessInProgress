using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Utils
{
  public class ScoreResult
  {
    public int Value { get; set; }
    public int MakeCheckmateLevel { get; set; }
    public int Order { get; set; }
    public ScoreResult()
    {
      Order = 10;
    }
  }
}

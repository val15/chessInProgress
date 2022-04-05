using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2Console
{
   public class PossibleMove
  {
    public int Index { get; set; }
    public bool IsContainOpinion { get; set; } = false;
    public int FromIndex { get; set; }
   // public string FromName { get; set; }

  }
}

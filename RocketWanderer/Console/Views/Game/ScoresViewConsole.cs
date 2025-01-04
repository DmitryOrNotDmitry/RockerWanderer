using Logic.Models.Game;
using Logic.Views.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Views.Game
{
  public class ScoresViewConsole : ScoresView
  {
    public ScoresViewConsole(Scores parScores, Map parMap) 
      : base(parScores, parMap)
    {
    }
  }
}

using Logic.Models.Game;
using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Game
{
  public abstract class GameView : BaseView
  {
    /// <summary>
    /// Модель карты
    /// </summary>
    private Map _map;

    /// <summary>
    /// Модель карты
    /// </summary>
    public Map Map
    {
      get { return _map; }
      set { _map = value; }
    }

  }
}

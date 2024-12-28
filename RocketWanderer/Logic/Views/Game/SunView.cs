
using Logic.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Game
{
  /// <summary>
  /// Представление солнца
  /// </summary>
  public class SunView : GameView 
  {
    /// <summary>
    /// Модель солнца
    /// </summary>
    private Sun _sun;

    /// <summary>
    /// Модель солнца
    /// </summary>
    public Sun Sun
    {
      get { return _sun; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parSun">Модель солнца</param>
    public SunView(Sun parSun) 
    {
      _sun = parSun;
    }
    
  }
}

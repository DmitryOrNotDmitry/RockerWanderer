using Logic.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Game
{
  /// <summary>
  /// Представление ракеты
  /// </summary>
  public abstract class RocketView : GameView
  {
    /// <summary>
    /// Модель ракеты
    /// </summary>
    private Rocket _rocket;

    /// <summary>
    /// Модель ракеты
    /// </summary>
    public Rocket Rocket
    {
      get { return _rocket; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parRocket">Модель ракеты</param>
    public RocketView(Rocket parRocket)
    {
      _rocket = parRocket;
    }
  }
}

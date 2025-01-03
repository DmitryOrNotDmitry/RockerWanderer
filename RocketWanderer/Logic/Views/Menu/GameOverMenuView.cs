using Logic.Models.Game;
using Logic.Models.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Menus
{
  /// <summary>
  /// Представление меню конца игры
  /// </summary>
  public abstract class GameOverMenuView : MenuView
  {
    /// <summary>
    /// Модель очков игрока
    /// </summary>
    private readonly Scores _scores;

    /// <summary>
    /// Модель очков игрока
    /// </summary>
    public Scores Scores
    {
      get { return _scores; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenu">Модель меню</param>
    /// <param name="parScores">Модель очков игрока</param>
    public GameOverMenuView(Menu parMenu, Scores parScores)
      : base(parMenu)
    {
      _scores = parScores;
    }

  }
}

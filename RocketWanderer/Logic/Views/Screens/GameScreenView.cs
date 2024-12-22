using Logic.Models.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Screens
{
  /// <summary>
  /// Представление экрана игры
  /// </summary>
  public abstract class GameScreenView : BaseView
  {
    /// <summary>
    /// Модель экрана игры
    /// </summary>
    private GameScreen _gameScreen;

    /// <summary>
    /// Модель экрана игры
    /// </summary>
    public GameScreen GameScreen
    {
      get { return _gameScreen; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parGameScreen">Модель экрана игры</param>
    public GameScreenView(GameScreen parGameScreen) 
    {
      _gameScreen = parGameScreen;
    }
  }
}

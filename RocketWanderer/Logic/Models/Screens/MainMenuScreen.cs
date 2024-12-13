using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Screens
{
  /// <summary>
  /// Модель экрана главного меню
  /// </summary>
  public class MainMenuScreen
  {
    /// <summary>
    /// Название игры
    /// </summary>
    private string _gameTitle;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parGameTitle">Название игры</param>
    public MainMenuScreen(string parGameTitle) 
    {
      _gameTitle = parGameTitle;
    }

  }
}

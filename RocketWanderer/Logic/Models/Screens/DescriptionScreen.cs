using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Screens
{
  /// <summary>
  /// Модель экрана описания
  /// </summary>
  public class DescriptionScreen
  {
    /// <summary>
    /// Описнаие игры
    /// </summary>
    private string _gameDescription;

    /// <summary>
    /// Описнаие игры
    /// </summary>
    public string GameDescription
    {
      get { return _gameDescription; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parGameDescription">Описание игры</param>
    public DescriptionScreen(string parGameDescription)
    {
      _gameDescription = parGameDescription;
    }
  }
}

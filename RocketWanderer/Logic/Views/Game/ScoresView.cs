using Logic.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Game
{
  /// <summary>
  /// Представление для очков игрока
  /// </summary>
  public class ScoresView : BaseView
  {
    /// <summary>
    /// Модель очков игрока
    /// </summary>
    private Scores _scores;

    /// <summary>
    /// Модель карты
    /// </summary>
    private Map _map;

    /// <summary>
    /// Модель очков игрока
    /// </summary>
    public Scores Scores 
    { 
      get { return _scores; }
    }

    /// <summary>
    /// Модель карты
    /// </summary>
    public Map Map
    {
      get { return _map; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parScores">Модель очков игрока</param>
    /// <param name="parMap">Модель карты</param>
    public ScoresView(Scores parScores, Map parMap)
    {
      _scores = parScores;
      _map = parMap;
    }
  }
}

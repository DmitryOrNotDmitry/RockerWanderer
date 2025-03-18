using ConsoleApp.App;
using Logic.Models.Game;
using Logic.Utils;
using Logic.Views.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp.Views.Game
{
  /// <summary>
  /// Представление табла очков от Console
  /// </summary>
  public class ScoresViewConsole : ScoresView
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parScores">Модель очков игрока</param>
    /// <param name="parMap">Модель карты</param>
    public ScoresViewConsole(Scores parScores, Map parMap) 
      : base(parScores, parMap)
    {
    }

    /// <summary>
    /// Отрисовывает очки игрока
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      string scoreLabel = "Очки: " + Scores.Current;

      ConsoleAdapter console = ConsoleAdapter.Instance;

      Vector2 parentSize = Parent.AbsoluteSize;

      double scaleY = parentSize.Y / Map.Size.Y;

      int y = (int)Math.Ceiling((Map.Size.Y - Map.BottomAsteroidBelt.Size.Y) * scaleY) - 1;
      int x = 2;

      console.WriteBuffer(x, y, scoreLabel);
    }
  }
}

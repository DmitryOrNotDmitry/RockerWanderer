using Logic.Models.Game;
using Logic.Utils;
using Logic.Views.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp.Views.Game
{
  /// <summary>
  /// Представление очков игрока от Wpf
  /// </summary>
  public class ScoresViewWpf : ScoresView, IWpfItem
  {
    /// <summary>
    /// Метка для отображения очков
    /// </summary>
    private Label _scoresLabel = new Label();

    /// <summary>
    /// Метка для отображения очков
    /// </summary>
    public UIElement Control
    {
      get { return _scoresLabel; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parScores">Модель очков игрока</param>
    /// <param name="parMap">Модель карты</param>
    public ScoresViewWpf(Scores parScores, Map parMap)
      : base(parScores, parMap)
    {
      _scoresLabel.Foreground = Brushes.White;
    }

    /// <summary>
    /// Отрисовывает солнце
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      _scoresLabel.Content = "Очки: " + Scores.Current;
      _scoresLabel.FontSize = Math.Max(1, AbsoluteSize.Y / 25);

      Vector2 parentSize = Parent.AbsoluteSize;

      double scale = parentSize.Y / Map.Size.Y;

      Canvas.SetBottom(_scoresLabel, Map.BottomAsteroidBelt.Size.Y * scale);
    }

  }
}

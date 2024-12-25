using Logic.Models.Screens;
using Logic.Utils;
using Logic.Views.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp.Views.Screens
{
  /// <summary>
  /// Представление экрана игры
  /// </summary>
  public class GameScreenViewWpf : GameScreenView, IWpfItem
  {
    /// <summary>
    /// Главный контролл представления
    /// </summary>
    private Canvas _canvasControl = new Canvas();

    /// <summary>
    /// Canvas, представляющий объект
    /// </summary>
    public UIElement Control
    {
      get { return _canvasControl; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parGameScreen">Модель экрана игры</param>
    public GameScreenViewWpf(GameScreen parGameScreen)
      : base(parGameScreen)
    {
      Size = new UDim2(1, 1);
    }

    /// <summary>
    /// Отрисовывает экран игры
    /// </summary>
    /// <param name="parParentSize">Размер родителя</param>
    public override void Draw(Vector2 parParentSize)
    {
      DrawChildren(AbsoluteSize(parParentSize));
    }
  }
}

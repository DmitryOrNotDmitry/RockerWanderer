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
using System.Windows.Markup;

namespace WpfApp.Views.Screens
{
  /// <summary>
  /// Представление экрана главного меню от WPF
  /// </summary>
  public class MainMenuScreenViewWpf : MainMenuScreenView, IWpfItem
  {

    /// <summary>
    /// Главный контролл представления
    /// </summary>
    private Canvas _canvasControl = new Canvas();

    /// <summary>
    /// Элемент отображения названия игры
    /// </summary>
    private TextBlock _gameTitleControl = new TextBlock();

    public UIElement Control
    {
      get { return _canvasControl; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMainMenuScreen">Модель экрана главного меню</param>
    public MainMenuScreenViewWpf(MainMenuScreen parMainMenuScreen)
      : base(parMainMenuScreen)
    {
      Size = new UDim2(1, 1);

      _gameTitleControl.Text = MainMenuScreen.GameTitle;
      _gameTitleControl.FontSize = 60;

      _canvasControl.Children.Add(_gameTitleControl);
    }

    /// <summary>
    /// Отрисовывает экран главного меню
    /// </summary>
    /// <param name="parParentSize">Размер родителя</param>
    public override void Draw(Vector2 parParentSize)
    {
      _gameTitleControl.FontSize = parParentSize.Y * 0.06;

      Canvas.SetLeft(_gameTitleControl, parParentSize.X / 2 - parParentSize.X * 0.25);
      Canvas.SetTop(_gameTitleControl, parParentSize.Y * 0.22);
      
      DrawChildren(AbsoluteSize(parParentSize));
    }
  }
}

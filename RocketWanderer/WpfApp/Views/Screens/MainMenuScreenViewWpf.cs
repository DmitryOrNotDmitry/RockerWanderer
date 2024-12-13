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
  /// Представление экрана главного меню от WPF
  /// </summary>
  public class MainMenuScreenViewWpf : MainMenuScreenView, IWpfItem
  {

    /// <summary>
    /// Главный контролл представления
    /// </summary>
    private Canvas _canvasControl = new Canvas();

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
    }

    public override void Draw(Vector2 parParentSize)
    {
      DrawChildren(AbsoluteSize(parParentSize));
    }
  }
}

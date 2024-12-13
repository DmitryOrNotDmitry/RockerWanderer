using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Logic.Models.Menus;
using Logic.Models.Windows;
using Logic.Utils;
using Logic.Views.Menus;
using WpfApp.Views.Windows;

namespace WpfApp.Views.Menus
{
  /// <summary>
  /// Представление меню
  /// </summary>
  public class MenuViewWpf : MenuView, IWpfItem
  {    
    /// <summary>
    /// Контейнер для пунктов меню
    /// </summary>
    private System.Windows.Controls.StackPanel _stackPanel = null;

    /// <summary>
    /// Размер элемента _stackPanel
    /// </summary>
    private UDim2 _stackPanelSize;

    /// <summary>
    /// Калькулятор координат для элементов меню
    /// </summary>
    private static CoordsCalculator _coordsCalculator = CoordsCalculator.Instance;

    /// <summary>
    /// Элемент WPF, представляющий данный объект
    /// </summary>
    public UIElement Control
    {
      get { return _stackPanel; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parSubMenuItem"></param>
    public MenuViewWpf(Menu parSubMenuItem, WindowViewWpf parAppWindowView) : base(parSubMenuItem)
    {
      _stackPanelSize = new UDim2(0.3, 0.35);

      _stackPanel = new System.Windows.Controls.StackPanel();
      _stackPanel.VerticalAlignment = VerticalAlignment.Center;
      _stackPanel.HorizontalAlignment = HorizontalAlignment.Center;

      ((IWpfItem)parAppWindowView).AddChild(this);

      parAppWindowView.Window.ScreenChanged += (ScreenType parNewScreen) =>
      {
        if (parNewScreen == ScreenType.MainMenu)
        {
          ((IWpfItem)parAppWindowView).RemoveChildren();
          ((IWpfItem)parAppWindowView).AddChild(this);
        }

        if (parNewScreen == ScreenType.Description)
        {
          // Окно для описания
        }

        if (parNewScreen == ScreenType.Records)
        {
          // Окно для ...
        }

        if (parNewScreen == ScreenType.Game)
        {
          // Окно для ...
        }
      };

      foreach (IWpfItem elViewMenuItem in Items)
      {
        ((IWpfItem)this).AddChild(elViewMenuItem);
      }

      Draw();
    }

    /// <summary>
    /// Отрисовывает меню
    /// </summary>
    public override void Draw()
    {
      Vector2 windowSize = _coordsCalculator.Сalculate(_stackPanelSize);
      _stackPanel.Width = windowSize.X;
      _stackPanel.Height = windowSize.Y;

      foreach (MenuItemView elViewMenuItem in Items)
      {
        elViewMenuItem.Draw();
      }
    }

    /// <summary>
    /// Создает представление пункта меню для WPF
    /// </summary>
    /// <param name="parMenuItem">Модель пункта меню</param>
    /// <returns>Представление пункта меню</returns>
    public override MenuItemView CreateMenuItemView(MenuItem parMenuItem)
    {
      return new MenuItemViewWpf(parMenuItem);
    }
  }
}

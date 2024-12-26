using Logic.Models.Menus;
using Logic.Models.Windows;
using Logic.Utils;
using Logic.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfApp.Views.Menus;
using WpfApp.Views.Windows;

namespace WpfApp.Views.Screens
{
  /// <summary>
  /// Представление кнопки "Назад"
  /// </summary>
  public class BackButtonView : MenuItemViewWpf
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    public BackButtonView(WindowData parWindowData)
      : base(new MenuItem(MenuItemAction.Back, "Назад"))
    {
      Size = new UDim2(0.16, 0.09);

      _button.FontSize = 40;

      Enter += (action) =>
      {
        Item.State = MenuItemState.Selected;
      };

      Focused += (action) =>
      {
        Item.State = MenuItemState.Focused;
      };

      Item.Selected += () =>
      {
        Item.State = MenuItemState.Normal;
        parWindowData.ChangeScreen(ScreenType.MainMenu);
      };
    }

    /// <summary>
    /// Отрисовывает кнопку "Назад"
    /// </summary>
    public override void Draw()
    {
      base.Draw();
      
      Vector2 parentSize = Parent.AbsoluteSize;

      _button.FontSize = parentSize.Y * 0.04;
    }

  }
}

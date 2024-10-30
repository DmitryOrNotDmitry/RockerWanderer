using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Logic.Models.Menu;
using Logic.Views.Menus;

namespace WpfApp.Views
{
  public class MenuViewWpf : MenuView, IMenu
  {
    private Window _window = null;
    public MenuViewWpf(Menu parSubMenuItem) : base(parSubMenuItem)
    {
      Draw();
    }
    public void Init()
    {
      _window = new Window();
      _window.ShowActivated = true;
      _window.WindowState = WindowState.Maximized;

      System.Windows.Controls.StackPanel stackPanel = new System.Windows.Controls.StackPanel();
      stackPanel.VerticalAlignment = VerticalAlignment.Center;
      stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
      _window.Content = stackPanel;

      SetParentControl(stackPanel);
      Draw();

      _window.Show();
    }
    public void Close()
    {
      _window.Close();
    }
    public override void Draw()
    {
      foreach (MenuItemView elViewMenuItem in Items)
      {
        elViewMenuItem.Draw();
      }
    }

    public void SetParentControl(FrameworkElement parControl)
    {
      foreach (MenuItemView elViewMenuItem in Items)
      {
        ((IMenu)elViewMenuItem).SetParentControl(parControl);
      }
    }

    public override MenuItemView CreateMenuItemView(MenuItem parMenuItem)
    {
      return new MenuItemViewWpf(parMenuItem);
    }
  }
}

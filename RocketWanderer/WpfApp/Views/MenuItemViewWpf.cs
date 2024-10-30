using Logic.Models.Menu;
using Logic.Views.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WpfApp.Views
{
  public class MenuItemViewWpf : MenuItemView, IMenu
  {

    public delegate void dEnter(MenuItemAction parAction);
    public event dEnter Enter = null;
    private FrameworkElement _parentControl = null;
    System.Windows.Controls.Button _button = null;
    Brush _brush = null;

    public MenuItemViewWpf(MenuItem parMenuItem) : base(parMenuItem)
    {
      _button = new System.Windows.Controls.Button();
      _button.Content = parMenuItem.Title;
      _button.Click += (s, e) => { Enter?.Invoke(this.Item.Action); };
    }

    private void ParItem_Selected()
    {
      _button.Focus();
      Draw();
    }
    
    public override void Draw()
    {
      //_button.Margin = new Thickness(X, Y, 0, 0);
      if (this.Item.State == MenuItemState.Focused || this.Item.State == MenuItemState.Selected)
        _button.Background = Brushes.Magenta;
      else
        _button.Background = _brush;
    }

    public void SetParentControl(FrameworkElement parControl)
    {
      if (_parentControl == null)
      {
        _parentControl = parControl;
        ((IAddChild)_parentControl).AddChild(_button);
      }
    }
  }
}

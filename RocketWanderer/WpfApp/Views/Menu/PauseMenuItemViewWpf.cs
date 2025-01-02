using Logic.Models.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfApp.Views.Menus;

namespace WpfApp.Views.Menus
{
  /// <summary>
  /// Представление пункта меню для паузы от WPf
  /// </summary>
  public class PauseMenuItemViewWpf : MenuItemViewWpf
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenuItem">Модель пункта меню</param>
    public PauseMenuItemViewWpf(MenuItem parMenuItem) 
      : base(parMenuItem)
    {
      _button.Foreground = Brushes.White;
    }
  }
}

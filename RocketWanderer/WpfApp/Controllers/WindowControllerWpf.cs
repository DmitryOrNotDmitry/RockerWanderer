using Logic.Controllers;
using Logic.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Views.Menus;
using WpfApp.Views.Windows;

namespace WpfApp.Controllers
{
  /// <summary>
  /// Контроллер окна для Wpf
  /// </summary>
  public class WindowControllerWpf : WindowController
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    public WindowControllerWpf() 
    {
    }

    /// <summary>
    /// Создает представление окна от Wpf
    /// </summary>
    /// <returns>Представление окна</returns>
    protected override WindowView CreateWindowView()
    {
      return new WindowViewWpf(Window);
    }
  }
}

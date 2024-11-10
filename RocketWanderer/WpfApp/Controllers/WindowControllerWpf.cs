using Logic.Controllers;
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
    /// Представленик окна
    /// </summary>
    private WindowViewWpf _windowView;

    /// <summary>
    /// Представленик окна
    /// </summary>
    public WindowViewWpf WindowView 
    { 
      get { return _windowView; } 
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public WindowControllerWpf() 
    {
      _windowView = new WindowViewWpf(Window);
    }
  }
}

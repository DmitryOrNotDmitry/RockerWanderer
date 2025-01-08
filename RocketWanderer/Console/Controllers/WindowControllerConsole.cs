using ConsoleApp.Views.Windows;
using Logic.Controllers;
using Logic.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Controllers
{
  /// <summary>
  /// Контроллер окна от Console
  /// </summary>
  public class WindowControllerConsole : WindowController
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    public WindowControllerConsole()
    {
    }

    /// <summary>
    /// Создает представление окна от Console
    /// </summary>
    /// <returns>Представление окна</returns>
    protected override WindowView CreateWindowView()
    {
      return new WindowViewConsole(Window);
    }
  }
}

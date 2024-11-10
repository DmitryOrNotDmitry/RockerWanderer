using Logic.Models.Menus;
using Logic.Models.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Controllers
{
  /// <summary>
  /// Контроллер окна
  /// </summary>
  public class WindowController : BaseController
  {
    /// <summary>
    /// Модель окна
    /// </summary>
    private WindowData _window;

    /// <summary>
    /// Модель окна
    /// </summary>
    public WindowData Window 
    { 
      get { return _window; } 
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public WindowController()
    {
      _window = new WindowData();
    }
  }
}

using Logic.Models.Menus;
using Logic.Models.Windows;
using Logic.Utils;
using Logic.Views.Windows;
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
  public abstract class WindowController : BaseController
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
    /// Представленик окна
    /// </summary>
    private WindowView _windowView;

    /// <summary>
    /// Представленик окна
    /// </summary>
    public WindowView WindowView
    {
      get { return _windowView; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public WindowController()
    {
      _window = new WindowData();
      _windowView = CreateWindowView();
    }

    /// <summary>
    /// Создает представление окна
    /// </summary>
    /// <returns>Представление окна</returns>
    protected abstract WindowView CreateWindowView();
  }
}

using Logic.Models.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Windows
{
  /// <summary>
  /// Представление окна
  /// </summary>
  public class WindowView
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
    /// <param name="parWindow">Модель окна</param>
    public WindowView(WindowData parWindow) 
    { 
      _window = parWindow;
    }
  }
}

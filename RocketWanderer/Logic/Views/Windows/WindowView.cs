using Logic.Models.Windows;
using Logic.Utils;
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
  public abstract class WindowView : BaseView
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
    /// Возвращает абсолютный размер окна
    /// </summary>
    /// <returns>Абсолютный размер</returns>
    public Vector2 AbsSize()
    {
      return new Vector2(Window.Width, Window.Height);
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parWindow">Модель окна</param>
    public WindowView(WindowData parWindow) 
    { 
      _window = parWindow;
    }

    /// <summary>
    /// Закрывает окно
    /// </summary>
    public abstract void Close();

  }
}

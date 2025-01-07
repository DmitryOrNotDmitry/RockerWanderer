using ConsoleApp.App;
using Logic.Models.Windows;
using Logic.Utils;
using Logic.Views.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Views.Windows
{
  /// <summary>
  /// Представление главного окна игры от Console
  /// </summary>
  public class WindowViewConsole : WindowView
  {
    /// <summary>
    /// Адаптер для консоли
    /// </summary>
    private ConsoleAdapter _console;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parWindow">Модель окна приложения</param>
    public WindowViewConsole(WindowData parWindow) 
      : base(parWindow)
    {
      Console.CursorVisible = false;
      
      Console.SetWindowSize(120, 30);
      try
      {
        Console.SetBufferSize(120, 30);
      }
      catch (Exception) { }

      _console = ConsoleAdapter.Instance;
      _prevWidth = _console.Width;
      _prevHeight = _console.Height;

      parWindow.ScreenChanged += (parNewScreen) =>
      {
        _console.Clear();
        _console.ClearBuffer();
        Redrawer.NeedRedraw = true;
      };
    }

    /// <summary>
    /// Закрывает окно
    /// </summary>
    public override void Close()
    {
      Environment.Exit(0);
    }

    /// <summary>
    /// Предыдущая ширина консоли
    /// </summary>
    private int _prevWidth;

    /// <summary>
    /// Предыдущая высолта консоли
    /// </summary>
    private int _prevHeight;

    /// <summary>
    /// Отрисовывает окно
    /// </summary>
    public override void Draw()
    {
      if (_prevWidth != _console.Width || _prevHeight != _console.Height)
      {
        _prevWidth = _console.Width;
        _prevHeight = _console.Height;
        _console.Clear();
      }

      Window.Width = _console.Width;
      Window.Height = _console.Height;

      AbsoluteSize = AbsSize();

      DrawChildren();

      _console.DropBuffer();
    }
  }
}

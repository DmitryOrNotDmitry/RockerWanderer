using ConsoleApp.App;
using Logic.Models.Windows;
using Logic.Views.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Views.Windows
{
  public class WindowViewConsole : WindowView
  {
    public WindowViewConsole(WindowData parWindow) 
      : base(parWindow)
    {
      Console.CursorVisible = false;
      Console.SetWindowSize(120, 30);

      ConsoleAdapter console = ConsoleAdapter.Instance;
      parWindow.ScreenChanged += (parNewScreen) =>
      {
        console.Clear();
        console.ClearBuffer();
      };
    }

    /// <summary>
    /// Закрывает окно
    /// </summary>
    public override void Close()
    {
      Environment.Exit(0);
    }

    private int _prevWidth = Console.BufferWidth;
    private int _prevHeight = Console.BufferHeight;

    /// <summary>
    /// Отрисовывает окно
    /// </summary>
    public override void Draw()
    {
      ConsoleAdapter console = ConsoleAdapter.Instance;

      if (_prevWidth != Console.BufferWidth || _prevHeight != Console.BufferHeight)
      {
        _prevWidth = Console.BufferWidth;
        _prevHeight = Console.BufferHeight;
        console.Clear();
      }

      Window.Width = Console.BufferWidth;
      Window.Height = Console.BufferHeight;

      AbsoluteSize = AbsSize();

      DrawChildren();
    }
  }
}

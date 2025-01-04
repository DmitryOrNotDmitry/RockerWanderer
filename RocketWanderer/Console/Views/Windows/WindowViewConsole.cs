﻿using Logic.Models.Windows;
using Logic.Views.Windows;
using System;
using System.Collections.Generic;
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
    }

    /// <summary>
    /// Закрывает окно
    /// </summary>
    public override void Close()
    {
      Environment.Exit(0);
    }

    /// <summary>
    /// Отрисовывает окно
    /// </summary>
    public override void Draw()
    {
      Console.Clear();

      Window.Width = Console.BufferWidth;
      Window.Height = Console.BufferHeight;

      AbsoluteSize = AbsSize();

      DrawChildren();
    }
  }
}

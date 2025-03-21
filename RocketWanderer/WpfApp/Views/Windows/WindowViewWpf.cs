﻿using Logic.Models.Menus;
using Logic.Models.Windows;
using Logic.Utils;
using Logic.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using WpfApp.Views.Menus;

namespace WpfApp.Views.Windows
{
  /// <summary>
  /// Представление окна для Wpf
  /// </summary>
  public class WindowViewWpf : WindowView, IWpfItem
  {
    /// <summary>
    /// Окно Wpf
    /// </summary>
    private Window _windowControl = null;
    
    /// <summary>
    /// Элемент WPF, представляющий данный объект
    /// </summary>
    public UIElement Control
    {
      get { return _windowControl; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parWindow">Модель окна</param>
    public WindowViewWpf(WindowData parWindow) 
      : base(parWindow)
    {
      _windowControl = new Window();
      _windowControl.ShowActivated = true;
      _windowControl.WindowState = WindowState.Maximized;

      _windowControl.Show();
     
      Window.Width = (int)_windowControl.Width;
      Window.Height = (int)_windowControl.Height;
    }

    /// <summary>
    /// Отрисовывает окно
    /// </summary>
    public override void Draw()
    {
      _windowControl.Dispatcher.Invoke(() =>
      {
        double clientWidth = _windowControl.ActualWidth;
        double clientHeight = _windowControl.ActualHeight - SystemParameters.CaptionHeight * 1.75;

        Window.Width = (int)clientWidth;
        Window.Height = (int)clientHeight;

        AbsoluteSize = AbsSize();

        DrawChildren();
      });
    }

    /// <summary>
    /// Закрывает окно
    /// </summary>
    public override void Close()
    {
      _windowControl.Close();
    }
  }
}

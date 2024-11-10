using Logic.Models.Menus;
using Logic.Models.Windows;
using Logic.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    /// <param name="parMenuViewWpf">Представление меню</param>
    public WindowViewWpf(WindowData parWindow) 
      : base(parWindow)
    {
      _windowControl = new Window();
      _windowControl.ShowActivated = true;
      _windowControl.WindowState = WindowState.Maximized;

      _windowControl.Show();
    }

    /// <summary>
    /// Закрывает окно
    /// </summary>
    public void Close()
    {
      _windowControl.Close();
    }
  }
}

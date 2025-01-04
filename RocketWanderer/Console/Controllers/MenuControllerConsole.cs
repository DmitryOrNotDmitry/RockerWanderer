using ConsoleApp.Views.Menu;
using Logic.Controllers;
using Logic.Views.Menus;
using Logic.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Controllers
{
  /// <summary>
  /// Контроллер главного меню от Console
  /// </summary>
  public class MenuControllerConsole : MenuController
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parWindowView">Представление окна</param>
    public MenuControllerConsole(WindowView parWindowView) 
      : base(parWindowView)
    {
    }

    /// <summary>
    /// Создает представление меню от Console
    /// </summary>
    /// <returns>Представление меню от Console</returns>
    public override MenuView CreateMenuView()
    {
      return new MenuViewConsole(Menu);
    }
  }
}

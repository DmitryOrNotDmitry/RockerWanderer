using ConsoleApp.Views.Menu;
using Logic.Controllers;
using Logic.Models.Menus;
using Logic.Models.Windows;
using Logic.Views.Menus;
using Logic.Views.Screens;
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
    private WindowData _window;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parWindowView">Представление окна</param>
    public MenuControllerConsole(WindowView parWindowView, MainMenuScreenView parMainMenuScreen) 
      : base(parWindowView)
    {
      _window = parWindowView.Window;

      parMainMenuScreen.AddChild(MenuView);
    }

    /// <summary>
    /// Создает представление меню от Console
    /// </summary>
    /// <returns>Представление меню от Console</returns>
    public override MenuView CreateMenuView()
    {
      return new MenuViewConsole(Menu);
    }

    /// <summary>
    /// Обработчик события на нажатие клавиши "Вверх"
    /// </summary>
    public void OnArrowUp()
    {
      if (_window.CurrentScreen == ScreenType.MainMenu)
      {
        Menu.FocusPrev();
      }
    }

    /// <summary>
    /// Обработчик события на нажатие клавиши "Вниз"
    /// </summary>
    public void OnArrowDown()
    {
      if (_window.CurrentScreen == ScreenType.MainMenu)
      {
        Menu.FocusNext();
      }
    }

    /// <summary>
    /// Обработчик события на нажатие клавиши "Enter"
    /// </summary>
    public void OnEnter()
    {
      if (_window.CurrentScreen == ScreenType.MainMenu)
      {
        Menu.SelectFocusedItem();
        Menu.Focus(MenuItemAction.NewGame);
      }
    }
  }
}

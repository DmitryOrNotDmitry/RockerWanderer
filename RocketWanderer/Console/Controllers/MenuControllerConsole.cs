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
    private bool _needExit = false;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parWindowView">Представление окна</param>
    public MenuControllerConsole(WindowView parWindowView, MainMenuScreenView parMainMenuScreen) 
      : base(parWindowView)
    {
      parMainMenuScreen.AddChild(MenuView);

      Menu[MenuItemAction.Exit].Selected += () => { _needExit = true; };

      Task.Run(() =>
      {
        while (!_needExit)
        {
          if (parWindowView.Window.CurrentScreen == ScreenType.MainMenu)
          {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
              case ConsoleKey.UpArrow:
                Menu.FocusPrev();
                break;
              case ConsoleKey.DownArrow:
                Menu.FocusNext();
                break;
              case ConsoleKey.Enter:
                Menu.SelectFocusedItem();
                Menu.Focus(MenuItemAction.NewGame);
                break;
            }
          }
        }
      });
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

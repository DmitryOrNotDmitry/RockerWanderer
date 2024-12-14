﻿ using Logic.Controllers;
using Logic.Models.Menus;
using Logic.Models.Windows;
using Logic.Views.Menus;
using Logic.Views.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Views;
using WpfApp.Views.Menus;
using WpfApp.Views.Windows;

namespace WpfApp.Controllers
{
  /// <summary>
  /// Контроллер главного меню для WPF
  /// </summary>
  public class MenuControllerWpf : MenuController
  {
    /// <summary>
    /// Представление меню для WPF
    /// </summary>
    private MenuViewWpf _menuView;

    /// <summary>
    /// Представление меню для WPF
    /// </summary>
    public MenuViewWpf MenuView
    {
      get { return _menuView; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public MenuControllerWpf(WindowViewWpf parAppWindowView, MainMenuScreenView parMainMenuScreen)
    {
      _menuView = new MenuViewWpf(Menu);

      parMainMenuScreen.AddChild(_menuView);

      ((IWpfItem)parMainMenuScreen).AddChild(_menuView);

      Menu[MenuItemAction.NewGame].Selected += () => { parAppWindowView.Window.ChangeScreen(ScreenType.Game); };
      Menu[MenuItemAction.Records].Selected += () => { parAppWindowView.Window.ChangeScreen(ScreenType.Records); };
      Menu[MenuItemAction.Description].Selected += () => { parAppWindowView.Window.ChangeScreen(ScreenType.Description); };

      Menu[MenuItemAction.Exit].Selected += () => { parAppWindowView.Close(); };      

      foreach (MenuItem elMenuItem in Menu.Items)
      {
        ((MenuItemViewWpf)_menuView[elMenuItem.Action]).Enter += (action) =>
        {
          Menu.Focus(action);
          Menu.SelectFocusedItem();
          parAppWindowView.Draw(null);
        };


        ((MenuItemViewWpf)_menuView[elMenuItem.Action]).Focused += (action) =>
        {
          Menu.Focus(action);
          parAppWindowView.Draw(null);
        };

        ((MenuItemViewWpf)_menuView[elMenuItem.Action]).MoveEnter += (action) =>
        {
          Menu.Focus(action);
          parAppWindowView.Draw(null);
        };
      }
    }

  }
}

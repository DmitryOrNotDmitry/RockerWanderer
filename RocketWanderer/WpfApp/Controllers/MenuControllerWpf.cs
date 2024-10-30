using Logic.Controllers;
using Logic.Models.Menu;
using Logic.Views.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Views;

namespace WpfApp.Controllers
{
  public class MenuControllerWpf : MenuController
  {
    private MenuViewWpf _menuView;

    public MenuControllerWpf()
    {
      Menu = new Menu();

      Menu.AddItem(new MenuItem(MenuItemAction.NewGame, "Новая игра"));
      Menu.AddItem(new MenuItem(MenuItemAction.Records, "Рекорды"));
      Menu.AddItem(new MenuItem(MenuItemAction.Exit, "Выход"));

      _menuView = new MenuViewWpf(Menu);

      Menu[MenuItemAction.Exit].Selected += () => { _menuView.Close(); };
      _menuView.Init();

      foreach (MenuItem elMenuItem in Menu.Items)
      {
        ((MenuItemViewWpf)_menuView[elMenuItem.Action]).Enter += (id) => { Menu.Focus(elMenuItem.Action); };
      }
    }
    public override void Start()
    {
      throw new NotImplementedException();
    }
  }
}

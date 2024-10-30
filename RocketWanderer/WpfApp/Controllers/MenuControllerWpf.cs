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
      _menuView = new MenuViewWpf(Menu);

      //Menu[(int)Model.Menu.MenuMain.MenuItemCodes.Exit].Selected += () => { _viewMenu.Close(); };
      _menuView.Init();

      //foreach (Model.Menu.MenuItem elMenuItem in Menu.Items)
      //{
      //  ((ViewWPF.MenuGraphics.ViewMenuItemWPF)_viewMenu[elMenuItem.ID]).Enter += (id) => { Menu.FocusItemById(id); Menu.SelectFocusedItem(); };
      //}
    }
    public override void Start()
    {
      throw new NotImplementedException();
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Controllers
{
  public abstract class MenuController : BaseController
  {
    private Models.Menu.Menu _menu;

    protected Models.Menu.Menu Menu
    {
      get { return _menu; }
      set { _menu = value; }
    }
  }
}

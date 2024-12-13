using Logic.Models.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Controllers
{
  /// <summary>
  /// Контроллер для экранов
  /// </summary>
  public class ScreenController : BaseController
  {
    /// <summary>
    /// Экран главного меню
    /// </summary>
    private MainMenuScreen _mainMenuScreen;

    /// <summary>
    /// Экран главного меню
    /// </summary>
    public MainMenuScreen MainMenuScreen
    {
      get { return _mainMenuScreen; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public ScreenController()
    {
      _mainMenuScreen = new MainMenuScreen("RocketWanderer");
    }
  }
}

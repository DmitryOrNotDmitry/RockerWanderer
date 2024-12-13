using Logic.Controllers;
using Logic.Models.Windows;
using Logic.Views.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Views;
using WpfApp.Views.Screens;
using WpfApp.Views.Windows;

namespace WpfApp.Controllers
{
  /// <summary>
  /// Контроллер для экрана от WPF
  /// </summary>
  public class ScreenControllerWpf : ScreenController
  {
    /// <summary>
    /// Представление экрана главного меню
    /// </summary>
    private MainMenuScreenViewWpf _mainMenuScreenView;

    /// <summary>
    /// Представление экрана главного меню
    /// </summary>
    public MainMenuScreenViewWpf MainMenuScreenView
    {
      get { return _mainMenuScreenView; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public ScreenControllerWpf(WindowViewWpf parAppWindowView)
    {
      _mainMenuScreenView = new MainMenuScreenViewWpf(MainMenuScreen);

      parAppWindowView.AddChild(_mainMenuScreenView);

      ((IWpfItem)parAppWindowView).SetChild(_mainMenuScreenView);

      parAppWindowView.Window.ScreenChanged += (ScreenType parNewScreen) =>
      {
        if (parNewScreen == ScreenType.MainMenu)
        {
          ((IWpfItem)parAppWindowView).SetChild(_mainMenuScreenView);
          parAppWindowView.Draw(null);
        }

        //if (parNewScreen == ScreenType.Description)
        //{
        //  // Окно для описания
        //}

        //if (parNewScreen == ScreenType.Records)
        //{
        //  // Окно для ...
        //}

        //if (parNewScreen == ScreenType.Game)
        //{
        //  // Окно для ...
        //}
      };
    }
  }
}

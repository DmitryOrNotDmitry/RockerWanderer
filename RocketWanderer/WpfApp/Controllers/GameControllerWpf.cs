using Logic.Controllers;
using Logic.Models.Windows;
using Logic.Views.Game;
using Logic.Views.Screens;
using Logic.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Views;
using WpfApp.Views.Game;
using WpfApp.Views.Windows;

namespace WpfApp.Controllers
{
  /// <summary>
  /// Контроллер для процесса игры от Wpf
  /// </summary>
  public class GameControllerWpf : GameController
  {
    /// <summary>
    /// Контроллер
    /// </summary>
    /// <param name="parGameScreenView">Представление экрана игры</param>
    /// <param name="parWindowView">Модель окна приложения</param>
    public GameControllerWpf(GameScreenView parGameScreenView, WindowView parWindowView) 
      : base(parWindowView)
    {
      IWpfItem.AddChild(parGameScreenView, MapView);

      ((Window)(((WindowViewWpf)parWindowView).Control)).KeyDown += (s, e) =>
      {
        if (e.Key == Key.Space)
        {
          RocketDepartAction();
        }

        if (e.Key == Key.Escape)
        {
          OnPauseAction();
        }
      };

    }

    /// <summary>
    /// Создает представление карты
    /// </summary>
    /// <returns>Представление карты</returns>
    public override MapView CreateMapView()
    {
      return new MapViewWpf(Map);
    }
  }
}

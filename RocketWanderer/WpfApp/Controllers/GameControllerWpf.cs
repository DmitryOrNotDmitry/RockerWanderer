using Logic.Controllers;
using Logic.Models.Windows;
using Logic.Views.Game;
using Logic.Views.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Views;
using WpfApp.Views.Game;

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
    /// <param name="parWindowData">Модель окна приложения</param>
    public GameControllerWpf(GameScreenView parGameScreenView, WindowData parWindowData) 
      : base(parWindowData)
    {
      IWpfItem.AddChild(parGameScreenView, MapView);
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

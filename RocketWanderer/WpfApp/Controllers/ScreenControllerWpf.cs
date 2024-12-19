using Logic.Controllers;
using Logic.Models.Menus;
using Logic.Models.Windows;
using Logic.Utils;
using Logic.Views;
using Logic.Views.Menus;
using Logic.Views.Screens;
using Logic.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Views;
using WpfApp.Views.Menus;
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
    /// Представление окна приложения
    /// </summary>
    private WindowView _appWindowView;

    /// <summary>
    /// Конструктор
    /// </summary>
    public ScreenControllerWpf(WindowView parAppWindowView)
      : base(parAppWindowView.Window)
    {
      _appWindowView = parAppWindowView;
     
      IWpfItem.AddChild(parAppWindowView, MainMenuScreenView);
    }

    /// <summary>
    /// Сменяет экран приложения
    /// </summary>
    /// <param name="parNewScreenType">Новый тип экрана</param>
    /// <exception cref="ArgumentException">Выбрасывается при неправильном указании parNewScreenType</exception>
    public override void ChangeScreen(ScreenType parNewScreenType)
    {
      BaseView? newScreen = GetScreen(parNewScreenType);

      if (newScreen is null)
      {
        throw new ArgumentException("Переданного типа экрана еще не реализовано");
      }

      IWpfItem.AddChild(_appWindowView, newScreen);
    }

    /// <summary>
    /// Создает представление экрана описания от Wpf
    /// </summary>
    /// <returns>Представление экрана описания</returns>
    public override DescriptionScreenView CreateDescriptionScreenView(WindowData parWindowData)
    {
      return new DescriptionScreenViewWpf(DescriptionScreen, parWindowData);
    }

    /// <summary>
    /// Создает предстваление экрана главного меню от Wpf
    /// </summary>
    /// <returns>Предстваление экрана главного меню</returns>
    public override MainMenuScreenView CreateMainMenuScreenView()
    {
      return new MainMenuScreenViewWpf(MainMenuScreen);
    }

    /// <summary>
    /// Создает представление экрана рекордов от Wpf
    /// </summary>
    /// <returns>Представление экрана рекордов от Wpf</returns>
    public override RecordsScreenView CreateRecordsScreenView(WindowData parWindowData)
    {
      return new RecordsScreenViewWpf(RecordsScreen, parWindowData);
    }
  }
}

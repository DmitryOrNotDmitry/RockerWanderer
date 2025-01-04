using ConsoleApp.Views.Screens;
using Logic.Controllers;
using Logic.Models.Windows;
using Logic.Views.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Controllers
{
  /// <summary>
  /// Контроллер для экранов от Console
  /// </summary>
  public class ScreenControllerConsole : ScreenController
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parWindowData">Модель окна</param>
    public ScreenControllerConsole(WindowData parWindowData) 
      : base(parWindowData)
    {
    }

    /// <summary>
    /// Сменяет экран приложения
    /// </summary>
    /// <param name="parNewScreenType">Новый тип экрана</param>
    public override void ChangeScreen(ScreenType parNewScreenType)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Создает представление экрана описания от Console
    /// </summary>
    /// <param name="parWindowData">Модель окна</param>
    /// <returns>Представление экрана описания</returns>
    public override DescriptionScreenView CreateDescriptionScreenView(WindowData parWindowData)
    {
      return new DescriptionScreenViewConsole(DescriptionScreen);
    }

    /// <summary>
    /// Создает представление экрана игры от Console
    /// </summary>
    /// <returns>Представление экрана игры</returns>
    public override GameScreenView CreateGameScreenView()
    {
      return new GameScreenViewConsole(GameScreen);
    }

    /// <summary>
    /// Создает предстваление экрана главного меню от Console
    /// </summary>
    /// <returns>Предстваление экрана главного меню</returns>
    public override MainMenuScreenView CreateMainMenuScreenView()
    {
      return new MainMenuScreenViewConsole(MainMenuScreen);
    }

    /// <summary>
    /// Создает представление экрана рекордов от Console
    /// </summary>
    /// <param name="parWindowData">Модель окна</param>
    /// <returns>Представление экрана рекордов от Console</returns>
    public override RecordsScreenView CreateRecordsScreenView(WindowData parWindowData)
    {
      return new RecordsScreenViewConsole(RecordsScreen);
    }

  }
}

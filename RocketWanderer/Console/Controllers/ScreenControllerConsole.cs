using ConsoleApp.Views.Screens;
using Logic.Controllers;
using Logic.Models.Menus;
using Logic.Models.Windows;
using Logic.Utils;
using Logic.Views;
using Logic.Views.Screens;
using Logic.Views.Windows;
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
    private WindowView _appWindowView;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parWindowData">Модель окна</param>
    public ScreenControllerConsole(WindowView parWindowView) 
      : base(parWindowView.Window)
    {
      _appWindowView = parWindowView;
     
      ChangeScreen(ScreenType.MainMenu);
    }

    /// <summary>
    /// Сменяет экран приложения
    /// </summary>
    /// <param name="parNewScreenType">Новый тип экрана</param>
    public override void ChangeScreen(ScreenType parNewScreenType)
    {
      BaseView? newScreen = GetScreen(parNewScreenType);

      if (newScreen is null)
      {
        throw new ArgumentException("Переданного типа экрана еще не реализовано");
      }

      _appWindowView.RemoveChildren();
      _appWindowView.AddChild(newScreen);
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

    /// <summary>
    /// Обработчик события на нажатие клавиши "Backspace"
    /// </summary>
    public void OnBackspace()
    {
      ScreenType currentScreen = _appWindowView.Window.CurrentScreen;
      if (currentScreen == ScreenType.Description || currentScreen == ScreenType.Records)
      {
        _appWindowView.Window.ChangeScreen(ScreenType.MainMenu);
      }
    }

    /// <summary>
    /// Обработчик события на ввод ника
    /// </summary>
    public void OnNickEnter(ConsoleKeyInfo parKeyInfo)
    {
      if (_appWindowView.Window.CurrentScreen == ScreenType.MainMenu)
      {
        if (parKeyInfo.Key == ConsoleKey.Backspace)
        {
          string name = MainMenuScreenView.PlayerSettingsView.PlayerSettings.Name;

          if (name.Length > 0)
            MainMenuScreenView.PlayerSettingsView.PlayerSettings.Name = name.Substring(0, name.Length - 1);
        }

        if (char.IsAsciiLetterOrDigit(parKeyInfo.KeyChar))
        {
          string name = MainMenuScreenView.PlayerSettingsView.PlayerSettings.Name;

          MainMenuScreenView.PlayerSettingsView.PlayerSettings.Name = name + parKeyInfo.KeyChar;
        }
      }

      Redrawer.NeedRedraw = true;
    }

  }
}

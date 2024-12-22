using Logic.Models.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Screens
{
  /// <summary>
  /// Представление экрана главного меню
  /// </summary>
  public abstract class MainMenuScreenView : BaseView
  {
    /// <summary>
    /// Модель экрана главного меню
    /// </summary>
    private MainMenuScreen _mainMenuScreen;

    /// <summary>
    /// Представление настроек игрока
    /// </summary>
    private PlayerSettingsView _settingsView;
    
    /// <summary>
    /// Модель экрана главного меню
    /// </summary>
    public MainMenuScreen MainMenuScreen
    {
      get { return _mainMenuScreen; }
    }

    /// <summary>
    /// Представление настроек игрока
    /// </summary>
    public PlayerSettingsView PlayerSettingsView
    {
      get { return _settingsView; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMainMenuScreen">Модель экрана главного меню</param>
    public MainMenuScreenView(MainMenuScreen parMainMenuScreen)
    {
      _mainMenuScreen = parMainMenuScreen;

      _settingsView = CreatePlayerSettingsView();
    }

    /// <summary>
    /// Создает представление настроек игрока
    /// </summary>
    /// <returns>Представление настроек игрока</returns>
    public abstract PlayerSettingsView CreatePlayerSettingsView();
  }
}

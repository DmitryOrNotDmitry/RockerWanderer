using Logic.Views.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Screens
{
  /// <summary>
  /// Модель экрана главного меню
  /// </summary>
  public class MainMenuScreen
  {
    /// <summary>
    /// Название игры
    /// </summary>
    private string _gameTitle;

    /// <summary>
    /// Название игры
    /// </summary>
    public string GameTitle
    {
      get { return _gameTitle; }
    }

    /// <summary>
    /// Модель настроек игрока
    /// </summary>
    private PlayerSettings _playerSettings;

    /// <summary>
    /// Модель настроек игрока
    /// </summary>
    public PlayerSettings PlayerSettings
    {
      get { return _playerSettings; }
    }    

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parGameTitle">Название игры</param>
    public MainMenuScreen(string parGameTitle) 
    {
      _gameTitle = parGameTitle;

      _playerSettings = new PlayerSettings();
    }

  }
}

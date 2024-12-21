using Logic.Models.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Screens
{
  /// <summary>
  /// Представление для настроек игрока
  /// </summary>
  public abstract class PlayerSettingsView : BaseView
  {
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
    /// <param name="parPlayerSettings">Модель настроек игрока</param>
    public PlayerSettingsView(PlayerSettings parPlayerSettings)
    {
      _playerSettings = parPlayerSettings;
    }
  }
}

using Logic.Models.Screens;
using Logic.Views.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Views.Screens
{
  public class MainMenuScreenViewConsole : MainMenuScreenView
  {
    public MainMenuScreenViewConsole(MainMenuScreen parMainMenuScreen)
      : base(parMainMenuScreen)
    {
    }

    /// <summary>
    /// Создает предстваление настроек игрока от Console
    /// </summary>
    /// <returns>Предстваление настроек игрока от Console</returns>
    public override PlayerSettingsView CreatePlayerSettingsView()
    {
      return new PlayerSettingsViewConsole(MainMenuScreen.PlayerSettings);
    }
  }
}

using ConsoleApp.App;
using Logic.Models.Menus;
using Logic.Models.Screens;
using Logic.Utils;
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

    /// <summary>
    /// Отрисовывает главный экран
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      ConsoleAdapter console = ConsoleAdapter.Instance;
      
      Vector2 parentSize = Parent.AbsoluteSize;

      Vector2 position = parentSize.Scale(0.3);
      console.WriteBuffer(position, MainMenuScreen.GameTitle, ConsoleColor.White);

      DrawChildren();
    }
  }
}

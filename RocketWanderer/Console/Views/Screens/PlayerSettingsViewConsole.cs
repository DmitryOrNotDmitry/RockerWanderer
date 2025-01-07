using ConsoleApp.App;
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
  public class PlayerSettingsViewConsole : PlayerSettingsView
  {
    public PlayerSettingsViewConsole(PlayerSettings parPlayerSettings) 
      : base(parPlayerSettings)
    {
    }

    /// <summary>
    /// Отрисовывает поле для изменения настроек игрока
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      ConsoleAdapter console = ConsoleAdapter.Instance;
     
      Vector2 parentSize = Parent.AbsoluteSize;

      string nickLabel = "Ник: " + PlayerSettings.Name;

      double yOffset = -5;
      double xOffset = -nickLabel.Length / 2;
      Vector2 position = new Vector2(parentSize.X / 2 + xOffset, parentSize.Y / 2 + yOffset);
      
      console.WriteBuffer(0, (int)position.Y, new string(' ', console.Width));

      console.WriteBuffer((int)position.X, (int)position.Y, nickLabel);
    }
  }
}

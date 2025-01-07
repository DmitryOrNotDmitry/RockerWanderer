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
  /// <summary>
  /// Представление настроек игрока от Console
  /// </summary>
  public class PlayerSettingsViewConsole : PlayerSettingsView
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlayerSettings">Модель настроек игрока</param>
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

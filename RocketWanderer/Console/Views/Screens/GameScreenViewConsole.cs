using ConsoleApp.App;
using ConsoleApp.Views.Menu;
using Logic.Models.Screens;
using Logic.Views.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Views.Screens
{
  public class GameScreenViewConsole : GameScreenView
  {
    public GameScreenViewConsole(GameScreen parGameScreen) 
      : base(parGameScreen)
    {
    }

    /// <summary>
    /// Отрисовывает экран игры
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      ConsoleAdapter console = ConsoleAdapter.Instance;

      DrawChildren();

      console.DropBuffer();
    }
  }
}

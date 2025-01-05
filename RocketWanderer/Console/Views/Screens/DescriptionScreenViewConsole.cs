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
  public class DescriptionScreenViewConsole : DescriptionScreenView
  {
    public DescriptionScreenViewConsole(DescriptionScreen parDescriptionScreen) 
      : base(parDescriptionScreen)
    {
    }

    /// <summary>
    /// Отрисовывает элемент
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;

      ConsoleColor savColor = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.White;

      Console.CursorLeft = 1;
      Console.CursorTop = 1;
      Console.Write("Назад [Backspace]");

      Console.CursorLeft = (int)(parentSize.X * 0.3);
      Console.CursorTop = (int)(parentSize.Y * 0.3);
      Console.Write("Описание");

      Console.CursorLeft = (int)(parentSize.X * 0.1);
      Console.CursorTop = (int)(parentSize.Y * 0.3 + 2);
      Console.Write(DescriptionScreen.GameDescription);


      Console.ForegroundColor = savColor;

      DrawChildren();
    }
  }
}

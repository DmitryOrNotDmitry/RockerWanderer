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
  /// Представление экрана описания от Console
  /// </summary>
  public class DescriptionScreenViewConsole : DescriptionScreenView
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parDescriptionScreen">Модель экрана описания</param>
    public DescriptionScreenViewConsole(DescriptionScreen parDescriptionScreen) 
      : base(parDescriptionScreen)
    {
    }

    /// <summary>
    /// Отрисовывает экран описания
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;

      Vector2 position = new Vector2(1, 1);
      
      ConsoleAdapter console = ConsoleAdapter.Instance;

      console.WriteBuffer(position, "Назад [Backspace]", ConsoleColor.White);

      console.WriteBuffer(parentSize.Scale(0.3), "Описание", ConsoleColor.White);

      position = new Vector2(parentSize.X * 0.1, parentSize.Y * 0.3 + 2);

      console.WriteBuffer(position, DescriptionScreen.GameDescription, ConsoleColor.White);

      DrawChildren();
    }
  }
}

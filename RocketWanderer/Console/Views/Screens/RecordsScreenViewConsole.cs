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
  public class RecordsScreenViewConsole : RecordsScreenView
  {
    public RecordsScreenViewConsole(RecordsScreen parRecordsScreen) 
      : base(parRecordsScreen)
    {
      this.AddChild(RecordsTableView);
    }

    /// <summary>
    /// Создает представление таблицы рекордов от Console
    /// </summary>
    /// <returns>Представление таблицы рекордов от Console</returns>
    public override RecordsTableView CreateRecordsTableView()
    {
      return new RecordsTableViewConsole(new RecordsTable());
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
      Console.Write("Рекорды");

      Console.ForegroundColor = savColor;

      DrawChildren();
    }
  }
}

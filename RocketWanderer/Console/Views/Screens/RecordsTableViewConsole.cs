using Logic.Models.Screens;
using Logic.Records;
using Logic.Utils;
using Logic.Views.Screens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Views.Screens
{
  public class RecordsTableViewConsole : RecordsTableView
  {
    public RecordsTableViewConsole(RecordsTable parRecordsTable) 
      : base(parRecordsTable)
    {
    }

    /// <summary>
    /// Отрисовывает таблицу рекордов
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;

      ConsoleColor savColor = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.Green;

      int maxStrs = (int)((Console.BufferHeight - parentSize.Y * 0.3 - 2) / 2);
      int i = 0;
      foreach (Record elRecord in RecordsTable.OrderedRecords)
      {
        if (i == maxStrs)
        {
          break;
        }

        string outStr = $"{i + 1}. Ник: {elRecord.Name} | очки: {elRecord.Score}";

        Console.CursorLeft = (int)(parentSize.X * 0.5 - outStr.Length / 2);
        Console.CursorTop = (int)(parentSize.Y * 0.3 + (i + 1) * 2);

        Console.Write(outStr);

        i++;
      }

      Console.ForegroundColor = savColor;
    }
  }
}

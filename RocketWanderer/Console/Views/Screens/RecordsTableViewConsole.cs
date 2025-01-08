using ConsoleApp.App;
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
  /// <summary>
  /// Представление таблицы рекордов от Console
  /// </summary>
  public class RecordsTableViewConsole : RecordsTableView
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parRecordsTable">Модель таблицы рекордов</param>
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

      ConsoleAdapter console = ConsoleAdapter.Instance;

      Vector2 parentSize = Parent.AbsoluteSize;

      Vector2 position = parentSize.Scale(0.3);
      console.WriteBuffer(position, "Рекорды", ConsoleColor.White);

      ConsoleColor selColor = ConsoleColor.Green;

      int maxStrs = (int)((console.Height - parentSize.Y * 0.3 - 2) / 2);
      int i = 0;
      foreach (Record elRecord in RecordsTable.OrderedRecords)
      {
        if (i == maxStrs)
        {
          break;
        }

        string outStr = $"{i + 1}. Ник: {elRecord.Name} | очки: {elRecord.Score}";

        position = new Vector2(parentSize.X * 0.5 - outStr.Length / 2, parentSize.Y * 0.3 + (i + 1) * 2);
        console.WriteBuffer(position, outStr, selColor);
        i++;
      }
    }
  }
}

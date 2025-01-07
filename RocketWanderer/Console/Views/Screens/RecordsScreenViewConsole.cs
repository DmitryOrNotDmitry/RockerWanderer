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

      ConsoleAdapter console = ConsoleAdapter.Instance;

      Vector2 parentSize = Parent.AbsoluteSize;

      Vector2 position = parentSize.Scale(0.3);
      console.WriteBuffer(position, "Рекорды", ConsoleColor.White);

      position = new Vector2(1, 1);
      console.WriteBuffer(position, "Назад [Backspace]", ConsoleColor.White);

      DrawChildren();
    }
  }
}

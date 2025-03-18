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
  /// Представление экрана рекордов от Console
  /// </summary>
  public class RecordsScreenViewConsole : RecordsScreenView
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parRecordsScreen">Модель экрана рекордов</param>
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
    /// Отрисовывает экран рекордов
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

using Logic.Models.Screens;
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
    }

    /// <summary>
    /// Создает представление таблицы рекордов от Console
    /// </summary>
    /// <returns>Представление таблицы рекордов от Console</returns>
    public override RecordsTableView CreateRecordsTableView()
    {
      return new RecordsTableViewConsole(new RecordsTable());
    }
  }
}

using Logic.Models.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Screens
{
  /// <summary>
  /// Представление таблицы рекордов
  /// </summary>
  public abstract class RecordsTableView : BaseView
  {
    /// <summary>
    /// Модель таблицы рекордов
    /// </summary>
    private RecordsTable _recordsTable;

    /// <summary>
    /// Модель таблицы рекордов
    /// </summary>
    public RecordsTable RecordsTable
    {
      get { return _recordsTable; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parRecordsTable">Модель таблицы рекордов</param>
    public RecordsTableView(RecordsTable parRecordsTable)
    {
      _recordsTable = parRecordsTable;
    }
  }
}

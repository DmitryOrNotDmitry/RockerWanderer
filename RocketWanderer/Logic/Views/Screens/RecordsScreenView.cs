using Logic.Models.Screens;
using Logic.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Screens
{
  /// <summary>
  /// Представление экрана рекордов
  /// </summary>
  public abstract class RecordsScreenView : BaseView
  {
    /// <summary>
    /// Модель экрана рекордов
    /// </summary>
    private RecordsScreen _recordsScreen;

    /// <summary>
    /// Представление таблицы рекордов
    /// </summary>
    private RecordsTableView _recordsTableView;

    /// <summary>
    /// Модель экрана рекордов
    /// </summary>
    public RecordsScreen RecordsScreen
    {
      get { return _recordsScreen; }
    }

    /// <summary>
    /// Представление таблицы рекордов
    /// </summary>
    public RecordsTableView RecordsTableView
    {
      get { return _recordsTableView; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parRecordsScreen">Модель экрана рекордов</param>
    public RecordsScreenView(RecordsScreen parRecordsScreen)
    {
      _recordsScreen = parRecordsScreen;

      _recordsTableView = CreateRecordsTableView();

      for (int i = 0; i < 1; i++) // TODO
      {
        _recordsTableView.RecordsTable.Add(new Record("QWe1", 100));
        _recordsTableView.RecordsTable.Add(new Record("QWe2", 200));
        _recordsTableView.RecordsTable.Add(new Record("QWerwer", 50));
      }

    }

    /// <summary>
    /// Создает представление таблицы рекордов
    /// </summary>
    /// <returns></returns>
    public abstract RecordsTableView CreateRecordsTableView();
  }
}

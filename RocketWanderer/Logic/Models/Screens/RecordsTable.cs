using Logic.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logic.Models.Menus.MenuItem;

namespace Logic.Models.Screens
{
  /// <summary>
  /// Таблица рекордов
  /// </summary>
  public class RecordsTable
  {
    /// <summary>
    /// Делегат, представляющий метод, который будет вызываться при добавлении нового рекорда
    /// </summary>
    public delegate void dRecordAdded();

    /// <summary>
    /// Событие, которое возникает при добавлении нового рекорда
    /// </summary>
    public event dRecordAdded? RecordAdded;

    /// <summary>
    /// Рекорды
    /// </summary>
    private List<Record> _records;

    /// <summary>
    /// Отсортированние рекорды в порядке убывания по очкам
    /// </summary>
    public Record[] OrderedRecords
    {
      get
      {
        _records.Sort((x, y) => -x.Score.CompareTo(y.Score));

        return _records.ToArray();
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public RecordsTable() 
    {
      _records = new List<Record>();
    }

    /// <summary>
    /// Добавляет новый рекорд в таблицу рекордов
    /// </summary>
    /// <param name="parRecord">Новый рекорд</param>
    public void Add(Record parRecord)
    {
      _records.Add(parRecord);
      RecordAdded?.Invoke();
    }
  }
}

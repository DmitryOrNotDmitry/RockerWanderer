using Logic.Models.Screens;
using Logic.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Controllers
{
  public class RecordsController : BaseController
  {
    /// <summary>
    /// Путь к файлу с рекордами
    /// </summary>
    private string _recordsFilePath = "records.json";

    /// <summary>
    /// Таблица рекордов
    /// </summary>
    private RecordsTable _recordsTable;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parRecordsTable">Модель таблицы рекордов</param>
    public RecordsController(RecordsTable parRecordsTable)
    {
      _recordsTable = parRecordsTable;

      ReadRecordsFile();
    }

    /// <summary>
    /// Считывает рекорды из файла
    /// </summary>
    private void ReadRecordsFile()
    {
      List<Record> records = new List<Record>();
      RecordsToFile.ImportJSON(records, _recordsFilePath);
      foreach (Record record in records)
      {
        _recordsTable.Add(record);
      }
    }

    /// <summary>
    /// Сохраняет рекорды в файл
    /// </summary>
    public void FillRecordsFile()
    {
      RecordsToFile.ExportJSON(_recordsTable.OrderedRecords, _recordsFilePath);
    }
  }
}

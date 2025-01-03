using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Logic.Records
{
  /// <summary>
  /// Экспортер рекордов в файл
  /// </summary>
  public class RecordsToFile
  {
    /// <summary>
    /// Закрытый конструктор
    /// </summary>
    private RecordsToFile() { }

    /// <summary>
    /// Экспортирует рекорды в файл в формате JSON
    /// </summary>
    /// <param name="parRecords">Рекорды</param>
    /// <param name="parOutFilePath">Путь файла вывода</param>
    public static void ExportJSON(ICollection<Record> parRecords, string parOutFilePath)
    {
      string jsonString = JsonSerializer.Serialize(parRecords);

      if (!File.Exists(parOutFilePath))
      {
        File.Create(parOutFilePath).Close();
      }
        
      File.WriteAllText(parOutFilePath, jsonString);
    }

    /// <summary>
    /// Импортирует рекорды из файла в коллекцию рекордов в формате JSON
    /// </summary>
    /// <param name="parRecords">Рекорды</param>
    /// <param name="parInFilePath">Путь файла вывода</param>
    public static void ImportJSON(ICollection<Record> parRecords, string parInFilePath)
    {
      if (File.Exists(parInFilePath))
      {
        string jsonString = File.ReadAllText(parInFilePath);

        ICollection<Record>? deserCollection = JsonSerializer.Deserialize<ICollection<Record>>(jsonString);
        if (deserCollection != null) 
        {
          parRecords.Clear();
          foreach (Record elRecord in deserCollection)
          {
            parRecords.Add(elRecord);
          }
        }
      }
    }
  }
}

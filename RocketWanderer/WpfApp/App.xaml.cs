using Logic.Models.Screens;
using Logic.Records;
using System.Configuration;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WpfApp.Controllers;
using WpfApp.Views.Windows;

namespace WpfApp
{
  /// <summary>
  /// Приложение
  /// </summary>
  public partial class App : Application
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
    /// Запускает компоненты приложения
    /// </summary>
    private void Application_Startup(object sender, StartupEventArgs e)
    {
      WindowControllerWpf windowController = new WindowControllerWpf();

      ScreenControllerWpf screenController = new ScreenControllerWpf(windowController.WindowView);
      
      MenuControllerWpf menuController = new MenuControllerWpf(windowController.WindowView, screenController.MainMenuScreenView);

      GameControllerWpf gameController = new GameControllerWpf(screenController.GameScreenView, windowController.WindowView);
      gameController.RecordsTable = screenController.RecordsScreenView.RecordsTableView.RecordsTable;
      gameController.PlayerSettings = screenController.MainMenuScreen.PlayerSettings;

      _recordsTable = gameController.RecordsTable;

      ReadRecordsFile();

      Task.Run(() =>
      {
        {
          try
          {
            while (true)
            {
              Dispatcher.Invoke(() =>
              {
                windowController.WindowView.Draw();
              });
            }
          }
          catch (TaskCanceledException e)
          {

          }
        }
      }
      );
    }

    /// <summary>
    /// Сохраняет рекорды в файл
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
    /// Останавливает компоненты приложения
    /// </summary>
    private void Application_Exit(object sender, ExitEventArgs e)
    {
      RecordsToFile.ExportJSON(_recordsTable.OrderedRecords, _recordsFilePath);
    }
  }
}

using Logic.Records;
using System.Configuration;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WpfApp.Controllers;
using WpfApp.Views.Windows;

namespace WpfApp
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private void Application_Startup(object sender, StartupEventArgs e)
    {
      WindowControllerWpf windowController = new WindowControllerWpf();

      ScreenControllerWpf screenController = new ScreenControllerWpf(windowController.WindowView);
      
      MenuControllerWpf menuController = new MenuControllerWpf(windowController.WindowView, screenController.MainMenuScreenView);

      GameControllerWpf gameController = new GameControllerWpf(screenController.GameScreenView, windowController.Window);

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

      ((Window)(((WindowViewWpf)windowController.WindowView).Control)).KeyDown += (s, e) =>
      {
        if (e.Key == Key.Space)
        {
          gameController.RocketDepartAction();
        }
      };

      //List<Record> records = new List<Record>();
      //records.Add(new Record("QWe1", 100));
      //records.Add(new Record("QWe2", 200));

      //RecordsToFile.ExportJSON(records, "records.json");

      //List<Record> records = new List<Record>();
      //RecordsToFile.ImportJSON(records, "records.json");
    }
  }

}

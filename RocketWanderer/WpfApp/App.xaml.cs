using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp.Controllers;

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

      Task.Run(() =>
      {
        {
          try
          {
            while (true)
            {
              Dispatcher.Invoke(() =>
              {
                windowController.WindowView.Draw(null);
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
  }

}

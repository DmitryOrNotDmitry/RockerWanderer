using Logic.App;
using Logic.Controllers;
using Logic.Models.Screens;
using Logic.Records;
using System.Configuration;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WpfApp.App;
using WpfApp.Controllers;
using WpfApp.Views.Windows;

namespace WpfApp
{
    /// <summary>
    /// Приложение запуска Wpf
    /// </summary>
    public partial class AppWpf : Application
  {
    /// <summary>
    /// Главный объект приложения
    /// </summary>
    private LogicApp _app;

    /// <summary>
    /// Запускает компоненты приложения
    /// </summary>
    private void ApplicationStartup(object sender, StartupEventArgs e)
    {
      ControllerFactory factory = new ControllerFactoryWpf();
      
      _app = new LogicApp(factory);
    }

    /// <summary>
    /// Останавливает компоненты приложения
    /// </summary>
    private void ApplicationExit(object sender, ExitEventArgs e)
    {
      _app.OnExit();
    }
  }
}

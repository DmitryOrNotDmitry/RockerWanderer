﻿using System.Configuration;
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
      new MenuControllerWpf();
    }
  }

}

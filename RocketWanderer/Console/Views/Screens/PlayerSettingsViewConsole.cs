using Logic.Models.Screens;
using Logic.Views.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Views.Screens
{
  public class PlayerSettingsViewConsole : PlayerSettingsView
  {
    public PlayerSettingsViewConsole(PlayerSettings parPlayerSettings) 
      : base(parPlayerSettings)
    {
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Screens
{
  /// <summary>
  /// Настройки игрока
  /// </summary>
  public class PlayerSettings
  {
    /// <summary>
    /// Ник игрока
    /// </summary>
    private string _name;

    /// <summary>
    /// Ник игрока
    /// </summary>
    public string Name 
    { 
      get { return _name; } 
      set { _name = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public PlayerSettings() 
    {
      _name = "Anomyn";
    }
  }
}

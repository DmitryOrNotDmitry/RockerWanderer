using Logic.Models.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Menus
  {
  /// <summary>
  /// Включаемое/выключаемое меню
  /// </summary>
  public class SwitchedMenu : NavigatedMenu
  {
    /// <summary>
    /// Доступно ли сейчас меню
    /// </summary>
    private bool _isEnabled;

    /// <summary>
    /// Доступно ли сейчас меню
    /// </summary>
    public bool IsEnabled
    {
      get { return _isEnabled; }
      set { _isEnabled = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public SwitchedMenu()
    {
      _isEnabled = false;
    }
  }
}

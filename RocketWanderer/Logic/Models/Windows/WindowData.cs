using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Windows
{
  /// <summary>
  /// Окно приложения
  /// </summary>
  public class WindowData
  {
    /// <summary>
    /// Текущий экран
    /// </summary>
    ScreenType _currentScreen;

    /// <summary>
    /// Делегат, представляющий метод, который будет вызываться при смене экрана
    /// </summary>
    /// <param name="parNewScreen">Новый тип экрана</param>
    public delegate void dScreenChanged(ScreenType parNewScreen);

    /// <summary>
    /// Событие, которое возникает при смене экрана
    /// </summary>
    public event dScreenChanged? ScreenChanged;

    /// <summary>
    /// Конструктор
    /// </summary>
    public WindowData()
    {
      _currentScreen = ScreenType.MainMenu;
    }

    /// <summary>
    /// Изменяет тип экрана на новый
    /// </summary>
    /// <param name="parNewScreen">Новый тип экрана</param>
    public void ChangeScreen(ScreenType parNewScreen)
    {
      _currentScreen = parNewScreen;
      ScreenChanged?.Invoke(_currentScreen);
    }
  }
}

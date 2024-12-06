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
    private ScreenType _currentScreen;

    /// <summary>
    /// Ширина окна
    /// </summary>
    private int _width;

    /// <summary>
    /// Высота окна
    /// </summary>
    private int _height;

    /// <summary>
    /// Ширина окна
    /// </summary>
    public int Width
    {
      get { return _width; }
      set { _width = value; }
    }

    /// <summary>
    /// Высота окна
    /// </summary>
    public int Height
    {
      get { return _height; }
      set { _height = value; }
    }

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

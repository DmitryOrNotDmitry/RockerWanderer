using Logic.Controllers;
using Logic.Models.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Utils
{
  /// <summary>
  /// Калькулятор координат в зависимости от текущего окна
  /// </summary>
  public class CoordsCalculator
  {
    /// <summary>
    /// Окно по которому будут рассчитаны координаты
    /// </summary>
    private WindowData? _window;

    /// <summary>
    /// Закрытый конструктор
    /// </summary>
    private CoordsCalculator() { }

    /// <summary>
    /// Единственный экземпляр
    /// </summary>
    private static CoordsCalculator _instance = new CoordsCalculator();

    /// <summary>
    /// Единственный экземпляр
    /// </summary>
    public static CoordsCalculator Instance
    {
      get { return _instance; }
    }

    /// <summary>
    /// Установить окно для рассчета координат
    /// </summary>
    /// <param name="parWindow">Окно</param>
    /// <exception cref="Exception">Выбрасывается при переопределение уже установленного окна</exception>
    public void SetWindow(WindowData parWindow)
    {
      if (_window is not null)
        throw new Exception("Объект _window уже определен для класса");

      _window = parWindow;
    }

    /// <summary>
    /// Рассчитать координаты вектора по размеру текущего окна
    /// </summary>
    /// <param name="parUDim2">Параметр расчета</param>
    /// <returns>Вектор, представляющий абсолютные координаты окна и рассчитанный по UDim2</returns>
    public Vector2 Сalculate(UDim2 parUDim2)
    {
      int x = (int)(parUDim2.X.Scale * _window.Width + parUDim2.X.Offset);
      int y = (int)(parUDim2.Y.Scale * _window.Height + parUDim2.Y.Offset);

      return new Vector2(x, y);
    }

  }
}

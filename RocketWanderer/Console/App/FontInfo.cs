using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.App
{
  /// <summary>
  /// Хранит размер шрифта для консольного приложения
  /// </summary>
  public class FontInfo
  {
    /// <summary>
    /// Размер шрифта консоли в пикселях
    /// </summary>
    private static Vector2 _fontSize = new Vector2(1, 1);

    /// <summary>
    /// Множитель, показывающий насколько размер шрифта по Y больше размера по X
    /// </summary>
    public static double FontYScale
    {
      get { return _fontSize.Y / _fontSize.X; }
    }

    /// <summary>
    /// Закрытый конструктор
    /// </summary>
    private FontInfo() { }

    /// <summary>
    /// Инициализирует класс
    /// </summary>
    public static void Init()
    {
      _fontSize.X = 1;
      _fontSize.Y = 2;
    }
  }
}

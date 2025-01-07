using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.App
{
  /// <summary>
  /// Данные для вывода цветного текста в консоль
  /// </summary>
  public class ConsoleFormatOut
  {
    /// <summary>
    /// Координата X
    /// </summary>
    private int _x;

    /// <summary>
    /// Координата Y
    /// </summary>
    private int _y;

    /// <summary>
    /// Координата X
    /// </summary>
    private string _out;

    /// <summary>
    /// Цвет выводимой строки
    /// </summary>
    private ConsoleColor _color;

    /// <summary>
    /// Координата X
    /// </summary>
    public int X
    {
      get { return _x; }
    }

    /// <summary>
    /// Координата Y
    /// </summary>
    public int Y
    {
      get { return _y; }
    }

    /// <summary>
    /// Координата X
    /// </summary>
    public string Out
    {
      get { return _out; }
    }

    /// <summary>
    /// Цвет выводимой строки
    /// </summary>
    public ConsoleColor Color
    {
      get { return _color; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    /// <param name="parString">Выводимая строка</param>
    /// <param name="parColor">Цвет выводимой строки</param>
    public ConsoleFormatOut(int parX, int parY, string parString, ConsoleColor parColor)
    {
      _x = parX;
      _y = parY;
      _out = parString;
      _color = parColor;
    }
  }
}

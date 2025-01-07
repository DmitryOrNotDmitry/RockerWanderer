using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.App
{
  /// <summary>
  /// Адаптер класса Console
  /// </summary>
  public class ConsoleAdapter
  {
    /// <summary>
    /// Единственный экземпляр класса
    /// </summary>
    private static ConsoleAdapter _instance = new ConsoleAdapter();

    /// <summary>
    /// Единственный экземпляр класса
    /// </summary>
    public static ConsoleAdapter Instance
    {
      get { return _instance; }
    }

    /// <summary>
    /// Пустой символ 
    /// </summary>
    private const char _emptyChar = ' ';

    /// <summary>
    /// Ширина буфера
    /// </summary>
    private readonly int _width;

    /// <summary>
    /// Длина буфера
    /// </summary>
    private readonly int _height;

    /// <summary>
    /// Буфер для двойной буферизации
    /// </summary>
    private char[,] _buffer;

    private char[,] _prevBuffer;

    /// <summary>
    /// Закрытый конструктор
    /// </summary>
    private ConsoleAdapter() 
    {
      _width = 1000;
      _height = 100;

      _buffer = new char[_height, _width];
      _prevBuffer = new char[_height, _width];
    }

    /// <summary>
    /// Заполняет символ консоли
    /// </summary>
    /// <param name="parX">Координата по X</param>
    /// <param name="parY">Координата по Y</param>
    /// <param name="parChar">Выводимый символ</param>
    public void Write(int parX, int parY, char parChar)
    {
      if (parX >= 0 && parX < Console.BufferWidth)
      {
        if (parY >= 0 && parY < Console.BufferHeight)
        {
          Console.SetCursorPosition(parX, parY);
          Console.Write(parChar);
        }
      }
    }

    /// <summary>
    /// Заполняет консоль пустыми символами
    /// </summary>
    public void Clear()
    {
      Console.Clear();
    }

    public void ClearBuffer(Rect parRect)
    {
      //string emptyLine = new string(' ', parRect.Width);

      int endY = parRect.Y + parRect.Height;
      int endX = parRect.X + parRect.Width;

      for (int y = parRect.Y; y < endY; y++)
      {
        for (int x = parRect.X; x < endX; x++)
        {
          _buffer[y, x] = ' ';
        }
      }
    }

    public void ClearBuffer()
    {
      for (int y = 0; y < Console.BufferHeight; y++)
      {
        for (int x = 0; x < Console.BufferWidth; x++)
        {
          _buffer[y, x] = ' ';
        }
      }
    }

    /// <summary>
    /// Заполняет символ буфера
    /// </summary>
    /// <param name="parX">Координата по X</param>
    /// <param name="parY">Координата по Y</param>
    /// <param name="parChar">Выводимый символ</param>
    public void WriteBuffer(int parX, int parY, char parChar)
    {
      if (parX >= 0 && parX < Console.BufferWidth)
      {
        if (parY >= 0 && parY < Console.BufferHeight)
        {
          _buffer[parY, parX] = parChar;
        }
      }
    }

    /// <summary>
    /// Заполняет буфер строкой
    /// </summary>
    /// <param name="parX">Координата по X</param>
    /// <param name="parY">Координата по Y</param>
    /// <param name="parString">Строка</param>
    public void WriteBuffer(int parX, int parY, string parString)
    {
      for (int i = 0; i < parString.Length; i++)
      {
        WriteBuffer(parX + i, parY, parString[i]);
      }
    }

    public void DropBuffer()
    {
      int height = Console.BufferHeight;
      int width = Console.BufferWidth;

      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          if (_buffer[y, x] != _prevBuffer[y, x])
          {
            Console.SetCursorPosition(x, y);
            Console.Write(_buffer[y, x]);
            _prevBuffer[y, x] = _buffer[y, x];
          }
        }
      }
    }


  }
}

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

    /// <summary>
    /// Буфер, хранящий прерыдущее состояние главного буфера _buffer
    /// </summary>
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

      for(int y = 0; y < _height; y++)
      {
        for (int x = 0; x < _width; x++)
        {
          _prevBuffer[y, x] = '1';
        }
      }
    }

    /// <summary>
    /// Напрямую заполняет символ консоли
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
    /// Напрямую заполняет консоль строкой
    /// </summary>
    /// <param name="parX">Координата по X</param>
    /// <param name="parY">Координата по Y</param>
    /// <param name="parStr">Выводимая строка</param>
    public void Write(int parX, int parY, string parStr)
    {
      for (int i = 0; i < parStr.Length; i++)
      {
        Write(parX + i, parY, parStr[i]);
      }
    }

    /// <summary>
    /// Заполняет консоль пустыми символами
    /// </summary>
    public void Clear()
    {
      lock (_prevBuffer)
      {
        Console.Clear();
        ClearBuffer(_prevBuffer);
      }
    }

    /// <summary>
    /// Очищает буфер в заданной области
    /// </summary>
    /// <param name="parRect">Область буфера, которая будет очищена</param>
    public void ClearBuffer(Rect parRect)
    {
      int endY = parRect.Y + parRect.Height;
      int endX = parRect.X + parRect.Width;

      lock (_buffer)
      {
        for (int y = parRect.Y; y < endY; y++)
        {
          for (int x = parRect.X; x < endX; x++)
          {
            _buffer[y, x] = _emptyChar;
          }
        }
      }
    }

    /// <summary>
    /// Полностью очищает буфер
    /// </summary>
    /// <param name="parBuffer">Буфер, который требуется очистить</param>
    private void ClearBuffer(char[,] parBuffer)
    {
      for (int y = 0; y < Console.BufferHeight; y++)
      {
        for (int x = 0; x < Console.BufferWidth; x++)
        {
          parBuffer[y, x] = _emptyChar;
        }
      }
    }

    /// <summary>
    /// Очищает главный буфер
    /// </summary>
    public void ClearBuffer()
    {
      lock (_buffer)
      {
        ClearBuffer(_buffer);
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
      lock (_buffer)
      {
        for (int i = 0; i < parString.Length; i++)
        {
          WriteBuffer(parX + i, parY, parString[i]);
        }
      }
    }

    /// <summary>
    /// Скидывает буфер в консоль, но только измененные символы
    /// </summary>
    public void DropBuffer()
    {
      int height = Console.BufferHeight;
      int width = Console.BufferWidth;

      lock (_buffer)
      {
        lock (_prevBuffer)
        {
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

  }
}

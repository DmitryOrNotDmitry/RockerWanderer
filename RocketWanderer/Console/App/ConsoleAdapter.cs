﻿using Logic.Utils;
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
  /// Адаптер класса Console, представляет двойную буферизацию
  /// </summary>
  public class ConsoleAdapter
  {
    /// <summary>
    /// Пустой символ 
    /// </summary>
    private const char EMPTY_CHAR = ' ';

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
    /// Буфер цветных строк
    /// </summary>
    private List<ConsoleFormatOut> _coloredOut = new();

    /// <summary>
    /// Ширина консоли
    /// </summary>
    public int Width
    {
      get { return Console.BufferWidth; }
    }

    /// <summary>
    /// Высота консоли
    /// </summary>
    public int Height
    {
      get { return Console.BufferHeight; }
    }

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
    /// Заполняет консоль пустыми символами
    /// </summary>
    public void Clear()
    {
      lock (_prevBuffer)
      {
        Console.Clear();
        ClearBuffer(_prevBuffer, new Rect(0, 0, Width, Height));
      }
    }

    /// <summary>
    /// Заполняет консоль пустыми символами в заданной области
    /// </summary>
    public void Clear(Rect parRect)
    {
      string emptyStr = new(EMPTY_CHAR, parRect.Width);
      int endY = parRect.Y + parRect.Height;

      lock (_prevBuffer)
      {
        for (int y = parRect.Y; y < endY; y++)
        {
          Console.SetCursorPosition(parRect.X, y);
          Console.Write(emptyStr);
        }

        ClearBuffer(_prevBuffer, parRect);
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
            _buffer[y, x] = EMPTY_CHAR;
          }
        }
      }
    }

    /// <summary>
    /// Очищает буфер в области
    /// </summary> 
    /// <param name="parBuffer">Буфер, который требуется очистить</param>
    /// <param name="parRect">Область, которая будет очищена</param>
    private void ClearBuffer(char[,] parBuffer, Rect parRect)
    {
      int endY = parRect.Y + parRect.Height;
      int endX = parRect.X + parRect.Width;

      for (int y = parRect.Y; y < endY; y++)
      {
        for (int x = parRect.X; x < endX; x++)
        {
          parBuffer[y, x] = EMPTY_CHAR;
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
        ClearBuffer(_buffer, new Rect(0, 0, Width, Height));
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
      if (parX >= 0 && parX < Width)
      {
        if (parY >= 0 && parY < Height)
        {
          _buffer[parY, parX] = parChar;
        }
      }
    }

    /// <summary>
    /// Заполняет символ буфера
    /// </summary>
    /// <param name="parPosition">Координаты символа</param>
    /// <param name="parChar">Выводимый символ</param>
    public void WriteBuffer(Vector2 parPosition, char parChar)
    {
      WriteBuffer((int)parPosition.X, (int)parPosition.Y, parChar);
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
    /// Заполняет буфер строкой
    /// </summary>
    /// <param name="parPosition">Координаты первого символа</param>
    /// <param name="parString">Строка</param>
    public void WriteBuffer(Vector2 parPosition, string parString)
    {
      WriteBuffer((int)parPosition.X, (int)parPosition.Y, parString);
    }

    /// <summary>
    /// Заполняет буфер цветной строкой
    /// </summary>
    /// <param name="parX">Координата по X</param>
    /// <param name="parY">Координата по Y</param>
    /// <param name="parString">Строка</param>
    /// <param name="parColor">Цвет надписи</param>
    public void WriteBuffer(int parX, int parY, string parString, ConsoleColor parColor)
    {
      lock (_coloredOut)
      {
        _coloredOut.Add(new ConsoleFormatOut(parX, parY, parString, parColor));
      }
    }

    /// <summary>
    /// Заполняет буфер цветной строкой
    /// </summary>
    /// <param name="parPosition">Координаты первого символа</param>
    /// <param name="parString">Строка</param>
    /// <param name="parColor">Цвет надписи</param>
    public void WriteBuffer(Vector2 parPosition, string parString, ConsoleColor parColor)
    {
      WriteBuffer((int)parPosition.X, (int)parPosition.Y, parString, parColor);
    }

    /// <summary>
    /// Скидывает буфер в консоль, но только измененные символы
    /// </summary>
    public void DropBuffer()
    {
      int height = Height;
      int width = Width;

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

      lock (_coloredOut)
      {
        ConsoleColor oldColor = Console.ForegroundColor;
        foreach (ConsoleFormatOut elOut in _coloredOut)
        {
          Console.ForegroundColor = elOut.Color;

          Console.SetCursorPosition(elOut.X, elOut.Y);
          Console.Write(elOut.Out);
        }
        Console.ForegroundColor = oldColor;
        _coloredOut.Clear();
      }
    }

  }
}

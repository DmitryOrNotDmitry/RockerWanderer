﻿using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Game
{
  /// <summary>
  /// Базовый класс для движущихся объектов
  /// </summary>
  public abstract class MovableItem : MapItem
  {
    /// <summary>
    /// Скорость единиц в секунду
    /// </summary>
    private Vector2 _velocity = new Vector2();

    /// <summary>
    /// Скорость единиц в секунду
    /// </summary>
    public Vector2 Velocity
    {
      get
      {
        lock (_lock)
        {
          return _velocity;
        }
      }
      set
      {
        lock (_lock)
        {
          _velocity = value;
        }
      }
    }

    /// <summary>
    /// Перемещает объект линейно
    /// </summary>
    /// <param name="parDeltaTimeSec">Прошедшее время в секундах</param>
    public virtual void Move(double parDeltaTimeSec)
    {
      lock (_lock)
      {
        Position += Velocity.Scale(parDeltaTimeSec);
      }
    }
  }
}

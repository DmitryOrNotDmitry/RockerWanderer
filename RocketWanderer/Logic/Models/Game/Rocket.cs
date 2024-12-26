using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Logic.Models.Game
{
  /// <summary>
  /// Ракета
  /// </summary>
  public class Rocket : MovableItem
  {
    /// <summary>
    /// Угол поворота
    /// </summary>
    private double _rotation;

    /// <summary>
    /// Планета, рядом с которой сейчас находится ракета
    /// </summary>
    private Planet? _location;

    /// <summary>
    /// Радиус орбиты, по которой движется ракета
    /// </summary>
    private double _reachedOrbit;

    /// <summary>
    /// Угол поворота
    /// </summary>
    public double Rotation
    {
      get { return _rotation; }
      set { _rotation = value; }
    }

    /// <summary>
    /// Планета, рядом с которой сейчас находится ракета
    /// </summary>
    public Planet? Location
    {
      get { return _location; }
      set { _location = value; }
    }

    /// <summary>
    /// Радиус орбиты, по которой движется ракета
    /// </summary>
    public double ReachedOrbit
    {
      get { return _reachedOrbit; }
      set { _reachedOrbit = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public Rocket() 
    {
      _rotation = 90;

      _reachedOrbit = 0;
    }

    /// <summary>
    /// Перемещает ракету по орбите планеты в Location
    /// </summary>
    /// <param name="parDeltaTimeSec">Прошедшее время в секундах</param>
    public void MoveAround(double parDeltaTimeSec)
    {
      double passedDistance = Velocity.Length * parDeltaTimeSec;

      double passedRadians = passedDistance / _reachedOrbit;
      passedRadians *= -1;

      Vector2 planetCenter = Location.Position;

      double currentAngle = Math.Atan2(Position.Y - planetCenter.Y, Position.X - planetCenter.X);

      double newAngle = currentAngle + passedRadians;

      Rotation = newAngle * 180 / Math.PI;

      double newX = Math.Cos(newAngle) * ReachedOrbit + planetCenter.X;
      double newY = Math.Sin(newAngle) * ReachedOrbit + planetCenter.Y;

      Position.X = newX;
      Position.Y = newY;
    }

    /// <summary>
    /// Перемещает ракету
    /// </summary>
    /// <param name="parDeltaTimeSec">Прошедшее время в секундах</param>
    public override void Move(double parDeltaTimeSec)
    {
      if (Location != null)
      {
        MoveAround(parDeltaTimeSec);
      }
      else
      {
        base.Move(parDeltaTimeSec);
      }
    }

  }
}

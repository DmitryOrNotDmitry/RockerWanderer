using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    /// Направление с которым ракета движется вокруг планеты
    /// </summary>
    private MovingDirection _moveDirection;

    /// <summary>
    /// Планета, рядом с которой сейчас находится ракета
    /// </summary>
    private Planet? _location;

    /// <summary>
    /// Предыдущая планета, рядом с которой находилась ракета
    /// </summary>
    private Planet? _prevLocation;

    /// <summary>
    /// Радиус орбиты, по которой движется ракета
    /// </summary>
    private double _reachedOrbit;

    /// <summary>
    /// Угол поворота
    /// </summary>
    public double Rotation
    {
      get
      {
        lock (_lock)
        {
          return _rotation;
        }
      }
      set
      {
        lock (_lock)
        {
          _rotation = value;
        }
      }
    }

    /// <summary>
    /// Планета, рядом с которой сейчас находится ракета
    /// </summary>
    public Planet? Location
    {
      get
      {
        lock (_lock)
        {
          return _location;
        }
      }
      set
      {
        lock (_lock)
        {
          if (value == null)
          {
            PrevLocation = _location;
          }
          _location = value;
        }
      }
    }

    /// <summary>
    /// Предыдущая планета, рядом с которой находилась ракета
    /// </summary>
    public Planet? PrevLocation
    {
      get
      {
        lock (_lock)
        {
          return _prevLocation;
        }
      }
      private set
      {
        _prevLocation = value;
      }
    }

    /// <summary>
    /// Радиус орбиты, по которой движется ракета
    /// </summary>
    public double ReachedOrbit
    {
      get
      {
        lock (_lock)
        {
          return _reachedOrbit;
        }
      }
      set
      {
        lock (_lock)
        {
          _reachedOrbit = value;
        }
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public Rocket() 
    {
      _moveDirection = MovingDirection.Clockwise;
      Rotation = 90;
      ReachedOrbit = 0;
    }

    /// <summary>
    /// Перемещает ракету по орбите планеты в Location
    /// </summary>
    /// <param name="parDeltaTimeSec">Прошедшее время в секундах</param>
    private void MoveAround(double parDeltaTimeSec)
    {
      double passedDistance = Velocity.Length * parDeltaTimeSec;

      double passedRadians = passedDistance / ReachedOrbit;
      if (_moveDirection == MovingDirection.Clockwise)
      {
        passedRadians *= -1;
      }

      Vector2 planetCenter = Location.Position;

      double currentAngle = Math.Atan2(Position.Y - planetCenter.Y, Position.X - planetCenter.X);

      double newAngle = currentAngle + passedRadians;

      double newX = Math.Cos(newAngle) * ReachedOrbit + planetCenter.X;
      double newY = Math.Sin(newAngle) * ReachedOrbit + planetCenter.Y;

      double newRotation = newAngle * 180 / Math.PI;
      if (_moveDirection == MovingDirection.AntiClockwise)
      {
        newRotation += 180;
      }

      Rotation = newRotation;
      Position = new Vector2(newX, newY);
    }

    /// <summary>
    /// Перемещает ракету
    /// </summary>
    /// <param name="parDeltaTimeSec">Прошедшее время в секундах</param>
    public override void Move(double parDeltaTimeSec)
    {
      lock (_lock)
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

    /// <summary>
    /// Отстыковывает ракету от планеты
    /// </summary>
    public void Depart()
    {
      lock (_lock)
      {
        if (Location != null)
        {
          Vector2 tmpVector = Location.Position + Position.Scale(-1);
          tmpVector = tmpVector.Scale(1.0 / tmpVector.Length);
          tmpVector = tmpVector.Rotate90().Scale(Velocity.Length);
          
          if (_moveDirection == MovingDirection.AntiClockwise)
          {
            tmpVector = tmpVector.Scale(-1);
          }
          Velocity = tmpVector;
          
          Location = null;
        }
      }
    }

    /// <summary>
    /// Попытка начать вращаться вокруг планеты
    /// </summary>
    /// <param name="parPlanet">Планета, вокруг которой нужно проверить возможность вращаться</param>
    /// <returns>true - возможность есть, иначе false </returns>
    public bool TryAttach(Planet parPlanet)
    {
      lock (_lock)
      {
        if (parPlanet != PrevLocation)
        {
          Vector2 rocketToPlanet = Position + parPlanet.Position.Scale(-1);
          Vector2 rocketLook = Velocity;
          double distanceToPlanet = rocketToPlanet.Length;

          if (distanceToPlanet <= parPlanet.OrbitRadius)
          {
            double angle = Vector2.AngleBetween(rocketToPlanet, rocketLook) * 180 / Math.PI;

            if (angle > 85 && angle < 95)
            {
              if (Center.Y > parPlanet.Center.Y)
              {
                _moveDirection = MovingDirection.Clockwise;
              }
              else
              {
                _moveDirection = MovingDirection.AntiClockwise;
              }

              ReachedOrbit = distanceToPlanet;
              Location = parPlanet;

              return true;
            }
          }
        }

        return false;
      }
    }

  }
}

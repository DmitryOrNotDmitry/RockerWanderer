using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Game
{
  public class MovableItem : MapItem
  {
    /// <summary>
    /// Скорость единиц в секунду
    /// </summary>
    private Vector2 _velocity = new Vector2();

    /// <summary>
    /// Скорость единиц в секунду
    /// </summary>
    public Vector2 Velocity;
    {
      get {  return _velocity; }
      set { _velocity = value; }
    }

    /// <summary>
    /// Перемещает объект
    /// </summary>
    /// <param name="parDeltaTimeSec">Прошедшее время в секундах</param>
    public void Move(double parDeltaTimeSec)
    {
      Position += Velocity.Scale(parDeltaTimeSec); 
    }
  }
}

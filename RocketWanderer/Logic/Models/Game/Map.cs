using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Game
{
  /// <summary>
  /// Карта
  /// </summary>
  public class Map
  {
    /// <summary>
    /// Размер видимой части карты
    /// </summary>
    private Vector2 _visibleSize;

    /// <summary>
    /// Ракета
    /// </summary>
    private Rocket _rocket;

    /// <summary>
    /// Верхний пояс астероидов
    /// </summary>
    private AsteroidBelt _topAsteroidBelt;

    /// <summary>
    /// Нижний пояс астероидов
    /// </summary>
    private AsteroidBelt _bottomAsteroidBelt;

    /// <summary>
    /// Стартовая планета
    /// </summary>
    private Planet _startPlanet;

    /// <summary>
    /// Генерируемые планеты
    /// </summary>
    private LinkedList<Planet> _planets;

    /// <summary>
    /// Солнце
    /// </summary>
    private Sun _sun;

    /// <summary>
    /// Ракета
    /// </summary>
    public Rocket Rocket
    {
      get { return _rocket; }
    }

    /// <summary>
    /// Стартовая планета
    /// </summary>
    public Planet StartPlanet
    {
      get { return _startPlanet; }
    }

    /// <summary>
    /// Размер видимой части карты
    /// </summary>
    public Vector2 VisibleSize
    {
      get { return _visibleSize; }
      set { _visibleSize = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parVisibleSize">Размер видимой части карты</param>
    public Map(Vector2 parVisibleSize)
    {
      _visibleSize = parVisibleSize;

      _rocket = new Rocket();
      _rocket.Position = new Vector2(_visibleSize.X * 0.3, _visibleSize.Y * 0.5);
      _rocket.Velocity = new Vector2(_visibleSize.X / 10, 0);
      _rocket.Size = new Vector2(170, 100);
      
      _startPlanet = new Planet(100);
      _startPlanet.Position = new Vector2(_visibleSize.X * 0.3, _visibleSize.Y * 0.5);

      _planets = new LinkedList<Planet>();
    }

    /// <summary>
    /// Обновляет данные перемещающихся объектов
    /// </summary>
    /// <param name="parDeltaSeconds">Время, прошедшее с предыдущего кадра</param>
    public void Update(double parDeltaSeconds)
    {
      _rocket.Move(parDeltaSeconds);
    }

  }
}

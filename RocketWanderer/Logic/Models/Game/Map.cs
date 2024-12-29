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
    /// Размер карты
    /// </summary>
    private Vector2 _size;

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
    /// Солнце
    /// </summary>
    public Sun Sun
    {
      get { return _sun; }
    }

    /// <summary>
    /// Верхний пояс астероидов
    /// </summary>
    public AsteroidBelt TopAsteroidBelt
    {
      get { return _topAsteroidBelt; }
    }

    /// <summary>
    /// Нижний пояс астероидов
    /// </summary>
    public AsteroidBelt BottomAsteroidBelt
    {
      get { return _bottomAsteroidBelt; }
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
    /// Размер карты
    /// </summary>
    public Vector2 Size
    {
      get { return _size; }
      set { _size = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parVisibleSize">Размер видимой части карты</param>
    public Map(Vector2 parVisibleSize)
    {
      _visibleSize = parVisibleSize;
      Vector2 initMapSize = new Vector2(1920, 1080);
      _size = initMapSize;

      _rocket = new Rocket();
      _rocket.Position = new Vector2(initMapSize.X * 0.3, initMapSize.Y * 0.5 + 170);
      _rocket.Velocity = new Vector2(initMapSize.X / 10, 0);
      _rocket.Size = new Vector2(170, 100);
      
      _startPlanet = new Planet(100);
      _startPlanet.Position = new Vector2(initMapSize.X * 0.3, initMapSize.Y * 0.5);

      _rocket.Location = _startPlanet;
      _rocket.ReachedOrbit = 200;

      double sunDiameter = initMapSize.Y;
      _sun = new Sun();
      _sun.Size = new Vector2(sunDiameter, sunDiameter);
      _sun.Position = new Vector2(-sunDiameter * 0.3, initMapSize.Y * 0.5);

      Vector2 asteroidsSize = new Vector2(initMapSize.X, initMapSize.Y * 0.08);

      _topAsteroidBelt = new AsteroidBelt();
      _topAsteroidBelt.Size = asteroidsSize;
      _topAsteroidBelt.Position = new Vector2(asteroidsSize.X / 2, asteroidsSize.Y / 2);

      _bottomAsteroidBelt = new AsteroidBelt();
      _bottomAsteroidBelt.Size = asteroidsSize;
      _bottomAsteroidBelt.Position = new Vector2(asteroidsSize.X / 2, initMapSize.Y - asteroidsSize.Y / 2);


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

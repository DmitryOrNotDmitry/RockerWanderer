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
    /// Размер карты по y доступное для планеты
    /// </summary>
    private double _yPlaceForPlanets;

    /// <summary>
    /// Шаг, с которым размещаются планеты
    /// </summary>
    private readonly int _planetStep;
    
    /// <summary>
    /// Начальный отступ по X размещения планет
    /// </summary>
    private double _startOffsetX;

    /// <summary>
    /// Количество созданных планет
    /// </summary>
    private uint _countCreatedPlanets;

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
    /// Генерируемые планеты
    /// </summary>
    public LinkedList<Planet> Planets
    {
      get { return _planets; }
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
      Vector2 initMapSize = new Vector2(1920, 1080);
      _size = initMapSize;

      _rocket = new Rocket();
      _rocket.Position = new Vector2(initMapSize.X * 0.3, initMapSize.Y * 0.5 + 170);
      _rocket.Velocity = new Vector2(initMapSize.X / 10 * 2, 0);
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

      _yPlaceForPlanets = initMapSize.Y / 2 - asteroidsSize.Y;
      _planetStep = 900;
      _startOffsetX = _startPlanet.Position.X;
      _countCreatedPlanets = 0;

      for (int i = 0; i < 10; i++)
      {
        CreatePlanet();
      }
    }
    
    private void CreatePlanet()
    {
      Random random = new Random();

      double radius = random.Next(70, 131);

      Planet newPlanet = new Planet(radius);

      int xNoiseBorder = 100;
      int yNoiseBorder = (int)(_yPlaceForPlanets - newPlanet.OrbitRadius);

      int xNoiseOffset = random.Next(-xNoiseBorder, xNoiseBorder);
      int yNoiseOffset = random.Next(-yNoiseBorder, yNoiseBorder);

      newPlanet.Position = new Vector2(
        _startOffsetX + _planetStep * (_countCreatedPlanets + 1) + xNoiseOffset,
        _size.Y / 2 + yNoiseOffset
      );

      _planets.AddLast(newPlanet);
      _countCreatedPlanets++;
    }

    /// <summary>
    /// Обновляет данные перемещающихся объектов
    /// </summary>
    /// <param name="parDeltaSeconds">Время, прошедшее с предыдущего кадра</param>
    public void Update(double parDeltaSeconds)
    {
      Rocket.Move(parDeltaSeconds);

      if (Rocket.Location == null)
      {
        foreach (Planet elPlanet in _planets)
        {
          if (Rocket.TryAttach(elPlanet))
          {
            break;
          }
        }
      }
    }

    /// <summary>
    /// Заставляет ракету вылететь с орбиты планеты
    /// </summary>
    public void RocketDepart()
    {
      _rocket.Depart();
    }

  }
}

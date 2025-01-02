using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static Logic.Models.Game.Map;

namespace Logic.Models.Game
{
  /// <summary>
  /// Карта
  /// </summary>
  public class Map
  {
    /// <summary>
    /// Делегат, представляющий метод, который будет вызываться при создании планеты
    /// </summary>
    public delegate void dPlanetCreated(Planet parNewPlanet);

    /// <summary>
    /// Событие, которое возникает при создании планеты
    /// </summary>
    public event dPlanetCreated? PlanetCreated;

    /// <summary>
    /// Делегат, представляющий метод, который будет вызываться при сбросе карты
    /// </summary>
    public delegate void dReseted();

    /// <summary>
    /// Событие, которое возникает при сбросе карты
    /// </summary>
    public event dReseted? Reseted;

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
    /// Текущее смещение камеры по X относительно начала карты
    /// </summary>
    private double _xCameraOffset;

    /// <summary>
    /// Необходимое смещение камеры по X относительно начала карты
    /// </summary>
    private double _xCameraMustOffset;

    /// <summary>
    /// Расстояние от _xCameraOffset, начиная с которого планеты удаляются/генерируются
    /// </summary>
    private readonly double _deletePlanetdistance = 3000;

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
    /// Смещение камеры по X относительно начала карты
    /// </summary>
    public double XCameraOffset
    {
      get { return _xCameraOffset; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parSize">Размер начальной части карты</param>
    public Map(Vector2 parSize)
    {
      _size = parSize;

      _rocket = new Rocket();

      _startPlanet = new Planet(100);
      _startPlanet.Position = new Vector2(_size.X * 0.3, _size.Y * 0.5);

      _sun = new Sun();
      double sunDiameter = _size.Y;
      _sun.Size = new Vector2(sunDiameter, sunDiameter);
      _sun.Position = new Vector2(-sunDiameter * 0.3, _size.Y * 0.5);

      Vector2 asteroidsSize = new Vector2(_size.X, _size.Y * 0.08);
      _topAsteroidBelt = new AsteroidBelt();
      _topAsteroidBelt.Size = asteroidsSize;
      _topAsteroidBelt.Position = new Vector2(asteroidsSize.X / 2, asteroidsSize.Y / 2);

      _bottomAsteroidBelt = new AsteroidBelt();
      _bottomAsteroidBelt.Size = asteroidsSize;
      _bottomAsteroidBelt.Position = new Vector2(asteroidsSize.X / 2, _size.Y - asteroidsSize.Y / 2);

      _planets = new LinkedList<Planet>();

      _yPlaceForPlanets = _size.Y / 2 - asteroidsSize.Y;
      _planetStep = 900;
      _startOffsetX = _startPlanet.Position.X;

      Reset();
    }

    /// <summary>
    /// Возвращает карту в состояние, которое готово к новой игре
    /// </summary>
    public void Reset()
    {
      _rocket.Position = new Vector2(_size.X * 0.3, _size.Y * 0.5 + 170);
      _rocket.Velocity = new Vector2(_size.X / 10 * 2, 0);
      _rocket.Size = new Vector2(53, 100);
      _rocket.Location = _startPlanet;
      _rocket.ReachedOrbit = 200;

      _planets.Clear();

      _countCreatedPlanets = 0;
      _xCameraMustOffset = 0;
      _xCameraOffset = 0;

      Reseted?.Invoke();
    }

    /// <summary>
    /// Создает случайную планету
    /// </summary>
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

      PlanetCreated?.Invoke(newPlanet);
    }

    /// <summary>
    /// Обновляет данные перемещающихся объектов
    /// </summary>
    /// <param name="parDeltaSeconds">Время, прошедшее с предыдущего кадра</param>
    public void Update(double parDeltaSeconds)
    {
      DeletePlanets();

      GeneratePlanets();

      MoveObjects(parDeltaSeconds);

      if (CheckCollisions())
      {
        Rocket.Destroy();
      }

      MoveCamera();
    }

    /// <summary>
    /// Удаляет планеты, которые оказались за картой
    /// </summary>
    private void DeletePlanets()
    {
      Planet? planet = _planets.First?.Value;
      while (planet != null)
      {
        if (planet.Position.X + _deletePlanetdistance < _xCameraOffset)
        {
          planet.Despawn();
          _planets.RemoveFirst();
        }
        else
        {
          break;
        }

        planet = _planets.First?.Value;
      }
    }

    /// <summary>
    /// Создает новые планеты
    /// </summary>
    private void GeneratePlanets()
    {
      if (_planets.Count == 0)
      {
        CreatePlanet();
      }

      while (_planets.Last.Value.Position.X < _xCameraOffset + _deletePlanetdistance)
      {
        CreatePlanet();
      }
    }

    /// <summary>
    /// Обновляет позиции движущихся объектов на карте
    /// </summary>
    /// <param name="parDeltaSeconds">Время, прошедшее с предыдущего кадра</param>
    private void MoveObjects(double parDeltaSeconds)
    {
      Rocket.Move(parDeltaSeconds);

      if (Rocket.Location == null)
      {
        foreach (Planet elPlanet in _planets.AsEnumerable().Reverse())
        {
          if (Rocket.TryAttach(elPlanet))
          {
            break;
          }
        }
      }
    }

    /// <summary>
    /// Передвигает камеру
    /// </summary>
    private void MoveCamera()
    {
      if (Rocket.Location == null)
      {
        _xCameraMustOffset = Rocket.Position.X - _startOffsetX;
      }
      else
      {
        Planet loc = Rocket.Location;
        if (loc != null)
        {
          _xCameraMustOffset = loc.Position.X - _startOffsetX;
        }
      }

      _xCameraOffset += (_xCameraMustOffset - _xCameraOffset) / 1000000;
    }

    /// <summary>
    /// Проверяет коллиции объектов
    /// </summary>
    private bool CheckCollisions()
    {
      if (Sun.IsCollideWith(Rocket))
      {
        return true;
      }

      if (TopAsteroidBelt.IsCollideWith(Rocket))
      {
        return true;
      }

      if (BottomAsteroidBelt.IsCollideWith(Rocket))
      {
        return true;
      }

      foreach (Planet elPlanet in _planets)
      {
        if (elPlanet.IsCollideWith(Rocket))
        {
          return true;
        }
      }

      return false;
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

﻿using Logic.Controllers;
using Logic.Models.Game;
using Logic.Utils;
using Logic.Views.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WpfApp.App;

namespace WpfApp.Views.Game
{
  /// <summary>
  /// Представление карты от Wpf
  /// </summary>
  public class MapViewWpf : MapView, IWpfItem
  {
    /// <summary>
    /// Относительные пути к изображениям
    /// </summary>
    private static List<string> _imagesPath = new List<string>
    {
      "planet_1.png",
      "planet_2.png",
      "planet_3.png",
      "planet_4.png",
    };

    /// <summary>
    /// Путь к папке с изображениями
    /// </summary>
    private static string _imagesFolder = ImagesFolder.RelativePath;

    /// <summary>
    /// Главный контролл представления
    /// </summary>
    private Canvas _canvasControl = new Canvas();

    /// <summary>
    /// Изображение иконки паузы
    /// </summary>
    private Image _pauseImage = new Image();

    /// <summary>
    /// Изображение горячей клавиши для паузы
    /// </summary>
    private Label _pauseLabel = new Label();

    /// <summary>
    /// Canvas, представляющий объект
    /// </summary>
    public UIElement Control
    {
      get { return _canvasControl; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMap"></param>
    public MapViewWpf(Map parMap)
      : base(parMap)
    {
      ImageBrush imageBrush = new ImageBrush
      {
        ImageSource = new BitmapImage(new Uri(ImagesFolder.RelativePath + "space_background.jpg", UriKind.Relative)),
        Stretch = Stretch.UniformToFill
      };

      _canvasControl.Background = imageBrush;
      _canvasControl.Children.Add(_pauseImage);
      _canvasControl.Children.Add(_pauseLabel);

      _pauseImage.Stretch = System.Windows.Media.Stretch.Uniform;
      _pauseImage.Source = new BitmapImage(new Uri(ImagesFolder.RelativePath + "pause.png", UriKind.Relative));

      _pauseLabel.Content = "[Esc]";
      _pauseLabel.FontSize = 20;
      _pauseLabel.Foreground = Brushes.White;
      _pauseLabel.RenderTransform = new RotateTransform(-10);
    }

    /// <summary>
    /// Отрисовывает карту
    /// </summary>
    public override void Draw()
    {
      Vector2 parentSize = Parent.AbsoluteSize;

      _canvasControl.Width = parentSize.X;
      _canvasControl.Height = parentSize.Y;

      AbsoluteSize = new Vector2(_canvasControl.Width, _canvasControl.Height);

      _pauseImage.Height = _canvasControl.Height / 15;
      _pauseImage.Width = _pauseImage.Height;
      
      double scale = parentSize.Y / Map.Size.Y;

      Canvas.SetTop(_pauseImage, TopBeltView.AsteroidBelt.Size.Y * scale);

      _pauseLabel.FontSize = _pauseImage.Width / 2.5;
      Canvas.SetLeft(_pauseLabel, _pauseImage.Width * 0.9);
      Canvas.SetTop (_pauseLabel, TopBeltView.AsteroidBelt.Size.Y * scale);

      DrawChildren();
    }

    /// <summary>
    /// Создает представление ракеты от Wpf
    /// </summary>
    /// <returns>Представление ракеты от Wpf</returns>
    public override RocketView CreateRocketView()
    {
      RocketView rocketView = new RocketViewWpf(Map.Rocket);
      IWpfItem.AddChild(this, rocketView);

      return rocketView;
    }

    /// <summary>
    /// Создает представление стартовой планеты от Wpf
    /// </summary>
    /// <returns>Представление стартовой планеты от Wpf</returns>
    public override PlanetView CreateStartPlanetView()
    {
      PlanetView newStartPlanetView = new PlanetViewWpf(Map.StartPlanet, ImagesFolder.RelativePath + "start_planet.png");
      IWpfItem.AddChild(this, newStartPlanetView);

      return newStartPlanetView;
    }

    /// <summary>
    /// Создает представление генерируемой планеты от Wpf
    /// </summary>
    /// <param name="parPlanet">Модель планеты</param>
    /// <returns>Представление генерируемой планеты от Wpf</returns>
    public override PlanetView CreatePlanetView(Planet parPlanet)
    {
      PlanetView planetView = new PlanetViewWpf(parPlanet, _imagesFolder + _imagesPath[new Random().Next(_imagesPath.Count)]);

      parPlanet.Despawned += () =>
      {
        _canvasControl.Dispatcher.Invoke(() =>
        {
          IWpfItem.RemoveChild(this, planetView);
        });
      };

      return planetView;
    }

    /// <summary>
    /// Обрабатывает новое представление планеты
    /// </summary>
    /// <param name="parNewPlanet">Модель планеты</param>
    protected override void ProcessCreatePlanetView(Planet parNewPlanet)
    {
      _canvasControl.Dispatcher.Invoke(() =>
      {
        base.ProcessCreatePlanetView(parNewPlanet);
        if (PlanetsView.Last != null)
        {
          IWpfItem.AddChild(this, PlanetsView.Last.ValueRef);
        }
      });
    }

    /// <summary>
    /// Создает представление солнца от Wpf
    /// </summary>
    /// <returns>Представление солнца от Wpf</returns>
    public override SunView CreateSunView()
    {
      SunView sunView = new SunViewWpf(Map.Sun);
      IWpfItem.AddChild(this, sunView);

      return sunView;
    }

    /// <summary>
    /// Создает представление пояса астероидов от Wpf
    /// </summary>
    /// <param name="parAsteroidBelt">Модель пояса астероидов</param>
    /// <returns>Представление пояса астероидов от Wpf</returns>
    public override AsteroidBeltView CreateAsteroidBeltView(AsteroidBelt parAsteroidBelt)
    {
      AsteroidBeltView newAsteroidBeltView = new AsteroidBeltViewWpf(parAsteroidBelt);
      IWpfItem.AddChild(this, newAsteroidBeltView);

      return newAsteroidBeltView;
    }

    /// <summary>
    /// Сбрасывает представление карты от Wpf
    /// </summary>
    public override void Reset()
    {
      foreach (PlanetView elPlanetView in PlanetsView)
      {
        IWpfItem.RemoveChild(this, elPlanetView);
      }
      base.Reset();
    }

  }
}

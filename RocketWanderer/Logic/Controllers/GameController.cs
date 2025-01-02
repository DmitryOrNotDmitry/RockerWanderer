using Logic.Models.Game;
using Logic.Models.Menus;
using Logic.Models.Pause;
using Logic.Models.Windows;
using Logic.Utils;
using Logic.Views.Game;
using Logic.Views.Menus;
using Logic.Views.Screens;
using Logic.Views.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Controllers
{
  /// <summary>
  /// Контроллер для процесса игры
  /// </summary>
  public abstract class GameController : BaseController
  {
    /// <summary>
    /// Рассчитываются ли сейчас данные игры
    /// </summary>
    private bool _isGameProcessed = false;

    /// <summary>
    /// На паузе ли сейчас игра
    /// </summary>
    private bool _isGamePaused = false;

    /// <summary>
    /// Модель карты
    /// </summary>
    private Map _map;

    /// <summary>
    /// Представление карты
    /// </summary>
    private MapView _mapView;

    /// <summary>
    /// Модель меню паузы
    /// </summary>
    private PauseMenu _pauseMenu;

    /// <summary>
    /// Представление меню паузы
    /// </summary>
    private MenuView _pauseMenuView;

    /// <summary>
    /// Главное окно приложения
    /// </summary>
    private WindowData _window;

    /// <summary>
    /// Модель очков игрока
    /// </summary>
    private Scores _scores;

    /// <summary>
    /// Представление очков игрока
    /// </summary>
    private ScoresView _scoresView;

    /// <summary>
    /// Модель очков игрока
    /// </summary>
    public Scores Scores
    {
      get { return _scores; }
    }

    /// <summary>
    /// Представление очков игрока
    /// </summary>
    public ScoresView ScoresView
    {
      get { return _scoresView; }
    }

    /// <summary>
    /// Модель карты
    /// </summary>
    public Map Map
    {
      get { return _map; }
    }

    /// <summary>
    /// Представление карты
    /// </summary>
    public MapView MapView
    {
      get { return _mapView; }
    }

    /// <summary>
    /// Модель меню паузы
    /// </summary>
    public PauseMenu PauseMenu
    {
      get { return _pauseMenu; }
    }

    /// <summary>
    /// Представление меню паузы
    /// </summary>
    public MenuView PauseMenuView
    {
      get { return _pauseMenuView; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public GameController(WindowView parWindowView) 
    {
      _window = parWindowView.Window;

      _map = new Map(new Vector2(1920, 1080));
      _mapView = CreateMapView();

      Map.Rocket.Destroyed += StopGame;

      _window.ScreenChanged += 
        (parScreenType) =>
      {
        if (parScreenType == ScreenType.Game)
        {
          Map.Reset();
          RunGameCalculating();
        }
      };


      _pauseMenu = new PauseMenu();

      _pauseMenu.AddItem(new MenuItem(MenuItemAction.Resume, "Продолжить"));
      _pauseMenu.AddItem(new MenuItem(MenuItemAction.Back, "Главное меню"));

      _pauseMenu[MenuItemAction.Resume].Selected += OnPauseAction;
      _pauseMenu[MenuItemAction.Back].Selected += StopGame;


      _pauseMenuView = CreatePauseMenuView();

      foreach (MenuItem elMenuItem in PauseMenu.Items)
      {
        (PauseMenuView[elMenuItem.Action]).Enter += (action) =>
        {
          PauseMenu.Focus(action);
          PauseMenu.SelectFocusedItem();
          PauseMenu.Unfocus();
        };

        (PauseMenuView[elMenuItem.Action]).Focused += PauseMenu.Focus;
      }

      _scores = new Scores();
      _scoresView = CreateScoresView();
    }

    /// <summary>
    /// Запускает отдельный поток с вычислением данных игры
    /// </summary>
    private void RunGameCalculating()
    {
      Task.Run(() =>
      {
        _isGamePaused = false;
        _isGameProcessed = true;

        Stopwatch stopwatch = Stopwatch.StartNew();
        double lastFrameTime = stopwatch.Elapsed.TotalSeconds;
        double currentFrameTime = 0;

        while (_isGameProcessed && !_isGamePaused)
        {
          currentFrameTime = stopwatch.Elapsed.TotalSeconds;

          Map.Update(currentFrameTime - lastFrameTime);
          Scores.Current = (int)Map.XMustCameraOffset;

          lastFrameTime = currentFrameTime;
        }

      });
    }

    /// <summary>
    /// Заканчивает рассчет логики игровых объектов
    /// </summary>
    private void StopGame()
    {
      _isGamePaused = false;
      PauseMenu.IsEnabled = false;
      _isGameProcessed = false;
      _window.ChangeScreen(ScreenType.MainMenu);
    }

    /// <summary>
    /// Запускает отстыковывание ракеты по действию пользователя
    /// </summary>
    public void RocketDepartAction()
    {
      if (_isGameProcessed)
      {
        Map.RocketDepart();
      }
    }

    /// <summary>
    /// Останавливает/возобновляет игру по действию пользователя
    /// </summary>
    public void OnPauseAction()
    {
      if (_isGameProcessed)
      {
        PauseMenu.IsEnabled = !PauseMenu.IsEnabled;

        if (_isGamePaused)
        {
          RunGameCalculating();
        }
        else
        {
          _isGamePaused = true;
        }
      }
    }

    /// <summary>
    /// Создает представление карты
    /// </summary>
    /// <returns>Представление карты</returns>
    public abstract MapView CreateMapView();

    /// <summary>
    /// Создает представление меню паузы
    /// </summary>
    /// <returns>Представление меню паузы</returns>
    public abstract MenuView CreatePauseMenuView();

    /// <summary>
    /// Создает представление очков игрока
    /// </summary>
    /// <returns>Представление очков игрока</returns>
    public abstract ScoresView CreateScoresView();

  }
}

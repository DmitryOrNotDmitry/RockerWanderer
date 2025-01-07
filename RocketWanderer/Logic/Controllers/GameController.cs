using Logic.Models.Game;
using Logic.Models.Menus;
using Logic.Models.Menus;
using Logic.Models.Screens;
using Logic.Models.Windows;
using Logic.Records;
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
    /// Не закончена ли сейчас игра
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
    private SwitchedMenu _pauseMenu;

    /// <summary>
    /// Представление меню паузы
    /// </summary>
    private MenuView _pauseMenuView;

    /// <summary>
    /// Модель меню конца игры
    /// </summary>
    private SwitchedMenu _gameOverMenu;

    /// <summary>
    /// Представление меню конца игры
    /// </summary>
    private GameOverMenuView _gameOverMenuView;

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
    /// Настройки игрока
    /// </summary>
    private PlayerSettings _playerSettings;

    /// <summary>
    /// Таблица рекордов
    /// </summary>
    private RecordsTable _recordsTable;

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
    public SwitchedMenu PauseMenu
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
    /// Модель меню конца игры
    /// </summary>
    public SwitchedMenu GameOverMenu
    {
      get { return _gameOverMenu;}
    }

    /// <summary>
    /// Представление меню конца игры
    /// </summary>
    public GameOverMenuView GameOverMenuView
    {
      get { return _gameOverMenuView; }
    }

    /// <summary>
    /// Настройки игрока
    /// </summary>
    public PlayerSettings PlayerSettings
    {
      get { return _playerSettings; }
      set { _playerSettings = value; }
    }

    /// <summary>
    /// Таблица рекордов
    /// </summary>
    public RecordsTable RecordsTable
    {
      get { return _recordsTable; }
      set { _recordsTable = value; }
    }

    /// <summary>
    /// Не закончена ли сейчас игра
    /// </summary>
    protected bool IsGameProcessed
    {
      get { return _isGameProcessed; }
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


      _pauseMenu = new SwitchedMenu();

      _pauseMenu.AddItem(new MenuItem(MenuItemAction.Resume, "Продолжить"));
      _pauseMenu.AddItem(new MenuItem(MenuItemAction.Back, "Закончить игру"));

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


      _gameOverMenu = new SwitchedMenu();
      
      _gameOverMenu.AddItem(new MenuItem(MenuItemAction.NewGame, "Заново"));
      _gameOverMenu.AddItem(new MenuItem(MenuItemAction.Back, "Главное меню"));

      _gameOverMenu[MenuItemAction.NewGame].Selected += () =>
      {
        GameOverMenu.IsEnabled = false;
        _window.ChangeScreen(ScreenType.Game);
      };

      _gameOverMenu[MenuItemAction.Back].Selected += () =>
      {
        GameOverMenu.IsEnabled = false;
        _window.ChangeScreen(ScreenType.MainMenu);
      };

      _gameOverMenuView = CreateGameOverMenuView();

      foreach (MenuItem elMenuItem in GameOverMenu.Items)
      {
        (GameOverMenuView[elMenuItem.Action]).Enter += (action) =>
        {
          GameOverMenu.Focus(action);
          GameOverMenu.SelectFocusedItem();
          GameOverMenu.Unfocus();
        };

        (GameOverMenuView[elMenuItem.Action]).Focused += GameOverMenu.Focus;
      }
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

          Redrawer.NeedRedraw = true;

          lastFrameTime = currentFrameTime;
        }

      });
    }

    /// <summary>
    /// Заканчивает рассчет логики игровых объектов
    /// </summary>
    protected virtual void StopGame()
    {
      GameOverMenu.IsEnabled = true;
      PauseMenu.IsEnabled = false;

      _isGamePaused = false;
      _isGameProcessed = false;

      _recordsTable.Add(new Record(PlayerSettings.Name, Scores.Current));

      GameOverMenu.Focus(MenuItemAction.NewGame);
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
    public virtual void OnPauseAction()
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
          PauseMenu.Focus(MenuItemAction.Resume);
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

    /// <summary>
    /// Создает представление меню конца игры
    /// </summary>
    /// <returns>Представление меню конца игры</returns>
    public abstract GameOverMenuView CreateGameOverMenuView();

  }
}

using Logic.Models.Screens;
using Logic.Models.Windows;
using Logic.Records;
using Logic.Views;
using Logic.Views.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Controllers
{
  /// <summary>
  /// Контроллер для экранов
  /// </summary>
  public abstract class ScreenController : BaseController
  {
    /// <summary>
    /// Представления экранов ассоциированные с типов экрана
    /// </summary>
    private Dictionary<ScreenType, BaseView> _screens;

    /// <summary>
    /// Экран главного меню
    /// </summary>
    private MainMenuScreen _mainMenuScreen;

    /// <summary>
    /// Представление экрана главного меню
    /// </summary>
    private MainMenuScreenView _mainMenuScreenView;

    /// <summary>
    /// Экран описания
    /// </summary>
    private DescriptionScreen _descriptionScreen;

    /// <summary>
    /// Представление экрана описания
    /// </summary>
    private DescriptionScreenView _descriptionScreenView;

    /// <summary>
    /// Экран рекордов
    /// </summary>
    private RecordsScreen _recordsScreen;

    /// <summary>
    /// Представление экрана рекордов
    /// </summary>
    private RecordsScreenView _recordsScreenView;

    /// <summary>
    /// Экран игры
    /// </summary>
    private GameScreen _gameScreen;

    /// <summary>
    /// Представление экрана игры
    /// </summary>
    private GameScreenView _gameScreenView;

    /// <summary>
    /// Экран главного меню
    /// </summary>
    public MainMenuScreen MainMenuScreen
    {
      get { return _mainMenuScreen; }
    }

    /// <summary>
    /// Представление экрана главного меню
    /// </summary>
    public MainMenuScreenView MainMenuScreenView
    {
      get { return _mainMenuScreenView; }
    }

    /// <summary>
    /// Экран описания
    /// </summary>
    public DescriptionScreen DescriptionScreen
    {
      get { return _descriptionScreen; }
    }

    /// <summary>
    /// Представление экрана описания
    /// </summary>
    public DescriptionScreenView DescriptionScreenView
    {
      get { return _descriptionScreenView; }
    }

    /// <summary>
    /// Экран рекордов
    /// </summary>
    public RecordsScreen RecordsScreen
    {
      get { return _recordsScreen; }
    }

    /// <summary>
    /// Представление экрана рекордов
    /// </summary>
    public RecordsScreenView RecordsScreenView
    {
      get { return _recordsScreenView; }
    }

    /// <summary>
    /// Экран игры
    /// </summary>
    public GameScreen GameScreen
    {
      get { return _gameScreen; }
    }

    /// <summary>
    /// Представление экрана игры
    /// </summary>
    public GameScreenView GameScreenView
    {
      get { return _gameScreenView; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parWindowData">Модель окна</param>
    public ScreenController(WindowData parWindowData)
    {
      _mainMenuScreen = new MainMenuScreen("RocketWanderer");
      _descriptionScreen = new DescriptionScreen(
        """
        В данной игре вам предстоит управлять космическим кораблем, который может перемещаться между орбитами планет. Управление кораблем происходит с помощью кнопки «Пробел», при нажатии на который корабль перестает двигаться по орбите и начинает двигаться по прямой. Ваша задача – попасть кораблем на орбиту другой планеты. Игра заканчивается, когда корабль врезается в планету, солнце или поток астероидов.
        """
        );
      _recordsScreen = new RecordsScreen();
      _gameScreen = new GameScreen();

      _descriptionScreenView = CreateDescriptionScreenView(parWindowData);
      _mainMenuScreenView = CreateMainMenuScreenView();
      _recordsScreenView = CreateRecordsScreenView(parWindowData);
      _gameScreenView = CreateGameScreenView();

      _screens = new Dictionary<ScreenType, BaseView>();
      _screens.Add(ScreenType.MainMenu, MainMenuScreenView);
      _screens.Add(ScreenType.Description, DescriptionScreenView);
      _screens.Add(ScreenType.Records, RecordsScreenView);
      _screens.Add(ScreenType.Game, GameScreenView);

      parWindowData.ScreenChanged += ChangeScreen;
    }

    /// <summary>
    /// Возвращает представление экран
    /// </summary>
    /// <param name="parType">Тип экрана</param>
    /// <returns>Представление экрана по типу</returns>
    protected BaseView GetScreen(ScreenType parType)
    {
      return _screens[parType];
    }

    /// <summary>
    /// Создает представление экрана главного меню
    /// </summary>
    /// <returns>Представление экрана главного меню</returns>
    public abstract MainMenuScreenView CreateMainMenuScreenView();

    /// <summary>
    /// Создает представление экрана описания
    /// </summary>
    /// <param name="parWindowData">Модель окна</param>
    /// <returns>Представление экрана описания</returns>
    public abstract DescriptionScreenView CreateDescriptionScreenView(WindowData parWindowData);

    /// <summary>
    /// Создает представление экрана рекордов
    /// </summary>
    /// <param name="parWindowData">Модель окна</param>
    /// <returns>Представление экрана рекордов</returns>
    public abstract RecordsScreenView CreateRecordsScreenView(WindowData parWindowData);

    /// <summary>
    /// Создает представление экрана игры
    /// </summary>
    /// <returns>Представление экрана игры</returns>
    public abstract GameScreenView CreateGameScreenView();

    /// <summary>
    /// Сменяет экран приложения
    /// </summary>
    /// <param name="parNewScreenType">Новый тип экрана</param>
    public abstract void ChangeScreen(ScreenType parNewScreenType);

    
  }
}

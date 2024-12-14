using Logic.Models.Screens;
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
    /// Конструктор
    /// </summary>
    public ScreenController()
    {
      _mainMenuScreen = new MainMenuScreen("RocketWanderer");
      _descriptionScreen = new DescriptionScreen(
        """
        В данной игре вам предстоит управлять космическим кораблем, который может перемещаться между орбитами планет. Управление кораблем происходит с помощью кнопки «Пробел», при нажатии на который корабль перестает двигаться по орбите и начинает двигаться по прямой. Ваша задача – попасть кораблем на орбиту другой планеты. Игра заканчивается, когда корабль врезается в планету, солнце или поток астероидов.
        """
        );

      _descriptionScreenView = CreateDescriptionScreenView();
      _mainMenuScreenView = CreateMainMenuScreenView();
    }

    /// <summary>
    /// Создает представление экрана главного меню
    /// </summary>
    /// <returns>Представление экрана главного меню</returns>
    public abstract MainMenuScreenView CreateMainMenuScreenView();

    /// <summary>
    /// Создает представление экрана описания
    /// </summary>
    /// <returns>Представление экрана описания</returns>
    public abstract DescriptionScreenView CreateDescriptionScreenView();
  }
}

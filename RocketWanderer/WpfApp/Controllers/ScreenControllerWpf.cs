using Logic.Controllers;
using Logic.Models.Menus;
using Logic.Models.Windows;
using Logic.Utils;
using Logic.Views;
using Logic.Views.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Views;
using WpfApp.Views.Menus;
using WpfApp.Views.Screens;
using WpfApp.Views.Windows;

namespace WpfApp.Controllers
{
  /// <summary>
  /// Контроллер для экрана от WPF
  /// </summary>
  public class ScreenControllerWpf : ScreenController
  {
    /// <summary>
    /// Модель кнопки "Назад"
    /// </summary>
    private MenuItem _backButton;

    /// <summary>
    /// Представление кнопки "Назад"
    /// </summary>
    private MenuItemViewWpf _backButtonView;

    /// <summary>
    /// Конструктор
    /// </summary>
    public ScreenControllerWpf(WindowViewWpf parAppWindowView)
    {
      parAppWindowView.AddChild(MainMenuScreenView);
      ((IWpfItem)parAppWindowView).SetChild((IWpfItem)MainMenuScreenView);

      parAppWindowView.Window.ScreenChanged += (ScreenType parNewScreen) =>
      {
        if (parNewScreen == ScreenType.MainMenu)
        {
          ChangeScreen(parAppWindowView, MainMenuScreenView);
        }

        if (parNewScreen == ScreenType.Description)
        {
          ChangeScreen(parAppWindowView, DescriptionScreenView);
        }

        if (parNewScreen == ScreenType.Records)
        {
          ChangeScreen(parAppWindowView, RecordsScreenView);
        }

        //if (parNewScreen == ScreenType.Game)
        //{
        //  // Окно для ...
        //}
      };

      ConfigureBackButton(parAppWindowView);
    }

    /// <summary>
    /// Настраивает кнопку "Назад"
    /// </summary>
    /// <param name="parAppWindowView">Окно приложения</param>
    private void ConfigureBackButton(WindowViewWpf parAppWindowView)
    {
      _backButton = new MenuItem(MenuItemAction.Back, "Назад");
      _backButtonView = new MenuItemViewWpf(_backButton);
      _backButtonView.Size = new UDim2(0.16, 0.09);

      _backButtonView.Enter += (action) =>
      {
        _backButton.State = MenuItemState.Selected;
        parAppWindowView.Draw(null);
      };

      _backButtonView.Focused += (action) =>
      {
        _backButton.State = MenuItemState.Focused;
        parAppWindowView.Draw(null);
      };

      _backButton.Selected += () =>
      {
        parAppWindowView.Window.ChangeScreen(ScreenType.MainMenu);
      };

      //DescriptionScreenView.AddChild(_backButtonView);
      //RecordsScreenView.AddChild(_backButtonView);
    }

    /// <summary>
    /// Сменяет экран приложения
    /// </summary>
    /// <param name="parWindowViewWpf">Окно приложения</param>
    /// <param name="parScreen">Экран, на который требуется перейти</param>
    private void ChangeScreen(WindowViewWpf parWindowViewWpf, BaseView parScreen)
    {
      ((IWpfItem)DescriptionScreenView).RemoveChild(_backButtonView);
      ((IWpfItem)RecordsScreenView).RemoveChild(_backButtonView);

      _backButton.State = MenuItemState.Normal;
      ((IWpfItem)parScreen).AddChild(_backButtonView);

      ((IWpfItem)parWindowViewWpf).SetChild((IWpfItem)parScreen);
      parWindowViewWpf.Draw(null);

      parWindowViewWpf.RemoveChildren();
      parWindowViewWpf.AddChild(parScreen);
    }

    /// <summary>
    /// Создает представление экрана описания от Wpf
    /// </summary>
    /// <returns>Представление экрана описания</returns>
    public override DescriptionScreenView CreateDescriptionScreenView()
    {
      return new DescriptionScreenViewWpf(DescriptionScreen);
    }

    /// <summary>
    /// Создает предстваление экрана главного меню от Wpf
    /// </summary>
    /// <returns>Предстваление экрана главного меню</returns>
    public override MainMenuScreenView CreateMainMenuScreenView()
    {
      return new MainMenuScreenViewWpf(MainMenuScreen);
    }

    /// <summary>
    /// Создает представление экрана рекордов от Wpf
    /// </summary>
    /// <returns>Представление экрана рекордов от Wpf</returns>
    public override RecordsScreenView CreateRecordsScreenView()
    {
      return new RecordsScreenViewWpf(RecordsScreen);
    }
  }
}

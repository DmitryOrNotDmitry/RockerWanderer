using Logic.Models.Screens;
using Logic.Models.Windows;
using Logic.Utils;
using Logic.Views.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using WpfApp.Views.Windows;

namespace WpfApp.Views.Screens
{
  /// <summary>
  /// Представление экрана главного меню от WPF
  /// </summary>
  public class DescriptionScreenViewWpf : DescriptionScreenView, IWpfItem
  {
    /// <summary>
    /// Главный контролл представления
    /// </summary>
    private Canvas _canvasControl = new Canvas();

    /// <summary>
    /// Элемент отображения описания игры
    /// </summary>
    private TextBlock _descriptionControl = new TextBlock();

    /// <summary>
    /// Элемент отображения строки заголовка
    /// </summary>
    private TextBlock _descriptionCapture = new TextBlock();

    /// <summary>
    /// Представление кнопки "Назад"
    /// </summary>
    private BackButtonView _backButtonView;

    public UIElement Control
    {
      get { return _canvasControl; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMainMenuScreen">Модель экрана главного меню</param>
    public DescriptionScreenViewWpf(DescriptionScreen parDescriptionScreen, WindowData windowData)
      : base(parDescriptionScreen)
    {
      Size = new UDim2(1, 1);

      _descriptionCapture.Text = "Описание";
      _descriptionCapture.FontSize = 40;
      _canvasControl.Children.Add(_descriptionCapture);

      DecorateDescriptionText(parDescriptionScreen.GameDescription);

      _descriptionControl.FontSize = 20;
      _descriptionControl.TextWrapping = TextWrapping.Wrap;
      _descriptionControl.TextAlignment = TextAlignment.Justify;
      _canvasControl.Children.Add(_descriptionControl);

      _backButtonView = new BackButtonView(windowData);

      IWpfItem.AddChild(this, _backButtonView);
    }

    /// <summary>
    /// Форматирует текст описания (выделяет ключевые слова жирным)
    /// </summary>
    /// <param name="parGameDescription">Текст описания</param>
    private void DecorateDescriptionText(string parGameDescription)
    {
      string boldText = "«Пробел»";
      int boldTextIndexStart = parGameDescription.IndexOf(boldText);

      if (boldTextIndexStart < 0)
      {
        _descriptionControl.Inlines.Add(new Run(parGameDescription));
      }
      else
      {
        _descriptionControl.Inlines.Add(
          new Run(parGameDescription.Substring(0, boldTextIndexStart))
        );

        _descriptionControl.Inlines.Add(
          new Run(boldText)
          {
            FontWeight = FontWeights.Bold
          }
        );

        int part2Idx = boldTextIndexStart + boldText.Length;
        _descriptionControl.Inlines.Add(
          new Run(parGameDescription.Substring(part2Idx, parGameDescription.Length - part2Idx))
        );
      }
    }

    /// <summary>
    /// Отрисовывает элемент
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;

      Canvas.SetLeft(_descriptionCapture, parentSize.X / 2 - parentSize.X * 0.25);
      Canvas.SetTop(_descriptionCapture, parentSize.Y * 0.22);

      UDim2 descriptionControlSize = new UDim2(0.8, 0.6);

      _descriptionControl.Width  = parentSize.X * descriptionControlSize.X.Scale;
      _descriptionControl.Height = parentSize.Y * descriptionControlSize.Y.Scale;

      Canvas.SetLeft(_descriptionControl,parentSize.X / 2 - _descriptionControl.Width / 2);
      Canvas.SetTop(_descriptionControl, parentSize.Y / 2 - _descriptionControl.Height / 2 + parentSize.Y * 0.1);

      DrawChildren();
    }
  }
}

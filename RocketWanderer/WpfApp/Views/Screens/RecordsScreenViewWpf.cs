using Logic.Models.Screens;
using Logic.Utils;
using Logic.Views.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Logic.Models.Windows;

namespace WpfApp.Views.Screens
{
  /// <summary>
  /// Представление экрана рекордов от Wpf
  /// </summary>
  public class RecordsScreenViewWpf : RecordsScreenView, IWpfItem
  {
    /// <summary>
    /// Главный контролл представления
    /// </summary>
    private Canvas _canvasControl = new Canvas();

    /// <summary>
    /// Элемент отображения строки заголовка
    /// </summary>
    private TextBlock _recordsCapture = new TextBlock();

    /// <summary>
    /// Представление кнопки "Назад"
    /// </summary>
    private BackButtonView _backButtonView;

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
    /// <param name="parRecordsScreen"></param>
    public RecordsScreenViewWpf(RecordsScreen parRecordsScreen, WindowData parWindowData) 
      : base(parRecordsScreen)
    {
      Size = new UDim2(1, 1);

      _recordsCapture.Text = "Рекорды";
      _recordsCapture.FontSize = 40;
      _canvasControl.Children.Add(_recordsCapture);

      _backButtonView = new BackButtonView(parWindowData);

      IWpfItem.AddChild(this, _backButtonView);
      IWpfItem.AddChild(this, RecordsTableView);
    }

    /// <summary>
    /// Отображает экран рекордов
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;

      Canvas.SetLeft(_recordsCapture, parentSize.X / 2 - parentSize.X * 0.25);
      Canvas.SetTop(_recordsCapture, parentSize.Y * 0.22);

      DrawChildren();
    }

    /// <summary>
    /// Создает представление таблицы рекордов от Wpf
    /// </summary>
    /// <returns>Представление таблицы рекордов от Wpf</returns>
    public override RecordsTableView CreateRecordsTableView()
    {
      return new RecordsTableViewWpf(new RecordsTable());
    }
  }
}

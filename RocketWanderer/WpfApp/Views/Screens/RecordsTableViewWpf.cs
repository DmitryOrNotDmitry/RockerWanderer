using Logic.Models.Screens;
using Logic.Records;
using Logic.Utils;
using Logic.Views.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp.Views.Screens
{
  /// <summary>
  /// Представление таблицы рекордов от Wpf
  /// </summary>
  public class RecordsTableViewWpf : RecordsTableView, IWpfItem
  {
    /// <summary>
    /// Элемент с прокруткой
    /// </summary>
    private ScrollViewer _scrollViewer;
    
    /// <summary>
    /// Панель для таблицы рекордов
    /// </summary>
    private StackPanel _stackPanel;

    /// <summary>
    /// ScrollView, определяющий элемент
    /// </summary>
    public UIElement Control
    {
      get { return _scrollViewer; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parRecordsTable"></param>
    public RecordsTableViewWpf(RecordsTable parRecordsTable)
      : base(parRecordsTable)
    {
      _stackPanel = new StackPanel();
      _stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
      _stackPanel.VerticalAlignment = VerticalAlignment.Stretch;

      UpdateRecords();

      _scrollViewer = new ScrollViewer();
      _scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
      _scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
      _scrollViewer.Content = _stackPanel;

      RecordsTable.RecordAdded += UpdateRecords;

      Size = new UDim2(0.5, 0.5);
    }

    /// <summary>
    /// Синхронизирует данные из модели данных о рекордах с представлдением
    /// </summary>
    private void UpdateRecords()
    {
      _stackPanel.Dispatcher.Invoke(() =>
      {
        _stackPanel.Children.Clear();

        Brush evenBrush = new SolidColorBrush(Color.FromRgb(217, 217, 217));
        Brush oddBrush = new SolidColorBrush(Color.FromRgb(235, 232, 232));

        int i = 0;

        foreach (Record elRecord in RecordsTable.OrderedRecords)
        {
          Label labelRecord = new Label();
          labelRecord.Content = $"Ник: {elRecord.Name} | очки: {elRecord.Score}";

          labelRecord.HorizontalContentAlignment = HorizontalAlignment.Center;
          labelRecord.VerticalContentAlignment = VerticalAlignment.Center;

          labelRecord.HorizontalAlignment = HorizontalAlignment.Stretch;
          labelRecord.Height = 50;
          labelRecord.FontSize = 30;

          labelRecord.Margin = new Thickness(3);

          if (i % 2 == 0)
          {
            labelRecord.Background = evenBrush;
          }
          else
          {
            labelRecord.Background = oddBrush;
          }

          _stackPanel.Children.Add(labelRecord);

          i++;
        }
      });
    }

    /// <summary>
    /// Отрисовывает таблицу рекордов
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;
      Vector2 tableSize = AbsoluteSize;

      _scrollViewer.Width = tableSize.X;
      _scrollViewer.Height = tableSize.Y;

      double leftOffset = parentSize.X / 2 - tableSize.X / 2;
      double topOffset = parentSize.Y / 2 - tableSize.Y / 2 + 40;

      System.Windows.Controls.Canvas.SetLeft(_scrollViewer, leftOffset);
      System.Windows.Controls.Canvas.SetTop(_scrollViewer, topOffset);
    }
  }
}

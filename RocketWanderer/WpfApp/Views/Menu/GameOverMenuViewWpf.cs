using Logic.Models.Game;
using Logic.Models.Menus;
using Logic.Utils;
using Logic.Views.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Effects;
using System.Windows.Media;

namespace WpfApp.Views.Menus
{
  /// <summary>
  /// Представление меню конца игры от Wpf
  /// </summary>
  public class GameOverMenuViewWpf : GameOverMenuView, IWpfItem
  {
    /// <summary>
    /// Контейнер для пунктов меню
    /// </summary>
    private System.Windows.Controls.StackPanel _stackPanel = null;

    /// <summary>
    /// Заголовок меню
    /// </summary>
    private System.Windows.Controls.Label _menuCapture;

    /// <summary>
    /// Оторажение набранных очков
    /// </summary>
    private System.Windows.Controls.Label _scoreLabel;

    /// <summary>
    /// Элемент WPF, представляющий данный объект
    /// </summary>
    public UIElement Control
    {
      get { return _stackPanel; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parMenu"></param>
    /// <param name="parScores"></param>
    public GameOverMenuViewWpf(Menu parMenu, Scores parScores)
      : base(parMenu, parScores)
    {
      Size = new UDim2(0.25, 0.40);

      _stackPanel = new System.Windows.Controls.StackPanel();
      _stackPanel.VerticalAlignment = VerticalAlignment.Center;
      _stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
      _stackPanel.Background = new SolidColorBrush(Color.FromArgb(128, 105, 105, 105));

      _menuCapture = new System.Windows.Controls.Label();
      _menuCapture.Content = "Игра окончена";
      _menuCapture.HorizontalContentAlignment = HorizontalAlignment.Center;
      _menuCapture.HorizontalAlignment = HorizontalAlignment.Stretch;
      _menuCapture.Foreground = Brushes.White;

      _menuCapture.Effect = new DropShadowEffect
      {
        Color = Colors.Gray,
        ShadowDepth = 4,
        BlurRadius = 8,
        Opacity = 0.8
      };

      _scoreLabel = new System.Windows.Controls.Label();
      _scoreLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
      _scoreLabel.HorizontalAlignment = HorizontalAlignment.Stretch;
      _scoreLabel.Foreground = Brushes.White;
      _scoreLabel.Effect = _menuCapture.Effect;

      _stackPanel.Children.Add(_menuCapture);
      _stackPanel.Children.Add(_scoreLabel);

      foreach (MenuItemViewWpf elViewMenuItem in Items)
      {
        elViewMenuItem.Size = new UDim2(0.90, 0.25);
        elViewMenuItem.Control.Effect = _menuCapture.Effect;
        
        IWpfItem.AddChild(this, elViewMenuItem);
      }
    }

    /// <summary>
    /// Отрисовывает меню
    /// </summary>
    public override void Draw()
    {
      if (((SwitchedMenu)Menu).IsEnabled)
      {
        Control.IsEnabled = true;
        Control.Visibility = Visibility.Visible;
        
        _menuCapture.FontSize = Math.Max(1, AbsoluteSize.Y / 7);
        _scoreLabel.FontSize = Math.Max(1, AbsoluteSize.Y / 10);
        _scoreLabel.Content = "Очки: " + Scores.Current;

        base.Draw();

        Vector2 parentSize = Parent.AbsoluteSize;

        Vector2 menuSize = AbsoluteSize;

        _stackPanel.Width = menuSize.X;
        _stackPanel.Height = menuSize.Y;

        Vector2 position = GetPosition(parentSize);

        System.Windows.Controls.Canvas.SetLeft(_stackPanel, position.X);
        System.Windows.Controls.Canvas.SetTop(_stackPanel, position.Y);

        DrawChildren();
      }
      else
      {
        Control.IsEnabled = false;
        Control.Visibility = Visibility.Hidden;
      }
    }

    /// <summary>
    /// Возвращает позицию меню
    /// </summary>
    /// <returns>Позицию меню</returns>
    protected Vector2 GetPosition(Vector2 parParentSize)
    {
      Vector2 menuSize = AbsoluteSize;

      double leftOffset = parParentSize.X / 2 - menuSize.X / 2;
      double topOffset = parParentSize.Y / 2 - menuSize.Y / 2;

      return new Vector2(leftOffset, topOffset);
    }

    /// <summary>
    /// Создает представление пункта меню от WPF
    /// </summary>
    /// <param name="parMenuItem">Модель пункта меню</param>
    /// <returns>Представление пункта меню</returns>
    public override MenuItemView CreateMenuItemView(MenuItem parMenuItem)
    {
      return new PauseMenuItemViewWpf(parMenuItem);
    }
  }
}

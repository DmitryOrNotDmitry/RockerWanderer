using Logic.Models.Screens;
using Logic.Utils;
using Logic.Views.Screens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp.Views.Screens
{
  public class PlayerSettingsViewWpf : PlayerSettingsView, IWpfItem
  {
    /// <summary>
    /// Панель для расположения элементов
    /// </summary>
    private StackPanel _panel;

    /// <summary>
    /// Элемент для ввода имени игрока
    /// </summary>
    private TextBox _playerNameInput;

    /// <summary>
    /// Элемент для отображения названия к элементу _playerNameInput
    /// </summary>
    private Label _playerNameLabel;

    /// <summary>
    /// StackPanel, представляющий объект
    /// </summary>
    public UIElement Control
    {
      get { return _panel; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlayerSettings">Модель настроек игрока</param>
    public PlayerSettingsViewWpf(PlayerSettings parPlayerSettings)
      : base(parPlayerSettings)
    {
      Size = new UDim2(0.2, 0.05);

      _panel = new StackPanel();
      _panel.Orientation = Orientation.Horizontal;

      const int fontSize = 30;
      
      _playerNameInput = new TextBox();
      _playerNameLabel = new Label();
      _playerNameLabel.VerticalAlignment = VerticalAlignment.Stretch;
      _playerNameLabel.HorizontalContentAlignment = HorizontalAlignment.Right;
      _playerNameLabel.VerticalContentAlignment = VerticalAlignment.Center;
      _playerNameLabel.Content = "Ник:";
      _playerNameLabel.FontSize = fontSize;
      _playerNameLabel.Target = _playerNameInput;
      _playerNameLabel.Margin = new Thickness(0, 0, 10, 0);
      _panel.Children.Add(_playerNameLabel);

      _playerNameInput.VerticalAlignment = VerticalAlignment.Stretch;
      _playerNameInput.HorizontalAlignment = HorizontalAlignment.Stretch;
      _playerNameInput.Text = PlayerSettings.Name;
      _playerNameInput.FontSize = fontSize;
      _playerNameInput.VerticalContentAlignment = VerticalAlignment.Center;
      _panel.Children.Add(_playerNameInput);

      _playerNameInput.LostFocus += (s, e) =>
      {
        PlayerSettings.Name = _playerNameInput.Text;
      };
    }

    /// <summary>
    /// Отрисовывает поле для изменения настроек игрока
    /// </summary>
    public override void Draw()
    {
      base.Draw();

      Vector2 parentSize = Parent.AbsoluteSize;
      Vector2 tableSize = AbsoluteSize;

      _playerNameLabel.Width = tableSize.X * 0.2;
      _playerNameInput.Width = tableSize.X - _playerNameLabel.Width - 20;

      _playerNameLabel.FontSize = parentSize.Y * 0.03;
      _playerNameInput.FontSize = parentSize.Y * 0.03;

      _panel.Width = tableSize.X;
      _panel.Height = tableSize.Y;

      double leftOffset = parentSize.X / 2 - tableSize.X / 2;
      double topOffset = parentSize.Y / 2 - tableSize.Y / 2 - parentSize.Y / 8;

      System.Windows.Controls.Canvas.SetLeft(_panel, leftOffset);
      System.Windows.Controls.Canvas.SetTop(_panel, topOffset);
    }
  }
}

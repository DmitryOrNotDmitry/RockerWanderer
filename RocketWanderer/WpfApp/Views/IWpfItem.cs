using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace WpfApp.Views
{
  /// <summary>
  /// Интерфейс для всех представлений WPF
  /// </summary>
  public interface IWpfItem
  {
    /// <summary>
    /// Элемент WPF, представляющий данный объект
    /// </summary>
    UIElement Control { get; }

    /// <summary>
    /// Добавляет дочерний объект
    /// </summary>
    /// <param name="childItem">дочерний объект</param>
    void AddChild(IWpfItem childItem)
    {
      if (Control is Panel panel)
      {
        panel.Children.Add(childItem.Control);
      }
    }

    /// <summary>
    /// Удаляет дочерний элемент
    /// </summary>
    /// <param name="deletedChild">Удаляемый элемент</param>
    void RemoveChild(IWpfItem deletedChild)
    {
      if (Control is Panel panel)
      {
        int t = panel.Children.IndexOf(deletedChild.Control);
        panel.Children.Remove(deletedChild.Control);
      }
    }

    /// <summary>
    /// Удаляет все дочерние элементы
    /// </summary>
    void RemoveChildren()
    {
      if (Control is Panel panel)
      {
        panel.Children.Clear();
      }
    }

    /// <summary>
    /// Устанавливает дочерний объект
    /// </summary>
    /// <param name="childItem">дочерний объект</param>
    void SetChild(IWpfItem childItem)
    {
      if (Control is ContentControl contentControl)
      {
        contentControl.Content = childItem.Control;
      }
    }
  }
}

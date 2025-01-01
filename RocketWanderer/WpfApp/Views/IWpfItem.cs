using Logic.Views;
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
    /// Устанавливает связи для родительского элементы и дочернего элемента
    /// </summary>
    /// <param name="parParentItem">Родительский элемент</param>
    /// <param name="parChildItem">Дочерний элемент</param>
    static void AddChild(BaseView parParentItem, BaseView parChildItem)
    {
      IWpfItem parent = (IWpfItem)parParentItem;
      IWpfItem child = (IWpfItem)parChildItem;

      if (parent.Control is Panel panel)
      {
        panel.Children.Add(child.Control);
      }
      else if (parent.Control is ContentControl contentControl)
      {
        parParentItem.RemoveChildren();
        contentControl.Content = child.Control;
      }

      parParentItem.AddChild(parChildItem);
    }

    /// <summary>
    /// Удаляет дочерний элемент
    /// </summary>
    public static void RemoveChild(BaseView parParentItem, BaseView parChildItem)
    {
      IWpfItem parent = (IWpfItem)parParentItem;
      IWpfItem child = (IWpfItem)parChildItem;

      if (parent.Control is Panel panel)
      {
        panel.Children.Remove(child.Control);
      }
      else if (parent.Control is ContentControl contentControl)
      {
        parParentItem.RemoveChildren();
        contentControl.Content = null;
      }

      parParentItem.RemoveChild(parChildItem);
    }

    /// <summary>
    /// Удаляет все дочерние элементы
    /// </summary>
    public void RemoveChildren()
    {
      if (Control is Panel panel)
      {
        panel.Children.Clear();
      }
    }
  }
}

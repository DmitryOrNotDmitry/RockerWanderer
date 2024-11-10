using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Menus
{
  /// <summary>
  /// Пункт меню
  /// </summary>
  public class MenuItem
  {
    /// <summary>
    /// Тип выполняемого дейсвия
    /// </summary>
    private MenuItemAction _action;

    /// <summary>
    /// Текущее состояние
    /// </summary>
    private MenuItemState _state;

    /// <summary>
    /// Название
    /// </summary>
    private readonly string _title;

    /// <summary>
    /// Делегат, представляющий метод, который будет вызываться при срабатывании события выбора
    /// </summary>
    public delegate void dSeleted();

    /// <summary>
    /// Событие, которое возникает при выборе
    /// </summary>
    public event dSeleted? Selected;

    /// <summary>
    /// Тип выполняемого дейсвия
    /// </summary>
    public MenuItemAction Action
    {
      get { return _action; }
    }

    /// <summary>
    /// Текущее состояние
    /// </summary>
    public MenuItemState State
    {
      get { return _state; }
      set 
      { 
        _state = value;
        if (_state == MenuItemState.Selected)
          Selected?.Invoke();
      }
    }

    /// <summary>
    /// Название
    /// </summary>
    public string Title
    {
      get { return _title; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parAction">Выполняемое действие</param>
    /// <param name="parTitle">Название</param>
    public MenuItem(MenuItemAction parAction, string parTitle)
    {
      _action = parAction;
      _title = parTitle;
    }
  }
}

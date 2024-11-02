using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Menus
{
  /// <summary>
  /// Меню, по которому можно перемещаться вперед и назад
  /// </summary>
  public class NavigatedMenu : Menu
  {
    /// <summary>
    /// Массив действий, упорядоченный по добавлению пунктов меню
    /// </summary>
    private List<MenuItemAction> _actionsOrder = new();

    /// <summary>
    /// Добавляет новый пункт меню
    /// </summary>
    /// <param name="parMenuItem">Новый пункт меню</param>
    public override void AddItem(MenuItem parMenuItem)
    {
      _actionsOrder.Add(parMenuItem.Action);
      base.AddItem(parMenuItem);
    }

    /// <summary>
    /// Устанавливает фокус на следующем пункте меню
    /// </summary>
    /// <param name="parStep">Шаг, с которым вибирается следующий пункт</param>
    public void FocusNext(int parStep = 1)
    {
      if (Count == 0)
        return;

      if (FocusedAction.HasValue)
      {
        int focusedActionIdx = _actionsOrder.IndexOf(FocusedAction.Value);

        focusedActionIdx += parStep;
        while (focusedActionIdx < 0)
          focusedActionIdx += Count;

        focusedActionIdx %= Count;

        Focus(_actionsOrder[focusedActionIdx]);
      }
    }

    /// <summary>
    /// Устанавливает фокус на предыдущем пункте меню
    /// </summary>
    public void FocusPrev()
    {
      FocusNext(-1);
    }
  }
}

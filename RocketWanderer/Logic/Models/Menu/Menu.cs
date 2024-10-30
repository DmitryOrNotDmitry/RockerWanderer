using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models.Menu
{
    /// <summary>
    /// Меню
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Словарь пунктов меню, индексированных по действиям
        /// </summary>
        private Dictionary<MenuItemAction, MenuItem> _items = new();

        /// <summary>
        /// Текущее выбранное действие
        /// </summary>
        private MenuItemAction? _focusedAction = null;

        /// <summary>
        /// Текущее выбранное действие
        /// </summary>
        protected MenuItemAction? FocusedAction
        {
            get { return _focusedAction; }
            set { _focusedAction = value; }
        }

        /// <summary>
        /// Количество пунктов меню
        /// </summary>
        protected int Count
        {
            get { return _items.Count; }
        }

        /// <summary>
        /// Массив пунктов меню
        /// </summary>
        public MenuItem[] Items
        {
            get { return _items.Values.ToArray(); }
        }

        /// <summary>
        /// Поиск пункта меню по действию
        /// </summary>
        /// <param name="parAction">Действие, по которому будет происходить поиск</param>
        /// <returns>Пункт меню, выполняемый переданное действие</returns>
        public MenuItem this[MenuItemAction parAction]
        {
            get { return _items[parAction]; }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Menu() { }

        /// <summary>
        /// Добавляет новый пункт меню
        /// </summary>
        /// <param name="parMenuItem">Новый пункт меню</param>
        public virtual void AddItem(MenuItem parMenuItem)
        {
            _items.Add(parMenuItem.Action, parMenuItem);
        }

        /// <summary>
        /// Устанавливает фокус на пункте меню, который выполняет переданное действие
        /// </summary>
        /// <param name="parNewFocusedAction">Действие, на которое требуется установить фокус</param>
        public void Focus(MenuItemAction parNewFocusedAction)
        {
            if (_focusedAction.HasValue)
            {
                this[_focusedAction.Value].State = MenuItemState.Normal;
            }

            _focusedAction = parNewFocusedAction;
            this[_focusedAction.Value].State = MenuItemState.Focused;
        }

    }
}

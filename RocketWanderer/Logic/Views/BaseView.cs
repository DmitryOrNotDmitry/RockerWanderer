using Logic.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views
{
  /// <summary>
  /// Базовый класс всех представлений
  /// </summary>
  public abstract class BaseView
  {
    /// <summary>
    /// Размер представления
    /// </summary>
    private UDim2 _size = new UDim2(0, 0);

    /// <summary>
    /// Позиция представления
    /// </summary>
    // private UDim2 _position = new UDim2(0, 0);

    /// <summary>
    /// Размер представления
    /// </summary>
    public UDim2 Size 
    { 
      get { return _size; } 
      set { _size = value; }
    }

    /// <summary>
    /// Позиция представления
    /// </summary>
    //public UDim2 Position
    //{
    //  get { return _position; }
    //  set { _position = value; }
    //}

    /// <summary>
    /// Дочерние представления
    /// </summary>
    public List<BaseView> _children = new List<BaseView>();

    /// <summary>
    /// Добавляет новый дочерний объект
    /// </summary>
    /// <param name="parChild">Новый дочерний объект</param>
    public void AddChild(BaseView parChild)
    {
      _children.Add(parChild);
    }

    /// <summary>
    /// Отрисовывает представление
    /// </summary>
    /// <param name="parParentSize">Абсолютный размер родителя</param>
    public abstract void Draw(Vector2 parParentSize);

    /// <summary>
    /// Отрисовывает дочерние элементы
    /// </summary>
    /// <param name="parThisSize">Абсолютный размер текущего элемента</param>
    protected void DrawChildren(Vector2 parThisSize)
    {
      foreach (BaseView elChild in _children)
      {
        elChild.Draw(parThisSize);
      }
    }

    /// <summary>
    /// Рассчитывает абсолютный размер представления относительно родителя
    /// </summary>
    /// <param name="parParentSize">Размер родителя</param>
    /// <returns>Абсолютный размер представления</returns>
    protected Vector2 AbsoluteSize(Vector2 parParentSize)
    {
      int x = (int)(_size.X.Scale * parParentSize.X + _size.X.Offset);
      int y = (int)(_size.Y.Scale * parParentSize.Y + _size.Y.Offset);

      return new Vector2(x, y);
    }
  }
}

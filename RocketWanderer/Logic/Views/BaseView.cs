using Logic.Controllers;
using Logic.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

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
    private UDim2 _size = new UDim2(1, 1);

    /// <summary>
    /// Позиция представления
    /// </summary>
    private Vector2 _position = new Vector2(0, 0);

    /// <summary>
    /// Абсолютный размер представления
    /// </summary>
    private Vector2 _absoluteSize = new Vector2(0, 0);

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
    public Vector2 Position
    {
      get { return _position; }
      set { _position = value; }
    }

    /// <summary>
    /// Абсолютный размер представления
    /// </summary>
    public Vector2 AbsoluteSize
    {
      get { return _absoluteSize; }
      set { _absoluteSize = value; }
    }

    /// <summary>
    /// Родительский элемент
    /// </summary>
    private BaseView? _parent;

    /// <summary>
    /// Родительский элемент
    /// </summary>
    public BaseView? Parent
    {
      get { return _parent; }
      set { _parent = value; }
    }

    /// <summary>
    /// Дочерние представления
    /// </summary>
    private List<BaseView> _children = new List<BaseView>();

    /// <summary>
    /// Добавляет новый дочерний объект
    /// </summary>
    /// <param name="parChild">Новый дочерний объект</param>
    public void AddChild(BaseView parChild)
    {
      lock (_children)
      {
        parChild.Parent = this;
        _children.Add(parChild);
      }
    }

    /// <summary>
    /// Удаляет дочерний объект
    /// </summary>
    /// <param name="parChild">Удаляемый дочерний объект</param>
    public void RemoveChild(BaseView parChild)
    {
      lock (_children)
      {
        parChild.Parent = null;
        _children.Remove(parChild);
      }
    }

    /// <summary>
    /// Удаляет все дочерние элементы
    /// </summary>
    public void RemoveChildren()
    {
      lock (_children)
      {
        foreach (BaseView elChild in _children) 
        {
          elChild.Parent = null;
        }
        _children.Clear();
      }
    }

    /// <summary>
    /// Отрисовывает представление
    /// </summary>
    public virtual void Draw()
    {
      if (Parent == null)
      {
        _absoluteSize = new Vector2(0, 0);
        return;
      }

      Vector2 parentSize = Parent.AbsoluteSize;

      int x = (int)(_size.X.Scale * parentSize.X + _size.X.Offset);
      int y = (int)(_size.Y.Scale * parentSize.Y + _size.Y.Offset);

      _absoluteSize = new Vector2(x, y);
    }

    /// <summary>
    /// Отрисовывает дочерние элементы
    /// </summary>
    protected void DrawChildren()
    {
      lock (_children)
      {
        foreach (BaseView elChild in _children)
        {
          elChild.Draw();
        }
      }
    }

  }
}

﻿namespace Logic.Controllers
{
  /// <summary>
  /// Базовый класс для всех контроллеров
  /// </summary>
  public abstract class BaseController
  {
    /// <summary>
    /// Пустой конструктор
    /// </summary>
    public BaseController()
    {
    }

    /// <summary>
    /// Запуск контроллера
    /// </summary>
    public virtual void Start()
    {
      throw new NotImplementedException();
    }
  }
}

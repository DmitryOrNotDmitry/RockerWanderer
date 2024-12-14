using Logic.Models.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Screens
{
  /// <summary>
  /// Представление экрана описания
  /// </summary>
  public abstract class DescriptionScreenView : BaseView 
  {
    /// <summary>
    /// Модель экрана описания
    /// </summary>
    private DescriptionScreen _descriptionScreen;

    /// <summary>
    /// Модель экрана описания
    /// </summary>
    protected DescriptionScreen DescriptionScreen
    {
      get { return _descriptionScreen; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parDescriptionScreen">Модель экрана описания</param>
    public DescriptionScreenView(DescriptionScreen parDescriptionScreen)
    {
      _descriptionScreen = parDescriptionScreen;
    }
  }
}

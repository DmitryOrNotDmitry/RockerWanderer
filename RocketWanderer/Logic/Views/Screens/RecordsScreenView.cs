using Logic.Models.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Views.Screens
{
  /// <summary>
  /// Представление экрана рекордов
  /// </summary>
  public abstract class RecordsScreenView : BaseView
  {
    /// <summary>
    /// Модель экрана рекордов
    /// </summary>
    private RecordsScreen _recordsScreen;

    /// <summary>
    /// Модель экрана рекордов
    /// </summary>
    public RecordsScreen RecordsScreen
    {
      get { return _recordsScreen; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parRecordsScreen">Модель экрана рекордов</param>
    public RecordsScreenView(RecordsScreen parRecordsScreen)
    {
      _recordsScreen = parRecordsScreen;
    }

  }
}

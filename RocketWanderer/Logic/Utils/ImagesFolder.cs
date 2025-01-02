using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Utils
{
  /// <summary>
  /// Класс, хранящий путь к папке с изображениями
  /// </summary>
  public class ImagesFolder
  {
    /// <summary>
    /// Относительный путь к папке с изображениями
    /// </summary>
    private static string _path = "../../../Images/";

    /// <summary>
    /// Относительный путь к папке с изображениями
    /// </summary>
    public static string RelativePath
    {
      get { return _path; } 
    }

    /// <summary>
    /// Закрытый конструктор
    /// </summary>
    private ImagesFolder() { }
  }
}

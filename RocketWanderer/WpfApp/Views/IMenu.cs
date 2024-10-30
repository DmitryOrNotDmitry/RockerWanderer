using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Views
{
  public interface IMenu
  {
    void SetParentControl(FrameworkElement parControl);
  }
}

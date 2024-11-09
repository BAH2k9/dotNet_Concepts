using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockableTabsTest
{
    public class DataTabViewModel : Screen
    {
        public BindableCollection<DataGridViewModel> DataGridViewModels { get; set; }
        public DataTabViewModel()
        {
            DataGridViewModels = new BindableCollection<DataGridViewModel>
        {
            new DataGridViewModel(),
            new DataGridViewModel(),
            new DataGridViewModel(),
            new DataGridViewModel(),
        };
        }
    }
}

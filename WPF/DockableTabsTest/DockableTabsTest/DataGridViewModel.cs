using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockableTabsTest
{
    public class Model
    {
        public string Name
        { get; set; }
        public int Id
        { get; set; }
    }
    public class DataGridViewModel : Screen
    {
        public BindableCollection<Model> Data
        { get; set; }

        public DataGridViewModel()
        {
            Data = new BindableCollection<Model>()
            {
                new Model{Name = "Mirakin", Id=0},
                new Model{Name = "Bill Bazington", Id = 1},
                new Model{Name = "Bill", Id = 2},
            };
        }
    }
}

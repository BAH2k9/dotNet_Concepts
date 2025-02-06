using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vanilla_MVVM.Models;

namespace Vanilla_MVVM.ViewModels
{
    public class TableViewModel
    {
        public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();
        public TableViewModel()
        {
            var Person1 = new Person { Id = 1, Name = "Bob" };
            var Person2 = new Person { Id = 2, Name = "Rob" };
            var Person3 = new Person { Id = 3, Name = "Tod" };

            People.Add(Person1);
            People.Add(Person2);
            People.Add(Person3);
        }
    }
}

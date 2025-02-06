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
    public class TableViewModelV2 : INotifyPropertyChanged
    {
        private List<Person> _People;
        public List<Person> People
        {
            get { return _People; }
            set { _People = value; OnPropertyChanged(nameof(People)); }
        }
        public TableViewModelV2()
        {
            People = new List<Person>();

            var Person1 = new Person { Id = 1, Name = "Bob" };
            var Person2 = new Person { Id = 2, Name = "Rob" };
            var Person3 = new Person { Id = 3, Name = "Tod" };

            People.Add(Person1);
            People.Add(Person2);
            People.Add(Person3);

            People = NewPeople();
        }

        private List<Person> NewPeople()
        {
            People = new List<Person>();

            var Person1 = new Person { Id = 4, Name = "Bob2" };
            var Person2 = new Person { Id = 5, Name = "Rob2" };
            var Person3 = new Person { Id = 6, Name = "Tod2" };

            People.Add(Person1);
            People.Add(Person2);
            People.Add(Person3);

            return People;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

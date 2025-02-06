using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vanilla_MVVM.ViewModels;

namespace Vanilla_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TableViewModel DisplayViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            DisplayViewModel = new TableViewModel();
        }
    }
}
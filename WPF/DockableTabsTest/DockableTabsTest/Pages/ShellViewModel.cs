using Stylet;

namespace DockableTabsTest.Pages
{
    public class ShellViewModel : Screen
    {
        public DataGridViewModel DataGridViewModel
        { get; set; }

        public DataTabViewModel DataTabViewModel
        { get; set; }

        public ShellViewModel()
        {
            DataGridViewModel = new DataGridViewModel();


            DataTabViewModel = new DataTabViewModel();
        }
    }
}

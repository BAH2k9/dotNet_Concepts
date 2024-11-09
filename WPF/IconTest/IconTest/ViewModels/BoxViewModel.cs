using Stylet;

namespace IconTest.ViewModels
{
    public class BoxViewModel : Screen
    {
        ImageViewModel _ImageViewModel;
        public ImageViewModel ImageViewModel
        { get => _ImageViewModel; set => SetAndNotify(ref _ImageViewModel, value); }

        GraphViewModel _GraphViewModel;
        public GraphViewModel GraphViewModel
        { get => _GraphViewModel; set => SetAndNotify(ref _GraphViewModel, value); }

        public BoxViewModel()
        {
            _ImageViewModel = new ImageViewModel();

            _GraphViewModel = new GraphViewModel();
        }
    }
}

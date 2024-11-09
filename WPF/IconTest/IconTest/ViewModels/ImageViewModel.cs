using OxyPlot;
using OxyPlot.Series;
using Stylet;
using System.Threading.Tasks;
using System.Windows.Media;

namespace IconTest.ViewModels
{
    public class ImageViewModel : Screen
    {
        int _Index = 0;

        private ScaleTransform _T1;
        public ScaleTransform T1
        {
            get => _T1;
            set => SetAndNotify(ref _T1, value);
        }

        private Color _shadowColor = Colors.Black;
        public Color ShadowColor
        {
            get => _shadowColor;
            set => SetAndNotify(ref _shadowColor, value);
        }

        private double _blurRadius = 10;
        public double BlurRadius
        {
            get => _blurRadius;
            set => SetAndNotify(ref _blurRadius, value);
        }

        private double _shadowDepth = 5;
        public double ShadowDepth
        {
            get => _shadowDepth;
            set => SetAndNotify(ref _shadowDepth, value);
        }

        private double _shadowDirection = 315;
        public double ShadowDirection
        {
            get => _shadowDirection;
            set => SetAndNotify(ref _shadowDirection, value);
        }

        private double _shadowOpacity = 0.7;
        public double ShadowOpacity
        {
            get => _shadowOpacity;
            set => SetAndNotify(ref _shadowOpacity, value);
        }
        public ImageViewModel()
        {
            T1 = new(1, 1);
        }


        public async void Beat()
        {
            Execute.OnUIThread(() =>
            {
                T1 = new(1, 1);

            });

            await Task.Delay(400);


            Execute.OnUIThread(() =>
            {
                T1 = new(0.9, 0.9);

            });

        }
    }
}

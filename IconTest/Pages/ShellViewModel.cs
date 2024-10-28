using IconTest.ViewModels;
using Stylet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace IconTest.Pages
{
    public class ShellViewModel : Screen
    {

        BindableCollection<BoxViewModel> _Boxes;
        public BindableCollection<BoxViewModel> Boxes
        { get => _Boxes; set => SetAndNotify(ref _Boxes, value); }

        public ShellViewModel()
        {
            _Boxes = new BindableCollection<BoxViewModel>();


            AddImages(10);


        }

        async void AddImages(int number)
        {
            var count = 0;

            while (count < number)
            {
                await Task.Delay(100);

                Boxes.Add(new BoxViewModel());

                count++;
            }

            await Task.Delay(200);
            await AddPoints();
        }



        async Task AddPoints()
        {
            var count = 0;
            List<int> pointsToDraw = new() { 1, 1, 1, 2, 2, 2, 1, 1, 4, 4, 4, 4, 1, 1, 1, 1, 1 };

            while (count < pointsToDraw.Count)
            {
                foreach (BoxViewModel box in Boxes)
                {
                    box.GraphViewModel.AddPoint(pointsToDraw[count]);
                    box.GraphViewModel.Redraw();

                    box.ImageViewModel.Beat();
                }

                count++;
                await Task.Delay(1000);

            }
        }

    }
}

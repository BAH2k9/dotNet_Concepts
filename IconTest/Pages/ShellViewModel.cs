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

        BindableCollection<ImageViewModel> _Images;
        public BindableCollection<ImageViewModel> Images
        { get => _Images; set => SetAndNotify(ref _Images, value); }

        public ShellViewModel()
        {
            Images = new BindableCollection<ImageViewModel>();


            AddImages(4);


        }

        async void AddImages(int number)
        {
            var count = 0;

            while (count < number)
            {
                await Task.Delay(100);

                Images.Add(new ImageViewModel());

                count++;
            }

            await AddPoints();
        }



        async Task AddPoints()
        {
            var count = 0;
            List<int> pointsToDraw = new() { 1, 1, 1, 2, 2, 2, 1, 1, 4, 4, 4, 4, 1, 1, 1, 1, 1 };

            while (count < pointsToDraw.Count)
            {
                foreach (ImageViewModel Image in Images)
                {
                    Image.GraphViewModel.AddPoint(pointsToDraw[count]);
                    Image.GraphViewModel.Redraw();

                    Image.Beat();


                }




                count++;
                await Task.Delay(1000);

            }
        }

    }
}

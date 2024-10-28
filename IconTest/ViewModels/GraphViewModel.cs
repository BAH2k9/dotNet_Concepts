using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IconTest.ViewModels
{
    public class GraphViewModel : Screen
    {
        LineSeries _LineSeries;
        LinearAxis _AxisX;
        int _Index;
        PlotModel _Graph;
        public PlotModel Graph
        { get => _Graph; set => SetAndNotify(ref _Graph, value); }

        public GraphViewModel()
        {
            _LineSeries = CreateLineSeries();
            _AxisX = CreateAxisX();
            _Graph = new PlotModel();


            Graph.Series.Add(_LineSeries);
            Graph.Axes.Add(_AxisX);
            Graph.Axes.Add(CreateAxisY());

        }

        LinearAxis CreateAxisX()
        {
            var linearAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                AbsoluteMinimum = 0,
                Minimum = 0,
                Maximum = 10, // adjust based on expected data points
                MajorStep = 1,
                IsPanEnabled = true,
                IsZoomEnabled = true,


            };

            return linearAxis;
        }

        CategoryAxis CreateAxisY()
        {
            //var linearAxis = new LinearAxis
            //{
            //    Position = AxisPosition.Left,
            //    Minimum = 0,
            //    Maximum = 5,
            //    MajorStep = 1,
            //    MinorStep = 1,
            //    IsPanEnabled = false,
            //    IsZoomEnabled = false
            //};

            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                Key = "EnumAxis",
                ItemsSource = Enum.GetNames(typeof(Enums.Results)) // Map enum names as categories
            };
            return categoryAxis;
        }

        LineSeries CreateLineSeries()
        {
            LineSeries lineSeries = new()
            {
                Color = OxyColors.Blue,
                MarkerType = MarkerType.Circle,
                MarkerSize = 1,
                MarkerStroke = OxyColors.Blue
            };
            return lineSeries;
        }

        public void AddPoint(int y)
        {
            AutoPan();
            // Add two points to emulate zero order hold
            DataPoint point = new(_Index, y);
            DataPoint endPoint = new(_Index + 1, y);

            _LineSeries.Points.Add(point);
            _LineSeries.Points.Add(endPoint);

            _Index++;
        }

        private void AutoPan()
        {
            if (_Index > 10 - 2)
            {
                _AxisX.Maximum = _Index + 2;
                _AxisX.Minimum = _Index - 10 + 2;
            }


        }

        public void Redraw()
        {
            Graph.InvalidatePlot(true);
        }
    }
}

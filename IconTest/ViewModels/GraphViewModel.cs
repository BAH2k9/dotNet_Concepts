using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconTest.ViewModels
{
    public class GraphViewModel : Screen
    {
        LineSeries _LineSeries;
        int _Index;
        PlotModel _Graph;
        public PlotModel Graph
        { get => _Graph; set => SetAndNotify(ref _Graph, value); }

        public GraphViewModel()
        {
            _LineSeries = CreateLineSeries();
            _Graph = new PlotModel();


            Graph.Series.Add(_LineSeries);
            Graph.Axes.Add(CreateAxisX());
            Graph.Axes.Add(CreateAxisY());

        }

        Axis CreateAxisX()
        {
            var linearAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 10, // adjust based on expected data points
                MajorStep = 1,
                IsPanEnabled = true,
                IsZoomEnabled = true,


            };

            return linearAxis;
        }

        Axis CreateAxisY()
        {
            var linearAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = 0,
                Maximum = 5,
                MajorStep = 1,
                MinorStep = 1,
                IsPanEnabled = false,
                IsZoomEnabled = false
            };

            return linearAxis;
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
            // Add two points to emulate zero order hold
            DataPoint point = new(_Index, y);
            DataPoint endPoint = new(_Index + 1, y);

            _LineSeries.Points.Add(point);
            _LineSeries.Points.Add(endPoint);

            _Index++;
        }

        internal void Redraw()
        {
            Graph.InvalidatePlot(true);
        }
    }
}

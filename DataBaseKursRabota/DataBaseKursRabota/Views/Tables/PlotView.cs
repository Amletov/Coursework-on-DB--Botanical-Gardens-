using DataBaseKursRabota.Repositories;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace DataBaseKursRabota.Views.Tables
{
    public partial class PlotView : Form
    {
        private PlotModel _model;
        public PlotView(ObjToDiagram obj)
        {
            InitializeComponent();
            _model = new PlotModel
            {
                Title = obj.Title,
            };
            var values = new List<BarItem>();
            var headers = new List<string>();

            foreach (var item in obj.Values)
            {
                headers.Add(item.Key);
                values.Add(new BarItem { Value = item.Value });
            }
            var series = new BarSeries
            {
                LabelPlacement = LabelPlacement.Outside,
                LabelFormatString = "{0:.00}",
                ItemsSource = values
            };
            _model.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                Key = obj.Title.Replace(" ", ""),
                ItemsSource = headers.ToArray()
            });
            _model.Series.Add(series);
            queryPlotView.Model = _model;
            queryPlotView.Invalidate();
        }
    }
}

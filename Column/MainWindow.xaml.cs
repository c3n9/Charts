using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts.Definitions.Charts;

namespace Column
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var points = App.DB.PlayerStatistics.Where(ps => ps.MatchupId == 3).ToList();
            var seriesCollection = new SeriesCollection();
            foreach (var point in points)
            {
                var columnSeries = new ColumnSeries
                {
                    Title = point.Player.Name,
                    LabelPoint = chartPoint => point.Player.Name,
                    Values = new ChartValues<int>() { point.Point },
                    DataLabels = true,
                    ColumnPadding = 10,
                    Width = 450,
                };
                seriesCollection.Add(columnSeries);
            }
            ChartColumn.Series = seriesCollection;


        }
    }
}

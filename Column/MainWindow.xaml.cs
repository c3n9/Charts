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
using System.Globalization;

namespace Column
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> Labels { get; set; }
        public SeriesCollection seriesCollection { get; set; }

        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            Labels = new List<string>();
            var points = App.DB.PlayerStatistics.Where(ps => ps.MatchupId == 6).ToList();
            var value = new ChartValues<int>();
            foreach (var point in points)
            {
                value.Add(point.Point);
                Labels.Add(point.Player.Name);
            }
            seriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = value,
                    DataLabels = true,
                    Fill = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)))
                }
            };
            DataContext = this;
        }
    }
}

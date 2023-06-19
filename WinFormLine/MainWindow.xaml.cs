using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WinFormLine
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<int> values = new List<int>();
            var playerStatistics = App.DB.PlayerStatistics.Where(ps => ps.Player.PlayerId == 3).OrderBy(x=> x.Matchup.Starttime).ToList();
            var areaPoints = LineChart.ChartAreas.Add("PointArea");
            var seriaPoint = LineChart.Series.Add("pointsLine");
            seriaPoint.ChartType = SeriesChartType.Line;
            seriaPoint.BorderWidth = 5;
            var chartDataPoint = playerStatistics.GroupBy(x=>x.Matchup.Starttime.Date).ToDictionary(Key => Key.Key, Value => Value.Sum(v => v.Point));
            seriaPoint.Points.DataBindXY(chartDataPoint.Keys, chartDataPoint.Values);
        }
    }
}

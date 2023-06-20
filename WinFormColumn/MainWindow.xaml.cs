using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WinFormColumn
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var points = App.DB.PlayerStatistics.Where(ps => ps.MatchupId == 6).ToList();
            var areaPoints = ColumnChart.ChartAreas.Add("pointArea");
            var seriaPoint = ColumnChart.Series.Add("pointsColumn");
            seriaPoint.ChartType = SeriesChartType.Column;
            ColumnChart.ChartAreas["pointArea"].AxisX.LabelStyle.Angle = 45;
            ColumnChart.ChartAreas[0].AxisX.Interval = 1;
            var chartDataPoint = points.ToDictionary(Key => Key.Player.Name, Value => Value.Point);
            seriaPoint.Points.DataBindXY(chartDataPoint.Keys, chartDataPoint.Values);
        }
    }
}

using Line.Models;
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

namespace Line
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IEnumerable<PlayerStatistics> playerStatistics;
        public MainWindow()
        {
            InitializeComponent();
            //Add area
            var areaPoints = ChartLine.ChartAreas.Add("PointsArea");
            CBPlayers.ItemsSource = App.DB.Player.ToList();
        }

        private void Refresh() 
        {
            ChartLine.Series.Clear();
            var seriaPoint = ChartLine.Series.Add("pointsLine");
            //Style
            seriaPoint.ChartType = SeriesChartType.Line;
            seriaPoint.BorderWidth = 5;
            //Drawing
            var chartDataPoint = playerStatistics.GroupBy(ps => ps.Matchup.Starttime).ToDictionary(Key => Key.Key, value => value.Sum(v => v.Point));
            seriaPoint.Points.DataBindXY(chartDataPoint.Keys, chartDataPoint.Values);
        }
        private void CBPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var player = CBPlayers.SelectedItem as Player;
            playerStatistics = App.DB.PlayerStatistics.Where(ps => ps.Player.PlayerId == player.PlayerId).ToList();
            Refresh();
        }
    }
}

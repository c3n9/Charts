using Line.Models;
using LiveCharts;
using LiveCharts.Wpf;
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
using LiveCharts;
using LiveCharts.Wpf;
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
            CBPlayers.ItemsSource = App.DB.Player.ToList();
        }

        private void Refresh() 
        {
            var seriesCollection = new SeriesCollection();
            foreach(var playerStatistic in playerStatistics)
            {
                var lineSeries = new LineSeries()
                {
                    Title = playerStatistic.Player.Name,
                    Values = new ChartValues<int> { playerStatistic.Point},
                };
                seriesCollection.Add(lineSeries);
            }
            LineChart.Series = seriesCollection;
        }
        private void CBPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var player = CBPlayers.SelectedItem as Player;
            playerStatistics = App.DB.PlayerStatistics.Where(ps => ps.Player.PlayerId == player.PlayerId).ToList();
            Refresh();
        }
    }
}

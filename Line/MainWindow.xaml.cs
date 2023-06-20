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
        public List<string> Labels { get; set; }
        public SeriesCollection seriesCollection { get; set; }
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            CBPlayers.ItemsSource = App.DB.Player.ToList();
        }

        private void Refresh()
        {
            DataContext = null;

            Labels = new List<string>();
            var value = new ChartValues<int>();
            var color = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)));
            foreach (var playerStatistic in playerStatistics)
            {
                value.Add(playerStatistic.Point);
                Labels.Add(playerStatistic.Matchup.Starttime.Date.ToString("dd.MM.yyyy"));
            }
            seriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Points",
                    Values = value,
                    DataLabels = true,
                    Stroke = color,
                    Fill = new SolidColorBrush(Color.FromArgb(100, (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255) ))
                }
            };
            DataContext = this;
        }
        private void CBPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var player = CBPlayers.SelectedItem as Player;
            playerStatistics = App.DB.PlayerStatistics.Where(ps => ps.Player.PlayerId == player.PlayerId).OrderBy(x => x.Matchup.Starttime).ToList();
            Refresh();
        }
    }
}

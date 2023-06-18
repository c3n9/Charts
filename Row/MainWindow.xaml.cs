using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Row
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
            var matchups = App.DB.Matchup.Where(m => m.SeasonId == 1 && m.MatchupTypeId == 201).ToList();
            var valueTeam1 = new ChartValues<int>();
            var valueTeam2 = new ChartValues<int>();
            foreach (var matchup in matchups)
            {
                valueTeam1.Add(matchup.Team_Away_Score);
                valueTeam2.Add(matchup.Team_Home_Score);
                Labels.Add($"{matchup.Team.TeamName} - {matchup.Team1.TeamName}");
            }
            seriesCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Values = valueTeam1,
                    DataLabels = true,
                    Fill = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)))
                }
            };
            seriesCollection.Add(new RowSeries
            {
                Values = valueTeam2,
                DataLabels = true,
                Fill = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)))
            });
            DataContext = this;
        }
    }
}

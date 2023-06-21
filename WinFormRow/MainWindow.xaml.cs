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

namespace WinFormRow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var areaMatchup = RowChart.ChartAreas.Add("MatchupArea");
            areaMatchup.AxisY.Interval = 10;
            var seriaMatchupTeam1 = RowChart.Series.Add("matchupRow1");
            var seriaMatchupTeam2 = RowChart.Series.Add("matchupRow2");
            seriaMatchupTeam1.ChartType = SeriesChartType.Bar;
            seriaMatchupTeam2.ChartType = SeriesChartType.Bar;
            var matchups = App.DB.Matchup.Where(m => m.SeasonId == 1 && m.MatchupTypeId == 201).ToList();
            var chartDataTeam1 = new List<ChartData>();
            var chartDataTeam2 = new List<ChartData>();

            foreach (var matchup in matchups)
            {
                chartDataTeam1.Add(new ChartData() { points = matchup.Team_Away_Score, Title = $"{matchup.Team.TeamName}-{matchup.Team1.TeamName}"});
                chartDataTeam2.Add(new ChartData() { points = matchup.Team_Home_Score, Title = $"{matchup.Team.TeamName}-{matchup.Team1.TeamName}"});

            }
            seriaMatchupTeam1.Points.DataBindXY(chartDataTeam1.Select(s => s.Title).ToList(), chartDataTeam1.Select(s => s.points).ToList());
            seriaMatchupTeam2.Points.DataBindXY(chartDataTeam2.Select(s => s.Title).ToList(), chartDataTeam2.Select(s => s.points).ToList());
        }

        private class ChartData
        {
            public string Title { get; set; }
            public int points { get; set; }
        }
    }
}

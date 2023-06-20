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
            var seriaMatchupTeam1 = RowChart.Series.Add("matchupRow1");
            var seriaMatchupTeam2 = RowChart.Series.Add("matchupRow2");
            seriaMatchupTeam1.ChartType = SeriesChartType.Bar;
            seriaMatchupTeam2.ChartType = SeriesChartType.Bar;
            var matchups = App.DB.Matchup.Where(m => m.SeasonId == 1 && m.MatchupTypeId == 201).ToList();
            var valueTeam1 = new List<int>();
            var valueTeam2 = new List<int>();
            var team = new List<string>();
            var team1 = new List<string>();
            foreach (var matchup in matchups)
            {
                valueTeam1.Add(matchup.Team_Away_Score);
                valueTeam2.Add(matchup.Team_Home_Score);
                team.Add(matchup.Team.TeamName);
                team1.Add(matchup.Team1.TeamName);
            }
            seriaMatchupTeam1.Points.DataBindXY(team,valueTeam1);
            seriaMatchupTeam2.Points.DataBindXY(team1,valueTeam2);
        }
    }
}

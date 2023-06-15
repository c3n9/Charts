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
            var matchup = App.DB.Matchup.FirstOrDefault(x => x.MatchupId == 12);
            var areaTeamScore = ChartColumn.ChartAreas.Add("TeamScoreArea");

            var seriaTeamAwayScore = ChartColumn.Series.Add("TeamAwayScoreSeria");
            var seriaTeamHomeScore = ChartColumn.Series.Add("TeamHomeScoreSeria");

            seriaTeamHomeScore.ChartType = SeriesChartType.Column;
            seriaTeamAwayScore.ChartType = SeriesChartType.Column;

            var chartDataAwayScore = matchup.MatchupDetail.GroupBy(md => md.Matchup.Team.TeamName).ToDictionary(Key => Key.Key, value => value.Sum(v => v.Team_Away_Score));
            var chartDataHomeScore = matchup.MatchupDetail.GroupBy(md => md.Matchup.Team1.TeamName).ToDictionary(Key => Key.Key, value => value.Sum(v => v.Team_Home_Score));
            seriaTeamAwayScore.Points.DataBindXY(chartDataAwayScore.Keys, chartDataAwayScore.Values);
            seriaTeamHomeScore.Points.DataBindXY(chartDataHomeScore.Keys, chartDataHomeScore.Values);

        }
    }
}
 
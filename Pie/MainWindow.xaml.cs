using LiveCharts;
using LiveCharts.Wpf;
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

namespace Pie
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SeriesCollection seriesCollection { get; set; }
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            var value = new ChartValues<decimal>();
            var salary = App.DB.PlayerInTeam.Where(x=> x.SeasonId == 2 && x.TeamId == 5).Select(p => p.Salary).ToList();
            foreach(var cost in salary)
            {
                value.Add(cost);
            }
            seriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Salary",
                    Values = value,
                    DataLabels = true,
                    Fill = new SolidColorBrush(Color.FromArgb(100, (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255) ))
                }
            };
            DataContext = this;
        }
    }
}

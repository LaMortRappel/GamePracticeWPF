using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Linq;
using System.Threading.Tasks;

namespace GamePracticeWPF
{
    /// <summary>
    /// Interaction logic for Level1.xaml
    /// </summary>
    public partial class Level1 : Window
    {
        public Level1()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Level1_Loaded);
            
        }

        async void Level1_Loaded(object sender, RoutedEventArgs e)
        {
            var colors = new Tuple<char, Color>[9]
                {Tuple.Create('R', Colors.Red),
                Tuple.Create('G', Colors.Green),
                Tuple.Create('B', Colors.Blue),
                Tuple.Create('C', Colors.Cyan),
                Tuple.Create('M', Colors.Magenta),
                Tuple.Create('Y', Colors.Yellow),
                Tuple.Create('K', Colors.Black),
                Tuple.Create('P', Colors.Pink),
                Tuple.Create('O', Colors.Orange)};
            var combo = new Color[9];
            var rnd = new Random();
            for (int i = 0; i <= 8; i++)
                combo[i] = colors[rnd.Next(0, 8)].Item2;

            for (int i = 0; i <= 8; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    grid.Background = new SolidColorBrush(Colors.White);
                    await Task.Delay(500);
                    grid.Background = new SolidColorBrush(combo[j]);
                    await Task.Delay(500);
                }
                grid.Background = new SolidColorBrush(Colors.White);
                await Task.Delay(2000);
            }
        }

        void TimerTick (object sender, EventArgs e)
        {
            lblTimer.Content = DateTime.Now.ToString("ss:ff");
        }

        private void btnR_Clk (object sender, RoutedEventArgs e)
        {

        }

        private void btnG_Clk(object sender, RoutedEventArgs e)
        {

        }

        private void btnB_Clk(object sender, RoutedEventArgs e)
        {

        }

        private void btnC_Clk(object sender, RoutedEventArgs e)
        {

        }

        private void btnM_Clk(object sender, RoutedEventArgs e)
        {

        }

        private void btnY_Clk(object sender, RoutedEventArgs e)
        {

        }

        private void btnK_Clk(object sender, RoutedEventArgs e)
        {

        }

        private void btnP_Clk(object sender, RoutedEventArgs e)
        {

        }

        private void btnO_Clk(object sender, RoutedEventArgs e)
        {

        }
    }
}

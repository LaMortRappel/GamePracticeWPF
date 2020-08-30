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
        private int count;
        private DispatcherTimer Countdown;
        List<char> inputCombo = new List<char>();

        public Level1()
        {
            InitializeComponent();
            Countdown = new DispatcherTimer();
            Countdown.Interval = TimeSpan.FromMilliseconds(100);
            Countdown.Tick += Countdown_Tick;
        }

        private void Countdown_Tick(object sender, EventArgs e)
        {
            if (count > 0)
            {
                count -= 100;
                lblTimer.Content = string.Format("{0}.{1}", count / 1000, count % 1000 / 100);
            }
            else
            {
                Countdown.Stop();
                lblTimer.Content = "";
            }
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
            var combo = new Tuple<char, Color>[9];
            var rnd = new Random();
            for (int i = 0; i <= 8; i++)
                combo[i] = colors[rnd.Next(0, 8)];
            
            for (int i = 0; i <= 8; i++)
            {
                EnableButtons(false);
                for (int j = 0; j <= i; j++)
                {
                    grid.Background = new SolidColorBrush(Colors.White);
                    await Task.Delay(500);
                    grid.Background = new SolidColorBrush(combo[j].Item2);
                    await Task.Delay(500);
                }
                grid.Background = new SolidColorBrush(Colors.White);
                inputCombo.Clear();
                int answerTime = 1500 + 500 * i;
                count = answerTime;
                Countdown.Start();
                EnableButtons(true);
                await Task.Delay(answerTime + 500);
                int inputLength = inputCombo.Count;
                if (inputLength != i + 1)
                {
                    i--;
                    continue;
                }
                for (int z = 0; z <= inputCombo.Count - 1; z++)
                {
                    if (inputCombo[z] != combo[z].Item1)
                    {
                        i--;
                        break;
                    }
                }
            }
            await Task.Delay(1000);
            lblTimer.Content = "Congratulations!";
            lblTimer.FontSize = 48;
            lblTimer.Foreground = Brushes.White;
            grid.Background = Brushes.Lime;
            await Task.Delay(5000);
            Window level2 = new Level2();
            this.Close();
            level2.Show();
        }

        public void EnableButtons(bool isEnabled)
        {
            btnR.IsEnabled = isEnabled;
            btnG.IsEnabled = isEnabled;
            btnB.IsEnabled = isEnabled;
            btnC.IsEnabled = isEnabled;
            btnM.IsEnabled = isEnabled;
            btnY.IsEnabled = isEnabled;
            btnK.IsEnabled = isEnabled;
            btnP.IsEnabled = isEnabled;
            btnO.IsEnabled = isEnabled;
        }

        private void btnR_Clk (object sender, RoutedEventArgs e)
        {
            inputCombo.Add('R');
        }

        private void btnG_Clk(object sender, RoutedEventArgs e)
        {
            inputCombo.Add('G');
        }

        private void btnB_Clk(object sender, RoutedEventArgs e)
        {
            inputCombo.Add('B');
        }

        private void btnC_Clk(object sender, RoutedEventArgs e)
        {
            inputCombo.Add('C');
        }

        private void btnM_Clk(object sender, RoutedEventArgs e)
        {
            inputCombo.Add('M');
        }

        private void btnY_Clk(object sender, RoutedEventArgs e)
        {
            inputCombo.Add('Y');
        }

        private void btnK_Clk(object sender, RoutedEventArgs e)
        {
            inputCombo.Add('K');
        }

        private void btnP_Clk(object sender, RoutedEventArgs e)
        {
            inputCombo.Add('P');
        }

        private void btnO_Clk(object sender, RoutedEventArgs e)
        {
            inputCombo.Add('O');
        }
    }
}

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

namespace GamePracticeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Window level1 = new Level1();
            this.Close();
            level1.Show();
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Window level1 = new Level1();
            this.Close();
            level1.Show();
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Window level2 = new Level2();
            this.Close();
            level2.Show();
        }
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            Window level3 = new Level3();
            this.Close();
            level3.Show();
        }
        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            //Window level4 = new Level4();
            this.Close();
            //level4.Show();
        }
        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            //Window level5 = new Level5();
            this.Close();
            //level5.Show();
        }
        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            //Window level6 = new Level6();
            this.Close();
            //level6.Show();
        }
    }
}

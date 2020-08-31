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
using System.Linq;

namespace GamePracticeWPF
{
    /// <summary>
    /// Interaction logic for Level3.xaml
    /// </summary>
    public partial class Level3 : Window
    {
        bool[][] correctItems = new bool[5][];
        int[] correctSequence;

        public Level3()
        {
            InitializeComponent();
        }

        private void Level3_Loaded(object sender, RoutedEventArgs e)
        {
            GenerateCorrectAnswers();
        }

        public void GenerateCorrectAnswers()
        {
            var random = new Random();
            for (int i = 0; i < 5; i++)
            {
                correctItems[i] = new bool[3];
                for (int j = 0; j < 3; j++)
                    correctItems[i][j] = false;
                int randId = random.Next(0, 3);
                correctItems[i][randId] = true;
            }

            correctSequence = Enumerable.Range(0, 5).OrderBy(x => random.Next()).ToArray();
        }

        private void SelectionChanged (object sender, EventArgs e)
        {
            var CBox = sender as ComboBox;
            int CBoxId = 0;
            switch (CBox.Name)
            {
                case "CB0":
                    CBoxId = 0;
                    break;
                case "CB1":
                    CBoxId = 1;
                    break;
                case "CB2":
                    CBoxId = 2;
                    break;
                case "CB3":
                    CBoxId = 3;
                    break;
                case "CB4":
                    CBoxId = 4;
                    break;
            }
            CheckPlGuess(CBox, CBoxId);
        }

        private void CheckPlGuess(ComboBox CBox, int CBoxId)
        {
            if (correctItems[CBoxId][CBox.SelectedIndex])
            {
                TBlock.Text = "*applause*";
            }
            else
                TBlock.Text = "*boos*";
        }
    }
}

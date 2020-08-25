using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GamePracticeWPF
{
    /// <summary>
    /// Interaction logic for Level2.xaml
    /// </summary>
    public partial class Level2 : Window
    {
        List<string[]> playerCities = new List<string[]>();
        List<string[]> computerCities = new List<string[]>();
        int stage = 0;

        public Level2()
        {
            InitializeComponent();
        }

        private void Level2_Loaded(object sender, RoutedEventArgs e)
        {
            

        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            SendInput();
        }

        private void RichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendInput();
                e.Handled = true;
            }
        }

        public void SendInput()
        {
            string input = new TextRange
                (
                InputBox.Document.ContentStart,
                InputBox.Document.ContentEnd
                ).Text;
            InputBox.Document.Blocks.Clear();
            input = input.Substring(0, input.Length - 2);
            if (stage == 0)
            {
                if (CheckPlayerCity(input))
                {
                    if (stage == 0)
                        GenerateComAnswer();
                    else
                        StartStage1();
                }
            }
            else if (stage == 1)
            {
                CheckStage1(input);
            }
            else if (stage == 2)
            {
                CheckStage2(input);
            }
            else if (stage == 3)
            {
                CheckStage3(input);
            }
        }

        public void StartStage1 ()
        {
            TBlock.Text = "Not bad. Let's see if you've been paying attention. What was your first city?";
            return;
        }

        public void CheckStage1 (string input)
        {
            if (input == playerCities[0][0])
            {
                stage++;
                TBlock.Text = "Seems alright. Do you remember the country of your second city?";
            }
            else
                TBlock.Text = "Not really. No. Try harder.";
            return;
        }

        public void CheckStage2 (string input)
        {
            if (input == playerCities[1][1])
            {
                stage++;
                TBlock.Text = "Great! And the last one. What was your third city's county?";
            }
            else
                TBlock.Text = "Not really. No. Try harder.";
            return;
        }

        public void CheckStage3(string input)
        {
            if (input == playerCities[2][2])
            {
                TBlock.Background = Brushes.Lime;
                TBlock.Foreground = Brushes.White;
                TBlock.Text = "Congratulations!";
            }
            else
                TBlock.Text = "Not really. No. Try harder.";
            return;
        }

        public void GenerateComAnswer ()
        {
            string lastPlCityName = playerCities[playerCities.Count - 1][0];
            char lastPlLetter = lastPlCityName[lastPlCityName.Length - 1];

            var suitableCities = new List<string[]>();

            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\CitiesNormalized.txt";
            var reader = new StreamReader(path);
            string line;
            string[] cityData;
            while ((line = reader.ReadLine()) != null)
            {
                cityData = line.Split(',');
                if (cityData[0][0] == char.ToUpper(lastPlLetter))
                {
                    suitableCities.Add(cityData);
                }
            }
            reader.Close();

            var random = new Random();
            string[] answer = suitableCities[random.Next(0, suitableCities.Count)];
            computerCities.Add(answer);
            TBlock.Text = $"My answer is {answer[0]}";
        }

        public bool CheckPlayerCity (string input)
        {
            foreach (char character in input)
                if (!char.IsLetter(character) && character != '-')
                {
                    TBlock.Text = "Input is invalid";
                    return false;
                }
            string[] cityData = FindCity(input);
            if (cityData == null)
            {
                TBlock.Text = "I don't know this city, try again";
                return false;
            }

            char firstPlLetter = cityData[0][0];
            string lastComCityName;
            char lastComLetter;
            if (computerCities.Count == 0)
            {
                playerCities.Add(cityData);
                return true;
            }
            else
            {
                lastComCityName = computerCities[computerCities.Count - 1][0];
                lastComLetter = lastComCityName[lastComCityName.Length - 1];
                if (firstPlLetter == char.ToUpper(lastComLetter))
                {
                    playerCities.Add(cityData);
                    if (playerCities.Count == 3)
                        stage = 1;
                    return true;
                }
                else
                {
                    TBlock.Text = $"It starts with a wrong letter, you should type a city starting with {lastComLetter}";
                    return false;
                }
            }

        }

        public string[] FindCity(string cityName)
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\CitiesNormalized.txt";
            var reader = new StreamReader(path);
            string line;
            string[] cityData;
            while ((line = reader.ReadLine()) != null)
            {
                cityData = line.Split(',');
                if (cityData[0] == cityName)
                {
                    reader.Close();
                    return cityData;
                }
            }
            reader.Close();
            return null;
        }
    }
}

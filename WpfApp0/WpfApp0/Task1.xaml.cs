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
using System.Windows.Shapes;

namespace WpfApp0
{
    /// <summary>
    /// Логика взаимодействия для Task1.xaml
    /// </summary>
    public partial class Task1 : Window
    {
        public Task1()
        {
            InitializeComponent();
        }

        double Distance, Speed, TimeStop, AllTime, AverageSpeed;

        private void InputTimeStop_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputTimeStop.Text.Length > 0)
            {
                if (!double.TryParse(InputTimeStop.Text, out TimeStop))
                {
                    MessageBox.Show("Неверный параметр");
                    InputTimeStop.Clear();
                }
            }
        }

        private void InputSpeed_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputSpeed.Text.Length > 0)
            {
                if (!double.TryParse(InputSpeed.Text, out Speed))
                {
                    MessageBox.Show("Неверный параметр");
                    InputSpeed.Clear();
                }
            }
        }

        private void InputDistance_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputDistance.Text.Length > 0)
            {
                if (!double.TryParse(InputDistance.Text, out Distance))
                {
                    MessageBox.Show("Неверный параметр");
                    InputDistance.Clear();
                }
            }
        }

        private void RunTask1_Click(object sender, RoutedEventArgs e)
        {
            if (InputDistance.Text.Length < 1 || InputTimeStop.Text.Length < 1 || InputSpeed.Text.Length < 1)
            {
                MessageBox.Show("Введите параметр");
            }
            else
            {
                AllTimeOut.Text = "";
                AverageSpeedOut.Text = "";
                Distance = Convert.ToDouble(InputDistance.Text);
                Speed = Convert.ToDouble(InputSpeed.Text);
                TimeStop = Convert.ToDouble(InputTimeStop.Text);
                if (Distance > 0 && Speed > 0 && TimeStop > 0)
                {
                    AllTime = Distance / Speed + TimeStop;
                    AverageSpeed = Distance / AllTime;
                    AllTimeOut.Text += AllTime.ToString();
                    AverageSpeedOut.Text += AverageSpeed.ToString();
                    InputSpeed.Clear();
                    InputDistance.Clear();
                    InputTimeStop.Clear();
                }
                else
                {
                    MessageBox.Show("Неверный параметр");
                    if (Distance == 0)
                    {
                        InputDistance.Clear();
                    }
                    else if (Speed == 0)
                    {
                        InputSpeed.Clear();
                    }
                    else
                    {
                        InputTimeStop.Clear();
                    }
                }
            }
        }

        private void BackMenuTask2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        


    }
}

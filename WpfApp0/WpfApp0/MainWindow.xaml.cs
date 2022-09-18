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

namespace WpfApp0
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

        private void ButtonTask2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Task2 task2 = new Task2();
            task2.Show();
        }

        private void ButtonTask1_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Task1 task1 = new Task1();
            task1.Show();
        }
    }
}

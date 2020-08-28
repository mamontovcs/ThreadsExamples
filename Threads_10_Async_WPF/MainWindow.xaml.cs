using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Threads_10_Async_WPF
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Program is not crashed!");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Task<int> task = Factorial();
            await Task.Delay(5000);
            var result = task.Result; //break point here

            MyText.Text = result.ToString();
        }

        static async Task<int> Factorial()
        {
            int result = 1;

            for (int i = 1; i <= 6; i++)
            {
                result *= i*5*9*7*2*new Random().Next(20,50);
            }

            return result;
        }
       
    }
}

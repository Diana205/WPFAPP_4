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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        public int K;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          K = Convert.ToInt32(text_ok.Text);
            Close();
        }

        private void text_ok_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Convert.ToInt32(text_ok.Text);
               // (this.Parent as MainWindow).key = K;
            }
            catch
            {
                MessageBox.Show("Введите целое число!");
            }
        }
    }
}

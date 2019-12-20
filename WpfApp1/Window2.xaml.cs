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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        public int x,x1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
            x = Convert.ToInt32(text2.Text);
            x1 = Convert.ToInt32(text2.Text);
                Close();
            }
            catch
            {
                MessageBox.Show("Введите целое число!");
            }
        }


    }
}

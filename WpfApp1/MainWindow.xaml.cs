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
using System.Collections;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<KeyValuePair<string, int>> valueList = new ObservableCollection<KeyValuePair<string, int>>();
        public MainWindow()
        {
            InitializeComponent();
            ColumnChart.DataContext = valueList;
        }
        //int[] number = new int[5];
        int number;
        int i;
        ArrayList myAL = new ArrayList();
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int itemCount = Convert.ToInt32(text1.Text);
                if (itemCount > 0)
                {
                    Random rnd1 = new Random();
                    list1.Items.Clear();
                    for (i = 1; i <= itemCount; i++)
                    {
                        number = -100 + rnd1.Next(200);
                        myAL.Add(number);
                        list1.Items.Add(number);
                    }
                    
                }
                else MessageBox.Show("Введите целое число больше нуля!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите число!!!");
            }
            
        }
        
        private void text1_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            try
            {
                Convert.ToInt32(text1.Text);
            }
            catch
            {
                MessageBox.Show("Большие числа нельзя!!!");
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int itemCount = Convert.ToInt32(text1.Text);
                if (itemCount > 0)
                {
                    Random rnd1 = new Random();
                    list1.Items.Clear();
                    list1.Items.Add("Исходный массив");
                    for (i = 1; i <= itemCount; i++)
                    {
                        number = -100 + rnd1.Next(200);
                        myAL.Add(number);
                        list1.Items.Add(number);
                    }
                    myAL.Sort();
                    list1.Items.Add("Отсортированный массив");

                    foreach (int elem in myAL)
                    {
                        list1.Items.Add(elem);
                    }
                }
                else MessageBox.Show("Введите целое число больше нуля!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите число!!!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.SaveFileDialog myDialog = new Microsoft.Win32.SaveFileDialog();
            myDialog.Filter = "Текст(*.TXT)|*.TXT" + "|Все файлы (*.*)|*.* ";

            if (myDialog.ShowDialog() == true)
            {
                string filename = myDialog.FileName;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, false))
                {
                    foreach (Object item in list1.Items)
                    {
                        file.WriteLine(item);
                    }
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //1
            
            try
            {
            int itemCount = Convert.ToInt32(text1.Text);
                if (itemCount > 0)
                {
                    Random rnd1 = new Random();
                    list1.Items.Clear();
                    myAL.Clear();
                    for (i = 1; i <= itemCount; i++)
                    {
                        number = -100 + rnd1.Next(200);
                        myAL.Add(number);
                        list1.Items.Add(number);
                    }
                    valueList.Clear();
                    for (int i = 0; i < itemCount; i++)
                    {
                        valueList.Add(new KeyValuePair<string, int>("", (int)myAL[i]));
                    }
                }
                else MessageBox.Show("Введите целое число больше нуля!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите число!!!");
            }
           
        }

        
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            AboutBox1 r = new AboutBox1();
            r.ShowDialog();
        }

    }
}
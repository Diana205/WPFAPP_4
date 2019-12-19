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
            rn.IsEnabled = false;
            kn_1.IsEnabled = false;
            kn_2.IsEnabled = false;
            kn_3.IsEnabled = false;
            kn_4.IsEnabled = false;
            kn_5.IsEnabled = false;
            kn_6.IsEnabled = false;
        }
        //int[] number = new int[5];
        int number;
        int i;
        ArrayList myAL = new ArrayList();
        public int key;
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
                    valueList.Clear();
                    for (int i = 0; i < itemCount; i++)
                    {
                        valueList.Add(new KeyValuePair<string, int>("", (int)myAL[i]));
                    }
                    rn.IsEnabled = true;
                    kn_1.IsEnabled = true;
                    kn_2.IsEnabled = true;
                    kn_3.IsEnabled = true;
                    kn_4.IsEnabled = true;
                    kn_5.IsEnabled = true;
                    kn_6.IsEnabled = true;
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
            int itemCount = Convert.ToInt32(text1.Text);
            int kol = 0;
            int a = itemCount - 1;
            for (i = 1; i < a; i++)
            {
                if (((int)myAL[i] > (int)myAL[i - 1]) && ((int)myAL[i] > (int)myAL[i + 1]))
                {
                    kol++;
                }
            }
            if ((int)myAL[0] < (int)myAL[1] && (int)myAL[0] < (int)myAL[itemCount - 1])
                kol++;
            if ((int)myAL[itemCount - 1] < (int)myAL[0] && (int)myAL[itemCount - 1] < (int)myAL[itemCount - 2])
                kol++;
            list1.Items.Add("Дан массив из K чисел.\n Сколько элементов массива меньше своих «соседей»,\n т.е. предыдущего и последующего. Первый\n и последний элементы массива считаются соседними,\n т.е. массив представляет из себя кольцевой список.");
            list1.Items.Add("Ответ:" + kol);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
        //2
            int itemCount = Convert.ToInt32(text1.Text);
          
            list1.Items.Add("Для массива из K чисел найти номер \nсамого малого по значению элемента, \nзначение которого больше среднего значения\n элементов массива.");
                    
                int sum = 0;
                for (i = 0; i < itemCount; i++)
                {
                    sum += (int)myAL[i];
                }
                float sr = 0;
                
                float min = -101;
                sr = (float)sum / (float)itemCount;
                for (i = 0; i < itemCount; i++)
                {
                    if ((int)myAL[i] > sr)
                    {
                        if ((int)myAL[i] < min)
                        {
                            min = (int)myAL[i];
                        }
                    }
                }
            list1.Items.Add("Ответ:" + i);
        }
        
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            AboutBox1 r = new AboutBox1();
            r.ShowDialog();
        }

    }
}
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
       
        void Gena()
        {
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Gena();
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


        private void kn_1_Click(object sender, RoutedEventArgs e)
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

        private void kn_2_Click(object sender, RoutedEventArgs e)
        {
            //2
            Gena();
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

        private void kn_3_Click(object sender, RoutedEventArgs e)
        {
            //3
            Gena();
            int itemCount = Convert.ToInt32(text1.Text);

            list1.Items.Add("Для массива из K чисел найти номер \nсамого малого по значению элемента, \nзначение которого больше среднего значения\n элементов массива.");

            int sum = 0;
            for (i = 0; i < itemCount; i++)
            {
                sum += (int)myAL[i];
            }
            float sr = 0;
            int j = 0;
            float min = (int)myAL[0];
            sr = (float)sum / (float)itemCount;
         
            while(min<sr)
            {
                min = (int)myAL[j];
                j++;
            }
            j = 0;
            for (i = 0; i < itemCount; i++)
            {
                if ((int)myAL[i] > sr)
                {
                    if ((int)myAL[i] < min)
                    {
                        min = (int)myAL[i];
                        j = i;
                        
                    }
                }
                
            }
            list1.Items.Add("Ответ: " + (j + 1));
        }

        private void kn_6_Click(object sender, RoutedEventArgs e)
        {
        //6
            int itemCount = Convert.ToInt32(text1.Text);
            list1.Items.Add("Дан массив из K чисел. Выведите к исходному \nмассиву вместо значений элементов их отклонение \nот среднего значения элементов массива.");
            int sum = 0;
            for (i = 0; i < itemCount; i++)
            {
                sum += (int)myAL[i];
            }
            float sr = 0, otkl = 0;

            sr = (float)sum / (float)itemCount;
            for (i = 0; i < itemCount; i++)
            {
                otkl = (int)myAL[i] - sr;
                list1.Items.Add("\t" + myAL[i] + "\t-->\t" + otkl);
            }
        }

        private void kn_7_Click(object sender, RoutedEventArgs e)
        {
        //7
            Gena();
            list1.Items.Add("Дан массив из K чисел. Найдите среднее\n значение элементов массива. Замените \nвсе элементы массива, отклонение от среднего \nзначения которых больше половины среднего \nотклонения всех элементов, на среднее значение.");

            int itemCount = Convert.ToInt32(text1.Text);
            int sum = 0;
            for (i = 0; i < itemCount; i++)
            {
                sum += (int)myAL[i];
            }
            float sr = 0, otkl = 0, sum_otkl = 0, sr_otkl = 0;
            sr = (float)sum / (float)itemCount;
            list1.Items.Add("Среднее значение: " + sr);

            for (i = 0; i < itemCount; i++)
            {
                otkl = (int)myAL[i] - sr;
                sum_otkl += otkl;
            }
            sr_otkl = (float)sum_otkl / (float)itemCount;
            for (i = 0; i < itemCount; i++)
            {
                otkl = (int)myAL[i] - sr;
                if (otkl > (sr_otkl / 2))
                {
                    myAL[i] = sr;
                }
                list1.Items.Add(myAL[i]);
            }
        }

        private void kn_8_Click(object sender, RoutedEventArgs e)
        {
            //8
            Gena();
            list1.Items.Add("Дан массив из K чисел. Найдите среднее \nзначение элементов массива. Замените все \nэлементы массива, отклонение от среднего \nзначения которых больше L процентов от среднего \nотклонения всех элементов, на среднее значение.");

            int itemCount = Convert.ToInt32(text1.Text);
            int sum = 0;
            for (i = 0; i < itemCount; i++)
            {
                sum += (int)myAL[i];
            }
            float sr = 0, otkl = 0, sum_otkl = 0, sr_otkl = 0;
            sr = (float)sum / (float)itemCount;
            list1.Items.Add("Среднее значение: " + sr);

            Window1 f = new Window1();
            f.ShowDialog();
            int L = f.K;

            for (i = 0; i < itemCount; i++)
            {
                otkl = (int)myAL[i] - sr;
                sum_otkl += otkl;
            }
            sr_otkl = (float)sum_otkl / (float)itemCount;
            for (i = 0; i < itemCount; i++)
            {
                otkl = (int)myAL[i] - sr;
                if (otkl > (sr_otkl / 100) * L)
                {
                    myAL[i] = sr;
                }
                list1.Items.Add(myAL[i]);
            }
        }

        private void kn_9_Click(object sender, RoutedEventArgs e)
        {
            //9
            Gena();
            list1.Items.Add("Дан массив из K чисел. Найдите среднее \nзначение элементов массива. Измените все \nэлементы массива, отклонение от среднего \nзначения которых больше L процентов от среднего \nотклонения всех элементов, на коэфициент Z.");

            int itemCount = Convert.ToInt32(text1.Text);
            int sum = 0;
            for (i = 0; i < itemCount; i++)
            {
                sum += (int)myAL[i];
            }
            float sr = 0, otkl = 0, sum_otkl = 0, sr_otkl = 0;
            sr = (float)sum / (float)itemCount;
            list1.Items.Add("Среднее значение: " + sr);

            Window2 O = new Window2();
            O.ShowDialog();
            int L = O.x, Z = O.x1;

            for (i = 0; i < itemCount; i++)
            {
                otkl = (int)myAL[i] - sr;
                sum_otkl += otkl;
            }
            sr_otkl = (float)sum_otkl / (float)itemCount;
            for (i = 0; i < itemCount; i++)
            {
                otkl = (int)myAL[i] - sr;
                if (otkl > (sr_otkl / 100) * L)
                {
                    myAL[i] = Z;
                }
                list1.Items.Add(myAL[i]);
            }
        }

        private void kn_10_Click(object sender, RoutedEventArgs e)
        {
            //10
            list1.Items.Clear();
            valueList.Clear();
            Window3 P = new Window3();
            P.ShowDialog();
            int k4 = P.x3,t=0;
            Gena();
            int itemCount = Convert.ToInt32(text1.Text);
            int sum = 0;
            Window2 O = new Window2();
            O.ShowDialog();
            int L = O.x, Z = O.x1;

            while(t<k4)
            {
                for (i = 0; i < itemCount; i++)
                {
                    sum += (int)myAL[i];
                }
                float sr = 0, otkl = 0, sum_otkl = 0, sr_otkl = 0;
                sr = (float)sum / (float)itemCount;
                list1.Items.Add("Среднее значение: " + sr);

                for (i = 0; i < itemCount; i++)
                {
                    otkl = (int)myAL[i] - sr;
                    sum_otkl += otkl;
                }
                sr_otkl = (float)sum_otkl / (float)itemCount;
                for (i = 0; i < itemCount; i++)
                {
                    otkl = (int)myAL[i] - sr;
                    if (otkl > (sr_otkl / 100) * L)
                    {
                        myAL[i] = Z;
                    }
                    list1.Items.Add(myAL[i]);
                }
                list1.Items.Add("-------------------------------");
                MessageBox.Show("Гистограмма изменится");
                valueList.Clear();
                for (int i = 0; i < itemCount; i++)
                {
                    valueList.Add(new KeyValuePair<string, int>("", (int)myAL[i]));
                }
                t++;
            }
        }
    }
}
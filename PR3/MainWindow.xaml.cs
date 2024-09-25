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

namespace PR3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Добавление числа в ListBox
            if (int.TryParse(TextBox.Text, out int number))
            {
                ListBoxNumbers.Items.Add(number);
                TextBox.Clear();
            }
            else
            {
                MessageBox.Show("Введите корректное число.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Удаление выделенного числа из ListBox
            if (ListBoxNumbers.SelectedItem != null)
            {
                ListBoxNumbers.Items.Remove(ListBoxNumbers.SelectedItem);
            }
            else
            {
                MessageBox.Show("Выберите число для удаления.");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ListBoxNumbers != null)
            {
                // Сортировка списка
                List<int> numbers = ListBoxNumbers.Items.Cast<int>().ToList();
                QuickSort(numbers, 0, numbers.Count - 1);
                ListBoxNumbers.Items.Clear(); // Очистка предыдущих значений

                foreach (var number in numbers)
                {
                    ListBoxNumbers.Items.Add(number);
                }
            }

            else
            {
                MessageBox.Show("Список пуст");
            }
        }
        void QuickSort(List<int> array, int left, int right)
        {
            if (ListBoxNumbers != null)
            {
                int i = left, j = right;
                int pivot = array[(left + right) / 2];

                while (i <= j)
                {
                    while (array[i] < pivot) i++;
                    while (array[j] > pivot) j--;

                    if (i <= j)
                    {
                        // Меняем местами
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                        i++;
                        j--;
                    }
                }


                // Метод вызывает сам себя
                if (left < j) QuickSort(array, left, j);
                if (i < right) QuickSort(array, i, right);
            }
            else
            {
                MessageBox.Show("Список пуст");
            }
        }
    }

    
}

        


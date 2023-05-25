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

namespace WpfApp1
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

        private void add_btn_Click(object sender, RoutedEventArgs e) 
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(parameter_add_tb.Text) && !listElem.Items.Contains(parameter_add_tb.Text))
                {
                if (MessageBox.Show("Вы действительно хотите добавить новый элемент?", "Добавление в список", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    listElem.Items.Add(parameter_add_tb.Text);
                    parameter_add_tb.Clear();
                }
                }
                else MessageBox.Show("Надо что-нибудь ввести!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            
                if (String.IsNullOrEmpty(parameter_add_tb.Text))//Проверка данных
                {
                    MessageBox.Show("Надо что-нибудь ввести!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else if (parameter_add_tb.Text.Length >= 7)//Проверка данных
                {
                    MessageBox.Show("Слишком длинное значение для списка!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректное значение для списка!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (StackOverflowException)//Вызов исключения при условии что программы не отвечает
            {
                 if(MessageBox.Show(" Перезапустить программу? ", "Программа не отвечает", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                 {
                    Application.Current.Shutdown();
                   Application.Current.Run();
                 }
                 if (MessageBox.Show(" Перезапустить программу? ", "Программа не отвечает", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                 {
                    Application.Current.Shutdown();
                }
                    
                
               
            }
        }

        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Clear_btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите очистить список?", "очистка списка", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                listElem.Items.Clear();
            }
            
        }

        private void parameter_add_tb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

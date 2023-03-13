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

namespace pr7_regist
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

        //Выход
        private void OnClose(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        //Авторизация
        private void OnClose1(object sender, RoutedEventArgs e)
        {
            Content = new AuthPage();
        }
        //Регистрация
        private void OnClose2(object sender, RoutedEventArgs e)
        {
            Content = new RegPage();
        }

        
    }
}

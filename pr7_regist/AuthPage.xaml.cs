using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Btn_Log_Click(object sender, RoutedEventArgs e)
        {
            Auth(TxtBox_log.Text, TxtBox_password.Text);
        }

        private int count_capch = 0;
        public bool Auth(string login, string password)
        {

            if (count_capch >= 1)
            {
                Window1 capch = new Window1();
                capch.Show();
                count_capch = 0;
            }

            // ошибки на пустые значения
            if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните поля: Логин и Пароль!", "Ошибка пустых значений");
                return false;
            }
            else if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Заполните поле Логин!", "Ошибка логина");
                return false;
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните поле Пароль!", "Ошибка пароля");
                return false;
            }

            using (var db = new bd_UserEntities())
            {
                var user = db.User
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Login == login /*&& u.Password == TxtBox_password.Text*/);
                if (user == null)
                {
                    if (login != "")
                    {
                        MessageBox.Show("Пользователя с таким логином не обнаружено!", "Предупреждение");
                        TxtBox_log.Clear();
                        TxtBox_password.Clear();
                        count_capch++;
                        return false;
                    }
                }
                else
                {
                    if (user.Role == "Удален")
                    {
                        MessageBox.Show("Пользователь с такими данными был удален!", "Удаленный пользователь");
                        TxtBox_log.Clear();
                        TxtBox_password.Clear();
                        count_capch++;
                        return false;
                    }
                    else if (user.Password != password)
                    {
                        MessageBox.Show("Не правильный пароль! Проверьте правильно ли вы его ввели", "Предупреждение");
                        count_capch++;
                        return false;
                    }
                    else
                    {
                        MessageBox.Show($"Здраствуйте, \"{user.Role}\" {user.FIO}", "Вы аторизированы");
                        TxtBox_log.Clear();
                        TxtBox_password.Clear();
                        count_capch = 0;
                        return true;
                    }
                }
                return true;
            }
        }

        private void Btn_return_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            var auth = new AuthPage();

            mainWindow.Show();
            Window.GetWindow(this)?.Close();
        }
    }
}

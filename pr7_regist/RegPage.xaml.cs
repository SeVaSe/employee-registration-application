using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics.Eventing.Reader;
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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }
        //назад
        private void Btn_return_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            MainWindow.GetWindow(this)?.Close();
        }

        private void Btn_Log_Click(object sender, RoutedEventArgs e)
        {
            Registr(TxtBox_log_Reg.Text, TxtBox_password_Reg.Text, TxtBox_password_again.Text, TxtBox_fio_Reg.Text);
        }

        public bool Registr(string logg, string pasw, string pasw_again, string fio)
        {
            string log_reg = logg;
            string fio_reg = fio;
            string password_reg = pasw;
            string password_again = pasw_again;


            if (string.IsNullOrEmpty(logg) || string.IsNullOrEmpty(fio) ||
                string.IsNullOrEmpty(pasw) || string.IsNullOrEmpty(pasw_again))
            {
                MessageBox.Show("Вы не заполнили поля или одно из полей!", "Ошибка пустого значаения");
                return false;
            }
            else if (password_reg != password_again)
            {
                MessageBox.Show("Пароли не совпадают, попробуйте проверить введеный вами пароль и его подтверждение!", "Не совпадение пароля");
                return false;
            }
            else if (password_reg.Length < 6)
            {
                MessageBox.Show("Пароль содержит меньше 6 знаков, увеличь его!", "Маленький пароль");
                return false;
            }
            else
            {
                bd_UserEntities db = new bd_UserEntities();
                User userObject = db.User.FirstOrDefault(u => u.Login == log_reg);
                if (userObject != null)
                {
                    MessageBox.Show("Такой пользователь с логином уже существует", "Существующий пользователь");
                    return false;
                }
                else
                {
                    userObject = new User
                    {
                        Login = logg,
                        Password = pasw,
                        FIO = fio,
                        Role = "Пользователь",
                    };
                    db.User.Add(userObject);
                    db.SaveChanges();

                    MessageBox.Show($"Здраствуйте \"{fio_reg}\", вы были зарегестрированы!", "Регистрация");
                    return true;
                }
                
            }
        }
    }
}

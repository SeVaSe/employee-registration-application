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

namespace pr7_regist
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ShowDialog();
            //this.Loaded += MainWindow_Loaded;
        }

        /* private void MainWindow_Loaded(object sender, RoutedEventArgs e)
         {
             Rand_ch();
         }

         public void Rand_ch()
         {
             Random rand = new Random();
             int rand_paswrd = rand.Next(100000, 999999);

             string r_str = Convert.ToString(rand_paswrd);
             Lbl_capch.Content = r_str;
         }*/

        private void Btn_Capch_get_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int rand_paswrd = rand.Next(100000, 999999);

            string r_str = Convert.ToString(rand_paswrd);
            TxtBl_code.Text = r_str;
        }

        private void Btn_capcha_Click(object sender, RoutedEventArgs e)
        {
            if (Box_pswrd.Password == TxtBl_code.Text)
            {

                Hide();
                Box_pswrd.Clear();
            }
            else
            {
                MessageBox.Show("Не правильная капча, попробуйте заново!", "Не правильная капча");
               // Rand_ch();
            }
        }

        
    }
}

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
using System.IO;

namespace Norbit.Snegirev.DevilDice
{
    static class FileWorks
    {
        public static string Score { get; set; }

    }
    public partial class MainWindow : Window
    {
        void CheckNameFile()
        {
            using (var sr = new StreamReader("Name.txt"))
            {
                string name = sr.ReadToEnd();
                if (name == "")
                {
                    Button1.Visibility = Visibility.Visible;
                    Button3.Visibility = Visibility.Hidden;
                    TextBox.Visibility = Visibility.Visible;
                    Button2.Visibility = Visibility.Hidden;
                    Button4.Visibility = Visibility.Hidden;

                }
                else
                {
                    Button2.Visibility = Visibility.Visible;
                    Button3.Visibility = Visibility.Hidden;
                    Button4.Visibility = Visibility.Visible;
                }

            }
        }
        async void Score()
        {
            using (var cr = new StreamReader("Score.txt"))
            {

                FileWorks.Score = (cr.ReadToEnd());

            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)//Кнопка для создания имени в файле и начала игры
        {
            using (var sw = new StreamWriter("Name.txt"))
            {
                sw.Write(TextBox.Text);
            }
            Window1 taskWindow = new Window1();
            taskWindow.Show();
            this.Close();

        }

        private void Butto3_Click(object sender, RoutedEventArgs e)// Старт игры(начать игру)
        {
            CheckNameFile();
            Score();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)// Удаление записей имени и счета
        {
            using (var sw = new StreamWriter("Name.txt"))
            {
                sw.Write("");
            }
            using (var sw = new StreamWriter("Score.txt"))
            {
                sw.Write("0");
            }
            Score();
            CheckNameFile();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)// продолжение игры
        {
            using (var sr = new StreamReader("Name.txt"))
            {
                string name = sr.ReadToEnd();
            }
            Window1 taskWindow = new Window1();
            taskWindow.Show();
            this.Close();
        }
    }
}

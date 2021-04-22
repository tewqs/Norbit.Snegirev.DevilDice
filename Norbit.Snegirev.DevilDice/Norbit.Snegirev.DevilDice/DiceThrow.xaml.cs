using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Norbit.Snegirev.DevilDice
{

    public partial class Window1 : Window
    {


        int DiceNumber;
        int NewRoll = Convert.ToInt32(FileWorks.Score);
        public static int DiceThrow()
        {
            Random rnd = new Random();
            int DiceThrowed = rnd.Next(1, 7);
            return DiceThrowed;//
        }


еу
        public Window1()
        {
            InitializeComponent();
        }

        //private void myGif_MediaEnded(object sender, RoutedEventArgs e) // Код для гифки, если понадобится.
        //{
        //    myGif.Position = new TimeSpan(0, 0, 1);
        //    myGif.Play();
        //}

        async void Resault()

        {

            DiceNumber = Convert.ToInt32(TextBox1.Text);
            int RandomDice = DiceThrow();

            if (NewRoll >= 666)
            {
                TextBlock1.Text = "Ты победил, прощай, человек.";
                await Task.Delay(800);
                Application.Current.Shutdown();
            }
            else
            {
                if (DiceNumber == RandomDice)
                {
                    NewRoll = NewRoll + RandomDice;
                    switch (RandomDice)// результат выпадения костей.
                    {
                        case 1:

                            TextBlock1.Text = ($"Выпала: 1. Поздравляю, удача на твоей стороне, неудачник.");
                            await Task.Delay(1000);
                            break;
                        case 2:

                            TextBlock1.Text = ($"Можешь порадоваться, тебе выпала: 2. Ничего страшного, кинь кости еще раз, можно ведь получить результат и похуже.");
                            await Task.Delay(1000);
                            break;
                        case 3:

                            TextBlock1.Text = ($"Тебе выпала: 3. Можешь порадоваться. Ни рыба, ни мясо, даже комментировать тошно.");
                            await Task.Delay(1000);
                            break;
                        case 4:

                            TextBlock1.Text = ($"Упала: 4. Иди лучше перерыв сделай, ато тебе слишком везет.");
                            await Task.Delay(1000);
                            break;
                        case 5:

                            TextBlock1.Text = ($"Эй-эй: 5. Даже не думай о большем, бросай!");
                            await Task.Delay(1000);
                            break;
                        case 6:

                            TextBlock1.Text = ($"Опять 6. Будь ты проклят!");
                            await Task.Delay(1000);

                            break;
                        default:
                            TextBlock1.Text = ($"Ничего не выпало");
                            await Task.Delay(1000);
                            break;

                    }

                    using (var sw = new StreamWriter("Score.txt"))
                    {

                        TextBlock1.Text = $"Твой счет {NewRoll}";
                        await Task.Delay(1000);
                        sw.Write(NewRoll);
                        TextBlock1.Text = "Какое число выпадет?";
                    }
                }
                else
                {
                    TextBlock1.Text = ($"Выпала {RandomDice}, не повезло");
                }
                TextBox1.Text = null;
            }

        }



        private async void Button1_Click(object sender, RoutedEventArgs e)//бросание костей
        {




            TextBlock1.Text = "Бросаем кости";
            await Task.Delay(500);

            if (TextBox1.Text == "")
            {
                TextBlock1.Text = "Подожди, ты не назвал число!";

            }
            else
            {

                Resault();
            }


        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)// условие, что можно вводить лишь цифры
        {
            if (e.Text != "." && IsNumber(e.Text) == false)
            {
                e.Handled = true;
            }
            else if (e.Text == ".")
            {
                if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
                {
                    e.Handled = false;
                }
            }
        }
        private bool IsNumber(string Text)
        {
            int output;
            return int.TryParse(Text, out output);
        }
    }
}

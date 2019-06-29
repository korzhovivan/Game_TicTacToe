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

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        public bool StartNewGame {
            set {
                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].Content = null;
                }
                for (int i = 0; i < 9; i++)
                {
                    game[i] = 0;
                }
                zero = true;
            }
        }

        List<Button> buttons = new List<Button>();

        bool zero = true;
        string path;
        int[] game = new int[9];

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 9; i++)
            {
                game[i] = 0;
            }
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            buttons.Add(btn);

            if (game[Convert.ToInt32(btn.Tag)] == 0)
            {
                if (zero)
                {
                    path = @"Images\2.png";
                    zero = false;
                    game[Convert.ToInt32(btn.Tag)] = 1;
                }
                else
                {
                    path = @"Images\1.png";
                    zero = true;
                    game[Convert.ToInt32(btn.Tag)] = 2;
                }
                Image img = new Image() { Stretch = Stretch.Fill };
                img.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                btn.Content = img;

                if (Array.IndexOf(game, 0) == -1)
                {
                    MessageBox.Show("Nobody Win");
                    StartNewGame = true;
                }
                else
                {
                    if (game[0] == 1 && game[1] == 1 && game[2] == 1 ||
                                    game[3] == 1 && game[4] == 1 && game[5] == 1 ||
                                    game[6] == 1 && game[7] == 1 && game[8] == 1 ||
                                    game[0] == 1 && game[3] == 1 && game[6] == 1 ||
                                    game[1] == 1 && game[4] == 1 && game[7] == 1 ||
                                    game[2] == 1 && game[5] == 1 && game[8] == 1 ||
                                    game[0] == 1 && game[4] == 1 && game[8] == 1 ||
                                    game[6] == 1 && game[4] == 1 && game[2] == 1)
                    {
                        MessageBox.Show("Win Zero");
                        StartNewGame = true;
                    }

                    if (game[0] == 2 && game[1] == 2 && game[2] == 2 ||
                        game[3] == 2 && game[4] == 2 && game[5] == 2 ||
                        game[6] == 2 && game[7] == 2 && game[8] == 2 ||
                        game[0] == 2 && game[3] == 2 && game[6] == 2 ||
                        game[1] == 2 && game[4] == 2 && game[7] == 2 ||
                        game[2] == 2 && game[5] == 2 && game[8] == 2 ||
                        game[0] == 2 && game[4] == 2 && game[8] == 2 ||
                        game[6] == 2 && game[4] == 2 && game[2] == 2)
                    {
                        MessageBox.Show("Win non Zero");
                        StartNewGame = true;
                    }
                }
            }
        }
    }
}

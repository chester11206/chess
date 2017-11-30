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

namespace START
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SolidColorBrush defaultBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E79460"));
            SolidColorBrush alternateBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E79460"));
            /*Border border = new Border();
            border.BorderBrush = Brushes.Black;
            Thickness thickness = new Thickness();
            border.BorderThickness = thickness;
            */ 
            for (int i = 0; i < 32; i++)
            {
                Grid cell = new Grid();
                Thickness margin = cell.Margin;
                margin.Left = 1;
                margin.Right = 1;
                margin.Top = 1;
                margin.Bottom = 1;
                cell.Margin = margin;

                if ((i + i / 8) % 2 == 0)
                {
                    cell.Background = defaultBrush;
                    ChessBoard_Up.Children.Add(cell);
                }
                else
                {
                    cell.Background = alternateBrush;
                    ChessBoard_Down.Children.Add(cell);
                }
            }
        }
        /*private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            Start.Visibility = System.Windows.Visibility.Hidden;
            InputName.Visibility = System.Windows.Visibility.Visible;
        }
        private void Name_Button_Click(object sender, RoutedEventArgs e)
        {
            InputName.Visibility = System.Windows.Visibility.Hidden;
            OnlineGame.Visibility = System.Windows.Visibility.Visible;
            username.DataContext = Username.Text.ToString();
        }*/
    }
}

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
using CirclesAndYearsLibrary;

namespace IForPW12
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
        delegate void DelegateFindAllSquares(object sender, RoutedEventArgs e);        
        Circles circles = new Circles();
        Centennial centennial = new Centennial();
        private void FindSquaresOfCircles_Click(object sender, RoutedEventArgs e)
        {
            if ((FirstRadius.Text != "") && (SecondRadius.Text != ""))
            {
                try
                {
                    FirstSquare.Text = circles.FirstCircle.FindSquare(circles.Radius = Convert.ToInt32(FirstRadius.Text)).ToString();
                    SecondSquare.Text = circles.SecondCircle.FindSquare(circles.Radius = Convert.ToInt32(SecondRadius.Text)).ToString();
                }
                catch
                {
                    MessageForUser();
                }
            }
            else MessageBox.Show("Необходимо ввести число для дальнейшего выполнения рассчетов!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void FindSquareOfRing_Click(object sender, RoutedEventArgs e)
        {
            SquareOfRing.Text = circles.FindSquareOfRing().ToString();
        }

        private void FirstRadius_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890".IndexOf(e.Text) < 0;
        }

        private void FindAllSquares_Click(object sender, RoutedEventArgs e)
        {
            DelegateFindAllSquares Finder = FindSquaresOfCircles_Click;
            Finder += FindSquareOfRing_Click;
            Finder(sender, e);
        }

        private void DisplayCentennial_Click(object sender, RoutedEventArgs e)
        {
            if(Year.Text != "") centennial.Year = Convert.ToInt32(Year.Text);
            Centennial.Text = centennial.DisplayCentennial().ToString();
        }
        private  void MessageForUser()
        {
            MessageBox.Show("Причина: " + Circles._infoaboutr1lessorequalr2, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

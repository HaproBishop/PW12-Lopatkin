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
using System.Windows.Threading;
using CirclesAndYearsLibrary;
/// <summary>
/// 
/// </summary>
namespace PW12
{
    /// <summary>
    /// Практическая работа №12. Лопаткин Сергей ИСП-31
    /// Реализовать расчет задачи:" +
    ///- Даны два круга с общим центром и радиусами R1 и R2(R1 > R2).Найти площади
    ///этих кругов S1 и S2, а также площадь S3 кольца, внешний радиус которого равен 
    ///R1, внутренний радиус равен R2: S1 = PI * (R1)2, S2 = PI * (R2)2, S3 = S1 – S2.В
    /// качестве значения PI использовать 3.14.
    ///- Дан номер некоторого года(целое положительное число).Определить
    ///соответствующий ему номер столетия, учитывая, что, к примеру, началом 20 
    ///столетия был 1901 год.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();//Создание экземпляра объекта таймер
            timer.Tick += Timer_Tick;//Плюсование действий метода Timer_Tick(За каждый пройденный интервал выполняются действия)
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);//Интервал обновления
            timer.IsEnabled = true;
        }        
        private void Timer_Tick(object sender, EventArgs e)//Метод тика таймера
        {
            if (FirstPage.IsSelected) Exercise.Text = "Задание №1";//Задание статусу текущего задания
            if (SecondPage.IsSelected) Exercise.Text = "Задание №2";
            if (ThirdPage.IsSelected) Exercise.Text = "Стандартные возможности";
            Time.Text = DateTime.Now.ToString("HH:mm");//Задание текущего времени
            DateNow.Text = DateTime.Now.ToString("dd.MM.yyyy");//Задание текущей даты
        }        
        delegate void DelegateFindAllSquares(object sender, RoutedEventArgs e);//Делегат для осуществления быстрого подсчета всех
        bool error;//площадей(специально для клавиши в toolbar)
        Circles circles = new Circles();//Создание экземпляра объекта
        Centennial centennial = new Centennial();
        private void FindSquaresOfCircles_Click(object sender, RoutedEventArgs e)
        {
            FirstPage.Focus();//Фокус на первую закладку
            if ((FirstRadius.Text != "") && (SecondRadius.Text != ""))//Проверка на пустоту значений
            {
                try
                {                    
                    circles.FirstCircle.FindSquare(circles.Radius = Convert.ToInt32(FirstRadius.Text)).ToString();//Универсальное занесение радиуса и нахождение площади
                    circles.SecondCircle.FindSquare(circles.Radius = Convert.ToInt32(SecondRadius.Text)).ToString();
                    FirstSquare.Text = circles.FirstCircle.Square.ToString();//Вывод на экран результатов
                    SecondSquare.Text = circles.SecondCircle.Square.ToString();                    
                    SwitchDefault(2);//Смена фокуса клавиши и работоспособности
                }
                catch
                {
                    MessageForUser();//Отображение шаблона сообщения пользователю
                }
            }
            else MessageForInputCheck();//Отображение шаблона сообщения пользователю
        }/// <summary>
         /// Вычисление площади кольца
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>

        private void FindSquareOfRing_Click(object sender, RoutedEventArgs e)
        {
            FirstPage.Focus();
            if (FirstSquare.Text != "" && SecondSquare.Text != "")//Проверка на включенность кнопки
            {
                SquareOfRing.Text = circles.FindSquareOfRing().ToString();
            }
            else MessageBox.Show("Вам необходимо для начала найти площади кругов, чтобы потом рассчитать площадь кольца","Уведомление",
                MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void FirstRadius_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!error)//Проверка на появление сообщения ошибки (специально для горячих клавиш меню, чтобы не выполнялось занесение данных в
                e.Handled = "1234567890".IndexOf(e.Text) < 0;//сфокусированные поля
            else e.Handled = true;
            error = false;
        }

        private void FindAllSquares_Click(object sender, RoutedEventArgs e)
        {
            DelegateFindAllSquares Finder = FindSquaresOfCircles_Click;//Объявление делегата и последующее присвоение двух методов,
            Finder += FindSquareOfRing_Click;//а также обращение
            Finder(sender, e);
        }

        private void DisplayCentennial_Click(object sender, RoutedEventArgs e)
        {
            SecondPage.Focus();
            if (Year.Text != "")
            {
                centennial.Year = Convert.ToInt32(Year.Text);//Занесение данных в объект
                Centennial.Text = centennial.DisplayCentennial().ToString();//Отображение результата
            }
            else MessageForInputCheck();
        }
        private void MessageForUser()
        {
            error = true;//Присвоение false для последующей проверки появления сообщения об ошибки (для горячих клавиш в меню, чтобы не было занесения данных в
            MessageBox.Show("Причина: " + Circles._infoaboutr1lessorequalr2, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);//сфокусированное поле
        }
        /// <summary>
        /// Справка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Support_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данная программа имеет следующие особенности:\n" +
                "1) Нельзя вводить более 5 символов в строку для радиусов и 8 для ввода года\n" +
                "2) Для быстрого закрытия программы можно использовать клавишу Esc\n" +
                "3) Для открытия доступа к кнопке \"Найти площадь кольца\" неообходимо" +
                " ввести первый радиус так, чтобы он был больше второго\n" +
                "4) В открытом меню \"Действия\" можно нажать клавиши Ctrl + 1/2/3," +
                "в зависимотси от пунктов в меню, для выполнения действий\n" +
                "5) Если не понятно назначение кнопки(кроме стандартных), то можно посмотреть всплывающую подсказку(нужно навестись указателем мыши для этого)", "Справка", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// О программе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Реализовать расчет задачи:" +
                "- Даны два круга с общим центром и радиусами R1 и R2(R1 > R2).Найти площади " +
                "этих кругов S1 и S2, а также площадь S3 кольца, внешний радиус которого равен " +
                "R1, внутренний радиус равен R2: S1 = PI * (R1)2, S2 = PI * (R2)2, S3 = S1 – S2.В" +
                " качестве значения PI использовать 3.14." +
                "- Дан номер некоторого года(целое положительное число).Определить " +
                "соответствующий ему номер столетия, учитывая, что, к примеру, началом 20 " +
                "столетия был 1901 год.", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// Выход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Событие изменения текста в поле Year
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Year_TextChanged(object sender, TextChangedEventArgs e)
        {
            Centennial.Clear();
        }
        /// <summary>
        /// Событие изменения текста в поле FirstRadius
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstRadius_TextChanged(object sender, TextChangedEventArgs e)
        {
            SwitchDefault(1);
            FirstSquare.Clear();
            circles.Clear();
            circles.FirstCircle.Clear();
            circles.SecondCircle.Clear();
        }
        /// <summary>
        /// Событие изменения текста поля SecondRadius
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecondRadius_TextChanged(object sender, TextChangedEventArgs e)
        {
            SwitchDefault(1);
            SecondSquare.Clear();//Очистка значений
            circles.Clear();
            circles.FirstCircle.Clear();//Очистка значений свойств у объектов
            circles.SecondCircle.Clear();
        }
        /// <summary>
        /// Событие получения фокуса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstRadius_GotFocus(object sender, RoutedEventArgs e)
        {
            if (FindSquareOfRing.IsEnabled == true) SwitchDefault(2);//Выбор фокуса в зависимости от включенной кнопки
            else SwitchDefault(1);
        }
        /// <summary>
        /// Данный метод позволяет быстро переключать дефолт на кнопках
        /// </summary>
        /// <param name="error">true, если начальные данные введены и необходимо найти кольцо;
        /// false, если необходимо откатиться и ввести начальные значения</param>
        private void SwitchDefault(int switcher)
        {
            switch (switcher)
            {
                case 1:
                    {                        
                        FindSquaresOfCircles.IsDefault = true;
                        FindSquareOfRing.IsDefault = false;
                        DisplayCentennial.IsDefault = false;//Смена дефолта
                        SquareOfRing.Clear();//Очистка значения площади кольца
                        break;
                    }
                case 2:
                    {                        
                        FindSquareOfRing.IsDefault = true;                                                                        
                        DisplayCentennial.IsDefault = false;
                        break;
                    }
                default:
                    {
                        FindSquaresOfCircles.IsDefault = false;//Используется для закладки "Нахождение столетия"
                        FindSquareOfRing.IsDefault = false;
                        DisplayCentennial.IsDefault = true;
                        break;
                    }
            }
        }
        /// <summary>
        /// Событие фокуса поля Year
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Year_GotFocus(object sender, RoutedEventArgs e)
        {
            SwitchDefault(3);
        }
        /// <summary>
        /// Горячие клавиши меню (должно быть открытым)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Actions.IsSubmenuOpen)
            {
            if(e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D1) FindSquaresOfCircles_Click(sender, e);
                else if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D2) FindSquareOfRing_Click(sender, e);
                else if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D3) DisplayCentennial_Click(sender, e);                
            }                   
        }
        /// <summary>
        /// Шаблонное сообщение пользователю
        /// </summary>
        private void MessageForInputCheck()
        {
            error = true;
            MessageBox.Show("Необходимо ввести число для дальнейшего выполнения рассчетов!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        /// <summary>
        /// Проверка фокуса закладок для установки фокуса внутри них
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            if (e.Source == FirstPage) FirstRadius.Focus();            
            if (e.Source == SecondPage) Year.Focus();            
        }
        /// <summary>
        /// Шаблонное заполнение для контекстного меню для радиусов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoFillRadiuses_Click(object sender, RoutedEventArgs e)
        {
            FirstRadius.Text = "4";
            SecondRadius.Text = "2";
        }

        /// <summary>
        /// Шаблонное заполнение для контекстного меню для года
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoFillYear_Click(object sender, RoutedEventArgs e)
        {
            Year.Text = DateTime.Now.ToString("yyyy");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CirclesAndYearsLibrary
{
    public class Circles:Circle
    {        
        static string _infoaboutr1lessorequalr2 = "R1 <= R2";
        public Circle FirstCircle { get; set; }
        public Circle SecondCircle { get; set; }
        /// <summary>
        /// Сравнение значений 
        /// (R1 > R2) - должно быть, иначе - нельзя добавить R2
        /// </summary>
        /// <param name="value">Вводимое число</param>
        /// <returns></returns>
        public double FindSquareOfRing(Circle firstcircle, Circle secondcircle)
        {
            try
            {
                if (firstcircle.Radius <= secondcircle.Radius) throw new Exception(_infoaboutr1lessorequalr2);
                else
                {
                    FirstCircle = firstcircle;
                    SecondCircle = secondcircle;                    
                    return FirstCircle.Square - SecondCircle.Square;
                }
            }
            catch
            {
                MessageBox.Show("Причина: "+ _infoaboutr1lessorequalr2, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return 0;
        }
        public static double FindSquareOfRing(double firstsquare, double secondsquare)
        {
            try
            {
                if (firstsquare <= secondsquare) throw new Exception(_infoaboutr1lessorequalr2);
                else
                {                    
                    return firstsquare - secondsquare;
                }
            }
            catch
            {
                MessageBox.Show(_infoaboutr1lessorequalr2, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return 0;
        }
    }
}

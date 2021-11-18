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
        double _finalsquare;
        Circle _firstcircle = new Circle();
        Circle _secondcircle = new Circle();
        static string _infoaboutr1lessorequalr2 = "R1 <= R2. Необходимо R1>R2, то есть радиус первого круга больше второго";        
        public Circle FirstCircle { get => _firstcircle; set => _firstcircle = value; }
        public Circle SecondCircle { get => _secondcircle; set => _secondcircle = ProveR1MoreR2(value.Radius) ? value : throw new Exception(_infoaboutr1lessorequalr2); }
        public double FinalSquare { get => _finalsquare; }    
        private bool ProveR1MoreR2(int value)
        {
            if (_firstcircle.Radius > value) return true;
            else return false;
        }
        public Circles() { }
        public Circles(Circle firstcircle, Circle secondcircle)
        {
            FirstCircle = firstcircle.Clone();
            SecondCircle = secondcircle.Clone();
        }
        public void GiveRadiuses(Circle firstcircle, Circle secondcircle)
        {
            FirstCircle = new Circle(firstcircle.Radius);            
            SecondCircle = new Circle(secondcircle.Radius);            
        }
        public void GiveCircles(Circle firstcircle, Circle secondcircle)
        {
            FirstCircle = firstcircle.Clone();
            SecondCircle = secondcircle.Clone();            
        }
        public double FindSquareOfRing()
        {            
            return _finalsquare = FirstCircle.Square - SecondCircle.Square;
        }
        public double FindSquareOfRing(Circle firstcircle, Circle secondcircle)
        {
            try
            {
                if (firstcircle.Radius <= secondcircle.Radius) throw new Exception(_infoaboutr1lessorequalr2);
                else
                {
                    FirstCircle = firstcircle;
                    SecondCircle = secondcircle;                    
                    return _finalsquare = FirstCircle.Square - SecondCircle.Square;
                }
            }
            catch
            {
                MessageForUser();
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
                MessageForUser();
            }
            return 0;
        }
        public new Circles Clone()
        {
            return (Circles)MemberwiseClone();
        }
        private static void MessageForUser()
        {
            MessageBox.Show("Причина: " + _infoaboutr1lessorequalr2, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

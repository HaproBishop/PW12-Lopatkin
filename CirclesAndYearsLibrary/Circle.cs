using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclesAndYearsLibrary
{
    public class Circle
    {
        int _radius;
        double _square;
        const double _PI = 3.14;
        string _infoabout0 = "Значение меньше или равно 0";
        public int Radius
        {
            get => _radius; set => _radius = ProveValue(value) ? value : throw new Exception(_infoabout0);
        }
        public double Square 
        { 
            get => _square; set => _square = ProveValue(value) ? value : throw new Exception(_infoabout0); 
        }
        /// <summary>
        /// Проверяет на отрицательность числа, вводящего пользователем
        /// </summary>
        /// <param name="value">Вводимое число</param>
        /// <returns></returns>
        private bool ProveValue(double value)
        {
            if (value > 0) return true;
            return false;
        }
        public Circle() { }
        public Circle(int radius)
        {
            Radius = radius;
        }
        public double FindSquare()
        {
            return Square = _PI * Math.Pow(Radius, 2);
        }
        public double FindSquare(int radius)
        {            
            return Square = _PI * Math.Pow(Radius=radius, 2);
        }
        public Circle Clone()
        {
            return (Circle)MemberwiseClone();
        }
    }
}

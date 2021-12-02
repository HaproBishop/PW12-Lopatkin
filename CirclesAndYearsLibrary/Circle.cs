using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclesAndYearsLibrary
{/// <summary>
/// Класс для вычисления площади круга
/// </summary>
    public class Circle:ICloneable
    {
        int _radius;
        int _reservedradius;
        double _square;
        double _reservedsquare;        
        const double _PI = 3.14;
        public static string _infoabout0 = "Значение меньше или равно 0";
        public int ReservedRadius { get => _reservedradius; }
        public double ReservedSquare { get => _reservedsquare; }
        public virtual int Radius
        {
            get => _radius;
            set
            {
                if (ProveValue(value))
                {
                    _reservedradius = _radius;                    
                    _radius = value;
                }
                else throw new Exception(_infoabout0);
            }
        }        
        public double Square { get => _square;}
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
        }/// <summary>
        /// Нахождение площади круга
        /// </summary>
        /// <returns></returns>
        public double FindSquare()
        {
            return _square = _PI * Math.Pow(Radius, 2);
        }
        /// <summary>
        /// Нахождение площади круга с заданным радиусом
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        public double FindSquare(int radius)
        {            
            return _square = _PI * Math.Pow(Radius=radius, 2);
        }
        /// <summary>
        /// Нахождение площади без создания объекта
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        public static double FindSquare(double radius)
        {
            return _PI * Math.Pow(radius, 2);
        }/// <summary>
        /// Универсальное клонирование объектов типа Circle или Circles
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Clone<T>()
        {
            return (T)MemberwiseClone();
        }/// <summary>
        /// Стандартное клонирование
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }/// <summary>
        /// Очистка данных объекта с предварительным сохранением
        /// </summary>
        public void Clear()
        {
            _reservedradius = _radius;
            _radius = 0;
            _reservedsquare = _square;
            _square = 0;
        }
    }
}

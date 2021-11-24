using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CirclesAndYearsLibrary
{/// <summary>
/// Класс, выполняющий вычисления площади кольца с учетом заданных условий (R1>R2 And S3=S1-S2)
/// </summary>
    public class Circles:Circle
    {        
        double _finalsquare;
        Circle _firstcircle = new Circle();
        Circle _secondcircle = new Circle();
        public static string _infoaboutr1lessorequalr2 = "R1 <= R2. Необходимо R1>R2, то есть радиус первого круга должен быть больше второго";
        public override int Radius 
        { 
            get => base.Radius; 
            set
            {
                if (ProveR1MoreR2(value))
                {                    
                    base.Radius = value;                    
                }
                else throw new Exception(_infoaboutr1lessorequalr2);
            } 
        }
        public Circle FirstCircle { get => _firstcircle; set =>_firstcircle = value; }
        public Circle SecondCircle { get => _secondcircle; set => _secondcircle = value; }
        public double FinalSquare { get => _finalsquare; }    
        /// <summary>
        /// Выполняется двухэтапная проверка числа на заданное условие(R1>R2 And R(Все)> 0)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool ProveR1MoreR2(int value)
        {
            if (base.Radius == value) return false;            
            else if ((_firstcircle.Radius == 0 && _secondcircle.Radius == 0) ^ _firstcircle.Radius >= value)
                return true;
            else return false;
        }
        public Circles() { }
        /// <summary>
        /// Создание объекта с хранящимися в нем объектами класса Circle
        /// </summary>
        /// <param name="firstcircle"></param>
        /// <param name="secondcircle"></param>
        public Circles(Circle firstcircle, Circle secondcircle)
        {
            FirstCircle = firstcircle.Clone<Circle>();
            SecondCircle = secondcircle.Clone<Circle>();
        }/// <summary>
        /// Задание радиусов для кругов внутри класса из объектов
        /// </summary>
        /// <param name="firstcircle"></param>
        /// <param name="secondcircle"></param>
        public void GiveRadiuses(Circle firstcircle, Circle secondcircle)
        {
            FirstCircle.Radius = firstcircle.Radius;            
            SecondCircle.Radius = secondcircle.Radius;            
        }/// <summary>
        /// Задание радиусов относительно простых int значений
        /// </summary>
        /// <param name="firstradius"></param>
        /// <param name="secondradius"></param>
        public void GiveRadiuses(int firstradius, int secondradius)
        {
            FirstCircle.Radius = firstradius;
            SecondCircle.Radius = secondradius;
        }/// <summary>
        /// Клонирование данных объектов во внутренние
        /// </summary>
        /// <param name="firstcircle"></param>
        /// <param name="secondcircle"></param>
        public void GiveCircles(Circle firstcircle, Circle secondcircle)
        {
            FirstCircle = firstcircle.Clone<Circle>();
            SecondCircle = secondcircle.Clone<Circle>();            
        }/// <summary>
        /// Нахождение площади кольца относительно объектов, хранящихся в классе Circles
        /// </summary>
        /// <returns></returns>
        public double FindSquareOfRing()
        {            
            return _finalsquare = Math.Round(FirstCircle.Square - SecondCircle.Square, 2);
        }/// <summary>
        /// Нахождение площади кольца вместе с заданием новых объектов и их площадей
        /// </summary>
        /// <param name="firstcircle"></param>
        /// <param name="secondcircle"></param>
        /// <returns></returns>
        public double FindSquareOfRing(Circle firstcircle, Circle secondcircle)
        {
            FirstCircle = firstcircle.Clone<Circle>();
            SecondCircle = secondcircle.Clone<Circle>();                    
            return _finalsquare = Math.Round(FirstCircle.Square - SecondCircle.Square,2);
        }/// <summary>
        /// Нахождение площади кольца без создания объекта
        /// </summary>
        /// <param name="firstsquare"></param>
        /// <param name="secondsquare"></param>
        /// <returns></returns>
        public static double FindSquareOfRing(double firstsquare, double secondsquare)
        {
            return firstsquare - secondsquare;
        }
    }
}

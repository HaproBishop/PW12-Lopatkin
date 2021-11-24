using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclesAndYearsLibrary
{/// <summary>
/// Класс для отображения столетия относительно заданного года
/// </summary>
    public class Centennial
    {
        public string _errorinfo = "Год не может быть отрицательным!";
        int _year;
        public int Year { get => _year; set => _year = ProveValue(value) ? value : throw new Exception(_errorinfo); }
        public Centennial() { }
        public Centennial(int year)
        {
            Year = year;
        }/// <summary>
        /// Локальная праверка значения
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool ProveValue(double value)
        {
            if (value >= 0) return true;
            return false;
        }/// <summary>
        /// Отображение столетия
        /// </summary>
        /// <returns></returns>
        public int DisplayCentennial()
        {
            if (_year % 100 >= 1) return _year / 100 + 1;
            else return _year / 100;
        }/// <summary>
        /// Отображение столетия с заданным годом
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public int DisplayCentennial(int year)
        {
            Year = year;
            if (_year % 100 >= 1) return _year / 100 + 1;
            else return _year / 100;
        }/// <summary>
        /// Отображение столетия без создания объекта
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static int DisplayCentennial(double year)
        {            
            if (Convert.ToInt32(year) % 100 >= 1) return Convert.ToInt32(year) / 100 + 1;
            else return Convert.ToInt32(year) / 100;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclesAndYearsLibrary
{
    public class Centennial
    {
        public string _errorinfo = "Год не может быть отрицательным!";
        int _year;
        public int Year { get => _year; set => _year = ProveValue(value) ? value : throw new Exception(_errorinfo); }
        public Centennial() { }
        public Centennial(int year)
        {
            Year = year;
        }
        private bool ProveValue(double value)
        {
            if (value >= 0) return true;
            return false;
        }
        public int DisplayCentennial()
        {
            if (_year % 100 >= 1) return _year / 100 + 1;
            else return _year / 100;
        }
        public int DisplayCentennial(int year)
        {
            Year = year;
            if (_year % 100 >= 1) return _year / 100 + 1;
            else return _year / 100;
        }
    }
}

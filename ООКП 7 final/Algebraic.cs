using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООКП_7_final
{
    class Algebraic
    {
        public string AlgebraicDec(string ad, string bd, string sym, int doubint)
        {
            double a = 0, b = 0;
            try { a = Convert.ToDouble(ad); b = Convert.ToDouble(bd); }
            catch { a = Convert.ToDouble(ad); b = 0; }
            switch (sym)
            {
                case "+":
                    return Convert.ToString(b + a);
                case "-":
                    return Convert.ToString(b - a);
                case "*":
                    return Convert.ToString(b * a);
                case "/":
                    if (doubint == 0) return Convert.ToString(Convert.ToInt32(b / a));
                    else return Convert.ToString(b / a);
                case "?":
                    return Convert.ToString(Math.Sin(a));
                case "$":
                    return Convert.ToString(Math.Cos(a));
                case "`":
                    return Convert.ToString(Math.Tan(a));
                case "^":
                    return Convert.ToString(Math.Pow(b, a));
                default:
                    return "Ошибка!";
            }
        }
    }
}

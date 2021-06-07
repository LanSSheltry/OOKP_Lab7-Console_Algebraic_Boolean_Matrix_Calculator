using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООКП_7_final
{
    class Boolean
    {
        public string BooleanDec(string ad, string bd, string sym)
        {
            double a, b;
            try { a = Convert.ToInt16(ad); b = Convert.ToInt16(bd); }
            catch { a = Convert.ToInt16(ad); b = 0; }
            if ((a > 1 || a < 0) || (b > 1 || b < 0)) return "Ошибка: выражение не является булевым!";
            switch (sym)
            {
                case "!":
                    if (a == 1) return "0";
                    else return "1";
                case "%":
                    if (a == 1 & b == 1) return "1";
                    else if ((a == 1 & b == 0) || (a == 0 & b == 1)) return "1";
                    else return "0";
                case "~":
                    if (a == 1 & b == 1) return "1";
                    else if ((a == 1 & b == 0) || (a == 0 & b == 1)) return "0";
                    else return "0";
                default:
                    return "Ошибка!";
            }
        }
    }
}

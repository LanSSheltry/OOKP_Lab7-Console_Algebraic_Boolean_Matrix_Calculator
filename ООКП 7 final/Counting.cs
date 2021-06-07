using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООКП_7_final
{
    class Counting
    {
        public int GetPriorityAlg(string sym)
        {
            if (sym == "(" || sym == ")")
            {
                return 0;
            }
            else if (sym == "+" || sym == "%")
            {
                return 1;
            }
            else if (sym == "/" || sym == "*" || sym == "~")
            {
                return 2;
            }
            else if (sym == "?" || sym == "$" || sym == "`" || sym == "!" || sym == "=" || sym == "^")
            {
                return 3;
            }
            else
            {
                return -1;
            }
        }

        public int IsUnary(char last, char curr)
        {
            if ((last == '(' || last == '/' || last == '*' || last == '+' || last == '-') & curr == '-') return 1;
            else return 0;
        }

        public string Decider(string ad, string bd, string sym, int var, int doubint)
        {
            if (var == 1)
            {
                try
                {
                    Algebraic algebraic = new Algebraic();
                    return algebraic.AlgebraicDec(ad, bd, sym, doubint);
                }
                catch { return "Произошла неизвестная ошибка!"; }
            }
            else if (var == 2)
            {
                Boolean boolean = new Boolean();
                return boolean.BooleanDec(ad, bd, sym);
            }
            else if (var == 3)
            {
                Matrix matrix = new Matrix();
                return matrix.MatrixCounter(ad, bd, sym);
            }
            return "";
        }
    }
}

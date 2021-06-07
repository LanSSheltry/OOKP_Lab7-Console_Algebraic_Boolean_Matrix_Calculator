using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ООКП_7_final
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Данная программа предназначена для подсчета значения введенного выражения\nАлгоритмом поддерживаются следующие типы выражений:" +
                "\n1 - Алгебраические (+, -, /, *, sin, cos, pi, e, ^, (, ), пользовательские переменные). Пример: 1+(2*cos(e)+pi-a)." +
                "\n2 - Булевые (/\u005c, \u005c/, !, пользовательские переменные) Пример: !1/\u005c!(0)." +
                "\n3 - Матрицы (inv(), +, -, *) Пример: inv([1 2 3 ; 3 2 1 ; 2 1 3])+[0 4 1 ; 4 6 2 ; 6 4 2]." +
                "\n");
            WriteLine("Для выхода введите 'exit'...");
            while (true)
            {
                int variant = 0;
                WriteLine("\nВведите выражение, значение которого необходимо найти: ");
                string expression = Convert.ToString(ReadLine());
                if (expression.Contains('[')) variant = 3;
                else if (expression.Contains(Convert.ToChar('\u005c'.ToString())) || expression.Contains('!')) variant = 2;
                else if (expression == "exit") break;
                else variant = 1;
                InputData input = new InputData(expression, variant);
                input.InputF();
            }
        }
    }
}

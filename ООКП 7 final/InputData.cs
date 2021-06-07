﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООКП_7_final
{
    class InputData : Notation
    {
        private string expression;
        private int variant;
        List<double> Now;
        public List<char> letters = new List<char>();
        public List<double> values = new List<double>();
        private char[] characters = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.', '%', '$', '?', '(', ')', '*', '/', '+', '-', '#', '@', ',', '`', '!', '%', '~', '[', ']', ' ', ';', '=', '^' };
        public InputData(string expr, int var)
        {
            expression = expr;
            variant = var;
        }

        public string InputF()
        {
            IsReservedSymbol();
            IsCharacters();
            Console.WriteLine("Присвойте значение переменным (Для остановки ввода нажмите enter дважды после ввода всех значений):");
            try
            {
                int cnt = 0;
                string current;
                while (true)
                {
                    Console.Write(letters[cnt] + "=");
                    current = Console.ReadLine();
                    if (current != null) values.Add(Convert.ToDouble(current.Replace('.', ',')));
                    cnt++;
                    cnt %= letters.Count;
                }
            }
            catch { Console.WriteLine("Значения введены..."); }
            if (values.Count != 0)
            {
                while (values.Count != 0)
                {
                    Values();
                    Format(letters, Now, expression, variant);
                }
            }
            else
            {
                Format(letters, Now, expression, variant);
            }

            return expression;
        }

        private void Values()
        {
            Now = new List<double>();
            try
            {
                for (int k = 0; k < letters.Count; k++)
                {
                    Now.Add(values[0]);
                    values.RemoveAt(0);
                }
            }
            catch { }
        }
        private void IsCharacters()
        {
            foreach (char a in expression)
            {
                if (characters.Contains(a) == false)
                {
                    letters.Add(a);
                }
            }
        }

        private void IsReservedSymbol()
        {
            List<char> chars = new List<char>();
            string s2 = "";
            bool mat = false;
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '[') mat = !mat;
                else if (expression[i] == ']') mat = !mat;
                try
                {
                    if (expression[i] == 'e')
                    {
                        chars.Add('#');
                    }
                    else if (expression[i] == '.')
                    {
                        chars.Add(',');
                    }
                    else if (expression[i] == '-')
                    {
                        if (i != 0)
                        {
                            if (expression[i - 1] != '(' & expression[i - 1] != '*' & expression[i - 1] != '/' & expression[i - 1] != '^' & expression[i - 1] != '+')
                                chars.Add('+');
                        }
                        chars.Add('(');
                        chars.Add('-');
                        chars.Add('1');
                        chars.Add(')');
                        chars.Add('*');
                    }
                    else if (expression[i] == 'p' & expression[i + 1] == 'i')
                    {
                        chars.Add('@');
                        i++;
                    }
                    else if (expression[i] == Convert.ToChar('\u005c'.ToString()) & expression[i + 1] == '/')
                    {
                        chars.Add('%');
                        i++;
                    }
                    else if (expression[i] == '/' & expression[i + 1] == Convert.ToChar('\u005c'.ToString()))
                    {
                        chars.Add('~');
                        i++;
                    }
                    else if (expression[i] == 's' & expression[i + 1] == 'i' & expression[i + 2] == 'n')
                    {
                        chars.Add('?');
                        i += 2;
                    }
                    else if (expression[i] == 'c' & expression[i + 1] == 'o' & expression[i + 2] == 's')
                    {
                        chars.Add('$');
                        i += 2;
                    }
                    else if (expression[i] == 't' & expression[i + 1] == 'a' & expression[i + 2] == 'n')
                    {
                        chars.Add('`');
                        i += 2;
                    }
                    else if (expression[i] == 'i' & expression[i + 1] == 'n' & expression[i + 2] == 'v')
                    {
                        chars.Add('=');
                        i += 2;
                    }
                    else
                    {
                        if ((expression[i] != ' ') & mat == false) chars.Add(expression[i]);
                        else if (mat == true) { chars.Add(expression[i]); }
                    }
                }
                catch
                {
                    if ((expression[i] != ' ') & mat == false) chars.Add(expression[i]);
                    else if (mat == true) { chars.Add(expression[i]); }
                }
            }
            for (int i = 0; i < chars.Count; i++)
            {
                s2 += chars[i];
            }
            expression = Convert.ToString(s2);
        }
    }
}

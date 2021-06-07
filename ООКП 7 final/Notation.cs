using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООКП_7_final
{
    class Notation : Counting
    {
        string after;
        const double e = Math.E;
        const double pi = Math.PI;
        List<string> separated;
        List<string> polnotation;
        public int selectedvariant;

        protected string Format(List<char> letters, List<double> values, string expression, int var)
        {
            after = "";
            selectedvariant = var;
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '@')
                {
                    after += Convert.ToString(pi);
                }
                else if (expression[i] == '#')
                {
                    after += Convert.ToString(e);
                }
                else
                {
                    int k = 0;
                    if (letters.Count > 0)
                    {
                        for (int j = 0; j < letters.Count; j++)
                        {
                            if (expression[i] == letters[j])
                            {
                                after += Convert.ToString(values[j]);
                                k = 1;
                            }
                        }
                    }
                    if (k == 0) after += expression[i];
                }
            }
            StringToArr();
            return after;
        }


        int doubint = 0;
        protected List<string> StringToArr()
        {
            string cache = "";
            separated = new List<string>();
            for (int i = 0; i < after.Length; i++)
            {
                if (GetPriorityAlg(Convert.ToString(after[i])) != -1)
                {
                    try
                    {
                        if (IsUnary(after[i - 1], after[i]) == 1)
                        {
                            cache += after[i];
                        }
                        else
                        {
                            if (cache != "") separated.Add(cache);
                            separated.Add(Convert.ToString(after[i]));
                            cache = "";
                        }
                    }
                    catch
                    {
                        if (IsUnary('/', after[i]) == 1)
                        {
                            cache += after[i];
                        }
                        else
                        {
                            if (cache != "") separated.Add(cache);
                            separated.Add(Convert.ToString(after[i]));
                            cache = "";
                        }
                    }

                }
                else
                {
                    cache += after[i];
                    if (cache.Contains(",") == true) doubint++;
                }
            }
            if (cache != "") separated.Add(cache);
            ConvertToPol();
            return separated;
        }

        protected List<string> ConvertToPol()
        {
            polnotation = new List<string>();
            Stack<string> operations = new Stack<string>();
            for (int i = 0; i < separated.Count; i++)
            {
                if (GetPriorityAlg(separated[i]) == -1)
                {
                    polnotation.Add(separated[i]);
                }
                if (GetPriorityAlg(separated[i]) != -1)
                {
                    if (separated[i] == "(")
                    {
                        operations.Push(separated[i]);
                    }
                    else if (separated[i] == ")")
                    {
                        try
                        {
                            string str = operations.Pop();
                            while (str != "(")
                            {
                                polnotation.Add(str);
                                str = operations.Pop();
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        if (operations.Count > 0)
                        {
                            if (GetPriorityAlg(separated[i]) <= GetPriorityAlg(operations.Peek()))
                            {
                                polnotation.Add(operations.Pop());
                            }
                        }
                        operations.Push(Convert.ToString(char.Parse(separated[i])));
                    }
                }
            }
            string s;
            while (operations.Count != 0)
            {
                s = operations.Pop();
                polnotation.Add(s);
            }
            Console.WriteLine("\nОтвет: " + Count());

            return polnotation;
        }

        protected string Count()
        {
            Stack<string> tmp = new Stack<string>();
            for (int i = 0; i < polnotation.Count; i++)
            {
                if (GetPriorityAlg(polnotation[i]) == -1)
                {
                    tmp.Push(polnotation[i]);
                }
                else
                {
                    string symbol = polnotation[i];
                    if (symbol == "?" || symbol == "$" || symbol == "`" || symbol == "!" || symbol == "=")
                    {
                        string a = tmp.Pop();
                        tmp.Push(Decider(a, "0", symbol, selectedvariant, doubint));
                    }
                    else
                    {
                        string a = tmp.Pop();
                        string b = tmp.Pop();
                        tmp.Push(Decider(a, b, symbol, selectedvariant, doubint));
                    }
                }
            }
            return " " + tmp.Peek();
        }
    }
}

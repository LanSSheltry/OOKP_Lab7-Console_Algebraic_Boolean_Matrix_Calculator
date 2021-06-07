using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООКП_7_final
{
    class Matrix
    {
        private List<List<double>> Mult(List<List<double>> mat1, List<List<double>> mat2)
        {
            int col2 = mat2[0].Count;
            int col1 = mat1[0].Count;
            double[,] M = new double[mat2.Count, col1];
            List<List<double>> mat3 = new List<List<double>>();

            for (int i = 0; i < mat2.Count; i++)
            {
                mat3.Add(new List<double>());
                for (int j = 0; j < col1; j++)
                {
                    mat3[i].Add(0);
                }
            }
            for (int i = 0; i < mat2.Count; i++)
            {
                for (int j = 0; j < col1; j++)
                {
                    for (int k = 0; k < col2; k++)
                    {
                        mat3[i][j] += mat1[k][j] * mat2[i][k];
                    }
                }
            }
            return mat3;
        }

        private List<List<double>> Inversion(List<List<double>> mat1, List<List<double>> mat2)
        {
            List<List<double>> matr = new List<List<double>>();
            List<List<double>> mat3 = new List<List<double>>();
            int col1 = mat1[0].Count;
            for (int i = 0; i < mat1.Count; i++)
            {
                mat3.Add(new List<double>());
                matr.Add(new List<double>());
                for (int j = 0; j < col1 * 2; j++)
                {

                    matr[i].Add(0);
                }
            }
            if (col1 == matr.Count)
            {
                int h = matr.Count;
                double t = 0;
                for (int i = 0; i < h; i++)
                    for (int j = 0; j < h; j++)
                        matr[i][j] = mat1[i][j];
                for (int i = 0; i < h; i++)
                    for (int j = h; j < 2 * h; j++)
                        if (i == j - h)
                            matr[i][j] = 1;
                        else { matr[i][j] = 0; }
                for (int i = 0; i < h; i++)
                {
                    t = matr[i][i];
                    for (int j = i; j < 2 * h; j++)
                    {
                        matr[i][j] = matr[i][j] / t;
                    }
                    for (int j = 0; j < h; j++)
                    {
                        if (i != j)
                        {
                            t = matr[j][i];
                            for (int k = 0; k < 2 * h; k++)
                            {
                                matr[j][k] = matr[j][k] - t * matr[i][k];
                            }
                        }
                    }
                }
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < col1 * 2; j++)
                    {
                        try { Console.WriteLine("Det=0!"); }
                        catch { }
                        if (j >= col1) mat3[i].Add(Convert.ToDouble(matr[i][j]));
                    }
                }
            }
            else { Console.WriteLine("Матрица не является квадратной!"); }
            return mat3;
        }

        private List<List<double>> Alg(List<List<double>> mat1, List<List<double>> mat2, string sym)
        {
            List<List<double>> mat3 = new List<List<double>>();
            if (mat1.Count == mat2.Count)
            {
                for (int i = 0; i < mat1.Count; i++)
                {
                    mat3.Add(new List<double>());
                    if (mat1[i].Count == mat2[i].Count)
                    {
                        for (int j = 0; j < mat1[i].Count; j++)
                        {
                            if (sym == "+") mat3[i].Add(mat2[i][j] + mat1[i][j]);
                            if (sym == "-") mat3[i].Add(mat2[i][j] - mat1[i][j]);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return mat3;
        }
        public string MatrixCounter(string ad, string bd, string sym)
        {
            List<List<double>> mat1 = new List<List<double>>();
            List<List<double>> mat2 = new List<List<double>>();
            string matsolution = "[ ";
            if (sym == "=")
            {
                mat1 = SyntaxMatix(ad);
            }
            else
            {
                mat1 = SyntaxMatix(ad);
                mat2 = SyntaxMatix(bd);
            }
            List<List<double>> mat3 = new List<List<double>>();
            if (sym == "-" || sym == "+")
            {
                mat3 = Alg(mat1, mat2, sym);
            }

            if (sym == "*")
            {
                if (bd.Contains('[') & ad.Contains('[')) mat3 = Mult(mat1, mat2);
                else if (bd.Contains('[') == false) mat3 = Coef(mat1, bd);
                else if (ad.Contains('[') == false) mat3 = Coef(mat2, ad);
            }
            if (sym == "=")
            {
                mat3 = Inversion(mat1, mat2);
            }


            int y = 0;
            for (int i = 0; i < mat3.Count; i++)
            {
                for (int j = 0; j < mat3[i].Count; j++)
                {
                    matsolution += Convert.ToString(mat3[i][j]) + " ";
                    if (i == mat3.Count - 1) y = 1;
                }
                if (y == 0) matsolution += " ; ";
                y = 0;
            }
            matsolution += " ]";
            return matsolution;
        }

        private List<List<double>> Coef(List<List<double>> mat1, string coef)
        {
            for (int i = 0; i < mat1.Count; i++)
            {
                for (int j = 0; j < mat1[i].Count; j++)
                {
                    mat1[i][j] *= Convert.ToDouble(coef);
                }
            }
            return mat1;
        }
        private List<List<double>> SyntaxMatix(string mat)
        {
            List<List<double>> matrix = new List<List<double>>();
            int index1 = 1;
            int index2 = 0;
            int sign = 1;
            if (mat[0] == '-') sign = -1;
            string cache = "";
            matrix.Add(new List<double>());
            while (true)
            {
                try
                {
                    if (index1 < mat.Length || index2 <= 100)
                    {
                        if ((mat[index1] == ' ' || mat[index1] == ']' || mat[index1] == ';' || mat[index1] == '[') & cache != "")
                        {
                            matrix[index2].Add(Convert.ToDouble(cache) * sign);
                            cache = "";
                            index1++;
                        }
                        else if (mat[index1] != ' ' & mat[index1] != ']' & mat[index1] != ';' & mat[index1] != '[')
                        {
                            cache += mat[index1];
                            index1++;
                        }
                        else if (mat[index1] == ';')
                        {
                            matrix.Add(new List<double>());
                            index1++;
                            index2++;
                        }
                        else if (index1 < mat.Length) { index1++; }
                        else { break; }
                    }
                    else { break; }
                }
                catch { break; }

            }
            return matrix;
        }
    }
}

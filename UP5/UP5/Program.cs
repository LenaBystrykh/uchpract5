using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP5
{
    class Program
    {
        static void Main(string[] args)
        {
            double upSumm, downSumm, eqSumm;
            int N = ReadN();
            double[,] matrix = new double[N, N];
            matrix = GenerateMatrix(N, matrix);
            PrintMatrix(N, matrix);
            GetSumm(N, matrix, out upSumm, out downSumm, out eqSumm);
            Console.WriteLine();
            Console.WriteLine("Сумма элементов выше главной диагонали, находящихся в строках, начинающихся с отрицательных элементов = " + upSumm);
            Console.WriteLine("Сумма элементов ниже главной диагонали, находящихся в строках, начинающихся с отрицательных элементов = " + downSumm);
            Console.WriteLine("Сумма элементов на главной диагонали, находящихся в строках, начинающихся с отрицательных элементов = " + eqSumm);

        }
        public static int ReadN()
        {
            bool ok;
            int N;

            Console.WriteLine("Введите размерность квадратной матрицы - целое число");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out N);
                if (!ok) Console.WriteLine("Ошибка ввода, повторите попытку");
                if (N < 2) Console.WriteLine("Матрица не может содержать меньше 2 строк и столбцов");
            } while (!ok || N < 2);
            return N;
        }
        public static double[,] GenerateMatrix(int N, double[,] matrix)
        {
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = Math.Round((rnd.NextDouble() * 40 - 20), 2); //генерация случайных вещественных чисел от -20 до 20 с 2 знаками после запятой                 
                }
            }
            return matrix;
        }
        public static void PrintMatrix(int N, double[,] matrix)
        {
            Console.WriteLine();
            Console.WriteLine("Полученная матрица:");
            Console.WriteLine();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void GetSumm(int N, double[,] matrix, out double upSumm, out double downSumm, out double eqSumm)
        {
            upSumm = 0; 
            downSumm = 0; 
            eqSumm = 0;
            for (int i = 0; i < N; i++)
            {
                if (matrix[i,0] < 0)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (i > j)
                        {
                            downSumm += matrix[i, j];
                        }
                        else
                        {
                            if (i < j)
                            {
                                upSumm += matrix[i, j];
                            }
                            else
                            {
                                if (i == j)
                                {
                                    eqSumm += matrix[i, j];
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

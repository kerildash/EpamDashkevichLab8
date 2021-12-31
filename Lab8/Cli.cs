using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class Cli
    {
        public void Menu()
        {
            bool isExit = false;
            while (!isExit)
            {
                try
                {
                    Console.WriteLine("\n   MENU");
                    Console.WriteLine("1. Matrix addition.");
                    Console.WriteLine("2. Matrix subtraction.");
                    Console.WriteLine("3. Matrix multiplication.");
                    Console.WriteLine("0. Exit.");
                    Console.Write("Choose what to do: ");
                    int menuItem = int.Parse(Console.ReadLine());

                    switch (menuItem)
                    {
                        case 1:
                            MatrixAddition();
                            break;
                        case 2:
                            MatrixSubtraction();
                            break;
                        case 3:
                            MatrixMultiplication();
                            break;
                        case 0:
                            isExit = true;
                            break;
                        default:
                            Console.WriteLine("Incorrect input");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        private void MatrixAddition()
        {
            Matrix a, b;
            InputMatrices(out a, out b);
            Matrix c = a + b;
            Console.WriteLine($"{a} +\n{b} =\n{c}");
        }

        private void MatrixSubtraction()
        {
            Matrix a, b;
            InputMatrices(out a, out b);
            Matrix c = a - b;
            Console.WriteLine($"{a} +\n{b} =\n{c}");
        }
        private void MatrixMultiplication()
        {
            Matrix a, b;
            InputMatrices(out a, out b);
            Matrix c = a * b;
            Console.WriteLine($"{a} +\n{b} =\n{c}");
        }
        private void InputMatrices(out Matrix a, out Matrix b)
        {
            Console.Write("Enter first matrix: ");
            a = InputMatrix();
            Console.Write("Enter second matrix: ");
            b = InputMatrix();
        }
        private Matrix InputMatrix()
        {
            int numberOfRows;
            int numberOfColumns;
            double[,] matrix;

            Console.Write("\nEnter number of rows: ");
            numberOfRows = int.Parse(Console.ReadLine());
            Console.Write("Enter number of columns: ");
            numberOfColumns = int.Parse(Console.ReadLine());

            matrix = new double[numberOfRows, numberOfColumns];

            Console.WriteLine("\nInput of matrix.\n");
            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
            {
                Console.WriteLine($"Enter elements of {i}th row.");
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                {
                    Console.Write($"[{i},{j}]: ");
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }

            return new Matrix(matrix);
        }
    }
}

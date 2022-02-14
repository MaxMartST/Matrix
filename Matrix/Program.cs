using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Matrix
    {
        public int[,] arr;

/*        public Matrix(int[,] inputArr)
        {
            this.arr = inputArr;
        }
*/
        public Matrix(int[,] inputArr)
        {
            int rows = inputArr.GetLength(0);
            int columns = inputArr.GetLength(1);

            arr = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    this.arr[i, j] = inputArr[i, j];
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[,] inputArr =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            
            Matrix matrix = new Matrix(inputArr);
            inputArr[0, 0] = 9;

            for (int i = 0; i < inputArr.GetLength(0); i++)
            {
                for (int j = 0; j < inputArr.GetLength(1); j++)
                {
                    Console.Write(matrix.arr[i, j]);
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}

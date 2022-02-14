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

        public int RowsCount()
        {
            return this.arr.GetLength(0);
        }

        public int ColumnsCount()
        {
            return this.arr.GetLength(1);
        }

        public static (int, int) GetSize(Matrix matrix)
        {
            return (matrix.arr.GetLength(0), matrix.arr.GetLength(1));
        }

        public static void PrintMatrix(Matrix matrix)
        {
            var size = GetSize(matrix);

            for (int i = 0; i < size.Item1; i++)
            {
                for (int j = 0; j < size.Item2; j++)
                {
                    Console.Write("{0}\t", matrix.arr[i, j]);
                }

                Console.WriteLine();
            }

        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            int rows = GetSize(matrix1).Item1;
            int columns = GetSize(matrix1).Item2;

            int[,] resultMatrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    resultMatrix[i, j] = matrix1.arr[i, j] + matrix2.arr[i, j];
                }
            }

            return new Matrix(resultMatrix);
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (GetSize(matrix1).Item1 != GetSize(matrix2).Item2)
            {
                throw new Exception("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }

            var resultArr = new int[matrix1.RowsCount(), matrix2.ColumnsCount()];

            for (var i = 0; i < matrix1.RowsCount(); i++)
            {
                for (var j = 0; j < matrix2.ColumnsCount(); j++)
                {
                    resultArr[i, j] = 0;

                    for (var k = 0; k < matrix1.ColumnsCount(); k++)
                    {
                        resultArr[i, j] += matrix1.arr[i, k] * matrix2.arr[k, j];
                    }
                }
            }

            return new Matrix(resultArr);
        }

        public static bool IsSameSize(Matrix matrix1, Matrix matrix2)
        {
            var size1 = GetSize(matrix1);
            var size2 = GetSize(matrix2);

            return size1.Item1 == size2.Item1 && size1.Item2 == size2.Item2;
        }

        public static bool operator ==(Matrix matrix1, Matrix matrix2)
        {
            if (!IsSameSize(matrix1, matrix2))
                return false;

            var size = GetSize(matrix1);

            for (int i = 0; i < size.Item1; i++)
            {
                for (int j = 0; j < size.Item2; j++)
                {
                    if (matrix1.arr[i, j] != matrix2.arr[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(Matrix matrix1, Matrix matrix2)
        {
            if (!IsSameSize(matrix1, matrix2))
                return false;

            var size = GetSize(matrix1);

            for (int i = 0; i < size.Item1; i++)
            {
                for (int j = 0; j < size.Item2; j++)
                {
                    if (matrix1.arr[i, j] != matrix2.arr[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[,] inputArr1 =
                       {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            //int[,] inputArr2 =
            //{
            //{ 3, 2, 1 },
            //{ 6, 5, 4 },
            //{ 9, 8, 7 }
            //};

            int[,] inputArr2 =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            Matrix matrix1 = new Matrix(inputArr1);
            Matrix matrix2 = new Matrix(inputArr2);

            //Matrix matrix3 = matrix1 * matrix2;
            //Matrix.PrintMatrix(matrix3);

            //Console.WriteLine(Matrix.IsSameSize(matrix1, matrix2));

            Console.WriteLine(matrix1 != matrix2);

            Console.ReadLine();
        }
    }
}

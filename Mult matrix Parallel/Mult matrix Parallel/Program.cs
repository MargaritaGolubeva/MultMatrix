using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mult_matrix_Parallel
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        double[,] MultMatrix(int size, double[,] matrix1, double[,] matrix2)
        {
            var result = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < size; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return result;
        }

        double[,] MultMatrixParallel(int size, double[,] matrix1, double[,] matrix2)
        {
            var result = new double[size, size];
            Parallel.For(0, size,
              i =>
              {
                  for (int j = 0; j < size; j++)
                  {
                      result[i, j] = 0;
                      for (int k = 0; k < size; k++)
                      {
                          result[i, j] += matrix1[i, k] * matrix2[k, j];
                      }
                  }
              });
            return result;
        }
    }
}

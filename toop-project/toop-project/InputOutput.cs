using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace toop_project
{
    class InputOutput
    {

        private StreamReader streamReader;

        public InputOutput()
        {

        }

        public void Input()
        {
            int n;
            double[,] matrix;
            InputDenseMatrix(out n, out matrix);
        }

        private void InputDenseMatrix(out int n, out double[,] matrix)
        {
            string matrixFileName = "D:\\Git\\toop-project\\toop-project\\toop-project\\Dense Matrix.txt";
            string descriptionFileName = "D:\\Git\\toop-project\\toop-project\\toop-project\\n.txt";

            //чтение размерности матрицы из указанного файла
            streamReader = new StreamReader(descriptionFileName);
            int.TryParse(streamReader.ReadLine(), out n);

            //чтение матрицы из указанного файла
            matrix = new double[n, n];
            streamReader = new StreamReader(matrixFileName);
            string[] stringsToParse = streamReader.ReadToEnd().Split(' ', '\n');
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double.TryParse(stringsToParse[i * n + j], NumberStyles.Any, new CultureInfo("en-US"), out matrix[i, j]);
                }
            }
        }
    }
}

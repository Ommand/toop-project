using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace toop_project
{
    class InputOutput : IInputOutput
    {

        private StreamReader streamReader;                                          //читалка из файла
        private CultureInfo cultureInfo;                                            //нужно для того, чтобы заменить , на . при конвертации строки в double
        private List<string> stringsToParse;                                        //содержимое файла, разбитое на строки

        public InputOutput()
        {
            cultureInfo = new CultureInfo("en-US");
        }

        public void Input()
        {
            int n;
            int m;
            double[] al;
            double[] au;
            double[] di;
            int[] ia;
            int[] ja;
            InputCompressedSparseRowColumnMatrix(out n, out m, out al, out au, out di, out ia, out ja);
        }

        //ввод матрицы в плотном формате
        private void InputDenseMatrix(out int n, out double[,] matrix)
        {
            string nFileName = "D:\\Git\\toop-project\\toop-project\\toop-project\\n.txt";
            string matrixFileName = "D:\\Git\\toop-project\\toop-project\\toop-project\\Dense Matrix.txt";

            //чтение размерности матрицы из указанного файла
            InputFromFile(nFileName, out n);

            //чтение матрицы из указанного файла
            InputFromFile(matrixFileName, n, n, out matrix);
        }

        //ввод матрицы в разреженном строчно-столбцовом формате
        private void InputCompressedSparseRowColumnMatrix(out int n, out int m, out double[] al, out double[] au, out double[] di, out int[] ia, out int[] ja)
        {
            string nFileName = "D:\\Git\\toop-project\\toop-project\\toop-project\\n.txt";
            string alFileName = "D:\\Git\\toop-project\\toop-project\\toop-project\\al.txt";
            string auFileName = "D:\\Git\\toop-project\\toop-project\\toop-project\\au.txt";
            string diFileName = "D:\\Git\\toop-project\\toop-project\\toop-project\\di.txt";
            string iaFileName = "D:\\Git\\toop-project\\toop-project\\toop-project\\ia.txt";
            string jaFileName = "D:\\Git\\toop-project\\toop-project\\toop-project\\ja.txt";

            //чтение размерности матрицы из указанного файла
            InputFromFile(nFileName, out n);

            //чтение профиля матрицы по строкам(это же так называется?) из файла
            InputFromFile(iaFileName, n + 1, out ia);

            //число элементов равно последнему значению ia
            m = ia[n];

            //чтение профиля матрицы по столбцам из файла
            InputFromFile(jaFileName, m, out ja);

            //чтение диагонали матрицы из файла
            InputFromFile(diFileName, n, out di);

            //чтение элементов нижнего профиля матрицы
            InputFromFile(alFileName, m, out al);

            //чтение элементов верхнего профиля матрицы
            InputFromFile(auFileName, m, out au);
        }

        //ввод целого числа из файла
        private void InputFromFile(string fileName, out int result)
        {
            streamReader = new StreamReader(fileName);
            int.TryParse(streamReader.ReadLine(), out result);
        }

        //ввод n целых чисел из файла
        private void InputFromFile(string fileName, int n, out int[] result)
        {
            result = new int[n];
            streamReader = new StreamReader(fileName);
            stringsToParse = Parse(streamReader.ReadToEnd());
            for (int i = 0; i < n; i++)
            {
                int.TryParse(stringsToParse[i], NumberStyles.Any, cultureInfo, out result[i]);
            }
        }

        //ввод n чисел из файла
        private void InputFromFile(string fileName, int n, out double[] result)
        {
            result = new double[n];
            streamReader = new StreamReader(fileName);
            stringsToParse = Parse(streamReader.ReadToEnd());
            for (int i = 0; i < n; i++)
            {
                double.TryParse(stringsToParse[i], NumberStyles.Any, cultureInfo, out result[i]);
            }
        }

        //ввод nxm целых чисел из файла (скорее всего, не понадобится, но пусть будет)
        private void InputFromFile(string fileName, int n, int m, out int[,] result)
        {
            result = new int[n, m];
            streamReader = new StreamReader(fileName);
            stringsToParse = Parse(streamReader.ReadToEnd());
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int.TryParse(stringsToParse[i * m + j], NumberStyles.Any, cultureInfo, out result[i, j]);
                }
            }
        }

        //ввод nxm чисел из файла
        private void InputFromFile(string fileName, int n, int m, out double[,] result)
        {
            result = new double[n, m];
            streamReader = new StreamReader(fileName);
            stringsToParse = Parse(streamReader.ReadToEnd());
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    double.TryParse(stringsToParse[i * m + j], NumberStyles.Any, cultureInfo, out result[i, j]);
                }
            }
        }

        private List<string> Parse(string stringToParse)
        {
            List<string> stringsToParse = stringToParse.Split(' ', '\n', '\r', '\t').ToList<string>();

            for(int i = 0; i < stringsToParse.Count(); i++)
            {
                if (stringsToParse[i] == "")
                {
                    stringsToParse.RemoveAt(i);
                    i--;
                }
            }
            return stringsToParse;
        }

    }
}

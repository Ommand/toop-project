using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace toop_project
{
	static class InputOutput
	{
		//метод для чтения матрицы из файла
		public static void InputMatrix(string fileName, out object[] matrixView)
		{
			StreamReader streamReader = new StreamReader(fileName);
			string[] fileContent = streamReader.ReadToEnd().Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

			string matrixFormat = fileContent[0];

			switch (matrixFormat)
			{
				//плотный формат
				case "DENSE":
				{
					InputDenseMatrix(fileContent, out matrixView);
					break;
				}
				//профильный формат
				case "SKYLINE":
				{
					InputSkylineMatrix(fileContent, out matrixView);
					break;
				}
				//разреженный строчно-столбцовый формат
				case "SPARSE":
				{
					InputSparseMatrix(fileContent, out matrixView);
					break;
				}
				//диагональный формат
				/*case "DIAGONAL":
				{
					//InputDiagonalMatrix(fileContent, out matrixView);
					break;
				}*/
				//ленточный формат
				case "BAND":
				{
					InputBandMatrix(fileContent, out matrixView);
					break;
				}
				//если пользователь не заинтересован в корректном вводе
				default:
				{
					matrixView = new object[1];
					matrixView[0] = 0;
					//throw какой-нибудь эксепшен
					break;
				}
			}
		}

		//метод для чтения правой части из файла
		public static void InputRightPart(string fileName, out List<double> rightPart)
		{
			CultureInfo cultureInfo = new CultureInfo("en-US");

			StreamReader streamReader = new StreamReader(fileName);
			string[] fileContent = streamReader.ReadToEnd().Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

			//чтение n
			int n;
			int.TryParse(fileContent[0], out n);

			double value;

			//чтение правой части
			rightPart = new List<double>(n);
			for (int i = 0; i < n; i++)
			{
				double.TryParse(fileContent[1 + i], NumberStyles.Any, cultureInfo, out value);
				rightPart.Add(value);
			}
		}

		//ввод матрицы в плотном формате
		private static void InputDenseMatrix(string[] fileContent, out object[] matrixView)
		{
			int pos = 2;
			CultureInfo cultureInfo = new CultureInfo("en-US");

			//чтение n
			int n;
			int.TryParse(fileContent[1], out n);

			//чтение матрицы
			double[,] matrix = new double[n, n];
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					double.TryParse(fileContent[pos + i * n + j], NumberStyles.Any, cultureInfo, out matrix[i, j]);
				}
			}

			//формирование образа матрицы на вывод
			matrixView = new object[3];

			matrixView[0] = 1;
			matrixView[1] = n;
			matrixView[2] = matrix;
		}

		//ввод матрицы в профильном формате
		private static void InputSkylineMatrix(string[] fileContent, out object[] matrixView)
		{
			int pos = 2;
			CultureInfo cultureInfo = new CultureInfo("en-US");

			//чтение n
			int n;
			int.TryParse(fileContent[1], out n);

			//чтение ia
			int[] ia = new int[n];
			for (int i = 0; i < n; i++)
			{
				int.TryParse(fileContent[pos + i], out ia[i]);
			}
			pos += n;

			int m = ia[n - 1];

			//чтение di
			double[] di = new double[n];
			for (int i = 0; i < n; i++)
			{
				double.TryParse(fileContent[pos + i], NumberStyles.Any, cultureInfo, out di[i]);
			}
			pos += n;

			//чтение al
			double[] al = new double[m];
			for (int i = 0; i < m; i++)
			{
				double.TryParse(fileContent[pos + i], NumberStyles.Any, cultureInfo, out al[i]);
			}
			pos += m;

			//чтение au
			double[] au = new double[m];
			for (int i = 0; i < m; i++)
			{
				double.TryParse(fileContent[pos + i], NumberStyles.Any, cultureInfo, out au[i]);
			}

			//формирование образа матрицы на вывод
			matrixView = new object[6];

			matrixView[0] = 2;
			matrixView[1] = n;
			matrixView[2] = ia;
			matrixView[3] = di;
			matrixView[4] = al;
			matrixView[5] = au;
		}

		//ввод матрицы в разреженном строчно-столбцовом формате
		private static void InputSparseMatrix(string[] fileContent, out object[] matrixView)
		{
			int pos = 2;
			CultureInfo cultureInfo = new CultureInfo("en-US");

			//чтение n
			int n;
			int.TryParse(fileContent[1], out n);

			//чтение ia
			int[] ia = new int[n];
			for (int i = 0; i < n; i++)
			{
				int.TryParse(fileContent[pos + i], out ia[i]);
			}
			pos += n;

			int m = ia[n - 1];

			//чтение ja
			int[] ja = new int[m];
			for (int i = 0; i < m; i++)
			{
				int.TryParse(fileContent[pos + i], out ja[i]);
			}
			pos += m;

			//чтение di
			double[] di = new double[n];
			for (int i = 0; i < n; i++)
			{
				double.TryParse(fileContent[pos + i], NumberStyles.Any, cultureInfo, out di[i]);
			}
			pos += n;

			//чтение al
			double[] al = new double[m];
			for (int i = 0; i < m; i++)
			{
				double.TryParse(fileContent[pos + i], NumberStyles.Any, cultureInfo, out al[i]);
			}
			pos += m;

			//чтение au
			double[] au = new double[m];
			for (int i = 0; i < m; i++)
			{
				double.TryParse(fileContent[pos + i], NumberStyles.Any, cultureInfo, out au[i]);
			}

			//формирование образа матрицы на вывод
			matrixView = new object[7];

			matrixView[0] = 3;
			matrixView[1] = n;
			matrixView[2] = ia;
			matrixView[3] = ja;
			matrixView[4] = di;
			matrixView[5] = al;
			matrixView[6] = au;
		}

		/*private static void InputDiagonalMatrix(string[] fileContent, out object[] matrixView)
		{

		}*/

		//ввод матрицы в ленточном формате
		private static void InputBandMatrix(string[] fileContent, out object[] matrixView)
		{
			int pos = 3;
			CultureInfo cultureInfo = new CultureInfo("en-US");

			//чтение n
			int n;
			int.TryParse(fileContent[1], out n);

			//чтение ширины полуленты
			int bandWidth;
			int.TryParse(fileContent[2], out bandWidth);

			//ширина полуленты не может превышать значение n - 1
			if (bandWidth > n - 1)
			{
				//throw какой-нибудь эксепшен
			}

			//чтение di
			double[] di = new double[n];
			for (int i = 0; i < n; i++)
			{
				double.TryParse(fileContent[pos + i], NumberStyles.Any, cultureInfo, out di[i]);
			}
			pos += n;

			//чтение al
			double[,] al = new double[n, bandWidth];
			for (int i = 0; i < bandWidth; i++)
			{
				for (int j = bandWidth - i; j < n; j++)
				{
					double.TryParse(fileContent[pos + j + i - bandWidth], NumberStyles.Any, cultureInfo, out al[j, i]);
				}
				pos += n + i - bandWidth;
			}

			//чтение au
			double[,] au = new double[n, bandWidth];
			for (int i = 0; i < bandWidth; i++)
			{
				for (int j = bandWidth - i; j < n; j++)
				{
					double.TryParse(fileContent[pos + j + i - bandWidth], NumberStyles.Any, cultureInfo, out au[j, i]);
				}
				pos += n + i - bandWidth;
			}

			//формирование образа матрицы на вывод
			matrixView = new object[6];

			matrixView[0] = 5;
			matrixView[1] = n;
			matrixView[2] = bandWidth;
			matrixView[3] = di;
			matrixView[4] = al;
			matrixView[5] = au;
		}

	}
}
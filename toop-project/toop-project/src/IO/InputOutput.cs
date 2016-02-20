using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using toop_project.src.Matrix;
using toop_project.src.Vector_;

namespace toop_project
{
	static class InputOutput
	{
		//метод для чтения матрицы из файла
		public static void InputMatrix(string fileName, out BaseMatrix matrix)
		{
			StreamReader streamReader = new StreamReader(fileName);
			string[] fileContent = streamReader.ReadToEnd().Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

			string matrixFormat = fileContent[0];

			switch (matrixFormat)
			{
				//плотный формат
				case "DENSE":
				{
					InputDenseMatrix(fileContent, out matrix);
					break;
				}
				//профильный формат
				/*
				case "SKYLINE":
				{
					InputSkylineMatrix(fileContent, out matrix);
					break;
				}*/
				//разреженный строчно-столбцовый формат
				case "SPARSE":
				{
					InputSparseMatrix(fileContent, out matrix);
					break;
				}
				//диагональный формат
				case "DIAGONAL":
				{
					InputDiagonalMatrix(fileContent, out matrix);
					break;
				}
				//ленточный формат
				case "BAND":
				{
					InputBandMatrix(fileContent, out matrix);
					break;
				}
				//если пользователь не заинтересован в корректном вводе
				default:
				{
					matrix = null;
					//throw какой-нибудь эксепшен
					break;
				}
			}
		}

		//метод для чтения правой части из файла
		public static void InputRightPart(string fileName, out Vector rightPart)
		{
			CultureInfo cultureInfo = new CultureInfo("en-US");

			StreamReader streamReader = new StreamReader(fileName);
			string[] fileContent = streamReader.ReadToEnd().Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

			//чтение n
			int n;
			int.TryParse(fileContent[0], out n);

			double bi;

			//чтение правой части
			rightPart = new Vector(n);
			for (int i = 0; i < n; i++)
			{
				double.TryParse(fileContent[1 + i], NumberStyles.Any, cultureInfo, out bi);
				rightPart[i] = bi;
			}
		}

		//ввод матрицы в плотном формате
		private static void InputDenseMatrix(string[] fileContent, out BaseMatrix matrix)
		{
			int pos = 2;
			CultureInfo cultureInfo = new CultureInfo("en-US");

			//чтение n
			int n;
			int.TryParse(fileContent[1], out n);

			//чтение матрицы
			double[][] matr = new double[n][];
			for (int i = 0; i < n; i++)
			{
				matr[i] = new double[n];
				for (int j = 0; j < n; j++, pos++)
				{
					double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out matr[i][j]);
				}
			}

			//формирование новой плотной матрицы
			matrix = new DenseMatrix(matr);
		}

		//ввод матрицы в профильном формате
		/*private static void InputSkylineMatrix(string[] fileContent, out BaseMatrix matrix)
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
		}*/

		//ввод матрицы в разреженном строчно-столбцовом формате
		private static void InputSparseMatrix(string[] fileContent, out BaseMatrix matrix)
		{
			int pos = 2;
			CultureInfo cultureInfo = new CultureInfo("en-US");

			//чтение n
			int n;
			int.TryParse(fileContent[1], out n);

			//чтение ia
			int[] ia = new int[n];
			for (int i = 0; i < n; i++, pos++)
			{
				int.TryParse(fileContent[pos], out ia[i]);
			}

			int m = ia[n - 1];

			//чтение ja
			int[] ja = new int[m];
			for (int i = 0; i < m; i++, pos++)
			{
				int.TryParse(fileContent[pos], out ja[i]);
			}

			//чтение di
			double[] di = new double[n];
			for (int i = 0; i < n; i++, pos++)
			{
				double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out di[i]);
			}

			//чтение al
			double[] al = new double[m];
			for (int i = 0; i < m; i++, pos++)
			{
				double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out al[i]);
			}

			//чтение au
			double[] au = new double[m];
			for (int i = 0; i < m; i++, pos++)
			{
				double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out au[i]);
			}

			//формирование новой разреженной матрицы
			matrix = new SparseMatrix(ia, ja, al, au, di);
		}

		//ввод матрицы в диагональном формате
		private static void InputDiagonalMatrix(string[] fileContent, out BaseMatrix matrix)
		{
			int pos = 4;
			CultureInfo cultureInfo = new CultureInfo("en-US");

			//чтение n
			int n;
			int.TryParse(fileContent[1], out n);

			//чтение nl
			int nl;
			int.TryParse(fileContent[2], out nl);

			//чтение nu
			int nu;
			int.TryParse(fileContent[3], out nu);

			//чтение shiftl
			int[] shiftl = new int[nl];
			for (int i = 0; i < nl; i++, pos++)
			{
				int.TryParse(fileContent[pos], out shiftl[i]);
			}

			//чтение shiftu
			int[] shiftu = new int[nu];
			for (int i = 0; i < nu; i++, pos++)
			{
				int.TryParse(fileContent[pos], out shiftu[i]);
			}

			//чтение di
			double[] di = new double[n];
			for (int i = 0; i < n; i++, pos++)
			{
				double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out di[i]);
			}

			//чтение al
			double[][] al = new double[n][];
			for (int i = 0; i < n; i++)
			{
				al[i] = new double[nl];
			}
			for (int i = 0; i < nl; i++)
			{
				for (int j = shiftl[i]; j < n; j++, pos++)
				{
					double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out al[j][i]);
				}
			}

			//чтение au
			double[][] au = new double[n][];
			for (int i = 0; i < n; i++)
			{
				au[i] = new double[nu];
			}
			for (int i = 0; i < nu; i++)
			{
				for (int j = shiftu[i]; j < n; j++, pos++)
				{
					double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out au[j][i]);
				}
			}

			//формирование новой диагональной матрицы
			matrix = new DiagonalMatrix(di, al, au, shiftl, shiftu);
		}

		//ввод матрицы в ленточном формате
		private static void InputBandMatrix(string[] fileContent, out BaseMatrix matrix)
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
			for (int i = 0; i < n; i++, pos++)
			{
				double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out di[i]);
			}

			//чтение al
			double[][] al = new double[n][];
			for (int i = 0; i < n; i++)
			{
				al[i] = new double[bandWidth];
				for (int j = (bandWidth - i) > 0 ? (bandWidth - i) : 0; j < bandWidth; j++, pos++)
				{
					double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out al[i][j]);
				}
			}

			//чтение au
			double[][] au = new double[n][];
			for (int i = 0; i < n; i++)
			{
				au[i] = new double[bandWidth];
				for (int j = (bandWidth - i) > 0 ? (bandWidth - i) : 0; j < bandWidth; j++, pos++)
				{
					double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out au[i][j]);
				}
			}

			//формирование новой ленточной матрицы
			matrix = new BandMatrix(bandWidth, di, al, au);
		}

	}
}
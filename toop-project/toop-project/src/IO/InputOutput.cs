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
		public static void InputMatrix(string fileName, out BaseMatrix matrix, out List<string> log)
		{
			string[] fileContent;
			string matrixFormat;

			log = new List<string>();

			try
			{
				//открываем файл для чтения и переносим всю информацию оттуда в массив строк
				using (StreamReader streamReader = new StreamReader(fileName))
				{
					log.Add("Чтение информации о матрице из файла " + fileName + ".");
					fileContent = streamReader.ReadToEnd().Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
				}
				log.Add("Чтение информации из файла завершено.");

				matrixFormat = fileContent[0];

				switch (matrixFormat)
				{
					//плотный формат
					case "DENSE":
					{
						InputDenseMatrix(fileContent, out matrix, log);
						break;
					}
					//профильный формат
					/*
					case "SKYLINE":
					{
						InputSkylineMatrix(fileContent, out matrix, log);
						break;
					}*/
					//разреженный строчно-столбцовый формат
					case "SPARSE":
					{
						InputSparseMatrix(fileContent, out matrix, log);
						break;
					}
					//диагональный формат
					case "DIAGONAL":
					{
						InputDiagonalMatrix(fileContent, out matrix, log);
						break;
					}
					//ленточный формат
					case "BAND":
					{
						InputBandMatrix(fileContent, out matrix, log);
						break;
					}
					//если пользователь не заинтересован в корректном вводе
					default:
					{
						matrix = null;
						throw new Exception("Неизвестный формат матрицы.");
					}
				}
			}
			catch (IndexOutOfRangeException e)
			{
				log.Add("Выхождение индекса за пределы массива с данными (Не хватает данных для корректного ввода).");
				log.Add("Аварийное завершение ввода матрицы.");
				matrix = null;
			}
			catch (Exception e)
			{
				log.Add(e.Message);
				log.Add("Аварийное завершение ввода матрицы.");
				matrix = null;
			}
		}

		//метод для чтения правой части из файла
		public static void InputRightPart(string fileName, out Vector rightPart, out List<string> log)
		{
			CultureInfo cultureInfo = new CultureInfo("en-US");

			string[] fileContent;

			log = new List<string>();

			try
			{
				using (StreamReader streamReader = new StreamReader(fileName))
				{
					log.Add("Чтение информации о правой части из файла " + fileName + ".");
					fileContent = streamReader.ReadToEnd().Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
				}

				//чтение n
				int n;
				log.Add("Ввод размерности правой части...");
				if (!int.TryParse(fileContent[0], out n))
				{
					throw new Exception("Некорректно введена размерность матрицы (Должна представлять собой целое число).");
				}
				if (n < 1)
				{
					throw new Exception("Некорректно введена размерность матрица (Не должна быть меньше 1).");
				}
				log.Add("Ввод размерности правой части завершен.");

				double bi;

				//чтение правой части
				rightPart = new Vector(n);
				log.Add("Ввод элементов правой части...");
				for (int i = 0; i < n; i++)
				{
					if (!double.TryParse(fileContent[1 + i], NumberStyles.Any, cultureInfo, out bi))
					{
						throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент правой части (Должен представлять собой число).");
					}
					rightPart[i] = bi;
				}
				log.Add("Ввод элементов правой части завершен.");

				log.Add("Успешное завершение ввода правой части.");
			}
			catch (IndexOutOfRangeException e)
			{
				log.Add("Выхождение индекса за пределы массива с данными (Не хватает данных для корректного ввода).");
				log.Add("Аварийное завершение ввода правой части.");
				rightPart = null;
			}
			catch (Exception e)
			{
				log.Add(e.Message);
				log.Add("Аварийное завершение ввода правой части.");
				rightPart = null;
			}
		}

		//ввод матрицы в плотном формате
		private static void InputDenseMatrix(string[] fileContent, out BaseMatrix matrix, List<string> log)
		{
			int pos = 2;
			CultureInfo cultureInfo = new CultureInfo("en-US");

			log.Add("Выбранный формат матрицы - плотный.");

			//чтение n
			int n;
			log.Add("Ввод размерности матрицы...");
			if (!int.TryParse(fileContent[1], out n))
			{
				throw new Exception("Некорректно введена размерность матрицы (Должна представлять собой целое число).");
			}
			if (n < 1)
			{
				throw new Exception("Некорректно введена размерность матрица (Не должна быть меньше 1).");
			}
			log.Add("Ввод размерности матрицы завершен.");

			//чтение матрицы
			double[][] matr = new double[n][];
			log.Add("Ввод элементов матрицы...");
			for (int i = 0; i < n; i++)
			{
				matr[i] = new double[n];
				for (int j = 0; j < n; j++, pos++)
				{
					if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out matr[i][j]))
					{
						throw new Exception("Некорректно введен (" + (i + 1).ToString() + " " + (j + 1).ToString() + ") элемент матрицы (Должен представлять собой число).");
					}
				}
			}
			log.Add("Ввод элементов матрицы завершен.");

			//формирование новой плотной матрицы
			matrix = new DenseMatrix(matr);
			log.Add("Успешное завершение ввода матрицы.");
		}

		//ввод матрицы в профильном формате
		/*private static void InputSkylineMatrix(string[] fileContent, out BaseMatrix matrix, List<string> log)
		{
			int pos = 2;
			CultureInfo cultureInfo = new CultureInfo("en-US");

			//чтение n
			int n;
			log.Add("Ввод размерности матрицы...");
			if (!int.TryParse(fileContent[1], out n))
			{
				throw new Exception("Некорректно введена размерность матрицы (Должна представлять собой целое число).");
			}
			if (n < 1)
			{
				throw new Exception("Некорректно введена размерность матрица (Не должна быть меньше 1).");
			}
			log.Add("Ввод размерности матрицы завершен.");

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
		private static void InputSparseMatrix(string[] fileContent, out BaseMatrix matrix, List<string> log)
		{
			int pos = 2;
			CultureInfo cultureInfo = new CultureInfo("en-US");

			log.Add("Выбранный формат матрицы - разреженный строчно-столбцовый.");

			//чтение n
			int n;
			log.Add("Ввод размерности матрицы...");
			if (!int.TryParse(fileContent[1], out n))
			{
				throw new Exception("Некорректно введена размерность матрицы (Должна представлять собой целое число).");
			}
			if (n < 1)
			{
				throw new Exception("Некорректно введена размерность матрица (Не должна быть меньше 1).");
			}
			log.Add("Ввод размерности матрицы завершен.");

			//чтение ia
			int[] ia = new int[n];
			log.Add("Ввод ia...");
			for (int i = 0; i < n; i++, pos++)
			{
				if (!int.TryParse(fileContent[pos], out ia[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент ia (Должен представлять собой целое число).");
				}
			}
			log.Add("Ввод ia завершен.");

			int m = ia[n - 1];

			//чтение ja
			int[] ja = new int[m];
			log.Add("Ввод ja...");
			for (int i = 0; i < m; i++, pos++)
			{
				if (!int.TryParse(fileContent[pos], out ja[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент ja (Должен представлять собой целое число).");
				}
			}
			log.Add("Ввод ja завершен.");

			//чтение di
			double[] di = new double[n];
			log.Add("Ввод di...");
			for (int i = 0; i < n; i++, pos++)
			{
				if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out di[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент di (Должен представлять собой число).");
				}
			}
			log.Add("Ввод di завершен.");

			//чтение al
			double[] al = new double[m];
			log.Add("Ввод al...");
			for (int i = 0; i < m; i++, pos++)
			{
				if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out al[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент al (Должен представлять собой число).");
				}
			}
			log.Add("Ввод al завершен.");

			//чтение au
			double[] au = new double[m];
			log.Add("Ввод au...");
			for (int i = 0; i < m; i++, pos++)
			{
				if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out au[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент au (Должен представлять собой число).");
				}
			}
			log.Add("Ввод au завершен.");

			//формирование новой разреженной матрицы
			matrix = new SparseMatrix(ia, ja, al, au, di);
			log.Add("Успешное завершение ввода матрицы.");
		}

		//ввод матрицы в диагональном формате
		private static void InputDiagonalMatrix(string[] fileContent, out BaseMatrix matrix, List<string> log)
		{
			int pos = 4;
			CultureInfo cultureInfo = new CultureInfo("en-US");

			log.Add("Выбранный формат матрицы - диагональный.");

			//чтение n
			int n;
			log.Add("Ввод размерности матрицы...");
			if (!int.TryParse(fileContent[1], out n))
			{
				throw new Exception("Некорректно введена размерность матрицы (Должна представлять собой целое число).");
			}
			if (n < 1)
			{
				throw new Exception("Некорректно введена размерность матрица (Не должна быть меньше 1).");
			}
			log.Add("Ввод размерности матрицы завершен.");

			//чтение nl
			int nl;
			log.Add("Ввод nl...");
			if (!int.TryParse(fileContent[2], out nl))
			{
				throw new Exception("Некорректно введено число диагоналей на нижнем треугольнике матрицы (Должно представлять собой целое число).");
			}
			if (nl < 0 || nl > n - 1)
			{
				throw new Exception("Некорректно введено число диагоналей на нижнем треугольнике матрицы (Не должно быть меньше 0 / больше n - 1).");
			}
			log.Add("Ввод nl завершен.");

			//чтение nu
			int nu;
			log.Add("Ввод nu...");
			if (!int.TryParse(fileContent[3], out nu))
			{
				throw new Exception("Некорректно введено число диагоналей на верхнем треугольнике матрицы (Должно представлять собой целое число).");
			}
			if (nu < 0 || nu > n - 1)
			{
				throw new Exception("Некорректно введено число диагоналей на верхнем треугольнике матрицы (Не должно быть меньше 0 / больше n - 1).");
			}
			log.Add("Ввод nu завершен.");

			//чтение shiftl
			int[] shiftl = new int[nl];
			log.Add("Ввод shift_l...");
			for (int i = 0; i < nl; i++, pos++)
			{
				if (!int.TryParse(fileContent[pos], out shiftl[i]))
				{
					throw new Exception("Некорректно введено смещение " + (i + 1).ToString() + " диагонали нижнего треугольника матрицы (Должно представлять собой целое число).");
				}
				if (shiftl[i] < 1 || shiftl[i] > n - 1)
				{
					throw new Exception("Некорректно введено смещение " + (i + 1).ToString() + " диагонали нижнего треугольника матрицы (Не должно быть меньше 1 / больше n - 1).");
				}
			}
			log.Add("Ввод shift_l завершен.");

			//чтение shiftu
			log.Add("Ввод shift_u...");
			int[] shiftu = new int[nu];
			for (int i = 0; i < nu; i++, pos++)
			{
				if (!int.TryParse(fileContent[pos], out shiftu[i]))
				{
					throw new Exception("Некорректно введено смещение " + (i + 1).ToString() + " диагонали верхнего треугольника матрицы (Должно представлять собой целое число).");
				}
				if (shiftu[i] < 1 || shiftu[i] > n - 1)
				{
					throw new Exception("Некорректно введено смещение " + (i + 1).ToString() + " диагонали верхнего треугольника матрицы (Не должно быть меньше 1 / больше n - 1).");
				}
			}
			log.Add("Ввод shift_u завершен.");

			//чтение di
			double[] di = new double[n];
			log.Add("Ввод di...");
			for (int i = 0; i < n; i++, pos++)
			{
				if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out di[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент di (Должен представлять собой число).");
				}
			}
			log.Add("Ввод di завершен.");

			//чтение al
			double[][] al = new double[n][];
			log.Add("Ввод al...");
			for (int i = 0; i < n; i++)
			{
				al[i] = new double[nl];
			}
			for (int i = 0; i < nl; i++)
			{
				for (int j = shiftl[i]; j < n; j++, pos++)
				{
					if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out al[j][i]))
					{
						throw new Exception("Некорректно введен элемент al в " + (j + 1).ToString() + " строке " + (i + 1).ToString() + " диагонали (Должен представлять собой число).");
					}
				}
			}
			log.Add("Ввод al завершен.");

			//чтение au
			double[][] au = new double[n][];
			log.Add("Ввод au...");
			for (int i = 0; i < n; i++)
			{
				au[i] = new double[nu];
			}
			for (int i = 0; i < nu; i++)
			{
				for (int j = shiftu[i]; j < n; j++, pos++)
				{
					if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out au[j][i]))
					{
						throw new Exception("Некорректно введен элемент au в " + (j + 1).ToString() + " столбце " + (i + 1).ToString() + " диагонали (Должен представлять собой число).");
					}
				}
			}
			log.Add("Ввод au завершен.");

			//формирование новой диагональной матрицы
			matrix = new DiagonalMatrix(di, al, au, shiftl, shiftu);
			log.Add("Успешное завершение ввода матрицы.");
		}

		//ввод матрицы в ленточном формате
		private static void InputBandMatrix(string[] fileContent, out BaseMatrix matrix, List<string> log)
		{
			int pos = 3;
			CultureInfo cultureInfo = new CultureInfo("en-US");

			log.Add("Выбранный формат матрицы - ленточный.");

			//чтение n
			int n;
			log.Add("Ввод размерности матрицы...");
			if (!int.TryParse(fileContent[1], out n))
			{
				throw new Exception("Некорректно введена размерность матрицы (Должна представлять собой целое число).");
			}
			if (n < 1)
			{
				throw new Exception("Некорректно введена размерность матрица (Не должна быть меньше 1).");
			}
			log.Add("Ввод размерности матрицы завершен.");

			//чтение ширины полуленты
			int bandWidth;
			log.Add("Ввод ширины полуленты...");
			if (!int.TryParse(fileContent[2], out bandWidth))
			{
				throw new Exception("Некорректно введена ширина полуленты (Должна представлять собой целое число).");
			}
			if (bandWidth < 0 || bandWidth > n - 1)
			{
				throw new Exception("Некорректно введена ширина полуленты (Не должна быть меньше 0 / больше n - 1).");
			}
			log.Add("Ввод ширины полуленты завершен.");

			//чтение di
			double[] di = new double[n];
			log.Add("Ввод di...");
			for (int i = 0; i < n; i++, pos++)
			{
				if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out di[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент di (Должен представлять собой число).");
				}
			}
			log.Add("Ввод di завершен.");

			//чтение al
			double[][] al = new double[n][];
			log.Add("Ввод al...");
			for (int i = 0; i < n; i++)
			{
				al[i] = new double[bandWidth];
				for (int j = (bandWidth - i) > 0 ? (bandWidth - i) : 0; j < bandWidth; j++, pos++)
				{
					if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out al[i][j]))
					{
						throw new Exception("Некорректно введен элемент al в " + (i + 1).ToString() + " cтроке " + (bandWidth - j).ToString() + " диагонали (Должен представлять собой число).");
					}
				}
			}
			log.Add("Ввод al завершен.");

			//чтение au
			double[][] au = new double[n][];
			log.Add("Ввод au...");
			for (int i = 0; i < n; i++)
			{
				au[i] = new double[bandWidth];
				for (int j = (bandWidth - i) > 0 ? (bandWidth - i) : 0; j < bandWidth; j++, pos++)
				{
					if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out au[i][j]))
					{
						throw new Exception("Некорректно введен элемент au в " + (i + 1).ToString() + " cтолбце " + (bandWidth - j).ToString() + " диагонали (Должен представлять собой число).");
					}
				}
			}
			log.Add("Ввод au завершен.");

			//формирование новой ленточной матрицы
			matrix = new BandMatrix(bandWidth, di, al, au);
			log.Add("Успешное завершение ввода матрицы.");
		}

	}
}
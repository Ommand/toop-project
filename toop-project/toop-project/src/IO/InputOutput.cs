using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using toop_project.src.Matrix;
using toop_project.src.Vector_;
using toop_project.src.Logging;

namespace toop_project
{
	static class InputOutput
	{
		//метод для чтения матрицы из файла
		public static BaseMatrix InputMatrix(string fileName)
		{
			Logger log = Logger.Instance;
			BaseMatrix matrix;

			string[] fileContent;
			string matrixFormat;

			try
			{
				//открываем файл для чтения и переносим всю информацию оттуда в массив строк
				using (StreamReader streamReader = new StreamReader(fileName))
				{
					log.Info("Чтение информации о матрице из файла " + fileName + "...");
					fileContent = streamReader.ReadToEnd().Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
				}
				log.Info("Чтение информации о матрице из файла завершено.");

				matrixFormat = fileContent[0];

				switch (matrixFormat)
				{
					//плотный формат
					case "DENSE":
					{
						matrix = InputDenseMatrix(fileContent);
						break;
					}
					//профильный формат
					case "SKYLINE":
					{
						matrix = InputSkylineMatrix(fileContent);
						break;
					}
					//разреженный строчно-столбцовый формат
					case "SPARSE":
					{
						matrix = InputSparseMatrix(fileContent);
						break;
					}
					//диагональный формат
					case "DIAGONAL":
					{
						matrix = InputDiagonalMatrix(fileContent);
						break;
					}
					//ленточный формат
					case "BAND":
					{
						matrix = InputBandMatrix(fileContent);
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
				log.Error("Выхождение индекса за пределы массива с данными (Не хватает данных для корректного ввода).");
				log.Error("Аварийное завершение ввода матрицы.");
				return null;
			}
			catch (Exception e)
			{
				log.Error(e.Message);
				log.Error("Аварийное завершение ввода матрицы.");
				return null;
			}

			return matrix;
		}

		//метод для чтения правой части из файла
		public static Vector InputRightPart(string fileName)
		{
			Logger log = Logger.Instance;
			CultureInfo cultureInfo = new CultureInfo("en-US");
			Vector rightPart;

			string[] fileContent;

			try
			{
				using (StreamReader streamReader = new StreamReader(fileName))
				{
					log.Info("Чтение информации о правой части из файла " + fileName + ".");
					fileContent = streamReader.ReadToEnd().Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
				}

				//чтение n
				int n;
				log.Info("Ввод размерности правой части...");
				if (!int.TryParse(fileContent[0], out n))
				{
					throw new Exception("Некорректно введена размерность матрицы (Должна представлять собой целое число).");
				}
				if (n < 1)
				{
					throw new Exception("Некорректно введена размерность матрица (Не должна быть меньше 1).");
				}
				log.Info("Ввод размерности правой части завершен.");

				double bi;

				//чтение правой части
				rightPart = new Vector(n);
				log.Info("Ввод элементов правой части...");
				for (int i = 0; i < n; i++)
				{
					if (!double.TryParse(fileContent[1 + i], NumberStyles.Any, cultureInfo, out bi))
					{
						throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент правой части (Должен представлять собой число).");
					}
					rightPart[i] = bi;
				}
				log.Info("Ввод элементов правой части завершен.");

				log.Info("Успешное завершение ввода правой части.");
			}
			catch (IndexOutOfRangeException e)
			{
				log.Error("Выхождение индекса за пределы массива с данными (Не хватает данных для корректного ввода).");
				log.Error("Аварийное завершение ввода правой части.");
				rightPart = null;
			}
			catch (Exception e)
			{
				log.Error(e.Message);
				log.Error("Аварийное завершение ввода правой части.");
				rightPart = null;
			}

			return rightPart;
		}

		public static void OutputVector(string fileName, Vector vector)
		{
			Logger log = Logger.Instance;

			try
			{
				using (StreamWriter streamWriter = new StreamWriter(fileName))
				{
					log.Info("Вывод результата в файл " + fileName + "...");
					for (int i = 0; i < vector.Size; i++)
					{
						streamWriter.WriteLine(vector[i]);
					}
					log.Info("Вывод результата в файл завершен.");
				}
			}
			catch (Exception e)
			{
				log.Error(e.Message);
				log.Error("Аварийное завершение вывода результата.");
			}
		}

		//ввод матрицы в плотном формате
		private static BaseMatrix InputDenseMatrix(string[] fileContent)
		{
			Logger log = Logger.Instance;
			CultureInfo cultureInfo = new CultureInfo("en-US");
			int pos = 2;

			log.Info("Выбранный формат матрицы - плотный.");

			//чтение n
			int n;
			log.Info("Ввод размерности матрицы...");
			if (!int.TryParse(fileContent[1], out n))
			{
				throw new Exception("Некорректно введена размерность матрицы (Должна представлять собой целое число).");
			}
			if (n < 1)
			{
				throw new Exception("Некорректно введена размерность матрица (Не должна быть меньше 1).");
			}
			log.Info("Ввод размерности матрицы завершен.");

			//чтение матрицы
			double[][] matr = new double[n][];
			log.Info("Ввод элементов матрицы...");
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
			log.Info("Ввод элементов матрицы завершен.");

			//формирование новой плотной матрицы
			log.Info("Успешное завершение ввода матрицы.");
			return new DenseMatrix(matr);
		}

		//ввод матрицы в профильном формате
		private static BaseMatrix InputSkylineMatrix(string[] fileContent)
		{
			Logger log = Logger.Instance;
			CultureInfo cultureInfo = new CultureInfo("en-US");
			int pos = 2;

			log.Info("Выбранный формат матрицы - профильный.");

			//чтение n
			int n;
			log.Info("Ввод размерности матрицы...");
			if (!int.TryParse(fileContent[1], out n))
			{
				throw new Exception("Некорректно введена размерность матрицы (Должна представлять собой целое число).");
			}
			if (n < 1)
			{
				throw new Exception("Некорректно введена размерность матрица (Не должна быть меньше 1).");
			}
			log.Info("Ввод размерности матрицы завершен.");

			//чтение ia
			int[] ia = new int[n + 1];
			log.Info("Ввод ia...");
			for (int i = 0; i < n + 1; i++, pos++)
			{
				if (!int.TryParse(fileContent[pos], out ia[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент ia (Должен представлять собой целое число).");
				}
			}
			log.Info("Ввод ia завершен.");

			int m = ia[n];

			//чтение di
			double[] di = new double[n];
			log.Info("Ввод di...");
			for (int i = 0; i < n; i++, pos++)
			{
				if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out di[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент di (Должен представлять собой число).");
				}
			}
			log.Info("Ввод di завершен.");

			//чтение al
			double[] al = new double[m];
			log.Info("Ввод al...");
			for (int i = 0; i < m; i++, pos++)
			{
				if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out al[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент al (Должен представлять собой число).");
				}
			}
			log.Info("Ввод al завершен.");

			//чтение au
			double[] au = new double[m];
			log.Info("Ввод au...");
			for (int i = 0; i < m; i++, pos++)
			{
				if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out au[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент au (Должен представлять собой число).");
				}
			}
			log.Info("Ввод au завершен.");

			//формирование новой профильной матрицы
			log.Info("Успешное завершение ввода матрицы.");
			return new ProfileMatrix(ia, al, au, di);
		}

		//ввод матрицы в разреженном строчно-столбцовом формате
		private static BaseMatrix InputSparseMatrix(string[] fileContent)
		{
			Logger log = Logger.Instance;
			CultureInfo cultureInfo = new CultureInfo("en-US");
			int pos = 2;

			log.Info("Выбранный формат матрицы - разреженный строчно-столбцовый.");

			//чтение n
			int n;
			log.Info("Ввод размерности матрицы...");
			if (!int.TryParse(fileContent[1], out n))
			{
				throw new Exception("Некорректно введена размерность матрицы (Должна представлять собой целое число).");
			}
			if (n < 1)
			{
				throw new Exception("Некорректно введена размерность матрица (Не должна быть меньше 1).");
			}
			log.Info("Ввод размерности матрицы завершен.");

			//чтение ia
			int[] ia = new int[n + 1];
			log.Info("Ввод ia...");
			for (int i = 0; i < n + 1; i++, pos++)
			{
				if (!int.TryParse(fileContent[pos], out ia[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент ia (Должен представлять собой целое число).");
				}
			}
			log.Info("Ввод ia завершен.");

			int m = ia[n];

			//чтение ja
			int[] ja = new int[m];
			log.Info("Ввод ja...");
			for (int i = 0; i < m; i++, pos++)
			{
				if (!int.TryParse(fileContent[pos], out ja[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент ja (Должен представлять собой целое число).");
				}
			}
			log.Info("Ввод ja завершен.");

			//чтение di
			double[] di = new double[n];
			log.Info("Ввод di...");
			for (int i = 0; i < n; i++, pos++)
			{
				if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out di[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент di (Должен представлять собой число).");
				}
			}
			log.Info("Ввод di завершен.");

			//чтение al
			double[] al = new double[m];
			log.Info("Ввод al...");
			for (int i = 0; i < m; i++, pos++)
			{
				if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out al[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент al (Должен представлять собой число).");
				}
			}
			log.Info("Ввод al завершен.");

			//чтение au
			double[] au = new double[m];
			log.Info("Ввод au...");
			for (int i = 0; i < m; i++, pos++)
			{
				if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out au[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент au (Должен представлять собой число).");
				}
			}
			log.Info("Ввод au завершен.");

			//формирование новой разреженной матрицы
			log.Info("Успешное завершение ввода матрицы.");
			return new SparseMatrix(ia, ja, al, au, di);
		}

		//ввод матрицы в диагональном формате
		private static BaseMatrix InputDiagonalMatrix(string[] fileContent)
		{
			Logger log = Logger.Instance;
			CultureInfo cultureInfo = new CultureInfo("en-US");
			int pos = 4;

			log.Info("Выбранный формат матрицы - диагональный.");

			//чтение n
			int n;
			log.Info("Ввод размерности матрицы...");
			if (!int.TryParse(fileContent[1], out n))
			{
				throw new Exception("Некорректно введена размерность матрицы (Должна представлять собой целое число).");
			}
			if (n < 1)
			{
				throw new Exception("Некорректно введена размерность матрица (Не должна быть меньше 1).");
			}
			log.Info("Ввод размерности матрицы завершен.");

			//чтение nl
			int nl;
			log.Info("Ввод nl...");
			if (!int.TryParse(fileContent[2], out nl))
			{
				throw new Exception("Некорректно введено число диагоналей на нижнем треугольнике матрицы (Должно представлять собой целое число).");
			}
			if (nl < 0 || nl > n - 1)
			{
				throw new Exception("Некорректно введено число диагоналей на нижнем треугольнике матрицы (Не должно быть меньше 0 / больше n - 1).");
			}
			log.Info("Ввод nl завершен.");

			//чтение nu
			int nu;
			log.Info("Ввод nu...");
			if (!int.TryParse(fileContent[3], out nu))
			{
				throw new Exception("Некорректно введено число диагоналей на верхнем треугольнике матрицы (Должно представлять собой целое число).");
			}
			if (nu < 0 || nu > n - 1)
			{
				throw new Exception("Некорректно введено число диагоналей на верхнем треугольнике матрицы (Не должно быть меньше 0 / больше n - 1).");
			}
			log.Info("Ввод nu завершен.");

			//чтение shiftl
			int[] shiftl = new int[nl];
			log.Info("Ввод shift_l...");
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
			log.Info("Ввод shift_l завершен.");

			//чтение shiftu
			log.Info("Ввод shift_u...");
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
			log.Info("Ввод shift_u завершен.");

			//чтение di
			double[] di = new double[n];
			log.Info("Ввод di...");
			for (int i = 0; i < n; i++, pos++)
			{
				if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out di[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент di (Должен представлять собой число).");
				}
			}
			log.Info("Ввод di завершен.");

			//чтение al
			double[][] al = new double[n][];
			log.Info("Ввод al...");
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
			log.Info("Ввод al завершен.");

			//чтение au
			double[][] au = new double[n][];
			log.Info("Ввод au...");
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
			log.Info("Ввод au завершен.");

			//формирование новой диагональной матрицы
			log.Info("Успешное завершение ввода матрицы.");
			return new DiagonalMatrix(di, al, au, shiftl, shiftu);
		}

		//ввод матрицы в ленточном формате
		private static BaseMatrix InputBandMatrix(string[] fileContent)
		{
			Logger log = Logger.Instance;
			CultureInfo cultureInfo = new CultureInfo("en-US");
			int pos = 3;

			log.Info("Выбранный формат матрицы - ленточный.");

			//чтение n
			int n;
			log.Info("Ввод размерности матрицы...");
			if (!int.TryParse(fileContent[1], out n))
			{
				throw new Exception("Некорректно введена размерность матрицы (Должна представлять собой целое число).");
			}
			if (n < 1)
			{
				throw new Exception("Некорректно введена размерность матрица (Не должна быть меньше 1).");
			}
			log.Info("Ввод размерности матрицы завершен.");

			//чтение ширины полуленты
			int bandWidth;
			log.Info("Ввод ширины полуленты...");
			if (!int.TryParse(fileContent[2], out bandWidth))
			{
				throw new Exception("Некорректно введена ширина полуленты (Должна представлять собой целое число).");
			}
			if (bandWidth < 0 || bandWidth > n - 1)
			{
				throw new Exception("Некорректно введена ширина полуленты (Не должна быть меньше 0 / больше n - 1).");
			}
			log.Info("Ввод ширины полуленты завершен.");

			//чтение di
			double[] di = new double[n];
			log.Info("Ввод di...");
			for (int i = 0; i < n; i++, pos++)
			{
				if (!double.TryParse(fileContent[pos], NumberStyles.Any, cultureInfo, out di[i]))
				{
					throw new Exception("Некорректно введен " + (i + 1).ToString() + " элемент di (Должен представлять собой число).");
				}
			}
			log.Info("Ввод di завершен.");

			//чтение al
			double[][] al = new double[n][];
			log.Info("Ввод al...");
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
			log.Info("Ввод al завершен.");

			//чтение au
			double[][] au = new double[n][];
			log.Info("Ввод au...");
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
			log.Info("Ввод au завершен.");

			//формирование новой ленточной матрицы
			log.Info("Успешное завершение ввода матрицы.");
			return new BandMatrix(bandWidth, di, al, au);
		}
		
	}
}
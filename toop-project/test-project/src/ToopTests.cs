using System;
using toop_project;
using toop_project.src.Matrix;
using toop_project.src.Solver;
using toop_project.src.Vector_;
using toop_project.src.Logging;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test_project {
	[TestClass]
	public class ToopTests {
		const int dim = 5;
		const double eps = 0.00001;
		const int maxIter = 100000;
		[TestMethod]
		public void TestProfileFormatJacobi() {
			int predCoeff = 0;

			Vector expectedAnswer = new Vector(dim);
			for (int i = 0; i < dim; i++)
				expectedAnswer[i] = i + 1;

			var matrix = generateProfileMatrix(predCoeff);
			var rightPart = generateRightPart(matrix, expectedAnswer);

			Jacobi solver = new Jacobi();
			Vector answer = solver.Solve(matrix, rightPart, new Vector(dim), Logger.Instance, Logger.Instance, new JacobiParametrs(eps, maxIter), null);

			Console.Write("Generate complete...\n");
			for (int i = 0; i < dim; i++) 
				Assert.AreEqual(expectedAnswer[i], answer[i], 0.001, "Not equal!");
		}

		private ProfileMatrix generateProfileMatrix(int predCoeff) {
			Random rnd = new Random();

			List<double> alList = new List<double>();
			List<double> auList = new List<double>();
	
			int[] igMax = new int[dim + 1];
			for (int i = 1; i < dim + 1; i++)
				igMax[i] = igMax[i - 1] + i - 1;

			int[] ig = new int[dim + 1];
			for (int i = 2; i < dim + 1; i++) {
				int j = igMax[i] - igMax[i - 1]; 
				bool haveProfile = false; 
				ig[i] = ig[i - 1];

				for (int ii = 0; ii < j; ii++) {
					double valueL = rnd.Next(-4, 1);
					double valueU = rnd.Next(-4, 1);

					if (haveProfile) {
						alList.Add(valueL);
						auList.Add(valueU);
						ig[i]++;
						continue;
					}
					if (valueL != 0 || valueU != 0) {
						alList.Add(valueL);
						auList.Add(valueU);
						ig[i]++;
						haveProfile = true;
					}
				}
			}

			double[] di = new double[dim];
			for (int row = 0; row < dim; row++) {
				int index = ig[row];
				for (int column = row - (ig[row + 1] - index); column < row; column++, index++) {
					di[row] -= alList[index];
					di[column] -= auList[index];
				}
			}

			di[0] += Math.Pow(10.0, (-1.0) * predCoeff);

			return new ProfileMatrix(ig, alList.ToArray(), auList.ToArray(), di);
		}

		private Vector generateRightPart(ProfileMatrix matrix, Vector answer) {
			return matrix.Multiply(answer);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Solver
{
    class GMRESParameters : ISolverParametrs
    {
        public GMRESParameters(double epsilon, int maxIterations, int m)
        {
            this.Epsilon = epsilon;
            this.MaxIterations = maxIterations;
            this.M = m;
        }
        public double Epsilon { get { return epsilon; } protected set { epsilon = value; } }
        private double epsilon;
        public int MaxIterations { get { return maxIterations; } protected set { maxIterations = value; } }
        private int maxIterations;
        public int M { get { return m; } protected set { m = value; } }
        private int m;
    }

}

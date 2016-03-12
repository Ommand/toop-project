using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Solver
{
    class MSGParametrs : ISolverParametrs
    {
        public MSGParametrs(double epsilon, int maxIterations)
        {
            this.Epsilon = epsilon;
            this.MaxIterations = maxIterations;
        }

        public double Epsilon { get { return epsilon; } protected set { epsilon = value; } }
        private double epsilon;
        public int MaxIterations { get { return maxIterations; } protected set { maxIterations = value; } }
        private int maxIterations;
    }
}

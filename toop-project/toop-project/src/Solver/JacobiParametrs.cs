using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Solver
{
    public class JacobiParametrs : ISolverParametrs {
        public JacobiParametrs(double epsilon, int maxIterations, double relax = 1.0) {
            this.Epsilon = epsilon;
            this.MaxIterations = maxIterations;
            this.Relaxation = relax;
        }

        public double Epsilon { get { return epsilon; } protected set { epsilon = value; } }
        private double epsilon;
        public int MaxIterations { get { return maxIterations; } protected set { maxIterations = value; } }
        private int maxIterations;
        public double Relaxation { get { return relaxation; } protected set { relaxation = value; } }
        private double relaxation;
    }
}

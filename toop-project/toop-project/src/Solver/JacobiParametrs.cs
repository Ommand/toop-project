using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Solver
{
    class JacobiParametrs : ISolverParametrs {
        public JacobiParametrs(double epsilon, int maxIterations, double relax = 1.0) {
            this.Epsilon = epsilon;
            this.MaxIterations = maxIterations;
            this.Relaxation = relax;
        }

        public double Epsilon { get;}
        private double epsilon;
        public int MaxIterations { get; }
        private int maxIterations;
        public double Relaxation { get; }
        private double relaxation;
    }
}

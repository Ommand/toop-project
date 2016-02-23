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

        private double epsilon;
        private int maxIterations;
        private double relaxation;
    }
}

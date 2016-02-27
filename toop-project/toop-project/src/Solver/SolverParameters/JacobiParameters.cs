using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Solver {
  class JacobiParameters : ISolverParameters {
    protected const double defaultRelaxation = 1.0;

    public double Relaxation { get { return relaxation; } protected set { relaxation = value; } }
    private double relaxation;

    public JacobiParameters() { }

    public JacobiParameters(double epsilon, int maxIterations, double relax = defaultRelaxation) {
      setParameters(epsilon, maxIterations, relax);
    }

    protected void setParameters(double epsilon, int maxIterations, double relax) {
      this.Epsilon = epsilon;
      this.MaxIterations = maxIterations;
      this.Relaxation = relax;
    }
  }
}

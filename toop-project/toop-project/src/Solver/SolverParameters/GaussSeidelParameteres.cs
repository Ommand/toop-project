using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Solver {
  class GaussSeidelParameters : JacobiParameters {
    public GaussSeidelParameters() { }

    public GaussSeidelParameters(double epsilon, int maxIterations, double relax = defaultRelaxation) {
      setParameters(epsilon, maxIterations, relax);
    }
  }
}

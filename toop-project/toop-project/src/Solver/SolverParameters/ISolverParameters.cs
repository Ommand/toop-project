using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Solver {
  public abstract class ISolverParameters {
    const double defaultEpsilon = 0.0001;
    const int defaultMaxIteration = 1000;

    public double Epsilon { get { return epsilon; } protected set { epsilon = value; } }
    private double epsilon = defaultEpsilon;
    public int MaxIterations { get { return maxIterations; } protected set { maxIterations = value; } }
    private int maxIterations = defaultMaxIteration;
    public src.Vector_.Vector InitialSolution { get { return initialSolution; } protected set { initialSolution = value.Clone() as src.Vector_.Vector; } }
    public src.Vector_.Vector initialSolution = null;
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Solver
{
    class JacobiParametrs:ISolverParametrs
    {

        JacobiParametrs(double epsilon, int maxIterations, double optionalRelaxationParameter)
        {
            this.epsilon = epsilon;
            this.maxIterations = maxIterations;
            this.optionalRelaxationParameter = optionalRelaxationParameter;
        }

       public double epsilon { get; }
       public int maxIterations { get; }
       public double optionalRelaxationParameter { get; } 

    }
}

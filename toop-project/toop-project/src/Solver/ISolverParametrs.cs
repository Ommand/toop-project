﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Solver
{
    public interface ISolverParametrs
    {
        double Epsilon { get; }
        int MaxIterations { get; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Slae {
    public class SLAE {
        public bool CanBeComputed() {
            if (Matrix == null) return false;
            if (Right == null) return false;
            //if (Precond == null) return false;
            if (Solver == null) return false;

            // TODO: check sizes of rp & matrix?

            return true;
        }
        public void Solve() {
            Result = Solver.Solve(Matrix, Right, new src.Vector_.Vector(6), src.Logger.Logger.getInstance(), Eps, MaxIter);
        }
        public src.Matrix.BaseMatrix Matrix = null;
        public src.Vector_.Vector Right = null;
        public src.Vector_.Vector Result = null;
        public src.Preconditioner.IPreconditioner Precond = null;
        public src.Solver.ISolver Solver = null;

        public double Eps = 1e-10;
        public int MaxIter = 1000;
    }

}

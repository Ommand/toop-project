using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Slae {
    public class SLAE {
        src.GUI.IGUI iGui = null;
        public SLAE(src.GUI.IGUI igui) {
            iGui = igui;
            MaxIter = DefaultMaxIter;
            MinResidual = DefaultMinResidual;
            MGMRES = DefaultMGMRES;
            Relaxation = DefaultRelaxation;
        }

        public bool CanBeComputed() {
            if (Matrix == null) return false;
            if (Right == null) return false;
            if (Solver == null) return false;
            if (Matrix.Size != Right.Size ||Initial != null && Matrix.Size != Initial.Size) return false;

            return true;
        }
        public void Solve() {
            //затычка, довести до запускаемой проги
            var Preconditioner = GeneratePreconditioner(PreconditionerType, Matrix);
            if (Initial == null)
                Initial = new Vector_.Vector(Right.Size);

            Result = Solver.Solve(Preconditioner, Right, Initial, src.Logging.Logger.Instance, src.Logging.Logger.Instance,
                GenerateParameters(Solver.Type,MaxIter,MinResidual,Relaxation, MGMRES));
            iGui.FinishSolve();
        }
        public src.Matrix.BaseMatrix Matrix = null;
        public src.Vector_.Vector Right = null;
        public src.Vector_.Vector Initial = null;
        public src.Vector_.Vector Result = null;
        public src.Solver.ISolver Solver = null;
        public src.Preconditioner.Type PreconditionerType = src.Preconditioner.Type.NoPrecond;

        public double MinResidual;
        public int MaxIter;
        public double Relaxation;
        public int MGMRES;

        private double defaultMinResidual = 1e-10;
        private int defaultMaxIter = 1000;
        private double defaultRelaxation = 1;
        private int defaultMGMRES = 30;

        public double DefaultMinResidual { get { return defaultMinResidual; } }
        public int DefaultMaxIter { get { return defaultMaxIter; } }
        public double DefaultRelaxation { get { return defaultRelaxation; } }
        public int DefaultMGMRES { get { return defaultMGMRES; } }

        src.Solver.ISolverParametrs GenerateParameters(src.Solver.Type type, int maxIter, double eps, double relaxation = 1,int mGMRES = 5) {
            switch(type) {
                case src.Solver.Type.GMRES:
                    return new Solver.GMRESParameters(eps, maxIter, mGMRES);
                case src.Solver.Type.Jacobi:
                    return new Solver.JacobiParametrs(eps, maxIter, relaxation);
                case src.Solver.Type.GaussSeidel:
                    return new Solver.GaussSeidelParametrs(eps, maxIter, relaxation);
                case src.Solver.Type.MSG:
                    return new Solver.MSGParametrs(eps, maxIter);
                case src.Solver.Type.BCGStab:
                    return new Solver.BCGStabParametrs(eps, MaxIter);
                case src.Solver.Type.LOS:
                    return new Solver.LOSParametrs(eps, MaxIter);
            }
            return null;
        }

        src.Preconditioner.IPreconditioner GeneratePreconditioner(src.Preconditioner.Type type, Matrix.BaseMatrix matrix) {
            switch (type) {
                case src.Preconditioner.Type.NoPrecond:
                    return src.Preconditioner.EmptyPreconditioner.Create(matrix);
                case src.Preconditioner.Type.Diagonal:
                    return src.Preconditioner.DiagonalPreconditioner.Create(matrix);
                case src.Preconditioner.Type.LLT:
                    return src.Preconditioner.LLTPreconditioner.Create(matrix);
                case src.Preconditioner.Type.LU:
                    return src.Preconditioner.LUPreconditioner.Create(matrix);
                case src.Preconditioner.Type.LUsq:
                    return src.Preconditioner.LUsqPreconditioner.Create(matrix);
            }
            return null;
        }

    }

}

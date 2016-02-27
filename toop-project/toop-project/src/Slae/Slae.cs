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
        }

        public bool CanBeComputed() {
            if (Matrix == null) return false;
            if (Right == null) return false;
            // TODO: uncomment if need precond
            //if (Precond == null) return false;
            if (Solver == null) return false;
            
            return true;
        }
        public void Solve() {
            try {
                Result = Solver.Solve(Matrix, Right);
                iGui.FinishSolve();
            }
            catch (Exception ex) {
                iGui.ShowError(ex.Message);
            }
        }
        public src.Matrix.BaseMatrix Matrix = null;
        public src.Vector_.Vector Right = null;
        public src.Vector_.Vector Result = null;
        public src.Preconditioner.IPreconditioner Precond = null;
        public src.Solver.ISolver Solver = null;
    }

}

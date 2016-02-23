﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Logger
{
    public class Logger
    {
        private static Logger instance = new Logger();
        private Logger() {}

        public static Logger getInstance() {
            return instance;
        }

        int IterationNumber { get; set; }
        /*IVector Residual { get; set; }
        IVector CurrentSolution { get; set; }
        ISolver CurrentSolver { get; set; }*/
    }
}

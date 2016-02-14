using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project
{
    interface ISLAE
    {
        IMatrix Matrix { get; set; }
        IVector RightPart { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05.Binary_Operator
{
    class BoundedTOperator : BinaryFSOperator
    {
        public BoundedTOperator()
        {
            Title = "Bounded Product T-norm ";
        }



        //override return data of Calculate function in BinaryFSOperator
        public override double Calculate(double x, double y)
        {
            return Math.Max(0, x * y - 1);
        }
    }
}

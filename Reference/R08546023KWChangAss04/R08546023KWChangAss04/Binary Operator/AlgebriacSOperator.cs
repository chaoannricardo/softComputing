﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05.Binary_Operator
{
    class AlgebriacSOperator : BinaryFSOperator
    {
        public AlgebriacSOperator()
        {
            Title = "Algebriac Sum S-norm ";
        }



        //override return data of Calculate function in BinaryFSOperator
        public override double Calculate(double x, double y)
        {
            return x + y - x * y;
        }
    }
}

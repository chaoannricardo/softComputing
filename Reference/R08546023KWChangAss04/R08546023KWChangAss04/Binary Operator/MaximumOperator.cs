﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05.Binary_Operator
{
    class UnionOperator : BinaryFSOperator
    {
        public UnionOperator()
        {
            Title = " Maximum T-norm ";
        }



        //override return data of Calculate function in BinaryFSOperator
        public override double Calculate(double x, double y)
        {
            //if x greater than y, return x, or y.
            return x > y ? x : y;
        }
    }
}

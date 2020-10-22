using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05.Binary_Operator
{
    class DrasticSOperator : BinaryFSOperator
    {
        public DrasticSOperator()
        {
            Title = "Drastic Sum S-norm ";
        }



        //override return data of Calculate function in BinaryFSOperator
        public override double Calculate(double x, double y)
        {
            //if x is 0, return y
            //if y is 0, return x
            //otherwise, 1
            if (x == 0)
            {
                return y;
            }
            else
            {
                if (y == 0)
                {
                    return x;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}

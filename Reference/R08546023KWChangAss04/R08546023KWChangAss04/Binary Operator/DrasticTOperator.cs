using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05.Binary_Operator
{
    class DrasticTOperator : BinaryFSOperator
    {
        public DrasticTOperator()
        {
            Title = "Drastic Product T-norm ";
        }



        //override return data of Calculate function in BinaryFSOperator
        public override double Calculate(double x, double y)
        {
            //if x is 1, return y
            //if y is 1, return x
            //otherwise, 0
            if(x ==1)
            {
                return y;
            }
            else
            {
                if(y == 1)
                {
                    return x;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}

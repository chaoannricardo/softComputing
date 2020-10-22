using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05.Binary_Operator
{
    class EinsteinSOperator : BinaryFSOperator
    {

        public EinsteinSOperator()
        {
            Title = "Einstein Sum S-norm ";
        }



        //override return data of Calculate function in BinaryFSOperator
        public override double Calculate(double x, double y)
        {
            return (x + y) / ( 1 + x * y);
        }
    }
}

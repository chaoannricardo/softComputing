using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class NegateOperator : UnaryFSOperator //繼承
    {
        public NegateOperator()
        {
            Title = "Negate";
        }
        //override return data of Calculate function in UnaryFSOperator
       public override double Calculate(double x)
        {
            return 1 - x;
        }
    }
}

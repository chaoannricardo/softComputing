using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05.Binary_Operator
{
    class HamacherSOperator : BinaryFSOperator
    {
        public HamacherSOperator()
        {
            parameters = new double[1];
            parameters[0] = 1;
            Title = "Hamacher Sum S-norm ";
        }

        //define property for alpha
        //attribute
        [Category("Parameters"), Description("p must be greater than 0.")]
        public double p
        {
            get
            {
                return parameters[0];
            }
            set
            {
                parameters[0] = value;
                FireOperatorParameterChangedEvent();
            }
        }



        //override return data of Calculate function in BinaryFSOperator
        public override double Calculate(double x, double y)
        {
            return (x + y - x * y - (1 - parameters[0]) * x * y) / (1 - (1 - parameters[0]) * x * y);
        }
    }
}

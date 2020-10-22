using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05.Binary_Operator
{
    class HamacherTOperator : BinaryFSOperator
    {
        public HamacherTOperator()
        {
            parameters = new double[1];
            parameters[0] = 1;
            Title = "Hamacher Product T-norm ";
        }

        //define property for alpha
        //attribute
        [Category("Parameters"), Description("")]
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
            if(x == 0 && y == 0 && parameters[0] ==0)
            {
                return 0;
            }
            else
            {
                return (x * y) / (parameters[0] + (1 - parameters[0]) * (x + y - x * y));
            }
        }
    }
}

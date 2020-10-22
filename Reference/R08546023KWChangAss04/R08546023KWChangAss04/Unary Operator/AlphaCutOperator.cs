using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R08546023KWChangAss05
{
    class AlphaCutOperator : UnaryFSOperator
    {
        
        public AlphaCutOperator()
        {
            parameters = new double[1];
            parameters[0] = 0.5;
            Title = Convert.ToString(parameters[0]) + " cut ";
            FireOperatorParameterChangedEvent();
        }



        //define property for alpha
        //attribute
        [Category("Parameters"), Description("Alpha must be between 0 and 1.")]
        public double Alpha
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

        //override return data of Calculate function in UnaryFSOperator
        public override double Calculate(double x)
        {
            //if the value greater than alpha, the value whould be rewrite as alpha, or remaind the same.
            return x > parameters[0] ? parameters[0] : x;
        }
    }

}

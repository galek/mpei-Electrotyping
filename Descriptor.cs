using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Descriptor
    {
        public double timestart = 0;
        public double timeend = 1500.0;

        public double h_step = 0.1;

        public double u0_min = 300;
        public double u0_value = 300;
        public double u0_max = 1000;

        public double r0_min = 0.1;
        public double r0_value = 0.1;
        public double r0_max = 1;

        // Используется только в режиме обучения
        public double Edu_targetValueD = 0.0;
        public string Edu_taskDesc = null;

        //TODO: For next-generation of program
        // you can describe specific coefficients

        public Descriptor
            (
            double _timestart, double _timeend,
            double _h_step,
            double _u0_min, double _u0_value, double _u0_max,
            double _r0_min, double _r0_value, double _r0_max,

            double _Edu_targetValueD, string _Edu_taskDesc
            )
        {
            timestart = _timestart;
            timeend = _timeend;
            h_step = _h_step;
            u0_min = _u0_min;
            u0_value = _u0_value;
            u0_max = _u0_max;
            r0_min = _r0_min;
            r0_value = _r0_value;
            r0_max = _r0_max;

            // Edu mode
            Edu_targetValueD = _Edu_targetValueD;
            Edu_taskDesc = _Edu_taskDesc;
        }
    }
}

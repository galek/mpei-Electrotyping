using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public class Compute
    {
        double tS = 0.0;
        double dS = 0.0;
        double tE = 1500.0;
        double h = 0.1;

        public void ComputeAction(System.Windows.Forms.DataVisualization.Charting.Chart _chart)
        {
            double[] arrD = new double[1000];
            double c1, c2, c3, c4;
            /*
character(*), parameter::frm = "(5x, 'Time', 9x, 'd')", frm2 = '(f12.2, e15.6)'
! Вывод заголовка таблицы результатов
open(1, file = "rslt.txt")
print frm
write(1, frm)

!
call drawCurve(k, 0.0, 1550.0, real(arrD), (/ 1.0, 0.0, 0.0 /), grid = .true., coords = .true.)
end program clcD*/

            //h-это шаг интегрирования
            double t = tS;// ЭТО [tS=xS,tE=xE] - отрезок интегрирования.
            double d = dS;
            double h2 = 0.5 * h;
            int m = 0;
            int k = 1;
            arrD[k] = d;
            
            _chart.ChartAreas[0].AxisX.Title = "x";
            _chart.ChartAreas[0].AxisY.Title = "y";

            //print frm2, t, d
            //write(1, frm2) t, d
            Console.Write("T " + t.ToString() + " D " + d.ToString());

            do
            {
                c1 = h * fn(t, d);// k1 = h * f(x, y) 
                c2 = h * fn(t + h2, d + 0.5 * c1);// k2 = h * f(x + h / 2, y + k1 / 2) 
                c3 = h * fn(t + h2, d + 0.5 * c2);// k3 = h * f(x + h / 2, y + k2 / 2) 
                c4 = h * fn(t + h2, d + c3);// k4 = h * f(x + h, y + k3) 

                d = d + (c1 + 2.0 * c2 + 2.0 * c3 + c4) / 6.0;// y = y + 1/ 6 *(k1 + 2 * k2 + 2 * k3 + k4) 
                t = t + h;// x = x + h
                m = m + 1;

                //!Выводим каждую 500 - ю точку
                if (m % 500 == 0)
                {
                    //print frm2, t, d
                    //write(1, frm2) t, d
                    Console.Write("T " + t.ToString() + " D " + d.ToString());

                    _chart.Series[0].Points.AddXY(t, d);

                    k = k + 1;
                    arrD[k] = d;
                }
            } while (t < tE);

            Console.Write("FINISHED");
        }

        public double fn(double t, double d)
        {
            double r0, u0, ks1, ks2, kf, b, a, r;
            r0 = 0.1;
            u0 = 300.0;
            b = 1.0;
            a = 2.25e-8;
            ks1 = 2.7e-6;
            ks2 = 1.3e-6;
            kf = 0.179;
            r = r0 + d * (1.0 / ks1 + Math.Log(1.0 + 1.0e6 * d) / ks2);
            return a * kf * u0 / (b + kf * r);
        }
    }
}

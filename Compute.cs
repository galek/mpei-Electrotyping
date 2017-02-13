/* Copyright (C) 2008-2017, Nick Galko. All rights reserved.
*
* Your use and or redistribution of this software in source and / or
* binary form, with or without modification, is subject to: (i) your
* ongoing acceptance of and compliance with the terms and conditions of
* the License Agreement; and (ii) your inclusion of this notice
* in any version of this software that you use or redistribute.
* A copy of the License Agreement is available on repository of project
*/

using System;

namespace WindowsFormsApplication1
{
    public class Compute
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="_chart"></param>
        /// <param name="_x">отрезок интегрирования - x</param>
        /// <param name="_y">отрезок интегрирования - y</param>
        /// <param name="_d">толщина покрытия</param>
        /// <param name="_h">шаг интегрирования</param>
        public void ComputeAction(System.Windows.Forms.DataVisualization.Charting.Chart _chart, double _x, double _y, double _d, double _h,
        double r0, double u0, double b, double a,
        double ks1, double ks2, double kf, ref int _CurrValue)
        {
            if (_chart == null)
                return;

            // Очищаем график
            if (_chart.Series != null)
            {
                _chart.Series[0].Points.Clear();
                // с закомментированным вариантом - рисует быстрее
                //_chart.Refresh();
            }
            else
            {
                return;
            }

            double[] arrD = new double[System.Int16.MaxValue];//655360
            double c1, c2, c3, c4;

            //h-это шаг интегрирования
            double t = _x;// ЭТО [tS=xS,tE=xE] - отрезок интегрирования.
            double d = _d;
            double h = _h;

            double h2 = 0.5 * h;
            int m = 0;
            int k = 1;
            arrD[k] = d;

            _chart.ChartAreas[0].AxisX.Title = "x=f(t)";
            _chart.ChartAreas[0].AxisY.Title = "y=d";

            Console.Write("T " + t.ToString() + " D " + d.ToString());

            do
            {
                c1 = h * fn1(t, d, r0, u0, b, a, ks1, ks2, kf);// k1 = h * f(x, y)
                c2 = h * fn1(t + h2, d + 0.5 * c1, r0, u0, b, a, ks1, ks2, kf);// k2 = h * f(x + h / 2, y + k1 / 2)
                c3 = h * fn1(t + h2, d + 0.5 * c2, r0, u0, b, a, ks1, ks2, kf);// k3 = h * f(x + h / 2, y + k2 / 2)
                c4 = h * fn1(t + h2, d + c3, r0, u0, b, a, ks1, ks2, kf);// k4 = h * f(x + h, y + k3)

                d = d + (c1 + 2.0 * c2 + 2.0 * c3 + c4) / 6.0;// y = y + 1/ 6 *(k1 + 2 * k2 + 2 * k3 + k4)
                t = t + h;// x = x + h
                m = m + 1;

                //!Выводим каждую 500 - ю точку
                if (m % 500 == 0)
                {
                    //print frm2, t, d
                    //write(1, frm2) t, d
                    Console.WriteLine("T " + t.ToString() + " D " + d.ToString());

                    _chart.Series[0].Points.AddXY(t, d);

                    // Выводим текущее значение
                    _CurrValue = Convert.ToInt32(Tools._MetersToNanoMeters(d));

                    Console.WriteLine("Ti " + Convert.ToInt32(t).ToString() + " Di " + _CurrValue.ToString());

                    k = k + 1;
                    arrD[k] = d;
                }
            } while (t < _y);

            Console.Write("FINISHED");
        }

        public double fn(double t, double d, double r0, double u0)
        {
            double ks1, ks2, kf, b, a;
            b = 1.0;
            a = 2.25e-8;

            ks1 = 2.7e-6;
            ks2 = 1.3e-6;
            kf = 0.179;

            return fn1(t, d, r0, u0, b, a, ks1, ks2, kf);
        }

        public double fn1(double t, double d, double r0, double u0, double b, double a,
        double ks1, double ks2, double kf)
        {
            double r;

            r = r0 + d * (1.0 / ks1 + Math.Log(1.0 + 1.0e6 * d) / ks2);
            return a * kf * u0 / (b + kf * r);
        }
    }
}
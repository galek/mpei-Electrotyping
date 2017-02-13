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
    internal static class Tools
    {
        public static bool _BiggerThanZero(int _v)
        {
            if (_v < 0)
                return false;

            return true;
        }

        /// <summary>
        /// Функция которая меня цвет заливки поля - полезно для отладки.
        /// </summary>
        /// <param name="tb">Textbox for changing of BackColor</param>
        /// <param name="_valid">Selection of color</param>
        public static void _ChangeColorEditBox(System.Windows.Forms.TextBox tb, bool _valid)
        {
            if (_valid)
            {
                tb.BackColor = System.Drawing.Color.White;
            }
            else
            {
                tb.BackColor = System.Drawing.Color.Red;
            }
        }

        public static double _MetersToNanoMeters(double _v)
        {
            return _v * 1000000000;
        }

        public static bool _CheckEditBoxOnNumbersOnly(System.Windows.Forms.TextBox tb, bool _resetOnCorrect)
        {
            try
            {
                double temp = Convert.ToDouble(tb.Text);
            }
            catch (Exception)
            {
                // debug only
                //{
                //    MessageBox.Show("Please provide number only");
                //}

                _ChangeColorEditBox(tb, false);
                return true;
            }

            if (string.IsNullOrEmpty(tb.Text))
            {
                _ChangeColorEditBox(tb, false);
                return true;
            }

            if (_resetOnCorrect)
                _ChangeColorEditBox(tb, true);
            return false;
        }
    }
}
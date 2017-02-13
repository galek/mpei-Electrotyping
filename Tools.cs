using System;

namespace WindowsFormsApplication1
{
    static class Tools
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

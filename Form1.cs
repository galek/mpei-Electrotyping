using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Compute comp = new Compute();
        const double MULLER = 1000.0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._UpdateValuesLimitsAndCompute(true);
        }
        private void _ComputeAction(bool _showMessage)
        {
            if (_CheckEditBoxOnNumbersOnly(this.xlimit) || _CheckEditBoxOnNumbersOnly(this.ylimit) ||
               _CheckEditBoxOnNumbersOnly(this.dVal) || _CheckEditBoxOnNumbersOnly(this.hVal) ||
               _CheckEditBoxOnNumbersOnly(this.r0) || _CheckEditBoxOnNumbersOnly(this.u0) ||
               _CheckEditBoxOnNumbersOnly(this.b) || _CheckEditBoxOnNumbersOnly(this.a) ||
               _CheckEditBoxOnNumbersOnly(this.ks1) || _CheckEditBoxOnNumbersOnly(this.ks2)
               || _CheckEditBoxOnNumbersOnly(this.kf))
            {
                // debug only
                //{
                //    if (_showMessage)
                //        MessageBox.Show("Не все поля заполнены - заполните, что бы осуществить перерасчет");
                //}

                return;
            }
            
            comp.ComputeAction(this.chart1, Convert.ToDouble(this.xlimit.Text), Convert.ToDouble(this.ylimit.Text), Convert.ToDouble(this.dVal.Text), Convert.ToDouble(this.hVal.Text),
            Convert.ToDouble(this.r0.Text), Convert.ToDouble(this.u0.Text),
            Convert.ToDouble(this.b.Text), Convert.ToDouble(this.a.Text),
            Convert.ToDouble(this.ks1.Text), Convert.ToDouble(this.ks2.Text), Convert.ToDouble(this.kf.Text));
        }

        private void r0_TextChanged(object sender, EventArgs e)
        {
            if (_CheckEditBoxOnNumbersOnly(this.r0))
            {
                //MessageBox.Show("Не прошли проверку r0_TextChanged");
                return;
            }

            _ChangeColorEditBox(this.r0, true);
            this._UpdateValuesLimitsAndCompute(true);
        }

        /// <summary>
        /// Функция которая меня цвет заливки поля - полезно для отладки. 
        /// </summary>
        /// <param name="tb">Textbox for changing of BackColor</param>
        /// <param name="_valid">Selection of color</param>
        private void _ChangeColorEditBox(System.Windows.Forms.TextBox tb, bool _valid)
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

        private bool _CheckEditBoxOnNumbersOnly(System.Windows.Forms.TextBox tb)
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

            _ChangeColorEditBox(tb, true);
            return false;
        }

        private void ylimit_TextChanged(object sender, EventArgs e)
        {
            // TODO: Check what time all time is >0
            if (_CheckEditBoxOnNumbersOnly(this.ylimit))
            {
                return;
            }

            _ChangeColorEditBox(this.ylimit, true);

            this._UpdateValuesLimitsAndCompute(true);
        }

        private void xlimit_TextChanged(object sender, EventArgs e)
        {
            // TODO: Check what time all time is >0
            if (_CheckEditBoxOnNumbersOnly(this.xlimit))
            {
                return;
            }

            _ChangeColorEditBox(this.xlimit, true);

            this._UpdateValuesLimitsAndCompute(true);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            u0.Text = (this.trackBar1.Value / MULLER).ToString();
            this._UpdateValuesLimitsAndCompute(true);
        }

        private void _UpdateLimits()
        {
            this.trackBar1.Minimum = Convert.ToInt32(Convert.ToDouble(this.u0_min.Text) * MULLER);
            this.trackBar1.Maximum = Convert.ToInt32(Convert.ToDouble(this.u0_max.Text) * MULLER);

            this.trackBar2.Minimum = Convert.ToInt32(Convert.ToDouble(this.r0_min.Text) * MULLER);
            this.trackBar2.Maximum = Convert.ToInt32(Convert.ToDouble(this.r0_max.Text) * MULLER);
        }

        private void _UpdateValues()
        {
            this._UpdateLimits();
        }

        private void _UpdateValuesAndCompute(bool _showMessage)
        {
            this._UpdateValues();
            // Now compute
            this._ComputeAction(_showMessage);
        }

        private void _UpdateValuesLimitsAndCompute(bool _showMessage)
        {
            this._UpdateValuesAndCompute(_showMessage);
        }

        private void r0_Leave(object sender, EventArgs e)
        {
            if (_CheckEditBoxOnNumbersOnly(this.r0))
            {
                MessageBox.Show("Пустое поле R0-введите его, что бы осуществить перерасчет");
                return;
            }
        }

        private void u0_Leave(object sender, EventArgs e)
        {
            if (_CheckEditBoxOnNumbersOnly(this.u0))
            {
                MessageBox.Show("Пустое поле u0-введите его, что бы осуществить перерасчет");
                return;
            }

        }

        private void u0_TextChanged(object sender, EventArgs e)
        {
            if (_CheckEditBoxOnNumbersOnly(this.u0))
            {
                return;
            }

            this._UpdateValuesLimitsAndCompute(true);
        }

        private void hVal_TextChanged(object sender, EventArgs e)
        {
            if (_CheckEditBoxOnNumbersOnly(this.hVal))
            {
                return;
            }

            this._UpdateValuesLimitsAndCompute(true);
        }

        private void hVal_Leave(object sender, EventArgs e)
        {
            if (_CheckEditBoxOnNumbersOnly(this.hVal))
            {
                MessageBox.Show("Пустое поле u0-введите его, что бы осуществить перерасчет");
                _ChangeColorEditBox(this.hVal, false);
                return;
            }
        }

        private void xlimit_Leave(object sender, EventArgs e)
        {
            if (_CheckEditBoxOnNumbersOnly(this.xlimit))
            {
                MessageBox.Show("Пустое поле xlimit-введите его, что бы осуществить перерасчет");
                _ChangeColorEditBox(this.xlimit, false);
                return;
            }
        }

        private void ylimit_Leave(object sender, EventArgs e)
        {
            if (_CheckEditBoxOnNumbersOnly(this.ylimit))
            {
                MessageBox.Show("Пустое поле ylimit-введите его, что бы осуществить перерасчет");
                _ChangeColorEditBox(this.ylimit, false);
                return;
            }
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            r0.Text = (this.trackBar2.Value / MULLER).ToString();

            this._UpdateValuesLimitsAndCompute(true);
        }

        private void u0_min_TextChanged(object sender, EventArgs e)
        {
            // TODO: always >0
            if (_CheckEditBoxOnNumbersOnly(this.u0_min))
            {
                return;
            }

            this.trackBar1.Minimum = Convert.ToInt32(Convert.ToDouble(this.u0_min.Text) * MULLER);
            this._UpdateValuesLimitsAndCompute(true);
        }

        private void u0_min_Leave(object sender, EventArgs e)
        {
            if (_CheckEditBoxOnNumbersOnly(this.u0_min))
            {
                MessageBox.Show("Пустое поле u0_min-введите его, что бы осуществить перерасчет");
                _ChangeColorEditBox(this.u0_min, false);
                return;
            }
        }

        private void u0_max_TextChanged(object sender, EventArgs e)
        {
            // TODO: always >0
            if (_CheckEditBoxOnNumbersOnly(this.u0_max))
            {
                return;
            }

            this.trackBar1.Maximum = Convert.ToInt32(Convert.ToDouble(this.u0_max.Text) * MULLER);
            this._UpdateValuesLimitsAndCompute(true);
        }

        private void u0_max_Leave(object sender, EventArgs e)
        {
            if (_CheckEditBoxOnNumbersOnly(this.u0_max))
            {
                MessageBox.Show("Пустое поле u0_max-введите его, что бы осуществить перерасчет");
                _ChangeColorEditBox(this.u0_max, false);
                return;
            }
        }

        private void r0_max_TextChanged(object sender, EventArgs e)
        {
            // TODO: always >0
            if (_CheckEditBoxOnNumbersOnly(this.r0_max))
            {
                return;
            }

            this.trackBar2.Maximum = Convert.ToInt32(Convert.ToDouble(this.r0_max.Text) * MULLER);

            this._UpdateValuesLimitsAndCompute(true);
        }

        private void r0_max_Leave(object sender, EventArgs e)
        {
            if (_CheckEditBoxOnNumbersOnly(this.r0_max))
            {
                MessageBox.Show("Пустое поле r0_max-введите его, что бы осуществить перерасчет");
                _ChangeColorEditBox(this.r0_max, false);
                return;
            }
        }

        private void r0_min_TextChanged(object sender, EventArgs e)
        {
            // TODO: always >0
            if (_CheckEditBoxOnNumbersOnly(this.r0_min))
            {
                return;
            }

            this.trackBar2.Minimum = Convert.ToInt32(Convert.ToDouble(this.r0_min.Text) * MULLER);
        }

        private void r0_min_Leave(object sender, EventArgs e)
        {
            if (_CheckEditBoxOnNumbersOnly(this.r0_min))
            {
                MessageBox.Show("Пустое поле r0_min-введите его, что бы осуществить перерасчет");
                _ChangeColorEditBox(this.r0_min, false);
                return;
            }
        }
    }
}

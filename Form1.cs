using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Compute comp = new Compute();
        // TODO: Implement different Edit boxes
        float m_MaxEnergy = 0;
        float m_MaxR0 = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._UpdateValuesAndCompute(true);
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
                return;
            }

            _ChangeColorEditBox(this.r0, true);
            this._UpdateValuesAndCompute(true);
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

            this._UpdateValuesAndCompute(true);
        }

        private void xlimit_TextChanged(object sender, EventArgs e)
        {
            // TODO: Check what time all time is >0
            if (_CheckEditBoxOnNumbersOnly(this.xlimit))
            {
                return;
            }

            _ChangeColorEditBox(this.xlimit, true);

            this._UpdateValuesAndCompute(true);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this._UpdateValuesAndCompute(true);
        }

        private void _UpdateValues()
        {
            u0.Text = this.trackBar1.Value.ToString();
            r0.Text = this.trackBar2.Value.ToString();
        }

        private void _UpdateValuesAndCompute(bool _showMessage)
        {
            this._UpdateValues();
            // Now compute
            this._ComputeAction(_showMessage);
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

            _ChangeColorEditBox(this.u0, true);

            this._UpdateValuesAndCompute(true);
        }

        private void hVal_TextChanged(object sender, EventArgs e)
        {
            if (_CheckEditBoxOnNumbersOnly(this.hVal))
            {
                return;
            }

            _ChangeColorEditBox(this.hVal, true);

            this._UpdateValuesAndCompute(true);
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
            this._UpdateValuesAndCompute(true);
        }
    }
}

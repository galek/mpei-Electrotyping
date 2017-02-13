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
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Compute comp = new Compute();
        private ModeManager man = new ModeManager();

        /// <summary>
        /// Muller used for slider, because default slider works only with integer
        /// </summary>
        private const double MULLER = 1000.0;

        public Form1()
        {
            InitializeComponent();
            // Расчитываем исходя из заданных значений
            this._UpdateValuesLimitsAndCompute(true);
            // Добавляем уже зарание заданные сценарии для обучения
            this._InitEduModeScenaries();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._UpdateValuesLimitsAndCompute(true);
        }

        private void _ComputeAction(bool _showMessage)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.xlimit, true) || Tools._CheckEditBoxOnNumbersOnly(this.ylimit, true) ||
               Tools._CheckEditBoxOnNumbersOnly(this.dVal, true) || Tools._CheckEditBoxOnNumbersOnly(this.hVal, true) ||
              Tools._CheckEditBoxOnNumbersOnly(this.r0, true) || Tools._CheckEditBoxOnNumbersOnly(this.u0, true) ||
               Tools._CheckEditBoxOnNumbersOnly(this.b, true) || Tools._CheckEditBoxOnNumbersOnly(this.a, true) ||
               Tools._CheckEditBoxOnNumbersOnly(this.ks1, true) || Tools._CheckEditBoxOnNumbersOnly(this.ks2, true)
               || Tools._CheckEditBoxOnNumbersOnly(this.kf, true))
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

        private void ylimit_TextChanged(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.ylimit, true))
            {
                return;
            }

            Tools._ChangeColorEditBox(this.ylimit, true);

            var value = Convert.ToInt32(Convert.ToDouble(this.ylimit.Text) * MULLER);
            if (!Tools._BiggerThanZero(value))
            {
                //MessageBox.Show("Данное значение должно быть больше 0");
                Tools._ChangeColorEditBox(this.ylimit, false);
                return;
            }

            this._UpdateValuesLimitsAndCompute(true);
        }

        private void xlimit_TextChanged(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.xlimit, true))
            {
                return;
            }

            Tools._ChangeColorEditBox(this.xlimit, true);

            var value = Convert.ToInt32(Convert.ToDouble(this.xlimit.Text) * MULLER);
            if (!Tools._BiggerThanZero(value))
            {
                // MessageBox.Show("Данное значение должно быть больше 0");
                Tools._ChangeColorEditBox(this.xlimit, false);
                return;
            }

            this._UpdateValuesLimitsAndCompute(true);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            u0.Text = (this.u0_trackBar1.Value / MULLER).ToString();
            this._UpdateValuesLimitsAndCompute(true);
        }

        private void _UpdateLimits()
        {
            this.u0_trackBar1.Minimum = Convert.ToInt32(Convert.ToDouble(this.u0_min.Text) * MULLER);
            this.u0_trackBar1.Maximum = Convert.ToInt32(Convert.ToDouble(this.u0_max.Text) * MULLER);

            this.r0_trackBar2.Minimum = Convert.ToInt32(Convert.ToDouble(this.r0_min.Text) * MULLER);
            this.r0_trackBar2.Maximum = Convert.ToInt32(Convert.ToDouble(this.r0_max.Text) * MULLER);
        }

        private void _UpdateValuesLimitsAndCompute(bool _showMessage)
        {
            this._UpdateLimits();
            // Now compute
            this._ComputeAction(_showMessage);
        }

        private void r0_Leave(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.r0, false))
            {
                MessageBox.Show("Пустое поле R0-введите его, что бы осуществить перерасчет");
                return;
            }
        }

        private void u0_Leave(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.u0, false))
            {
                MessageBox.Show("Пустое поле u0-введите его, что бы осуществить перерасчет");
                return;
            }
        }

        private void r0_TextChanged(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.r0, true))
            {
                MessageBox.Show("Не прошли проверку r0_TextChanged");
                return;
            }

            Tools._ChangeColorEditBox(this.r0, true);

            if (r0.Focused)
            {
                //MessageBox.Show("Focused");
                {
                    this._UpdateLimits();

                    var value = Convert.ToInt32(Convert.ToDouble(r0.Text) * MULLER);
                    //MessageBox.Show("Конвертировано: " + value.ToString() + " Максимум " + this.trackBar2.Maximum.ToString()
                    //    + " Минимум " + this.trackBar2.Minimum.ToString());
                    //MessageBox.Show(value.ToString());

                    if (IsInValidValue(value, this.r0_trackBar2, this.r0))
                        return;

                    Tools._CheckEditBoxOnNumbersOnly(this.r0, true);
                    this.r0_trackBar2.Value = Convert.ToInt32(value);
                }
            }
            else
            { /*MessageBox.Show("!Focused");*/ }
        }

        private void u0_TextChanged(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.u0, true))
            {
                MessageBox.Show("Не прошли проверку r0_TextChanged");
                return;
            }

            Tools._ChangeColorEditBox(this.u0, true);

            if (u0.Focused)
            {
                //MessageBox.Show("Focused");
                {
                    this._UpdateLimits();

                    var value = Convert.ToInt32(Convert.ToDouble(u0.Text) * MULLER);
                    //MessageBox.Show("Конвертировано: " + value.ToString() + " Максимум " + this.trackBar2.Maximum.ToString()
                    //    + " Минимум " + this.trackBar2.Minimum.ToString());
                    //MessageBox.Show(value.ToString());

                    if (IsInValidValue(value, this.u0_trackBar1, this.u0))
                        return;

                    Tools._CheckEditBoxOnNumbersOnly(this.u0, true);
                    this.u0_trackBar1.Value = Convert.ToInt32(value);
                }
            }
            else
            { /*MessageBox.Show("!Focused");*/ }
        }

        private void hVal_TextChanged(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.hVal, true))
            {
                return;
            }

            var value = Convert.ToInt32(Convert.ToDouble(this.hVal.Text) * MULLER);
            if (!Tools._BiggerThanZero(value))
            {
                // MessageBox.Show("Данное значение должно быть больше 0");
                Tools._ChangeColorEditBox(this.hVal, false);
                return;
            }

            this._UpdateValuesLimitsAndCompute(true);
        }

        private bool IsInValidValue(int value, System.Windows.Forms.TrackBar _track, System.Windows.Forms.TextBox tb)
        {
            if (value > _track.Maximum)
            {
                Tools._ChangeColorEditBox(tb, false);
                return true;
            }
            if (value < _track.Minimum)
            {
                Tools._ChangeColorEditBox(tb, false);
                return true;
            }

            Tools._ChangeColorEditBox(tb, true);
            return false;
        }

        private void hVal_Leave(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.hVal, false))
            {
                MessageBox.Show("Пустое поле u0-введите его, что бы осуществить перерасчет");
                Tools._ChangeColorEditBox(this.hVal, false);
                return;
            }
        }

        private void xlimit_Leave(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.xlimit, false))
            {
                MessageBox.Show("Пустое поле xlimit-введите его, что бы осуществить перерасчет");
                Tools._ChangeColorEditBox(this.xlimit, false);
                return;
            }
        }

        private void ylimit_Leave(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.ylimit, false))
            {
                MessageBox.Show("Пустое поле ylimit-введите его, что бы осуществить перерасчет");
                Tools._ChangeColorEditBox(this.ylimit, false);
                return;
            }
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            r0.Text = (this.r0_trackBar2.Value / MULLER).ToString();

            this._UpdateValuesLimitsAndCompute(true);
        }

        private void u0_min_TextChanged(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.u0_min, true))
            {
                return;
            }

            var value = Convert.ToInt32(Convert.ToDouble(this.u0_min.Text) * MULLER);
            if (!Tools._BiggerThanZero(value))
            {
                MessageBox.Show("Данное значение должно быть больше 0");
                Tools._ChangeColorEditBox(this.u0_min, false);
                return;
            }

            this.u0_trackBar1.Minimum = Convert.ToInt32(Convert.ToDouble(this.u0_min.Text) * MULLER);
            this._UpdateValuesLimitsAndCompute(true);
        }

        private void u0_min_Leave(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.u0_min, false))
            {
                MessageBox.Show("Пустое поле u0_min-введите его, что бы осуществить перерасчет");
                Tools._ChangeColorEditBox(this.u0_min, false);
                return;
            }
            var value = Convert.ToInt32(Convert.ToDouble(this.u0_min.Text) * MULLER);
            if (!Tools._BiggerThanZero(value))
            {
                //MessageBox.Show("Данное значение должно быть больше 0");
                Tools._ChangeColorEditBox(this.u0_min, false);
                return;
            }
        }

        private void u0_max_TextChanged(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.u0_max, true))
            {
                return;
            }

            var value = Convert.ToInt32(Convert.ToDouble(this.u0_max.Text) * MULLER);
            if (!Tools._BiggerThanZero(value))
            {
                //MessageBox.Show("Данное значение должно быть больше 0");
                Tools._ChangeColorEditBox(this.u0_max, false);
                return;
            }

            this.u0_trackBar1.Maximum = Convert.ToInt32(Convert.ToDouble(this.u0_max.Text) * MULLER);
            this._UpdateValuesLimitsAndCompute(true);
        }

        private void u0_max_Leave(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.u0_max, false))
            {
                MessageBox.Show("Пустое поле u0_max-введите его, что бы осуществить перерасчет");
                Tools._ChangeColorEditBox(this.u0_max, false);
                return;
            }
        }

        private void r0_max_TextChanged(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.r0_max, true))
            {
                return;
            }

            var value = Convert.ToInt32(Convert.ToDouble(this.r0_max.Text) * MULLER);
            if (!Tools._BiggerThanZero(value))
            {
                //MessageBox.Show("Данное значение должно быть больше 0");
                Tools._ChangeColorEditBox(this.r0_max, false);
                return;
            }

            this.r0_trackBar2.Maximum = value;

            this._UpdateValuesLimitsAndCompute(true);
        }

        private void r0_max_Leave(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.r0_max, false))
            {
                MessageBox.Show("Пустое поле r0_max-введите его, что бы осуществить перерасчет");
                Tools._ChangeColorEditBox(this.r0_max, false);
                return;
            }
        }

        private void r0_min_TextChanged(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.r0_min, true))
            {
                return;
            }

            var value = Convert.ToInt32(Convert.ToDouble(this.r0_min.Text) * MULLER);
            if (!Tools._BiggerThanZero(value))
            {
                MessageBox.Show("Данное значение должно быть больше 0");
                Tools._ChangeColorEditBox(this.r0_min, false);
                return;
            }

            this.r0_trackBar2.Minimum = Convert.ToInt32(Convert.ToDouble(this.r0_min.Text) * MULLER);
        }

        private void r0_min_Leave(object sender, EventArgs e)
        {
            if (Tools._CheckEditBoxOnNumbersOnly(this.r0_min, false))
            {
                MessageBox.Show("Пустое поле r0_min-введите его, что бы осуществить перерасчет");
                Tools._ChangeColorEditBox(this.r0_min, false);
                return;
            }
        }

        private void WorkMode_B_CheckedChanged(object sender, EventArgs e)
        {
            if (man == null)
                return;

            man.SwitchToWorkMode();
            _ApplyState(man.GetScenario(0));
            this._ShowHideEduMode(false);
        }

        private void _ShowHideEduMode(bool _state)
        {
            this.Selector_Datas_desc.Visible = _state;
            this.Selector_Datas_sel.Visible = _state;

            {
                this.EduMode_YouMustGetL.Visible = _state;
                this.EduMode_YouMustGetV.Visible = _state;
                this.EduMode_YouMustGetLV.Visible = _state;
            }
        }

        private void _ApplyState(Descriptor _desc)
        {
            this.xlimit.Text = _desc.timestart.ToString();
            this.ylimit.Text = _desc.timeend.ToString();

            this.u0_min.Text = _desc.u0_min.ToString();
            this.u0.Text = _desc.u0_value.ToString();
            this.u0_max.Text = _desc.u0_max.ToString();

            this.r0_min.Text = _desc.r0_min.ToString();
            this.r0.Text = _desc.r0_value.ToString();
            this.r0_max.Text = _desc.r0_max.ToString();

            this.hVal.Text = _desc.h_step.ToString();

            this.EduDesc.Lines = new[] { _desc.Edu_taskDesc };
        }

        private void EduMode_B_CheckedChanged(object sender, EventArgs e)
        {
            this._SwitchToEduMode(0);
        }

        private void _SwitchToEduMode(int _in)
        {
            if (man == null)
                return;

            man.SwitchToEduMode();
            _ApplyState(man.GetScenario(_in));
            _ShowHideEduMode(true);
        }

        private void _InitEduModeScenaries()
        {
            for (var i = ModeManager.Edu_Scenario.Edu_Scenario_First; i < ModeManager.Edu_Scenario.Edu_Scenario_NUM; i++)
                this.Selector_Datas_sel.Items.Add(i.ToString());// TODO: тут можно сделать получение заголовка из дескриптора
        }

        private void Selector_Datas_sel_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SwitchToEduMode(this.Selector_Datas_sel.SelectedIndex);
        }
    }
}
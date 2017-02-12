using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Compute comp = new Compute();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._ComputeAction();
        }
        private void _ComputeAction()
        {
            comp.ComputeAction(this.chart1, Convert.ToDouble(this.xlimit.Text), Convert.ToDouble(this.ylimit.Text), Convert.ToDouble(this.dVal.Text), Convert.ToDouble(this.hVal.Text),
            Convert.ToDouble(this.r0.Text), Convert.ToDouble(this.u0.Text),
            Convert.ToDouble(this.b.Text), Convert.ToDouble(this.a.Text),
            Convert.ToDouble(this.ks1.Text), Convert.ToDouble(this.ks2.Text), Convert.ToDouble(this.kf.Text));
        }

        private void u0_TextAlignChanged(object sender, EventArgs e)
        {
            this._ComputeAction();
        }

        private void r0_TextChanged(object sender, EventArgs e)
        {
            this._ComputeAction();
        }

        private void ylimit_TextChanged(object sender, EventArgs e)
        {
            this._ComputeAction();
        }

        private void xlimit_TextChanged(object sender, EventArgs e)
        {
            this._ComputeAction();
        }
    }
}

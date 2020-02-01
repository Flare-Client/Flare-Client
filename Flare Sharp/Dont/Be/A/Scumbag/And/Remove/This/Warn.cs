using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.Dont.Be.A.Scumbag.And.Remove.This
{
    class Warn
    {
        public static void warn()
        {
            MessageBox.Show("Flare client is FREE and OPEN SOURCE!"+ "\nIf you paid for this, get a refund.", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

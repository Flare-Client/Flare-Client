using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp.UI
{
    public class TabUI : Form
    {
        public TabUI()
        {
            Console.WriteLine("Starting Tab GUI...");
            Thread drawThread = new Thread(()=>
            {
                while (true)
                {

                }
            });
            Console.WriteLine("Tab GUI draw loop started!");
            this.Paint += OnPaint;
        }

        public void OnPaint(object sender, PaintEventArgs args)
        {
            Graphics graphics = args.Graphics;
        }
    }
}

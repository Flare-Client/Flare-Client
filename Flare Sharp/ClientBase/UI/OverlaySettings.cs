using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.UI
{
    public class OverlaySettings
    {
        // 60 frames/sec roughly
        public int UpdateRate { get; set; }

        public string Author { get; set; }
        public string Description { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
    }
}

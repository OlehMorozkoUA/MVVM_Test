using System.Collections.Generic;
using System.Drawing;

namespace MVVM_Test.Models
{
    internal class PlaceInfo
    {
        public string Name { get; set; }
        public Point Location { get; set; }

        public IEnumerable<ConfirmedCount> Counts { get; set; }
    }
}

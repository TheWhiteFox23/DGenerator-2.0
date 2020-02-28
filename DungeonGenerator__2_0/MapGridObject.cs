using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    interface MapGridObject
    {
        int ID { get; }
        int[] CenterPointInGrid { get; set; }
        void Draw(MapGrid Grid);
    }
}

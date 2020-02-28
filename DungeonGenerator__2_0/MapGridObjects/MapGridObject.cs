using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    interface MapGridObject
    {
        //int ID { get; }
        void Draw(MapGrid Grid, int XPointCenter, int YPointCenter);
        int getID();
        int[] getCenterPoint();
        void setCenterPoint(int[] CenterPoint);
    }
}

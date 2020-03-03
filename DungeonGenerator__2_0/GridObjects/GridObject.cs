using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    interface GridObject
    {
        //int ID { get; }
        void Draw(Raster Grid, int XPointCenter, int YPointCenter);
        int getID();
        int[] getCenterPoint();
        void setCenterPoint(int[] CenterPoint);

        void setAngle(int Angle);
        int getAngle();

        void setInfill(bool Infill);
        void setBorderSize(int BorderSize);
        int getBorderSize();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    public interface GridObject
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
        bool CanBePlaced(Raster RasterGrid, int Xcenter, int Ycenter);
        int[][] FindClosestNeighbourt(Raster Grid);
    }
}

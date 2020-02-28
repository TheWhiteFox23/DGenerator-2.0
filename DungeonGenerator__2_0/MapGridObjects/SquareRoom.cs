using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    public class SquareRoom : MapGridObject
    {
        private int[] CenterPointInGrid;
        private int ID;
        private int SideLength;
        private int Angle;
        private int BorderSize_pixels;
        private bool Infill;

        //For calculation
        private double Diameter;

      
        public SquareRoom(int ID, int SideLength)
        {
            this.ID = ID;
            this.Angle = 0;
            this.SideLength = SideLength;
            this.Diameter = Math.Sqrt(2 * SideLength * SideLength);
            this.BorderSize_pixels = 1;
            this.Infill = false;
        }        
        public SquareRoom(int ID, int minSideLength, int maxSideLength)
        {
            this.ID = ID;
            this.Angle = 0;
            this.SideLength = new Random().Next(minSideLength, maxSideLength);
            this.Diameter = Math.Sqrt(2 * SideLength * SideLength);
            this.BorderSize_pixels = 1;
            this.Infill = false;
        }
        public SquareRoom(int ID, int minSideLength, int maxSideLength, int seed)
        {
            this.ID = ID;
            this.Angle = 0;
            this.SideLength = new Random(seed).Next(minSideLength, maxSideLength);
            this.Diameter = Math.Sqrt(2 * SideLength * SideLength);
            this.BorderSize_pixels = 1;
            this.Infill = false;
        }
        public void Draw(MapGrid Grid, int XPointCenter, int YPointCenter)
        {
            CenterPointInGrid = new int[] { XPointCenter, YPointCenter };
            //DrawBorders
            for (int j = 0; j < BorderSize_pixels; j++)
            {
                int DiameterShift = (int)(Math.Round(Diameter / 2, MidpointRounding.AwayFromZero)) + j;
                int[][] extremePoints =
                {
                Drawing.GetAngledPoint(CenterPointInGrid[0], CenterPointInGrid[1],(45 +         Angle)%360, DiameterShift), //UperRightCorner
                Drawing.GetAngledPoint(CenterPointInGrid[0], CenterPointInGrid[1],(45 + 90  +   Angle)%360, DiameterShift), //UperLeftCorner
                Drawing.GetAngledPoint(CenterPointInGrid[0], CenterPointInGrid[1],(45 + 180 +   Angle)%360, DiameterShift), //LowerLeftCorner
                Drawing.GetAngledPoint(CenterPointInGrid[0], CenterPointInGrid[1],(45 + 270 +   Angle)%360, DiameterShift)  //LowerRightCorner
                };

                int[][] sides =
                {
                    new int[]{0,1},
                    new int[]{1,2},
                    new int[]{2,3},
                    new int[]{3,0},
                };

                for (int i = 0; i < sides.Length; i++)
                {
                    int x1 = extremePoints[sides[i][0]][0];
                    int y1 = extremePoints[sides[i][0]][1];
                    int x2 = extremePoints[sides[i][1]][0];
                    int y2 = extremePoints[sides[i][1]][1];

                    Drawing.DrawLine(x1, y1, x2, y2, Grid, ID);
                } 
            }
            //infil
            if (Infill)
            {
                Drawing.FloodFill(ID, CenterPointInGrid[0], CenterPointInGrid[1], Const.EMPTY, Grid.getGrid(), false);
            }
        }








        //GET - SET methods
        public void setInfill(bool infill)
        {
            this.Infill = infill;

        }
        public int getID()
        {
            return ID;
        }
        public int[] getCenterPoint()
        {
            return CenterPointInGrid;
        }
        public void setCenterPoint(int[] CenterPoint)
        {
            this.CenterPointInGrid = CenterPoint;
        }
        public void setSideLength(int sideLength)
        {
            this.SideLength = sideLength;
        }
        public int getSideLength()
        {
            return SideLength;
        }        
        public void setAngle(int angle)
        {
            this.Angle = angle;
        }
        public int getAngle()
        {
            return Angle;
        }
        public int getBorderSize()
        {
            return BorderSize_pixels;
        }
        public void setBorderSize(int borderSize)
        {
            this.BorderSize_pixels = borderSize;
        }
    }
}
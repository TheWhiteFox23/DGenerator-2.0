using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    public class SquareRoom : MapGridObject
    {
        public int[] CenterPointInGrid { get; set; }
        public int ID { get; }
        public int Height { get; set; }
        public int Width { get; set; }


        public SquareRoom(int[] xAndYCoordinatesOfTheCenter, int ID, int width, int height)
        {
            this.CenterPointInGrid = xAndYCoordinatesOfTheCenter;
            this.ID = ID;
            this.Width = width;
            this.Height = height;
        }

        
        public void Draw(MapGrid Grid)
        {
            //Get Extreme points - shifts from the center X, Y
            int[][] extremePoints =
            {
                new int[]{-1,-1,},  //LoweLeft
                new int[]{-1,1,},   //UperLeft
                new int[]{1,-1,},   //LowerRight
                new int[]{1, 1,}    //UpperRight
            };

            int[][] sides =
            {
                new int[]{0,1},
                new int[]{1,3},
                new int[]{3,2},
                new int[]{2,0},
            };

            for(int i = 0; i < sides.Length; i++)
            {
                int x1 = CenterPointInGrid[0] + (extremePoints[sides[i][0]][0] * (Width / 2));
                int y1 = CenterPointInGrid[1] + (extremePoints[sides[i][0]][1] * (Height / 2));
                int x2 = CenterPointInGrid[0] + (extremePoints[sides[i][1]][0] * (Width / 2));
                int y2 = CenterPointInGrid[1] + (extremePoints[sides[i][1]][1] * (Height / 2));
                Drawing.DrawLine(x1, y1, x2, y2, Grid, ID);
            }


            /*int x1 = CenterPointInGrid[0] - Width / 2;
            int y1 = CenterPointInGrid[1] - Height / 2;
            int x2 = CenterPointInGrid[0] + Width / 2;
            int y2 = CenterPointInGrid[1] + Height / 2;*/

            //Drawing.DrawLine(x1, y1, x2, y2, Grid, ID);
            /*for(int i = CenterPointInGrid[1] - Height/2; i< CenterPointInGrid[1] + Height/2; i++)
            {
                for(int j = CenterPointInGrid[0] -Width/2; j<CenterPointInGrid[0] + Width/2; j++)
                {
                    if(i>0 && j>0 && i< Grid.GetHeight() && j < Grid.GetWidth())
                    {
                        Grid.SetTileID(ID, i, j);
                    }
                }
            }*/

        }
    }
}
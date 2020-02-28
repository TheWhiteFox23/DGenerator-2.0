using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonGenerator
{
    public static class Drawing
    {
        public static void DrawLine(int x0, int y0, int x1, int y1, MapGrid Grid, int ID)
        {
            int dx, dy;
            int stepX, stepY;

            dx = (x1 - x0);
            dy = (y1 - y0);

            if (dy < 0)
            {
                dy = -dy;
                stepY = -1;
            }
            else
            {
                stepY = 1;
            }
            if (dx < 0)
            {
                dx = -dx;
                stepX = -1;
            }
            else
            {
                stepX = 1;
            }

            //Im not totaly sure WHY ??????
            dx <<= 1;
            dy <<= 1;

            //Check if point is inside of the raster and plot first pixel
            if ((0 <= x0) && (x0 < Grid.GetWidth()) && (0 <= y0) && (y0 < Grid.GetHeight())) Grid.SetTileID(ID, x0, y0);
            if (dx > dy)
            {
                int fraction = dy - (dx >> 1);
                while (x0 != x1)
                {
                    x0 += stepX;
                    if (fraction >= 0)
                    {
                        y0 += stepY;
                        fraction -= dx;

                    }
                    fraction += dy;
                    if ((0 <= x0) && (x0 < Grid.GetWidth()) && (0 <= y0) && (y0 < Grid.GetHeight())) Grid.SetTileID(ID, x0, y0);
                }

            }
            else
            {
                int fraction = dx - (dy >> 1);
                while (y0 != y1)
                {
                    if (fraction >= 0)
                    {
                        x0 += stepX;
                        fraction -= dy;
                    }
                    fraction += dx;
                    y0 += stepY;
                    if ((0 <= x0) && (x0 < Grid.GetWidth()) && (0 <= y0) && (y0 < Grid.GetHeight())) Grid.SetTileID(ID, x0, y0);
                }

            }
        }

        static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        public static void FloodFill(int ID, int X, int Y, int target, int[][] roomMap, bool corners)
        {
            Dictionary<string, int[]> floodFiled = new Dictionary<string, int[]>();
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { X, Y });
            while (queue.Count() > 0)
            {
                if (!floodFiled.ContainsKey(X + "." + Y)) floodFiled.Add(X + "." + Y, new int[] { X, Y });
                int indexX = queue.Peek()[0];
                int indexY = queue.Dequeue()[1];
                int[] W = { indexX, indexY };
                int[] E = { indexX, indexY };

                while (W[1] >= 0 && W[1] < roomMap[1].Length && W[0] >= 0 && W[0] < roomMap[1].Length && roomMap[W[1]][W[0]] == target)
                {
                    W[0]--;
                }

                while (E[1] >= 0 && E[1] < roomMap[1].Length && E[0] >= 0 && E[0] < roomMap[1].Length && roomMap[E[1]][E[0]] == target)
                {
                    E[0]++;
                }
                for (int i = W[0] + 1; i < E[0]; i++)
                {
                    roomMap[W[1]][i] = ID;
                    if (!floodFiled.ContainsKey(i + "." + W[1])) floodFiled.Add(i + "." + W[1], new int[] { i, W[1] });
                    if (W[1] + 1 >= 0 && W[1] + 1 < roomMap.Length && roomMap[W[1] + 1][i] == target)
                    {
                        queue.Enqueue(new int[] { i, W[1] + 1 });
                    }
                    if (corners)
                    {
                        if (W[1] + 1 >= 0 && W[1] + 1 < roomMap.Length && i + 1 < roomMap.Length && roomMap[W[1] + 1][i + 1] == target)
                        {
                            queue.Enqueue(new int[] { i + 1, W[1] + 1 });
                        }
                        if (W[1] - 1 >= 0 && W[1] - 1 < roomMap.Length && i + 1 < roomMap.Length && roomMap[W[1] - 1][i + 1] == target)
                        {
                            queue.Enqueue(new int[] { i + 1, W[1] - 1 });
                        }
                        if (W[1] + 1 >= 0 && W[1] + 1 < roomMap.Length && i - 1 >= 0 && roomMap[W[1] + 1][i - 1] == target)
                        {
                            queue.Enqueue(new int[] { i - 1, W[1] + 1 });
                        }
                        if (W[1] - 1 >= 0 && W[1] - 1 < roomMap.Length && i - 1 >= 0 && roomMap[W[1] - 1][i - 1] == target)
                        {
                            queue.Enqueue(new int[] { i - 1, W[1] - 1 });
                        }
                    }

                    if (W[1] - 1 >= 0 && W[1] - 1 < roomMap.Length && roomMap[W[1] - 1][i] == target)
                    {
                        queue.Enqueue(new int[] { i, W[1] - 1 });
                    }
                }
            }
        }

        public static void DrawLineAngle(int xCoordinate, int yCoordinate, int angleInDegrees, int length, MapGrid grid, int ID)
        {
            //grid.SetTileID(100, 100, 100);
            //Console.WriteLine("WhatTheFuck?");
            //SecondPoint coordinates
            int x2Coordinate;
            int y2Coordinate;

            double yShift = Math.Round(Math.Sin(DegreesToRadians(angleInDegrees)) * length, MidpointRounding.AwayFromZero);
            double xShift = Math.Round(Math.Cos(DegreesToRadians(angleInDegrees)) * length, MidpointRounding.AwayFromZero);

            y2Coordinate = (int)(yCoordinate - yShift);
            x2Coordinate = (int)(xCoordinate - xShift);

            //Console.WriteLine("Angle : {4}   -----  Xshift : {0}, Yshift : {1}  ---- Final X2 : {2},  Final Y2 : {3}", xShift, yShift, x2Coordinate, y2Coordinate, angleInDegrees);

            DrawLine(xCoordinate, yCoordinate, x2Coordinate, y2Coordinate, grid, ID);
        }

        public static double CalculateAbsolutePointDistance(int xCenter, int yCenter, int xPoint, int yPoint)
        {

            int absoluteXDifference = Math.Abs(xCenter - xPoint);
            int absoluteYDifference = Math.Abs(yCenter - yPoint);
            double Distance = Math.Sqrt(absoluteXDifference * absoluteXDifference + absoluteYDifference + absoluteYDifference);

            return Distance;
        }

        public static int CalculateAproxPointDistance(int x0, int y0, int x1, int y1)
        {
            int DistanceCount = 0;
            int dx, dy;
            int stepX, stepY;

            dx = (x1 - x0);
            dy = (y1 - y0);

            if (dy < 0)
            {
                dy = -dy;
                stepY = -1;
            }
            else
            {
                stepY = 1;
            }
            if (dx < 0)
            {
                dx = -dx;
                stepX = -1;
            }
            else
            {
                stepX = 1;
            }

            //Im not totaly sure WHY ??????
            dx <<= 1;
            dy <<= 1;

            //Check if point is inside of the raster and plot first pixel
            DistanceCount++;
            if (dx > dy)
            {
                int fraction = dy - (dx >> 1);
                while (x0 != x1)
                {
                    x0 += stepX;
                    if (fraction >= 0)
                    {
                        y0 += stepY;
                        fraction -= dx;

                    }
                    fraction += dy;
                    DistanceCount++;
                }

            }
            else
            {
                int fraction = dx - (dy >> 1);
                while (y0 != y1)
                {
                    if (fraction >= 0)
                    {
                        x0 += stepX;
                        fraction -= dy;
                    }
                    fraction += dx;
                    y0 += stepY;
                    DistanceCount++;
                }

            }
            return DistanceCount;

        }

        public static double CalculateCurrantAngle(int x0, int y0, int x1, int y1)
        {

            double differenceX = (x1 - x0);
            double differenceY = (y1 - y0); 
            if(differenceX < 0)
            {
                differenceX = differenceX  * -1;
            }
            if(differenceY < 0)
            {
                differenceY = differenceY *-1;
            }
            //Console.WriteLine(differenceX);
            //Console.WriteLine(differenceY);
            //if(x0>x1 && y0>y1)
            //{
            //int differenceX = x0 - x1;
            //int differenceY = y0 - y1;

            //}else if(x0<x1 && y0 > y1)
            //{
            //
            //}
            if (differenceX == 0)
            {
                if (y0 > y1) return 90;
                return 270;

            }
            else
            {
                double angle = Math.Round((Math.Atan(differenceY / differenceX) * 180) / Math.PI,2, MidpointRounding.AwayFromZero);
                if (x0 > x1 && y0 >= y1)
                {
                    return angle%360;
                }
                else if (x0 < x1 && y0 >= y1)
                {
                    return (180 - angle)%360;
                }else if (x0<x1 && y0 <= y1)
                {
                    return (180 + angle)%360;
                }
                else
                {
                    return (360 - angle)%360;
                }

            }
        }

        public static int[] GetAngledPoint(int xCenter, int Ycenter, int angle, int length)
        {
            int x2Coordinate;
            int y2Coordinate;

            double yShift = Math.Round(Math.Sin(DegreesToRadians(angle)) * length, MidpointRounding.AwayFromZero);
            double xShift = Math.Round(Math.Cos(DegreesToRadians(angle)) * length, MidpointRounding.AwayFromZero);

            y2Coordinate = (int)(Ycenter - yShift);
            x2Coordinate = (int)(xCenter - xShift);

            return new int[] { x2Coordinate, y2Coordinate };
        }
    }
}

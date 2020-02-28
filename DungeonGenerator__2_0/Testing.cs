using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    public class Testing
    {
        public void AproximationsTest()
        {
            Console.WriteLine(" -----------AproximationsTests----------- ");
            int[][] testedValues =
            {
                new int[] {100,100,1,100},
                new int[] {100,100,1,75},
                new int[] {100,100,1,50},
                new int[] {100,100,1,25},
                new int[] {100,100,1,1},
                new int[] {100,100,25,1},
                new int[] {100,100,50,1},
                new int[] {100,100,75,1},
                new int[] {100,100,100,1},
                new int[] {100,100,125,1},
                new int[] {100,100,150,1},
                new int[] {100,100,175,1},
                new int[] {100,100,200,1},
                new int[] {100,100,200,25},
                new int[] {100,100,200,50},
                new int[] {100,100,200,75},
                new int[] {100,100,200,100},
                new int[] {100,100,200,125},
                new int[] {100,100,200,150},
                new int[] {100,100,200,175},
                new int[] {100,100,200,200},
                new int[] {100,100,175,200},
                new int[] {100,100,150,200},
                new int[] {100,100,125,200},
                new int[] {100,100,100,200},
                new int[] {100,100,75,200},
                new int[] {100,100,50,200},
                new int[] {100,100,25,200},
                new int[] {100,100,1,200},
                new int[] {100,100,1,175},
                new int[] {100,100,1,150},
                new int[] {100,100,1,125},
            };

            for (int i = 0; i < testedValues.Length; i++)
            {
                int x0 = testedValues[i][0];
                int y0 = testedValues[i][1];
                int x1 = testedValues[i][2];
                int y1 = testedValues[i][3];
                Console.WriteLine("Tested points : x0:{0} , y0{1}, x1{2}, y1{3} ---- relativeDistance :  {4},   AbsolutDistance ---- {5}",
                    x0, y0, x1, y1,
                    DungeonGenerator.Drawing.CalculateAproxPointDistance(x0, y0, x1, y1),
                    DungeonGenerator.Drawing.CalculateAbsolutePointDistance(x0, y0, x1, y1));
            }

        }
        public void AngleTest()
        {
            Console.WriteLine(" -----------AngleCalculationTest----------- ");
            int[][] testedValues =
            {
                new int[] {100,100,1,100},
                new int[] {100,100,1,75},
                new int[] {100,100,1,50},
                new int[] {100,100,1,25},
                new int[] {100,100,1,1},
                new int[] {100,100,25,1},
                new int[] {100,100,50,1},
                new int[] {100,100,75,1},
                new int[] {100,100,100,1},
                new int[] {100,100,125,1},
                new int[] {100,100,150,1},
                new int[] {100,100,175,1},
                new int[] {100,100,200,1},
                new int[] {100,100,200,25},
                new int[] {100,100,200,50},
                new int[] {100,100,200,75},
                new int[] {100,100,200,100},
                new int[] {100,100,200,125},
                new int[] {100,100,200,150},
                new int[] {100,100,200,175},
                new int[] {100,100,200,200},
                new int[] {100,100,175,200},
                new int[] {100,100,150,200},
                new int[] {100,100,125,200},
                new int[] {100,100,100,200},
                new int[] {100,100,75,200},
                new int[] {100,100,50,200},
                new int[] {100,100,25,200},
                new int[] {100,100,1,200},
                new int[] {100,100,1,175},
                new int[] {100,100,1,150},
                new int[] {100,100,1,125},
            };

            for (int i = 0; i < testedValues.Length; i++)
            {
                int x0 = testedValues[i][0];
                int y0 = testedValues[i][1];
                int x1 = testedValues[i][2];
                int y1 = testedValues[i][3];
                Console.WriteLine("Tested points : x0: {0} , y0: {1}, x1: {2}, y1: {3} ---- Angle :  {4}",
                    x0, y0, x1, y1,
                    DungeonGenerator.Drawing.CalculateCurrantAngle(x0, y0, x1, y1));
            }

        }
        public void DrawTest(MapGrid grid, int ID)
        {
            Console.WriteLine(" -----------DrawingTest----------- ");
            int[][] testedValues =
            {
                new int[] {100,100,1,100},
                new int[] {100,100,1,75},
                new int[] {100,100,1,50},
                new int[] {100,100,1,25},
                new int[] {100,100,1,1},
                new int[] {100,100,25,1},
                new int[] {100,100,50,1},
                new int[] {100,100,75,1},
                new int[] {100,100,100,1},
                new int[] {100,100,125,1},
                new int[] {100,100,150,1},
                new int[] {100,100,175,1},
                new int[] {100,100,200,1},
                new int[] {100,100,200,25},
                new int[] {100,100,200,50},
                new int[] {100,100,200,75},
                new int[] {100,100,200,100},
                new int[] {100,100,200,125},
                new int[] {100,100,200,150},
                new int[] {100,100,200,175},
                new int[] {100,100,200,200},
                new int[] {100,100,175,200},
                new int[] {100,100,150,200},
                new int[] {100,100,125,200},
                new int[] {100,100,100,200},
                new int[] {100,100,75,200},
                new int[] {100,100,50,200},
                new int[] {100,100,25,200},
                new int[] {100,100,1,200},
                new int[] {100,100,1,175},
                new int[] {100,100,1,150},
                new int[] {100,100,1,125},
            };

            for (int i = 0; i < testedValues.Length; i++)
            {
                int x0 = testedValues[i][0];
                int y0 = testedValues[i][1];
                int x1 = testedValues[i][2];
                int y1 = testedValues[i][3];
                Console.WriteLine("Tested points : x0: {0} , y0: {1}, x1: {2}, y1: {3} ",
                    x0, y0, x1, y1);
                Drawing.DrawLine(x0, y0, x1, y1, grid, ID);
            }

        }
    }
}

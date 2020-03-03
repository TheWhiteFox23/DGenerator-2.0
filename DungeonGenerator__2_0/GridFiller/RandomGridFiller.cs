using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    public class RandomGridFiller : GridFiller
    {
        Random random;
        public RandomGridFiller(Random random)
        {
            this.random = random;

        }        
        public RandomGridFiller(int seed)
        {
            this.random = new Random(seed);

        }
        public void FillGrid(Raster Grid, GridObjectTemplate objectTemplate, int NumberOfObject)
        {
            int RemainCount = NumberOfObject;
            //Random random = Grid.getRandom();
            int Width = Grid.GetWidth();
            int Height = Grid.GetHeight();
            GridObject objectToPLace = objectTemplate.GenerateGridObject();
            while(RemainCount != 0)
            {
                int Xcoordinate = random.Next(1, Width);
                int Ycoordinate = random.Next(1, Height);
                if(objectToPLace.CanBePlaced(Grid, Xcoordinate, Ycoordinate))
                {
                    objectToPLace.Draw(Grid, Xcoordinate, Ycoordinate);
                    objectToPLace = objectTemplate.GenerateGridObject(random);
                    RemainCount--;
                }
            }
        }
    }
}

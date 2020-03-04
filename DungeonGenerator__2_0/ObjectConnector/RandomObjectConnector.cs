using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DungeonGenerator
{
    public class CloseObjectConnector : ObjectConnector
    {
        public void Connect(Raster Grid)
        {
            //Object added test
            foreach(var r in Grid.getGridObjectList())
            {
                Console.WriteLine(r.getID());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    class SquareRoomTemplate : GridObjectTemplate
    {
        int SideLengthMin;
        int SideLengthMax;
        Random random = new Random();
        //Angele Related properties
        bool RandomAngle = false;
        int MinAngle = 0;
        int MaxAngle = 0;
        int Angle = 0;
        bool FixedAngle = false;
        bool Infill = false;
        bool FixedBorderSize = false;
        int BorderSize = 1;
        int MinBorderSize = 0;
        int MaxBorderSize = 1;
        bool RandomBorderSize = false;




        //Privisory random
        //Random random = new Random();
        public SquareRoomTemplate(int SideLengthMin, int SideLengthMax)
        {
            this.SideLengthMax = SideLengthMax;
            this.SideLengthMax = SideLengthMin;
        }
        public GridObject GenerateGridObject(int ID, Random random)
        {
            //create GridObject instance
            GridObject squareRoom = new SquareRoom(ID, random.Next(SideLengthMin, SideLengthMax));

            //setingObject
            SetGridObject(random, squareRoom);
            return squareRoom;
        }

        private void SetGridObject(Random random, GridObject squareRoom)
        {
            //set Angle
            if (RandomAngle)
            {
                squareRoom.setAngle(random.Next(MinAngle, MaxAngle));
            }else if (FixedAngle)
            {
                squareRoom.setAngle(Angle);
            }
            squareRoom.setInfill(Infill);
            if (FixedBorderSize)
            {
                squareRoom.setBorderSize(BorderSize);
            }else if (RandomBorderSize)
            {
                squareRoom.setBorderSize(random.Next(MinBorderSize, MaxBorderSize));
            }
        }

        public GridObject GenerateGridObject(int ID)
        {
            GridObject squareRoom = new SquareRoom(ID, random.Next(SideLengthMin, SideLengthMax));
            SetGridObject(random, squareRoom);
            return squareRoom;
        }
        public void setRandomAngle(int MinAngle, int MaxAngle)
        {
            this.MinAngle = MinAngle;
            this.MaxAngle = MaxAngle;
            RandomAngle = true;
            FixedAngle = false;
        }
        public void setFixedAngle(int Angle)
        {
            this.Angle = Angle;
            FixedAngle = true;
            RandomAngle = false;
        }
        public void ResetAngle()
        {
            Angle = 0;
            FixedAngle = false;
            MinAngle = 0;
            MaxAngle = 0;
            RandomAngle = false;
        }
        public void setInfill(bool Infill)
        {
            this.Infill = Infill;
        }
        public void setFixedBorderSize(int BorderSize)
        {
            this.FixedBorderSize = true;
            this.BorderSize = BorderSize;
            this.RandomBorderSize = false;
        }

        public void setRandomBorderSize(int MinBorderSize, int MaxBorderSize)
        {
            this.MinBorderSize = MinBorderSize;
            this.MaxBorderSize = MaxBorderSize;
            RandomBorderSize = true;
            FixedBorderSize = false;
        }

        public void ResetBorderSize()
        {
            BorderSize = 0;
            FixedBorderSize = false;
            MinBorderSize = 0;
            MaxBorderSize = 0;
            RandomBorderSize = false;
        }



    }
}

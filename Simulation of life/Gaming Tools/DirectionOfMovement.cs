using System;

namespace Simulation_of_life.Gaming_Tools
{
    public static class DirectionOfMovement
    {

        private static readonly int SizeCell = World.SizeCell;
        private static readonly Tuple<int, int, string>[] SidesOfDirection8 =
        {
            new (SizeCell, 0, "Right"),
            new (-SizeCell, 0, "Left"),
            new (0, SizeCell, "Down"),
            new (0, -SizeCell, "Up"),


            new (SizeCell, SizeCell, "Right Down Diagonally"),
            new (-SizeCell, -SizeCell, "Left Up Diagonally"),
            new (-SizeCell, SizeCell, "Left Down Diagonally"),
            new (SizeCell, -SizeCell, "Right Up Diagonally")
        };

        private static readonly Tuple<int, int, string>[] SidesOfDirection4 =
        {
            new (SizeCell, 0, "Right"),
            new (-SizeCell, 0, "Left"),
            new (0, SizeCell, "Down"),
            new (0, -SizeCell, "Up")
        };
        
        public static Tuple<int, int, string>[] GetSidesOfDirection_8()
        {
            return SidesOfDirection8;
        }

        public static Tuple<int, int, string>[] GetSidesOfDirection_4()
        {
            return SidesOfDirection4;
        }
        
    }
}
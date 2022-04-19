using System;

namespace Simulation_of_life
{
    public abstract class Movement
    {
        protected virtual void MoveTowardsGoal(ref int x, ref int y, int goalX, int goalY, bool isBoost,
            Tuple<int, int, string>[] listOfDestinations)
        {
            var motionVector = DetermineDirection(x, y, goalX, goalY, listOfDestinations);

            TakeStep(ref x, motionVector.Item1, isBoost, goalX - x);
            TakeStep(ref y, motionVector.Item2, isBoost, goalX - y);
        }

        protected void TakeStep(ref int coordinate, int step, bool isBoost, int d)
        {
            if (CheckNextPosition(coordinate + step))
            {
                coordinate += step;
            }
        }

        protected virtual Tuple<int, int, string> DetermineDirection(int currentX, int currentY, int goalX, int goalY,
            Tuple<int, int, string>[] nextPosition)
        {
            var min = Int32.MaxValue;
            var hmin = 0;
            var indexTuple = 0;
            var correctIndexTuple = 0;

            foreach (var position in nextPosition)
            {
                hmin = Math.Abs(currentX + position.Item1 - goalX) + Math.Abs(currentY + position.Item2 - goalY);

                if (min > hmin)
                {
                    min = hmin;
                    correctIndexTuple = indexTuple;
                }

                indexTuple++;
            }

            return nextPosition[correctIndexTuple];
        }

        private bool CheckNextPosition(int nextCoordinate)
        {
            if (nextCoordinate < 0 || nextCoordinate > World._sizeOfWorld)
            {
                return false;
            }

            return true;
        }
    }
}
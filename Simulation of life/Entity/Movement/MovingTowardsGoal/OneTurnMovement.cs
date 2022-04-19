using System;
using Simulation_of_life.Gaming_Tools;

namespace Simulation_of_life
{
    class OneTurnMovement: Movement
    {
        private bool _directionFlag = true;
        
        public void MoveTowardsGoal(ref int x, ref int y, int goalX, int goalY, bool isBoost)
        {
            MoveTowardsGoal(ref x, ref y,  goalX, goalY, isBoost,DirectionOfMovement.GetSidesOfDirection_4()); 
        }

        protected override void MoveTowardsGoal(ref int x, ref int y, int goalX, int goalY, bool isBoost, Tuple<int, int, string>[] listOfDestinations)
        {
            var dx = goalX - x;
            var dy = goalY - y;
            
            if (dx != 0)
            {
                _directionFlag = true;
                var step = DetermineDirection(x, y, goalX, goalY, listOfDestinations).Item1;
                
                TakeStep(ref x,  step, isBoost, dx);
            }
            
            else if (dy != 0)
            {
                _directionFlag = false;
                var step = DetermineDirection(x, y, goalX, goalY, listOfDestinations).Item2;
                
                TakeStep(ref y,  step, isBoost, dy);
            }
            else
            {
                return;
            }
        }

        protected override Tuple<int, int, string> DetermineDirection(int x, int y, int goalX, int goalY, Tuple<int, int, string>[] nextPosition)
        {
            var dx = goalX - x;
            var dy = goalY - y;
            
            if (_directionFlag)
            {
                if (dx > 0)
                {
                    return nextPosition[0];
                }
                else
                {
                    return nextPosition[1];
                }
            }
            else
            {
                if (dy > 0)
                {
                    return nextPosition[2];
                }
                else
                {
                    return nextPosition[3];
                }
            }
        }
    }
}
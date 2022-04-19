using Simulation_of_life.Gaming_Tools;

namespace Simulation_of_life
{
    class OrthogonalMovement : Movement
    {
        public void MoveTowardsGoal(ref int x, ref int y, int goalX, int goalY, bool isBoost)
        {
            MoveTowardsGoal(ref x, ref y,  goalX, goalY, isBoost,  DirectionOfMovement.GetSidesOfDirection_4());
        }
    }
}

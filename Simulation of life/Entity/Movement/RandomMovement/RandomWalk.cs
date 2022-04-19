namespace Simulation_of_life
{
    public abstract class RandomWalk
    {
        protected int TargetX;
        protected int TargetY;
        protected int typeOfMovement;

        public abstract void StartMoving(ref int x, ref int y, int baseX, int baseY, int typeOfMovement, bool isBoost);
        protected abstract void GetFinalCoordinate();
        
        protected virtual void DetermineTypeOfToTheTarget(ref int x, ref int y, bool isBoost)
        {
            switch (typeOfMovement)
            {
                case 0:
                {
                    OneTurnMovement movement = new OneTurnMovement();
                    movement.MoveTowardsGoal(ref x, ref y, TargetX, TargetY, isBoost);
                    break;
                }
                case 1:
                {
                    OrthogonalMovement movement = new OrthogonalMovement();
                    movement.MoveTowardsGoal(ref x, ref y, TargetX, TargetY, isBoost);
                    break;
                }
                case 2:
                {
                    FullMovement movement = new FullMovement();
                    movement.MoveTowardsGoal(ref x, ref y, TargetX, TargetY, isBoost);
                    break;
                }
            }
        }
        
        protected bool CheckNextPosition(int nextCoordinate)
        {
            if (nextCoordinate < 0 || nextCoordinate > World._sizeOfWorld)
            {
                return true;
            }

            return false;
        }
    }
}
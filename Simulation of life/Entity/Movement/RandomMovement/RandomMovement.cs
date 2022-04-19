using System.Diagnostics;
using Simulation_of_life.Gaming_Tools;

namespace Simulation_of_life
{
    public class RandomMovement : RandomWalk
    {
        private readonly int _radius = SimulationEngine.Rnd.Next(0, 6);

        private int _targetX;
        private int _targetY;
        public override void StartMoving(ref int x, ref int y, int baseX, int baseY, int typeOfMovement, bool isBoost)
        {
            base.typeOfMovement = typeOfMovement;
            
            GetFinalCoordinate();
            DetermineTypeOfToTheTarget(ref x, ref y, isBoost);
        }

        protected override void GetFinalCoordinate()
        {
            var side =  DirectionOfMovement.GetSidesOfDirection_4()[SimulationEngine.Rnd.Next(DirectionOfMovement.GetSidesOfDirection_4().Length)];
          
            _targetX += side.Item1;
            _targetY += side.Item2;
        }
        
        protected override void DetermineTypeOfToTheTarget(ref int x, ref int y, bool isBoost)
        {
           
            x += _targetX;
            y += _targetY;
        }
    }
}
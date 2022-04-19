using System.Security.Cryptography.X509Certificates;
using Simulation_of_life.Gaming_Tools;

namespace Simulation_of_life
{
    public class  RandomMovementWithinRadius : RandomWalk
    {
        private readonly int _radius = SimulationEngine.Rnd.Next(0, 6);

        private int _baseX;
        private int _baseY;
        
        public override void StartMoving(ref int x, ref int y, int baseX, int baseY, int typeOfMovement, bool isBoost)
        {
            this._baseX = baseX;
            this._baseY = baseY;
            
            base.typeOfMovement = typeOfMovement;
            
            GetFinalCoordinate();
            DetermineTypeOfToTheTarget(ref x, ref y, isBoost);
        }

        protected override void GetFinalCoordinate()
        {
            TargetY = _baseY + _radius * World.SizeCell * GenerateSign();
            TargetX = _baseX + _radius * World.SizeCell * GenerateSign();
            
        }

        private int GenerateSign()
        {
            var rndNumbers = SimulationEngine.Rnd.Next(1, 100);

            if (rndNumbers % 2 == 0)
            {
                return 1;
            }

            else
            {
                return -1;
            }
        }

    }
}
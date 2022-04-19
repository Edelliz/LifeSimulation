using Simulation_of_life.Gaming_Tools;

namespace Simulation_of_life
{
    public class RandomMovementWithPriority
    {
       // private int _targetX;
       // private int _targetY;
       // private string _direction;
       // private readonly int _radius = SimulationEngine._rnd.Next(0, 5);
       // private int typeOfMovement;
       // 
       // public void StartMoving(ref int x, ref int y, int baseX, int baseY, int typeOfMovement)
       // {
       //     this.typeOfMovement = typeOfMovement;
       //     DetermineDirectionVector();
       //     GetFinalCoordinate(x,  y);
       //     DetermineTypeOfMovementToTheGoal(ref x, ref y);
       // }
       //
       // private void DetermineDirectionVector()
       // {
       //     if (typeOfMovement != 2)
       //     {
       //         var randomDirection = SimulationEngine._rnd.Next(170, 1001);
       //         
       //         for (int i = 0; i < DirectionOfMovement.GetPrioritySidesOfDirection_4().Length; i++)
       //         {
       //             if (i == 0)
       //             {
       //                 if (randomDirection >= 170 &&
       //                     randomDirection < DirectionOfMovement.GetPrioritySidesOfDirection_4()[i].Item1)
       //                 {
       //                     _direction = DirectionOfMovement.GetPrioritySidesOfDirection_4()[i].Item2;
       //                 } 
       //             }
       //             else if (randomDirection < DirectionOfMovement.GetPrioritySidesOfDirection_4()[i].Item1 &&
       //                 randomDirection >= DirectionOfMovement.GetPrioritySidesOfDirection_4()[i - 1].Item1)
       //             {
       //                 _direction = DirectionOfMovement.GetPrioritySidesOfDirection_4()[i].Item2;
       //             }
       //         }
       //     }
       //     
       //     else
       //     {
       //         var randomDirection = SimulationEngine._rnd.Next(100, 1001);
       //         
       //         for (int i = 0; i < DirectionOfMovement.GetPrioritySidesOfDirection_8().Length; i++)
       //         {
       //             if (i == 0)
       //             {
       //                 if (randomDirection >= 100 &&
       //                     randomDirection < DirectionOfMovement.GetPrioritySidesOfDirection_8()[i].Item1)
       //                 {
       //                     _direction = DirectionOfMovement.GetPrioritySidesOfDirection_8()[i].Item2;
       //                 } 
       //             }
       //             else if (randomDirection < DirectionOfMovement.GetPrioritySidesOfDirection_8()[i].Item1 &&
       //                      randomDirection >= DirectionOfMovement.GetPrioritySidesOfDirection_8()[i - 1].Item1)
       //             {
       //                 _direction = DirectionOfMovement.GetPrioritySidesOfDirection_8()[i].Item2;
       //             }
       //         }
       //     }
       // }
       //
       // private void GetFinalCoordinate(int x, int y)
       // {
       //     var coef = 1;
       //     
       //     GenerateSign("x", ref coef);
       //     _targetX = x + _radius * coef;
       //     
       //     GenerateSign("y", ref coef);
       //     _targetY = y + _radius * coef;
       //     
       //     while (CheckNextPosition(_targetX))
       //     {
       //         GenerateSign("x", ref coef);
       //         _targetX = x + _radius * World.GetSizeCell() * coef;
       //     }
       //     
       //     while (CheckNextPosition(_targetY))
       //     {
       //         GenerateSign("y", ref coef);
       //         _targetY = y + _radius * World.GetSizeCell() * coef;
       //     }
       // }
       // 
       // private void GenerateSign(string nameOfCoordinate, ref int coef)
       // {
       //     if (typeOfMovement != 2)
       //     {
       //         foreach (var d in DirectionOfMovement.GetSidesOfDirection_4())
       //         {
       //             if (d.Item3 == _direction)
       //             {
       //                 if (nameOfCoordinate == "x")
       //                 {
       //                     coef = d.Item1;
       //                 }
       //                 else
       //                 {
       //                     coef = d.Item2;
       //                 }
       //             }
       //         }
       //     }
       //     
       //     else
       //     {
       //         foreach (var d in DirectionOfMovement.GetSidesOfDirection_8())
       //         {
       //             if (d.Item3 == _direction)
       //             {
       //                 if (nameOfCoordinate == "x")
       //                 {
       //                     coef = d.Item1;
       //                 }
       //                 else
       //                 {
       //                     coef = d.Item2;
       //                 }
       //             }
       //             else
       //             {
       //                 continue;
       //             }
       //         }
       //     }
       // }
       //
       // private bool CheckNextPosition(int nextCoordinate)
       // {
       //     if (nextCoordinate < 0 || nextCoordinate > World.GetSize())
       //     {
       //         return true;
       //     }
       //
       //     return false;
       // }
       // private void DetermineTypeOfMovementToTheGoal(ref int x, ref int y)
       // {
       //     switch (typeOfMovement)
       //     {
       //         case 0:
       //         {
       //             OneTurnMovement movement = new OneTurnMovement();
       //             movement.MoveTowardsGoal(ref x, ref y, _targetX, _targetY);
       //             break;
       //         }
       //         case 1:
       //         {
       //             OrthogonalMovement movement = new OrthogonalMovement();
       //             movement.MoveTowardsGoal(ref x, ref y, _targetX, _targetY);
       //             break;
       //         }
       //         case 2:
       //         {
       //             FullMovement movement = new FullMovement();
       //             movement.MoveTowardsGoal(ref x, ref y, _targetX, _targetY);
       //             break;
       //         }
       //     }
       // }
    }
}
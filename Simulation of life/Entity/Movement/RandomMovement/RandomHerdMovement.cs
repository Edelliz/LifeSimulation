using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulation_of_life
{
    public class RandomHerdMovement : RandomWalk
    {
        private const int MinHerdSize = 3;
        private readonly int _fieldOfView = World.SizeCell * 10;
        private int _counterOfAnimals = 0;
        
        private readonly List<Tuple<int, int>> _coordinatesOfNearestAnimals = new ();
        private Animal _animal;
        
        public override void StartMoving(ref int x, ref int y, int baseX, int baseY, int typeOfMovement, bool isBoost)
        {
            base.typeOfMovement = typeOfMovement;
            
            FindClusterOfAnimal(World.SizeCell, x, y);

             if (_counterOfAnimals == MinHerdSize)
             {
                 GetFinalCoordinate();
                 DetermineTypeOfToTheTarget(ref x, ref y, isBoost);

                 _counterOfAnimals = 0;
             }
             else
             {
                 RandomMovementWithinRadius movement = new RandomMovementWithinRadius();
                 movement.StartMoving(ref x, ref y, x, y, typeOfMovement, isBoost);
             }
        }

        private void FindClusterOfAnimal(int searchWidth, int X, int Y)
        {
            if (searchWidth >= _fieldOfView)
            {
                return;
            }

            for (int x = X - searchWidth; x <= X + searchWidth; x += World.SizeCell)
            {
                if (CheckCoordinatesOfNearestAnimal(x, Y - searchWidth))
                {
                    IdentifyAnimal(x, Y - searchWidth);
                    _coordinatesOfNearestAnimals.Add(new Tuple<int, int>(_animal.X, _animal.Y));
                    _counterOfAnimals++;
                    
                    return;
                }

                if (CheckCoordinatesOfNearestAnimal(x, Y + searchWidth))
                {
                    IdentifyAnimal(x, Y + searchWidth);
                    _coordinatesOfNearestAnimals.Add(new Tuple<int, int>(_animal.X, _animal.Y));
                    _counterOfAnimals++;
                    
                    return;
                }
            }

            for (int y = Y - searchWidth + World.SizeCell; y < Y + searchWidth; y += World.SizeCell)
            {
                if (CheckCoordinatesOfNearestAnimal(X - searchWidth, y))
                {
                    IdentifyAnimal(X - searchWidth, y);
                    _coordinatesOfNearestAnimals.Add(new Tuple<int, int>(_animal.X, _animal.Y));
                    _counterOfAnimals++;
                    
                    return;
                }

                if (CheckCoordinatesOfNearestAnimal(X + searchWidth, y))
                {
                    IdentifyAnimal(X + searchWidth, y);
                    _coordinatesOfNearestAnimals.Add(new Tuple<int, int>(_animal.X, _animal.Y));
                    _counterOfAnimals++;
                    
                    return;
                }
            }

            FindClusterOfAnimal(searchWidth + World.SizeCell, X, Y);
        }

        private bool CheckCoordinatesOfNearestAnimal(int x, int y)
        {
            var listOfAllAnimal = World.ListOfCarnivorousAnimals
                .Concat<Animal>(World.ListOfOmnivorousAnimals)
                .Concat(World.ListOfHerbivorousAnimals).ToList();
            
            foreach (var t in listOfAllAnimal)
            {
                if (t.X == x && t.Y == y)
                {
                    return true;
                }
            }

            return false;
        }
        
        private void IdentifyAnimal(int x, int y)
        {
            var listOfAllAnimal = World.ListOfCarnivorousAnimals
                .Concat<Animal>(World.ListOfOmnivorousAnimals)
                .Concat(World.ListOfHerbivorousAnimals).ToList();
            
            foreach (var t in listOfAllAnimal)
            {
                if (t.X == x && t.Y == y)
                {
                    _animal = t;
                    return;
                }
            }
        }

        protected override void GetFinalCoordinate()
        {
            var sumX = 0;
            var sumY = 0;
            
            for (int i = 0; i < MinHerdSize; i++)
            {
                sumX += _coordinatesOfNearestAnimals[i].Item1;
                sumY += _coordinatesOfNearestAnimals[i].Item2;
            }

            sumX /= MinHerdSize;
            sumY /= MinHerdSize;

            TargetX = sumX;
            TargetY = sumY;
        }
    }
}
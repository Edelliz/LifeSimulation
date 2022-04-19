using System;
using System.Collections.Generic;
using System.Linq;


namespace Simulation_of_life
{
    public class Animal : Entity
    {
        private static int _satiety = 100;
        private int _satietyTreshold = 80;
        private int _indexOfPlants = 0;
        
        private static Tuple<int, int, string>[] _nextPositionOfAnimal =
        {
            new Tuple<int, int, string>(World.GetSizeCell(), 0, "Right"),
            new Tuple<int, int, string>(-World.GetSizeCell(), 0, "Left"),
            new Tuple<int, int, string>(0, World.GetSizeCell(), "Down"),
            new Tuple<int, int, string>(0, -World.GetSizeCell(), "Up"),
            
            
            new Tuple<int, int, string>(World.GetSizeCell(), World.GetSizeCell(), "Right Down Diagonally"),
            new Tuple<int, int, string>(-World.GetSizeCell(), -World.GetSizeCell(), "Left Up Diagonally"),
            new Tuple<int, int, string>(-World.GetSizeCell(), World.GetSizeCell(), "Left Down Diagonally"),
            new Tuple<int, int, string>(World.GetSizeCell(), -World.GetSizeCell(), "Right Up Diagonally"),

        };
        
        public Animal(int x, int y) : base(x, y)
        {
        }
        
        private void RandomMove()
        {
            _satiety -= 1;
            var side = _nextPositionOfAnimal[SimulationEngine._rnd.Next(0, _nextPositionOfAnimal.Length - 5)];
            
            X += side.Item1;
            Y += side.Item2;
        }

        private void SearchFood()
        {
            double minDistanceToPlant = Double.MaxValue;
            var minDistance = new List<double>();

            foreach (var t in World.ListOfPlants)
            {
                if (t.NutritionalValue != 0)
                {
                    minDistance.Add(Math.Sqrt(Math.Pow(t.X - X, 2) + Math.Pow(t.Y - Y, 2)));
                }
                else
                {
                    minDistance.Add(-1);
                }
            }

            if (minDistance.Count == 0)
            {
                RandomMove();
            }
            
            foreach (var d in minDistance)
            {
                if (d != -1 && d < minDistanceToPlant)
                {
                    minDistanceToPlant = d;
                }
            }
            
            for (var i = 0; i < minDistance.Count; i++)
            {
                if (minDistanceToPlant == minDistance[i] && minDistance[i] != -1)
                {
                    _indexOfPlants = i;
                    CheckIndex();

                    break;
                }
            }
        }
        
        private void ChooseTheDirectionOfMovement(int dx, int dy)
        {
            if (dx > 0 && dy > 0)
            {
                MoveToFood(_nextPositionOfAnimal[7].Item3);
            }

            else if (dx < 0 && dy < 0)
            {
                MoveToFood(_nextPositionOfAnimal[6].Item3);
            }

            else if (dx < 0 && dy > 0)
            {
                MoveToFood(_nextPositionOfAnimal[5].Item3);
            }

            else if (dx > 0 && dy < 0)
            {
                MoveToFood(_nextPositionOfAnimal[4].Item3);
            }

            else if (dx == 0 && dy < 0)
            {
                MoveToFood(_nextPositionOfAnimal[3].Item3);
            }

            else if (dx == 0 && dy > 0)
            {
                MoveToFood(_nextPositionOfAnimal[2].Item3);
            }

            else if (dx < 0 && dy == 0)
            {
                MoveToFood(_nextPositionOfAnimal[1].Item3);
            }

            else if (dx > 0 && dy == 0)
            {
                MoveToFood(_nextPositionOfAnimal[0].Item3);
            }
        }

        private void MoveToFood(string motionVector)
        {
            foreach (var position in _nextPositionOfAnimal)
            {
                if (motionVector == position.Item3)
                {
                    if (CheckNextPosition(X + position.Item1, Y + position.Item2))
                    {
                        Step(position.Item1, ref X);
                        Step(position.Item2, ref Y);
                    }
                }
            }
        }
        
        private void Step(int sizeStep, ref int coordinate)
        {
            CheckSatietyValue();
            _satiety -= 1;
            coordinate += sizeStep;
        }

        private bool CheckNextPosition(int nextX, int nextY)
        {
            if (nextX < 0 || nextX > World.GetSize() || nextY < 0 || nextY > World.GetSize())
            {
                return false;
            }

            foreach (var t in World.ListOfAnimals)
            {
                if (t.X == nextX && t.Y == nextY)
                {
                    return false;
                }
            }

            foreach (var t1 in World.ListOfPlants)
            {
                if (typeof(Tree) == t1.GetType() && t1.X == nextX && t1.Y == nextY)
                {
                    return false;
                }
            }

            return true;
        }

        private void Eat(Plant food)
        {
            _satiety += food.NutritionalValue;
            Hp += food.NutritionalValue;

            food.Die(food);
        }

        private void CheckSatietyValue()
        {
            if (_satiety <= Hp*0.5)
            {
                Hp--;
                IsLives();
            }
        }

        private void IsLives()
        {
            if (Hp <= 0 || _satiety == 0)
            {
                Die();
            }
        }

        public override void Die()
        {
            World.ListOfAnimals.Remove(this);
        }

        public override void Move()
        {
            if (_satiety >= _satietyTreshold)
            {
                RandomMove();
            }

            else if (_satiety < _satietyTreshold)
            {
                SearchFood();
                CheckIndex();
                ChooseTheDirectionOfMovement(World.ListOfPlants[_indexOfPlants].X - X, World.ListOfPlants[_indexOfPlants].Y - Y);

                if (X == World.ListOfPlants[_indexOfPlants].X && Y == World.ListOfPlants[_indexOfPlants].Y)
                {
                    Eat(World.ListOfPlants[_indexOfPlants]);
                }
            }
        }

        private void CheckIndex()
        {
            if (_indexOfPlants >= World.ListOfPlants.Count)
            {
                SearchFood();
            }
        }

        public override void Reproduce()
        {
           return;
        }
    }
}
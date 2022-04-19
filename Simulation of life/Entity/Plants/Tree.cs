using System;
using System.Drawing;
using System.Linq;

namespace Simulation_of_life
{
    public class Tree : Plant
    {
        private static Random Rnd = new Random();
        private bool _harmfulness = false;
        private int _numberOfSeed = Rnd.Next(0, 4);
        private int _countOfSeed = 0;
        
        public Tree(int x, int y, string typeOfPlants, bool isToxic, Color currentColor) : base(x, y, typeOfPlants,
            isToxic)
        {
            TypeOfPlant = typeOfPlants;

            ColorOfSeed = Color.Bisque;
            ColorOfSprout = Color.Goldenrod;
            ColorOfMature = Color.Brown;
            ColorOfDying = Color.SaddleBrown;

            AgeOfSeed = 200;
            AgeOfSprout = 500;
            AgeOfMature = 1000;
            AgeOfDying = 1200;
            NutritionalValue = 0;
        }

        protected override void BecomeSeed()
        {
            TypeOfPlant = "Seed";
            CurrentColor = ColorOfSeed;
        }

        protected override void BecomeSprout()
        {
            TypeOfPlant = "Sprout";
            CurrentColor = ColorOfSprout;
        }

        protected override void BecomeMature()
        {
            TypeOfPlant = "AdultPlants";
            CurrentColor = ColorOfMature;

            if (_countOfSeed <= _numberOfSeed && World.ListOfPlants.Count < ReproduceTreshold)
            {
                ReproduceSeed();
            }
        }

        protected override void ReproduceSeed()
        {
            _countOfSeed++;
            int radiusOfTheSpreadByX = Rnd.Next(2, 25);
            int radiusOfTheSpreadByY = Rnd.Next(2, 25);
            foreach (var position in SeedPosition)
            {
                if (CheckPosition(X + position.Item1 * radiusOfTheSpreadByX, Y + position.Item2 * radiusOfTheSpreadByY))
                {
                    World.ListOfPlants.Add(new Tree(X + position.Item1 * radiusOfTheSpreadByX, Y + position.Item2 * radiusOfTheSpreadByY, "Seed", IsToxic,
                        ColorOfSeed));
                    break;
                }
            }
        }
        protected override void BecomeDying()
        {
            TypeOfPlant = "DyingPlants";
            CurrentColor = ColorOfDying;
        }
        
        public override void Die()
        {
            World.ListOfPlants.Remove(this);
        }
        
        public override void Reproduce()
        {
            return;
        }
    }
}
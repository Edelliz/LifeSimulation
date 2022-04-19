using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Simulation_of_life
{
    public class PlantsWithoutBerries : Plant
    {
        private static readonly Random Rnd = new Random();
        private readonly Color colorOfSeed = Color.Moccasin;
        private int numberOfSeed = Rnd.Next(0, 12);
        private int countOfSeed = 0;

        public PlantsWithoutBerries(int x, int y, string typeOfPlants, bool isToxic, Color currentColor) : base(x, y,
            typeOfPlants, isToxic)
        {
            if (isToxic)
            {
                colorOfSeed = Color.Silver;
                ColorOfSprout = Color.Beige;
                ColorOfMature = Color.LightSlateGray;
                ColorOfDying = Color.Ivory;
            }
            else
            {
                colorOfSeed = Color.Silver;
                ColorOfSprout = Color.Bisque;
                ColorOfMature = Color.Yellow;
                ColorOfDying = Color.OrangeRed;
            }
        }

        protected override void BecomeSeed()
        {
            TypeOfPlant = "Seed";
            CurrentColor = ColorOfSeed;
            NutritionalValue = 0;
        }

        protected override void BecomeSprout()
        {
            TypeOfPlant = "Sprout";
            CurrentColor = ColorOfSprout;
            NutritionalValue = 40 * CheckToxicityForNutritionalValue();
        }

        protected override void BecomeMature()
        {
            TypeOfPlant = "AdultPlants";
            CurrentColor = ColorOfMature;
            NutritionalValue = 80 * CheckToxicityForNutritionalValue();

            if (countOfSeed <= numberOfSeed && World.ListOfPlants.Count + 1 <= ReproduceTreshold)
            {
                ReproduceSeed();
            }
        }

        protected override void ReproduceSeed()
        {
            int radiusOfTheSpreadByX = Rnd.Next(2, 15);
            int radiusOfTheSpreadByY = Rnd.Next(2, 15);
            countOfSeed++;
            foreach (var position in SeedPosition)
            {
                if (CheckPosition(X + position.Item1 * radiusOfTheSpreadByX, Y + position.Item2 * radiusOfTheSpreadByY))
                {
                    World.ListOfPlants.Add(new PlantsWithoutBerries(X + position.Item1 * radiusOfTheSpreadByX,
                        Y + position.Item2 * radiusOfTheSpreadByY, "Seed", IsToxic, colorOfSeed));
                    break;
                }
            }
        }

        protected override void BecomeDying()
        {
            TypeOfPlant = "DyingPlants";
            CurrentColor = ColorOfDying;
            NutritionalValue = 0;
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
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Simulation_of_life
{
    public class PlantsWithBerries : Plant
    {
        private readonly int _numberOfBerries = Rnd.Next(0, 8);
        private int _countOfBerries = 0;
        private int _numberOfSeed = Rnd.Next(0, 12);
        private int _countOfSeed = 0;

        private readonly Color colorOfSeed = Color.Moccasin;
        private static int _dx = World.GetSizeCell();
        private static int _dy = World.GetSizeCell();

        private Tuple<int, int>[] berriesPosition =
        {
            new Tuple<int, int>(-_dx, -_dy),
            new Tuple<int, int>(0, -_dy),
            new Tuple<int, int>(_dx, -_dy),
            new Tuple<int, int>(-_dx, 0),
            new Tuple<int, int>(_dx, 0),
            new Tuple<int, int>(-_dx, _dy),
            new Tuple<int, int>(0, _dy),
            new Tuple<int, int>(_dx, _dy),
        };

        public PlantsWithBerries(int x, int y, string typeOfPlants, bool isToxic, Color currentColor) : base(x, y,
            typeOfPlants, isToxic)
        {
            colorOfSeed = Color.Moccasin;
            ColorOfSprout = Color.Olive;
            ColorOfMature = Color.Green;
            ColorOfDying = Color.DarkGray;
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

            if (_countOfSeed <= _numberOfSeed && World.ListOfPlants.Count + 1 < ReproduceTreshold)
            {
                ReproduceSeed();
            }

            if (_countOfBerries <= _numberOfBerries)
            {
                ReproduceBerries();
            }
        }

        protected override void ReproduceSeed()
        {
            int radiusOfTheSpreadByX = Rnd.Next(2, 15);
            int radiusOfTheSpreadByY = Rnd.Next(2, 15);
            _countOfSeed++;
            foreach (var position in SeedPosition)
            {
                if (CheckPosition(X + position.Item1 * radiusOfTheSpreadByX, Y + position.Item2 * radiusOfTheSpreadByY))
                {
                    World.ListOfPlants.Add(new PlantsWithBerries(X + position.Item1 * radiusOfTheSpreadByX,
                        Y + position.Item2 * radiusOfTheSpreadByY, "Seed", IsToxic, colorOfSeed));
                    break;
                }
            }
        }

        private void ReproduceBerries()
        {
            _countOfBerries++;
            foreach (var position in berriesPosition)
            {
                if (CheckPosition(X + position.Item1, Y + position.Item2))
                {
                    if (IsToxic)
                    {
                        World.ListOfPlants.Add(new Berrie(X + position.Item1, Y + position.Item2, "Berries", IsToxic,
                            Color.Orchid));

                        break;
                    }

                    else
                    {
                        World.ListOfPlants.Add(new Berrie(X + position.Item1, Y + position.Item2, "Berries", IsToxic,
                            Color.Cyan));

                        break;
                    }
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
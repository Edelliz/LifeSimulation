using System;
using System.Drawing;

namespace Simulation_of_life
{
    class InediblePlantWithBerries : InediblePlant
    {
        private int _numberOfBerries = SimulationEngine.Rnd.Next(0, 8);

        private static readonly int Dx = World.SizeCell;
        private static readonly int Dy = World.SizeCell;

        private bool isAdilityToGiveOfBerries = true;
        
        private Tuple<int, int>[] berriesPosition =
        {
            new (-Dx, -Dy),
            new (0, -Dy),
            new (Dx, -Dy),
            new (-Dx, 0),
            new (Dx, 0),
            new (-Dx, Dy),
            new (0, Dy),
            new (Dx, Dy),
        };

        public InediblePlantWithBerries(Cell position, EnumStagesOfGrowth stageOfGrowth, Bitmap currentImage, EnumOfEntities type) : base(position, stageOfGrowth, currentImage, type)
        {
            AgeOfSeed = 100;
            AgeOfSprout = 250;
            AgeOfMature = 500;
            AgeOfDying = 1000;

            ImageOfSeed = ImageOfEntity.Seed;
            ImageOfSprout = ImageOfEntity.InedibleSproutPlantWithBerrie;
            ImageOfMature = ImageOfEntity.InedibleAdultPlantWithBerrie;
            ImageOfDying = ImageOfEntity.InedibleDyingPlantWithBerrie;

            СoefficientReproduction = 0.6;
            ReproduceThreshold = (int)(World.StartingNumberOfInediblePlantWithBerries * СoefficientReproduction);
        }

        protected override void SetSeasonalParameters()
        {
            base.SetSeasonalParameters();

            switch (SimulationEngine.currentSeasons)
            {
                case EnumOfSeasons.Summer:
                    World.Summer.ChangeTheAbilityToGrowBerries(_typeOfThis, ref isAdilityToGiveOfBerries);

                    break;

                case EnumOfSeasons.Winter:
                    World.Winter.ChangeTheAbilityToGrowBerries(_typeOfThis, ref isAdilityToGiveOfBerries);

                    break;

                case EnumOfSeasons.Spring:
                    World.Spring.ChangeTheAbilityToGrowBerries(_typeOfThis, ref isAdilityToGiveOfBerries);

                    break;
            }
        }

        protected override void Reproduce()
        {
            if (_numberOfBerries >= 0 && isAdilityToGiveOfBerries == true)
            {
                GiveBerries();
            }

            int randomRadiusX = SimulationEngine.Rnd.Next(0, 10);
            int randomRadiusY = SimulationEngine.Rnd.Next(0, 10);

            if (NumberSeed >= 0 && GeneratingNewEntity.CountInediblePlantWithBerries <= ReproduceThreshold)
            {
                foreach (var (dx, dy) in SeedPosition)
                {
                    if (CheckPosition(X + dx * randomRadiusX, Y + dy * randomRadiusY))
                    {
                        World.ListOfInediblePlants.Add(new InediblePlantWithBerries(new Cell(X + dx * randomRadiusX, Y + dy * randomRadiusY),
                            EnumStagesOfGrowth.Seed, ImageOfSeed, _typeOfThis));

                        NumberSeed--;
                        GeneratingNewEntity.CountInediblePlantWithBerries++;


                        break;
                    }
                }
            }
        }
        
        private void GiveBerries()
        {
            foreach (var (dx, dy) in berriesPosition)
            {
                if (CheckPosition(X + dx, Y + dy))
                {
                    World.ListOfBerries.Add(new InedibleBerrie(new Cell(X + dx, Y + dy), ImageOfEntity.InedibleSproutBerrie));
                    _numberOfBerries--;

                    break;
                }
            }
        }

        public override void Die(Entity entity)
        {
            GeneratingNewEntity.CountInediblePlantWithBerries--;
            World.ListOfInediblePlants.Remove(this);
        }
    }

}


using System;
using System.Drawing;

namespace Simulation_of_life
{
    class EdibleToxicPlantWithBerries : EdiblePlant
    {
     
        private int _numberOfBerries = SimulationEngine.Rnd.Next(0, 8);

        private readonly int _toxicityValue = SimulationEngine.Rnd.Next(1, 10) / 10;

        private bool isAdilityToGiveOfBerries = true;

        private static readonly int Dx = World.SizeCell;
        private static readonly int Dy = World.SizeCell;

        private readonly Tuple<int, int>[] _berriesPosition =
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
        public EdibleToxicPlantWithBerries(Cell position, EnumStagesOfGrowth stageOfGrowth, Bitmap currentImage, EnumOfEntities type) : base(position, stageOfGrowth, currentImage, type)
        {
            AgeOfSeed = 25;
            AgeOfSprout = 80;
            AgeOfMature = 180;
            AgeOfDying = 250;

            ImageOfSeed = ImageOfEntity.Seed;
            ImageOfSprout = ImageOfEntity.EdibleSproutToxicPlantWithBerrie;
            ImageOfMature = ImageOfEntity.EdibleAdultToxicPlantWithBerrie;
            ImageOfDying = ImageOfEntity.EdibleDyingToxicPlantWithBerrie;

            СoefficientReproduction = 0.6;
            ReproduceThreshold = (int)(World.StartingNumberOfEdibleToxicPlantWithBerries * СoefficientReproduction);
        }

        protected override void StartLiving(EnumStagesOfGrowth stage)
        {
            base.StartLiving(stage);

            _nutritionalValue = stage switch
            {
                EnumStagesOfGrowth.Seed => 0,
                EnumStagesOfGrowth.Sprout => -20 * _toxicityValue,
                EnumStagesOfGrowth.AdultPlants => -45 * _toxicityValue,
                EnumStagesOfGrowth.DyingPlants => -5 * _toxicityValue
            };
        }

        private void GiveBerries()
        {
            foreach (var position in _berriesPosition)
            {
                if (CheckPosition(X + position.Item1, Y + position.Item2))
                {
                    World.ListOfBerries.Add(new EdibleToxicBerrie(new Cell(X + position.Item1, Y + position.Item2), ImageOfEntity.EdibleSproutToxicBerrie));
                    _numberOfBerries--;

                    break;
                }
            }
        }

        protected override void Reproduce()
        {
            int randomRadiusX = SimulationEngine.Rnd.Next(0, 10);
            int randomRadiusY = SimulationEngine.Rnd.Next(0, 10);
            if (_numberOfBerries >= 0 && isAdilityToGiveOfBerries == true)
            {
                GiveBerries();
            }

            if (NumberSeed >= 0 && GeneratingNewEntity.CountEdibleToxicPlantWithBerries <= ReproduceThreshold)
            {
                foreach (var (dx, dy) in SeedPosition)
                {
                    if (CheckPosition(X + dx * randomRadiusX, Y + dy * randomRadiusY))
                    {
                        World.ListOfEdiblePlants.Add(new EdibleToxicPlantWithBerries(new Cell(X + dx * randomRadiusX, Y + dy * randomRadiusY),
                            EnumStagesOfGrowth.Seed, ImageOfSeed, _typeOfThis));

                        NumberSeed--;

                        GeneratingNewEntity.CountEdibleToxicPlantWithBerries++;


                        break;
                    }
                }
            }
        }

        public override void Die(Entity entity)
        {
            GeneratingNewEntity.CountEdibleToxicPlantWithBerries--;
            World.ListOfEdiblePlants.Remove(this);
        }

    }
}

using System;
using System.Drawing;

namespace Simulation_of_life
{
    class EdibleNonToxicPlantWithBerries : EdiblePlant
    {

        private int _numberOfBerries = SimulationEngine.Rnd.Next(0, 8);

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

        public EdibleNonToxicPlantWithBerries(Cell position, EnumStagesOfGrowth stageOfGrowth, Bitmap currentImage, EnumOfEntities type) : base(position, stageOfGrowth, currentImage, type)
        {
            AgeOfSeed = 25;
            AgeOfSprout = 50;
            AgeOfMature = 180;
            AgeOfDying = 220;

            ImageOfSeed = ImageOfEntity.Seed;
            ImageOfSprout = ImageOfEntity.EdibleSproutNonToxicPlantWithBerrie;
            ImageOfMature = ImageOfEntity.EdibleAdultNonToxicPlantWithBerrie;
            ImageOfDying = ImageOfEntity.EdibleDyingNonToxicPlantWithBerrie;

            СoefficientReproduction = 0.9;
            ReproduceThreshold = (int)(World.StartingNumberOfEdibleNonToxicPlantWithBerries * СoefficientReproduction);
        }

        protected override void StartLiving(EnumStagesOfGrowth stage)
        {
            base.StartLiving(stage);

            _nutritionalValue = stage switch
            {
                EnumStagesOfGrowth.Seed => 0,
                EnumStagesOfGrowth.Sprout => 40,
                EnumStagesOfGrowth.AdultPlants => 90,
                EnumStagesOfGrowth.DyingPlants => 5
            };
        }

        private void GiveBerries()
        {
            foreach (var (dx, dy) in _berriesPosition)
            {

                if (CheckPosition(X + dx, Y + dy))
                {
                    World.ListOfBerries.Add(new EdibleNonToxicBerrie(new Cell(X + dx, Y + dy), ImageOfEntity.EdibleSproutNonToxicBerrie));
                    _numberOfBerries--;

                    break;
                }
            }
        }
        protected override void Reproduce()
        {
            int randomRadiusX = SimulationEngine.Rnd.Next(0, 10);
            int randomRadiusY = SimulationEngine.Rnd.Next(0, 10);
            
            if (_numberOfBerries >=0 && isAdilityToGiveOfBerries == true)
            {
                GiveBerries();
            }

            if (NumberSeed >= 0 && GeneratingNewEntity.CountEdibleNonToxicPlantWithBerries <= ReproduceThreshold)
            {
                foreach (var (dx, dy) in SeedPosition)
                {
                    if (CheckPosition(X + dx * randomRadiusX, Y + dy * randomRadiusY))
                    {
                        World.ListOfEdiblePlants.Add(new EdibleNonToxicPlantWithBerries(new Cell(X + dx * randomRadiusX, Y + dy * randomRadiusY),
                            EnumStagesOfGrowth.Seed, ImageOfSeed, _typeOfThis));

                        NumberSeed--;
                        GeneratingNewEntity.CountEdibleNonToxicPlantWithBerries++;


                        break;
                    }
                }
            }
        }

        public override void Die(Entity entity)
        {
            GeneratingNewEntity.CountEdibleNonToxicPlantWithBerries--;
            World.ListOfEdiblePlants.Remove(this);
        }
      
    }
}

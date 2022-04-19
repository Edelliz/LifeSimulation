using System;
using System.Drawing;

namespace Simulation_of_life
{
    class EdibleNonToxicPlantWithoutBerries : EdiblePlant
    {
        public EdibleNonToxicPlantWithoutBerries(Cell position, EnumStagesOfGrowth stageOfGrowth, Bitmap currentImage, EnumOfEntities type) : base(position, stageOfGrowth, currentImage, type)
        {
            AgeOfSeed = 25;
            AgeOfSprout = 100;
            AgeOfMature = 250;
            AgeOfDying = 300;

            ImageOfSeed = ImageOfEntity.Seed;
            ImageOfSprout = ImageOfEntity.EdibleSproutNonToxicPlantWithoutBerrie;
            ImageOfMature = ImageOfEntity.EdibleAdultNonToxicPlantWithoutBerrie;
            ImageOfDying = ImageOfEntity.EdibleDyingNonToxicPlantWithoutBerrie;

            СoefficientReproduction = 0.8;
            ReproduceThreshold = (int)(World.StartingNumberOfEdibleNonToxicPlantWithoutBerries * СoefficientReproduction);
        }

        protected override void StartLiving(EnumStagesOfGrowth stage)
        {
            base.StartLiving(stage);

            _nutritionalValue = stage switch
            {
                EnumStagesOfGrowth.Seed => 0,
                EnumStagesOfGrowth.Sprout => 50,
                EnumStagesOfGrowth.AdultPlants => 100,
                EnumStagesOfGrowth.DyingPlants => 1
            };
        }
        
        protected override void Reproduce()
        {
            int randomRadiusX = SimulationEngine.Rnd.Next(0, 10);
            int randomRadiusY = SimulationEngine.Rnd.Next(0, 10);

            if (NumberSeed > 0 && GeneratingNewEntity.CountEdibleNonToxicPlantWithoutBerries <= ReproduceThreshold)
            {
                foreach (var (dx, dy) in SeedPosition)
                {
                    
                    if (CheckPosition(X + dx * randomRadiusX, Y + dy * randomRadiusY))
                    {
                        World.ListOfEdiblePlants.Add(new EdibleNonToxicPlantWithoutBerries(new Cell(X + dx * randomRadiusX, Y + dy * randomRadiusY),
                            EnumStagesOfGrowth.Seed, ImageOfSeed, _typeOfThis));

                        NumberSeed--;
                        GeneratingNewEntity.CountEdibleNonToxicPlantWithoutBerries++;


                        break;
                    }
                }
            }
        }

        public override void Die(Entity entity)
        {
            GeneratingNewEntity.CountEdibleNonToxicPlantWithoutBerries--;
            World.ListOfEdiblePlants.Remove(this);
        }

    }
}

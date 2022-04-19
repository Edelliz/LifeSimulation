using System;
using System.Drawing;

namespace Simulation_of_life
{
    class EdibleToxicPlantWithoutBerries : EdiblePlant
    {
     
        private readonly int _toxicityValue = SimulationEngine.Rnd.Next(1, 10) / 10;
        public EdibleToxicPlantWithoutBerries(Cell position, EnumStagesOfGrowth stageOfGrowth, Bitmap currentImage, EnumOfEntities type) : base(position, stageOfGrowth, currentImage, type)
        {
            AgeOfSeed = 10;
            AgeOfSprout = 25;
            AgeOfMature = 50;
            AgeOfDying = 60;

            ImageOfSeed = ImageOfEntity.Seed;
            ImageOfSprout = ImageOfEntity.EdibleSproutToxicPlantWithoutBerrie;
            ImageOfMature = ImageOfEntity.EdibleAdultToxicPlantWithoutBerrie;
            ImageOfDying = ImageOfEntity.EdibleDyingToxicPlantWithoutBerrie;

            СoefficientReproduction = 0.7;
            ReproduceThreshold = (int)(World.StartingNumberOfEdibleToxicPlantWithoutBerries * СoefficientReproduction);
        }

        protected override void StartLiving(EnumStagesOfGrowth stage)
        {
            base.StartLiving(stage);

            _nutritionalValue = stage switch
            {
                EnumStagesOfGrowth.Seed => 0,
                EnumStagesOfGrowth.Sprout => -30 * _toxicityValue,
                EnumStagesOfGrowth.AdultPlants => -50 * _toxicityValue,
                EnumStagesOfGrowth.DyingPlants => -1 * _toxicityValue
            };
        }
        
        protected override void Reproduce()
        {
            int randomRadiusX = SimulationEngine.Rnd.Next(0, 10);
            int randomRadiusY = SimulationEngine.Rnd.Next(0, 10);

            if (NumberSeed >= 0 && GeneratingNewEntity.CountEdibleToxicPlantWithoutBerries <= ReproduceThreshold)
            {
                foreach (var (dx, dy) in SeedPosition)
                {
                    if (CheckPosition(X + dx * randomRadiusX, Y + dy * randomRadiusY))
                    {
                        World.ListOfEdiblePlants.Add(new EdibleToxicPlantWithoutBerries(new Cell(X + dx * randomRadiusX, Y + dy * randomRadiusY),
                            EnumStagesOfGrowth.Seed, ImageOfSeed, _typeOfThis));

                        NumberSeed--;
                        GeneratingNewEntity.CountEdibleToxicPlantWithoutBerries++;
                        
                        break;
                    }
                }
            }
        }

        public override void Die(Entity entity)
        {
            GeneratingNewEntity.CountEdibleToxicPlantWithoutBerries--;
            World.ListOfEdiblePlants.Remove(this);
        }

    }
}

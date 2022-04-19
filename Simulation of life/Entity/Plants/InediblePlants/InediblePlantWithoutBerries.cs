using System;
using System.Drawing;

namespace Simulation_of_life
{
    class InediblePlantWithoutBerries :  InediblePlant
    {
        public InediblePlantWithoutBerries(Cell position, EnumStagesOfGrowth stageOfGrowth, Bitmap currentImage, EnumOfEntities type) : base(position, stageOfGrowth, currentImage, type)
        {
            AgeOfSeed = 50;
            AgeOfSprout = 125;
            AgeOfMature = 250;
            AgeOfDying = 500;

            ImageOfSeed = ImageOfEntity.Seed;
            ImageOfSprout = ImageOfEntity.InedibleSproutPlantWithoutBerrie;
            ImageOfMature = ImageOfEntity.InedibleAdultPlantWithoutBerrie;
            ImageOfDying = ImageOfEntity.InedibleDyingPlantWithoutBerrie;

            СoefficientReproduction = 0.6;
            ReproduceThreshold = (int)(World.StartingNumberOfInediblePlantWithoutBerries * СoefficientReproduction);
        }
        
        protected override void Reproduce()
        {
            int randomRadiusX = SimulationEngine.Rnd.Next(0, 10);
            int randomRadiusY = SimulationEngine.Rnd.Next(0, 10);

            if (NumberSeed >= 0 && GeneratingNewEntity.CountInediblePlantWithoutBerries <= ReproduceThreshold)
            {
                foreach (var (dx, dy) in SeedPosition)
                {
                    if (CheckPosition(X + dx * randomRadiusX, Y + dy * randomRadiusY))
                    {
                        World.ListOfInediblePlants.Add(new InediblePlantWithoutBerries(new Cell(X + dx * randomRadiusX, Y + dy * randomRadiusY),
                            EnumStagesOfGrowth.Seed, ImageOfSeed, _typeOfThis));

                        NumberSeed--;
                        GeneratingNewEntity.CountInediblePlantWithoutBerries++;
                        
                        break;
                    }
                }
            }
        }

        public override void Die(Entity entity)
        {
            GeneratingNewEntity.CountInediblePlantWithoutBerries--;
            World.ListOfInediblePlants.Remove(this);
        }
    }
}

using System.Drawing;

namespace Simulation_of_life
{
    class EdibleToxicBerrie : Berrie
    {   
        private int _toxicityValue = SimulationEngine.Rnd.Next(1, 10) / 10;

        public EdibleToxicBerrie(Cell position, Bitmap currentImage) : base(position, currentImage)
        {
            CurrentAge = 5;
            AgeOfSprout = 45;
            AgeOfMature = 110;
            AgeOfDying = 200;

            ImageOfSprout = ImageOfEntity.EdibleSproutToxicBerrie;
            ImageMature = ImageOfEntity.EdibleAdultToxicBerrie;
            ImageDying = ImageOfEntity.EdibleDyingToxicBerrie;
        }

        protected override void BecomeOlder(EnumStagesOfGrowth stage)
        {
            base.BecomeOlder(stage);


            _nutritionalValue = stage switch
            {
                EnumStagesOfGrowth.Sprout => -20 * _toxicityValue,
                EnumStagesOfGrowth.AdultPlants => -50 * _toxicityValue,
                EnumStagesOfGrowth.DyingPlants => -5 * _toxicityValue
            };

        }
        
    }
}

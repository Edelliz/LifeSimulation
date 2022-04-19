using System.Drawing;

namespace Simulation_of_life
{
    class EdibleNonToxicBerrie : Berrie
    {
        public EdibleNonToxicBerrie(Cell position, Bitmap currentImage) : base(position, currentImage)
        {
            CurrentAge = 5;
            AgeOfSprout = 40;
            AgeOfMature = 100;
            AgeOfDying = 180;
            
            ImageOfSprout = ImageOfEntity.EdibleSproutNonToxicBerrie;
            ImageMature = ImageOfEntity.EdibleAdultNonToxicBerrie;
            ImageDying = ImageOfEntity.EdibleDyingNonToxicBerrie;
        }

        protected override void BecomeOlder(EnumStagesOfGrowth stage)
        {
            base.BecomeOlder(stage);

            _nutritionalValue = stage switch
            {  
                EnumStagesOfGrowth.Sprout => 20,
                EnumStagesOfGrowth.AdultPlants => 50,
                EnumStagesOfGrowth.DyingPlants => 5
            };
        }
    }
}


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_of_life
{
    public class Summer : SeasonOfTheYear
    {
        public Summer()
        {
            DeltaOfSatiety = -1;

            ColorOfTheSeason = Color.Black;
            AbilityToGrowBerries = true;
            AbilityToLive = true;
            isSleeper = false;

            SeasonalImageRabbit = ImageOfEntity.Rabbit;
            SeasonalImageWolf = ImageOfEntity.Wolf;
            SeasonalImageMouse = ImageOfEntity.Mouse;

            SeasonalImageMan = ImageOfEntity.Man;
            SeasonalImageWoman = ImageOfEntity.Woman;

            SeasonalImagePanda = ImageOfEntity.Panda;
            SeasonalImageBobcat = ImageOfEntity.Bobcat;
            SeasonalImageCow = ImageOfEntity.Cow;

        }

        public override void ChangeReproductionThreshold(EnumOfEntities typeOfEntity, ref double coef)
        {
            coef = typeOfEntity switch
            {
                EnumOfEntities.CarnivorousAnimal => 0.7,
                EnumOfEntities.OmnivorousAnimal => 0.7,
                EnumOfEntities.HerbivorousAnimal => 0.8,
                EnumOfEntities.InediblePlantWithBerries => 0.6,
                EnumOfEntities.InediblePlantWithoutBerries => 0.6,
                EnumOfEntities.EdibleNonToxicPlantWithBerries => 0.8,
                EnumOfEntities.EdibleNonToxicPlantWithoutBerries => 0.8,
                EnumOfEntities.EdibleToxicPlantWithBerries => 0.5,
                EnumOfEntities.EdibleToxicPlantWithoutBerries => 0.5,
                EnumOfEntities.Human => 0.7
            };
        }

        public override void ChangeSatietyTreshold(EnumOfEntities typeOfEntity, ref double coef)
        {
            coef = typeOfEntity switch
            {
                EnumOfEntities.CarnivorousAnimal => 0.6,
                EnumOfEntities.OmnivorousAnimal => 0.5,
                EnumOfEntities.HerbivorousAnimal => 0.4,
                EnumOfEntities.Human => 0.6

            };
        }
    }
}

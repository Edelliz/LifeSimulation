
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_of_life
{
    public class Spring : SeasonOfTheYear
    {
        public Spring()
        {
            DeltaOfSatiety = -1;

            ColorOfTheSeason = Color.LightSalmon;
            AbilityToGrowBerries = false;
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
                EnumOfEntities.CarnivorousAnimal => 0.8,
                EnumOfEntities.OmnivorousAnimal => 0.8,
                EnumOfEntities.HerbivorousAnimal => 0.9,
                EnumOfEntities.InediblePlantWithBerries => 0.7,
                EnumOfEntities.InediblePlantWithoutBerries => 0.7,
                EnumOfEntities.EdibleNonToxicPlantWithBerries => 0.9,
                EnumOfEntities.EdibleNonToxicPlantWithoutBerries => 0.9,
                EnumOfEntities.EdibleToxicPlantWithBerries => 0.6,
                EnumOfEntities.EdibleToxicPlantWithoutBerries => 0.6,
                EnumOfEntities.Human => 0.8
            };
        }

        public override void ChangeSatietyTreshold(EnumOfEntities typeOfEntity, ref double coef)
        {
            coef = typeOfEntity switch
            {
                EnumOfEntities.CarnivorousAnimal => 0.5,
                EnumOfEntities.OmnivorousAnimal => 0.4,
                EnumOfEntities.HerbivorousAnimal => 0.3,
                EnumOfEntities.Human => 0.5

            };
            
        }
    }
}

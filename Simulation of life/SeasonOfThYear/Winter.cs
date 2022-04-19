
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_of_life
{
    public class Winter : SeasonOfTheYear
    {
        public Winter()
        {
            DeltaOfSatiety = -2;
    
            ColorOfTheSeason = Color.DarkSlateBlue;
            AbilityToGrowBerries = false;
            AbilityToLive = false;
            isSleeper = true;

            SeasonalImageRabbit = ImageOfEntity.WintersRabbit;
            SeasonalImageWolf = ImageOfEntity.WintersWolf;
            SeasonalImageMouse = ImageOfEntity.WintersMouse;

            SeasonalImageMan = ImageOfEntity.WinterMan;
            SeasonalImageWoman = ImageOfEntity.WinterWoman;

            SeasonalImagePanda = ImageOfEntity.WintersPanda;
            SeasonalImageBobcat = ImageOfEntity.WintersBobcat;
            SeasonalImageCow = ImageOfEntity.WintersCow;

        }

        public override void ChangeReproductionThreshold(EnumOfEntities typeOfEntity, ref double coef)
        {
            coef = typeOfEntity switch
            {
                EnumOfEntities.CarnivorousAnimal => 0.6,
                EnumOfEntities.OmnivorousAnimal => 0.6,
                EnumOfEntities.HerbivorousAnimal => 0.7,
                EnumOfEntities.InediblePlantWithBerries => 0,
                EnumOfEntities.InediblePlantWithoutBerries => 0.5,
                EnumOfEntities.EdibleNonToxicPlantWithBerries => 0.7,
                EnumOfEntities.EdibleNonToxicPlantWithoutBerries => 0.6,
                EnumOfEntities.EdibleToxicPlantWithBerries => 0,
                EnumOfEntities.EdibleToxicPlantWithoutBerries => 0.4,
                EnumOfEntities.Human => 0.5
            };
        }

        public override void ChangeSatietyTreshold(EnumOfEntities typeOfEntity, ref double coef)
        {   
            coef = typeOfEntity switch
            {
                EnumOfEntities.CarnivorousAnimal => 0.9,
                EnumOfEntities.OmnivorousAnimal => 0.8,
                EnumOfEntities.HerbivorousAnimal => 0.7,
                EnumOfEntities.Human => 0.5
               
            };
        }

        public override void ChangeTheAbilityToGrowBerries(EnumOfEntities typeOfEntity, ref bool isAbility)
        {
            if (typeOfEntity == EnumOfEntities.InediblePlantWithBerries
                || typeOfEntity == EnumOfEntities.EdibleToxicPlantWithBerries)  //Chage Type to Enum  (If plant species are added :) )
            {
                isAbility = AbilityToGrowBerries;
            }

        }
    }
}

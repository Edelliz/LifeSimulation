using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_of_life
{
    public abstract class SeasonOfTheYear
    {
        protected int DeltaOfSatiety;
        protected int СoefficientReproduction;

        protected int СoefficientSatiety;
        protected Color ColorOfTheSeason;

        protected bool AbilityToGrowBerries;
        protected bool AbilityToLive;
        protected bool isSleeper;

        protected Bitmap SeasonalImageRabbit;
        protected Bitmap SeasonalImageWolf;
        protected Bitmap SeasonalImageMouse;

        protected Bitmap SeasonalImageMan;
        protected Bitmap SeasonalImageWoman;

        protected Bitmap SeasonalImagePanda;
        protected Bitmap SeasonalImageBobcat;
        protected Bitmap SeasonalImageCow;

        public void ChangeDeltaOfSatiety(ref int delta)
        {
            delta = DeltaOfSatiety;
        }

        public abstract void ChangeReproductionThreshold(EnumOfEntities typeOfEntity, ref double coef);
        public abstract void ChangeSatietyTreshold(EnumOfEntities typeOfEntity, ref double coef);
              
        public Bitmap ChangeTheImage(ref Bitmap currentTheImage, EnumOfAnimals animal)
        {
            currentTheImage = animal switch
            {
                EnumOfAnimals.Rabbit => SeasonalImageRabbit,
                EnumOfAnimals.Wolf => SeasonalImageWolf,
                EnumOfAnimals.Mouse => SeasonalImageMouse,
                EnumOfAnimals.Man => SeasonalImageMan,
                EnumOfAnimals.Woman => SeasonalImageWoman,

                //Sleeping animals
                EnumOfAnimals.Panda => SeasonalImagePanda,
                EnumOfAnimals.Bobcat => SeasonalImageBobcat,
                EnumOfAnimals.Cow => SeasonalImageCow,
                _ => currentTheImage

            };

            return currentTheImage;
        }

        public Color ChangeColorOfTheSeason()
        {
            return ColorOfTheSeason;
        }
        public virtual void ChangeTheAbilityToGrowBerries(EnumOfEntities typeOfEntity, ref bool isAbility)
        {
            if (typeOfEntity == EnumOfEntities.InediblePlantWithBerries)
            {
                isAbility = AbilityToGrowBerries;
            }
        }
        public void ChangeTheAbilityToLive(EnumOfEntities typeOfEntity, ref bool isAbility)
        {
            if (typeOfEntity == EnumOfEntities.EdibleToxicPlantWithoutBerries) 
            {
                isAbility = AbilityToLive;
            }
        }

        public void BecomeSleeper(ref bool sleep,EnumOfAnimals animal)
        {
            sleep = animal switch
            {
                EnumOfAnimals.Panda => isSleeper,
                EnumOfAnimals.Bobcat => isSleeper,
                EnumOfAnimals.Cow => isSleeper,
                _ => sleep
            };
        }
    }
}

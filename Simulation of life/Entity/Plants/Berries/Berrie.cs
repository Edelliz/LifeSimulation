using System.Drawing;
using System.Windows.Forms;

namespace Simulation_of_life
{
    public abstract class Berrie
    {
        protected int _nutritionalValue;
        
        protected int CurrentAge;         
        protected int AgeOfSprout;
        protected int AgeOfMature;
        protected int AgeOfDying;

        public Bitmap CurrentImage;
        protected Bitmap ImageOfSprout;
        protected Bitmap ImageMature;
        protected Bitmap ImageDying;

        private readonly Cell _coordinate;

        protected Berrie(Cell position, Bitmap currentImage)
        {
            _coordinate = position;
            CurrentImage = currentImage;
        }
        
        protected virtual void BecomeOlder(EnumStagesOfGrowth stage)
        {
            CurrentImage = stage switch
            {  
                EnumStagesOfGrowth.Sprout => ImageOfSprout,
                EnumStagesOfGrowth.AdultPlants => ImageMature,
                EnumStagesOfGrowth.DyingPlants => ImageDying
            };
        }
        
        public void Move()
        {
            if (CurrentAge <= AgeOfSprout)
            {
                BecomeOlder(EnumStagesOfGrowth.Sprout);
            }

            else if (CurrentAge > AgeOfSprout && CurrentAge <= AgeOfMature)
            {
                BecomeOlder(EnumStagesOfGrowth.AdultPlants);
            }

            else if (CurrentAge > AgeOfMature && CurrentAge < AgeOfDying)
            {
                BecomeOlder(EnumStagesOfGrowth.DyingPlants);
            }

            else if (CurrentAge == AgeOfDying)
            {
                Die();
            }

            CurrentAge++;
        }

        public void Die()
        {
            World.ListOfBerries.Remove(this);
        }
        
        public int NutritionalValue => _nutritionalValue;
        public Cell GetPosition => _coordinate;
    }
}
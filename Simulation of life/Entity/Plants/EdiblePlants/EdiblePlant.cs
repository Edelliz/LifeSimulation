
using System.Drawing;

namespace Simulation_of_life
{
    public abstract class EdiblePlant : Plant
    {
        protected int _nutritionalValue;


        protected EdiblePlant(Cell position, EnumStagesOfGrowth stageOfGrowth, Bitmap currentImage, EnumOfEntities type) : base(position, stageOfGrowth, currentImage, type)
        {
        }

        
        public int GetNutritionalValue()
        {
            return _nutritionalValue;
        }

        public int NutritionalValue => _nutritionalValue;
    }
}

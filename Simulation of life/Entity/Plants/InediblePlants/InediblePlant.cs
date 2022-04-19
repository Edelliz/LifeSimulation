
using System.Drawing;

namespace Simulation_of_life
{
    public abstract class InediblePlant : Plant
    {
        protected InediblePlant(Cell position, EnumStagesOfGrowth stageOfGrowth, Bitmap currentImage, EnumOfEntities type) : base(position, stageOfGrowth, currentImage, type)
        {
        }

    }
}

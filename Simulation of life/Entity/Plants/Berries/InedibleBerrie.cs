using System.Drawing;

namespace Simulation_of_life
{
    class InedibleBerrie : Berrie
    {
        public InedibleBerrie(Cell position, Bitmap currentImage) : base(position, currentImage)
        {
            CurrentAge = 5;
            AgeOfSprout = 30;
            AgeOfMature = 80;
            AgeOfDying = 100;


            ImageOfSprout = ImageOfEntity.InedibleSproutBerrie;
            ImageMature = ImageOfEntity.InedibleAdultBerrie;
            ImageDying = ImageOfEntity.InedibleDyingBerrie;
        }
    }
}

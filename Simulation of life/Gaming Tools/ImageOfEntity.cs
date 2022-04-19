using System.Drawing;

namespace Simulation_of_life
{
    class ImageOfEntity
    {
        private static int SizeImage = World.SizeCell;

        //Animal

        /*Humans*/

        public static Bitmap WinterWoman = new Bitmap(Properties.Resources.WinterWoman, SizeImage, SizeImage);
        public static Bitmap WinterMan = new Bitmap(Properties.Resources.WinterMan, SizeImage, SizeImage);
        public static Bitmap Woman = new Bitmap(Properties.Resources.woman, SizeImage, SizeImage);
        public static Bitmap Man = new Bitmap(Properties.Resources.man, SizeImage, SizeImage);
        
        /*Winters images*/
        public static Bitmap WintersMouse = new Bitmap(Properties.Resources.WintersMouse, SizeImage, SizeImage);
        public static Bitmap WintersWolf = new Bitmap(Properties.Resources.WintersWolf, SizeImage, SizeImage);
        public static Bitmap WintersRabbit = new Bitmap(Properties.Resources.WintersRabbit, SizeImage, SizeImage);

        public static Bitmap WintersCow = new Bitmap(Properties.Resources.WintersCow, SizeImage, SizeImage);
        public static Bitmap WintersPanda = new Bitmap(Properties.Resources.WintersPanda, SizeImage, SizeImage);
        public static Bitmap WintersBobcat = new Bitmap(Properties.Resources.WintersBobcat, SizeImage, SizeImage);


        /* Omnivorous */
        public static Bitmap Mouse = new Bitmap(Properties.Resources.Mouse, SizeImage, SizeImage);
        public static Bitmap Panda = new Bitmap(Properties.Resources.Panda, SizeImage, SizeImage);
        public static Bitmap Hedgehog = new Bitmap(Properties.Resources.Hedgehog, SizeImage, SizeImage);

        /* Carnivorous */
        public static Bitmap Bobcat = new Bitmap(Properties.Resources.Bobcat, SizeImage, SizeImage);
        public static Bitmap Leopard = new Bitmap(Properties.Resources.Leopard, SizeImage, SizeImage);
        public static Bitmap Wolf = new Bitmap(Properties.Resources.Wolf, SizeImage, SizeImage);

        public static Bitmap Cow = new Bitmap(Properties.Resources.Cow, SizeImage, SizeImage);
        public static Bitmap Rabbit = new Bitmap(Properties.Resources.Rabbit, SizeImage, SizeImage);
        public static Bitmap Beaver = new Bitmap(Properties.Resources.Beaver, SizeImage, SizeImage);

        //Plant

        /* Seed */

        public static Bitmap Seed = new Bitmap(Properties.Resources.Seed, SizeImage, SizeImage);

        /* Edible */

        /*ToxicWithBerrie*/

        public static Bitmap EdibleSproutToxicPlantWithBerrie = new Bitmap(Properties.Resources.SproutToxicBerrie, SizeImage, SizeImage);
        public static Bitmap EdibleAdultToxicPlantWithBerrie = new Bitmap(Properties.Resources.MaidenGrapesBush, SizeImage, SizeImage);
        public static Bitmap EdibleDyingToxicPlantWithBerrie = new Bitmap(Properties.Resources.MaidenGrapesBushDying, SizeImage, SizeImage);

        public static Bitmap EdibleSproutToxicBerrie = new Bitmap(Properties.Resources.MaidenGrapesBerrySprout, SizeImage, SizeImage);
        public static Bitmap EdibleAdultToxicBerrie = new Bitmap(Properties.Resources.MaidenGrapesBerry, SizeImage, SizeImage);
        public static Bitmap EdibleDyingToxicBerrie = new Bitmap(Properties.Resources.MaidenGrapesBerryDying, SizeImage, SizeImage);

        /*NonToxicWithBerrie*/

        public static Bitmap EdibleSproutNonToxicPlantWithBerrie = new Bitmap(Properties.Resources.RaspberrySprout, SizeImage, SizeImage);
        public static Bitmap EdibleAdultNonToxicPlantWithBerrie = new Bitmap(Properties.Resources.RaspberryBush, SizeImage, SizeImage);
        public static Bitmap EdibleDyingNonToxicPlantWithBerrie = new Bitmap(Properties.Resources.RaspberryBushDying, SizeImage, SizeImage);

        public static Bitmap EdibleSproutNonToxicBerrie = new Bitmap(Properties.Resources.RaspberryBerrySprout, SizeImage, SizeImage);
        public static Bitmap EdibleAdultNonToxicBerrie = new Bitmap(Properties.Resources.RaspberryBerry, SizeImage, SizeImage);
        public static Bitmap EdibleDyingNonToxicBerrie = new Bitmap(Properties.Resources.RaspberryBerryDying, SizeImage, SizeImage);

        /*Toxic*/

        public static Bitmap EdibleSproutToxicPlantWithoutBerrie = new Bitmap(Properties.Resources.SproutAgaric, SizeImage, SizeImage);
        public static Bitmap EdibleAdultToxicPlantWithoutBerrie = new Bitmap(Properties.Resources.Agaric, SizeImage, SizeImage);
        public static Bitmap EdibleDyingToxicPlantWithoutBerrie = new Bitmap(Properties.Resources.AgaricDying, SizeImage, SizeImage);

        /*NonToxic*/

        public static Bitmap EdibleSproutNonToxicPlantWithoutBerrie = new Bitmap(Properties.Resources.SproutNonToxic, SizeImage, SizeImage);
        public static Bitmap EdibleAdultNonToxicPlantWithoutBerrie = new Bitmap(Properties.Resources.Nettle, SizeImage, SizeImage);
        public static Bitmap EdibleDyingNonToxicPlantWithoutBerrie = new Bitmap(Properties.Resources.NettleDying, SizeImage, SizeImage);


        /* Inedible */

        /* WithBerrie */

        public static Bitmap InedibleSproutPlantWithBerrie = new Bitmap(Properties.Resources.SproutSakura, SizeImage, SizeImage);
        public static Bitmap InedibleAdultPlantWithBerrie = new Bitmap(Properties.Resources.SakuraTree, SizeImage, SizeImage);
        public static Bitmap InedibleDyingPlantWithBerrie = new Bitmap(Properties.Resources.SakuraTreeDying, SizeImage, SizeImage);

        public static Bitmap InedibleSproutBerrie = new Bitmap(Properties.Resources.SakuraLeafSprout, SizeImage, SizeImage);
        public static Bitmap InedibleAdultBerrie = new Bitmap(Properties.Resources.SakuraLeaf, SizeImage, SizeImage);
        public static Bitmap InedibleDyingBerrie = new Bitmap(Properties.Resources.SakuraLeafDying, SizeImage, SizeImage);

        /* WithoutBerrie */

        public static Bitmap InedibleSproutPlantWithoutBerrie = new Bitmap(Properties.Resources.SproutTree, SizeImage, SizeImage);
        public static Bitmap InedibleAdultPlantWithoutBerrie = new Bitmap(Properties.Resources.Tree, SizeImage, SizeImage);
        public static Bitmap InedibleDyingPlantWithoutBerrie = new Bitmap(Properties.Resources.TreeDying, SizeImage, SizeImage);

    }
}

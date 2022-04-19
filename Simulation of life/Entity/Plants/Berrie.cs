using System.Diagnostics.Eventing.Reader;
using System.Drawing;

namespace Simulation_of_life
{
    public class Berrie: Plant
    {

        public Berrie(int x, int y, string typeOfPlants, bool isToxic, Color colorOfBerries) : base(x, y, typeOfPlants, isToxic)
        {

            if (isToxic)
            {
                ColorOfSprout = Color.Orchid;
                ColorOfMature = Color.Fuchsia;
                ColorOfDying = Color.Red;
            }

            else
            {
                ColorOfSprout = Color.Cyan;
                ColorOfMature = Color.Aqua;
                ColorOfDying = Color.Teal;
            }

            CurrentAge = 5;
            AgeOfSeed = 0;
            AgeOfSprout = 30;
            AgeOfMature = 80;
            AgeOfDying = 100;
        }
        
        protected override void BecomeSprout()
        {
            CurrentColor = ColorOfSprout;
            
            NutritionalValue = 15 * CheckToxicityForNutritionalValue();
        }

        protected override void BecomeMature()
        {
           CurrentColor = ColorOfMature;
            NutritionalValue = 30 * CheckToxicityForNutritionalValue();
        }

        protected override void BecomeDying()
        {
            CurrentColor = ColorOfDying;
            NutritionalValue = 0;
        }

        protected override void ReproduceSeed()
        {
            return;
        }
        
        protected override void BecomeSeed()
        {
            return;
        }
        
        public override void Die()
        {
            World.ListOfPlants.Remove(this);
        }
        
        public override void Reproduce()
        {
            return;
        }
    }
}
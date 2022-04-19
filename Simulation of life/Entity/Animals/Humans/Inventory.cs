using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_of_life
{
    public class Inventory
    {

        public int Capacity  = 20;
        public  int Fullness = 0;
        public int AmountOfMeat;
        
        public readonly List<EdiblePlant> SectionWithEdiblePlants = new();
        public readonly List<InediblePlant> SectionWithInediblePlants = new();
        public readonly List<Berrie> SectionWithBerries = new();
        public readonly List<Medicine> SectionWithMedicines = new();

        private int SizeOfTheSectionWithEdiblePlants { get; }
        private int SizeOfTheSectionWithInediblePlants { get; }
        private int SizeOfTheSectionWithBerries { get; }
        private int SizeOfTheSectionWithMeat { get; }
        private int SizeOfTheSectionWithMedicines { get; }

        public Inventory()
        {
            SizeOfTheSectionWithEdiblePlants = (int) (Capacity * 0.3);
            SizeOfTheSectionWithInediblePlants = (int) (Capacity * 0.1);
            SizeOfTheSectionWithBerries = (int)(0.2);
            SizeOfTheSectionWithMeat = 30;
            SizeOfTheSectionWithMedicines = (int) (Capacity * 0.1);
            
        }

        public int GetAPieceOfMeat()
        {
            return 10;
        }
    }
}

using System.Collections.Generic;

namespace Simulation_of_life
{
    public class World
    {
        public static Summer Summer;
        public static Spring Spring;
        public static Winter Winter;
        public static  int _sizeOfWorld { get; set; }
        public static int SizeCell { get; set; } = 20;
       
        public static int StartingNumberOfEdibleNonToxicPlantWithBerries { get; set; }
        public  static int StartingNumberOfEdibleNonToxicPlantWithoutBerries { get; set; }
 
        public static int StartingNumberOfEdibleToxicPlantWithBerries { get; set; }
        public static int StartingNumberOfEdibleToxicPlantWithoutBerries { get; set; }
     
        public static int StartingNumberOfInediblePlantWithBerries { get; set; }
        public static int StartingNumberOfInediblePlantWithoutBerries { get; set; }
    
        public static int StartingNumberOfCarnivorousAnimal { get; set; }
        public static int StartingNumberOfHerbivorousAnimal { get; set; }
        public static int StartingNumberOfOmnivorousAnimal { get; set; }
        
        public static int StartingNumberOfHuman { get; set; }

        public static readonly List<Cell> Map = new();

        public static readonly List<CarnivorousAnimal> ListOfCarnivorousAnimals = new();
        public static readonly List<HerbivorousAnimal> ListOfHerbivorousAnimals = new();
        public static readonly List<OmnivorousAnimal> ListOfOmnivorousAnimals = new();
        public static readonly List<Human> ListOfHumans = new();

        public static readonly List<EdiblePlant> ListOfEdiblePlants = new();
        public static readonly List<InediblePlant> ListOfInediblePlants = new();
        public static readonly List<Berrie> ListOfBerries = new();
        
    }
}
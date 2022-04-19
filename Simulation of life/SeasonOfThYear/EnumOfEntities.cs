using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_of_life
{
    public enum EnumOfEntities
    {
        /*Types*/

        //Animals

        CarnivorousAnimal,
        OmnivorousAnimal,
        HerbivorousAnimal,

        //Plants

        InediblePlantWithBerries,
        InediblePlantWithoutBerries,

        EdibleNonToxicPlantWithBerries,
        EdibleNonToxicPlantWithoutBerries,

        EdibleToxicPlantWithBerries,
        EdibleToxicPlantWithoutBerries,
        
        //Human
        Human
    }
}

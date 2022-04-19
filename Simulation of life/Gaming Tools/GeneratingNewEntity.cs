using System;
using System.Drawing;
using System.Linq;

namespace Simulation_of_life
{
    class GeneratingNewEntity
    {
        private static int CountCarnivorousAnimal;
        private static int CountHerbivorousAnimal;
        private static int CountOmnivorousAnimal;
        private static int CountHuman;

        public static int CountEdibleNonToxicPlantWithBerries;
        public static int CountEdibleToxicPlantWithBerries;

        public static int CountEdibleToxicPlantWithoutBerries;

        public static int CountEdibleNonToxicPlantWithoutBerries;

        public static int CountInediblePlantWithBerries;
        public static int CountInediblePlantWithoutBerries;

        public static char[] GenderOfAnimal = {'m', 'w'};

        private int _localCounter = 0;

        private readonly Array _growthStage = Enum.GetValues(typeof(EnumStagesOfGrowth));
        
        private static Char GetRandomGender()
        {
            return GenderOfAnimal[SimulationEngine.Rnd.Next(0, GenderOfAnimal.Length)];
        }

        private void GenerateNewHuman()
        {
            while (_localCounter != CountHuman)
            {
                _localCounter++;

                var subspecies = GetRandomOfSubspecies(SimulationEngine.Rnd.Next(9, 11));
                char gender;

                if (subspecies == EnumOfAnimals.Man)
                {
                    gender = GenderOfAnimal[0];
                }

                else
                {
                    gender = GenderOfAnimal[1];
                }

                World.ListOfHumans.Add(new Human(GetRandomPosition(), true,
                    gender, GetTheAppearanceOfAnimal(subspecies), EnumOfEntities.Human, subspecies));
            }

            _localCounter = 0;
        }
        private void GenerateNewOmnivorousAnimal()
        {
            while (_localCounter != CountOmnivorousAnimal)
            {
                _localCounter++;

                var subspecies = GetRandomOfSubspecies(SimulationEngine.Rnd.Next(6, 9));

                World.ListOfOmnivorousAnimals.Add(new OmnivorousAnimal(GetRandomPosition(), true,
                    GetRandomGender(), GetTheAppearanceOfAnimal(subspecies), EnumOfEntities.OmnivorousAnimal, subspecies));
            }

            _localCounter = 0;
        }

        private void GenerateNewCarnivorousAnimal()
        {
            while (_localCounter != CountCarnivorousAnimal)
            {
                _localCounter++;

                var subspecies = GetRandomOfSubspecies(SimulationEngine.Rnd.Next(3, 6));

                World.ListOfCarnivorousAnimals.Add(new CarnivorousAnimal(GetRandomPosition(), true,
                    GetRandomGender(), GetTheAppearanceOfAnimal(subspecies), EnumOfEntities.CarnivorousAnimal, subspecies));
            }

            _localCounter = 0;
        }

        private void GenerateNewHerbivorousAnimal()
        {
            while (_localCounter != CountHerbivorousAnimal)
            {
                _localCounter++;

                var subspecies = GetRandomOfSubspecies(SimulationEngine.Rnd.Next(0, 3));

                World.ListOfHerbivorousAnimals.Add(new HerbivorousAnimal(GetRandomPosition(), true,
                    GetRandomGender(), GetTheAppearanceOfAnimal(subspecies), EnumOfEntities.HerbivorousAnimal, subspecies));
            }

            _localCounter = 0;
        }

        private EnumOfAnimals GetRandomOfSubspecies(int num)
        {
            switch (num)
            {
                case 0:
                    return EnumOfAnimals.Cow;
                case 1:
                    return EnumOfAnimals.Rabbit;
                case 2:    
                    return EnumOfAnimals.Beaver;
                case 3:    
                    return EnumOfAnimals.Wolf;
                case 4:   
                    return EnumOfAnimals.Leopard;
                case 5:    
                    return EnumOfAnimals.Bobcat;
                case 6:    
                    return EnumOfAnimals.Mouse;
                case 7:    
                    return EnumOfAnimals.Panda;
                case 8:   
                    return EnumOfAnimals.Hedgehog;
                case 9:   
                    return EnumOfAnimals.Woman;
                case 10:   
                    return EnumOfAnimals.Man;
            }

            return EnumOfAnimals.Cow;
        }
        
        private Bitmap GetTheAppearanceOfAnimal(EnumOfAnimals type)
        {
            return type switch
            {
                EnumOfAnimals.Woman => ImageOfEntity.Woman,
                EnumOfAnimals.Man => ImageOfEntity.Man,
                EnumOfAnimals.Cow => ImageOfEntity.Cow,
                EnumOfAnimals.Rabbit => ImageOfEntity.Rabbit,
                EnumOfAnimals.Beaver => ImageOfEntity.Beaver,
                EnumOfAnimals.Bobcat => ImageOfEntity.Bobcat,
                EnumOfAnimals.Wolf => ImageOfEntity.Wolf,
                EnumOfAnimals.Leopard => ImageOfEntity.Leopard,
                EnumOfAnimals.Mouse => ImageOfEntity.Mouse,
                EnumOfAnimals.Panda => ImageOfEntity.Panda,
                EnumOfAnimals.Hedgehog => ImageOfEntity.Hedgehog,
            };

        }

        private void GenerateNewEdibleNonToxicPlantWithBerries()
        {
            while (_localCounter != CountEdibleNonToxicPlantWithBerries)
            {
                _localCounter++;

                var growthStage =
                    (EnumStagesOfGrowth) _growthStage.GetValue(SimulationEngine.Rnd.Next(_growthStage.Length));

                World.ListOfEdiblePlants.Add(new EdibleNonToxicPlantWithBerries(GetRandomPosition(), growthStage
                    , GetTheAppearanceOfEdibleNonToxicPlantWithBerries(growthStage), EnumOfEntities.EdibleNonToxicPlantWithBerries));
            }

            _localCounter = 0;
        }

        private Bitmap GetTheAppearanceOfEdibleNonToxicPlantWithBerries(EnumStagesOfGrowth stage)
        {
            return stage switch
            {
                EnumStagesOfGrowth.Seed => ImageOfEntity.Seed,
                EnumStagesOfGrowth.Sprout => ImageOfEntity.EdibleSproutNonToxicPlantWithBerrie,
                EnumStagesOfGrowth.AdultPlants => ImageOfEntity.EdibleAdultNonToxicPlantWithBerrie,
                EnumStagesOfGrowth.DyingPlants => ImageOfEntity.EdibleDyingNonToxicPlantWithBerrie
            };
        }

        private void GenerateNewEdibleToxicPlantWithBerries()
        {
            while (_localCounter != CountEdibleToxicPlantWithBerries)
            {
                _localCounter++;

                var growthStage =
                    (EnumStagesOfGrowth) _growthStage.GetValue(SimulationEngine.Rnd.Next(_growthStage.Length));

                World.ListOfEdiblePlants.Add(new EdibleToxicPlantWithBerries(GetRandomPosition(),
                    growthStage, GetTheAppearanceOfEdibleToxicPlantWithBerries(growthStage), EnumOfEntities.EdibleToxicPlantWithBerries));
            }

            _localCounter = 0;
        }

        private Bitmap GetTheAppearanceOfEdibleToxicPlantWithBerries(EnumStagesOfGrowth stage)
        {
            return stage switch
            {
                EnumStagesOfGrowth.Seed => ImageOfEntity.Seed,
                EnumStagesOfGrowth.Sprout => ImageOfEntity.EdibleSproutToxicPlantWithBerrie,
                EnumStagesOfGrowth.AdultPlants => ImageOfEntity.EdibleAdultToxicPlantWithBerrie,
                EnumStagesOfGrowth.DyingPlants => ImageOfEntity.EdibleDyingToxicPlantWithBerrie
            };
        }

        private void GenerateNewEdibleToxicPlantWithoutBerries()
        {
            while (_localCounter != CountEdibleToxicPlantWithoutBerries)
            {
                _localCounter++;

                var growthStage =
                    (EnumStagesOfGrowth) _growthStage.GetValue(SimulationEngine.Rnd.Next(_growthStage.Length));

                World.ListOfEdiblePlants.Add(new EdibleToxicPlantWithoutBerries(GetRandomPosition(),
                    growthStage, GetTheAppearanceOfEdibleToxicPlantWithoutBerries(growthStage), EnumOfEntities.EdibleToxicPlantWithoutBerries));
            }

            _localCounter = 0;
        }

        private Bitmap GetTheAppearanceOfEdibleToxicPlantWithoutBerries(EnumStagesOfGrowth stage)
        {
            return stage switch
            {
                EnumStagesOfGrowth.Seed => ImageOfEntity.Seed,
                EnumStagesOfGrowth.Sprout => ImageOfEntity.EdibleSproutToxicPlantWithoutBerrie,
                EnumStagesOfGrowth.AdultPlants => ImageOfEntity.EdibleAdultToxicPlantWithoutBerrie,
                EnumStagesOfGrowth.DyingPlants => ImageOfEntity.EdibleDyingToxicPlantWithoutBerrie
            };
        }

        private void GenerateNewEdibleNonToxicPlantWithoutBerries()
        {
            while (_localCounter != CountEdibleNonToxicPlantWithoutBerries)
            {
                _localCounter++;

                var growthStage =
                    (EnumStagesOfGrowth) _growthStage.GetValue(SimulationEngine.Rnd.Next(_growthStage.Length));

                World.ListOfEdiblePlants.Add(new EdibleNonToxicPlantWithoutBerries(GetRandomPosition(), growthStage,
                    GetTheAppearanceOfEdibleNonToxicPlantWithoutBerries(growthStage), EnumOfEntities.EdibleNonToxicPlantWithoutBerries
                ));
            }

            _localCounter = 0;
        }

        private Bitmap GetTheAppearanceOfEdibleNonToxicPlantWithoutBerries(EnumStagesOfGrowth stage)
        {
            return stage switch
            {
                EnumStagesOfGrowth.Seed => ImageOfEntity.Seed,
                EnumStagesOfGrowth.Sprout => ImageOfEntity.EdibleSproutNonToxicPlantWithoutBerrie,
                EnumStagesOfGrowth.AdultPlants => ImageOfEntity.EdibleAdultNonToxicPlantWithoutBerrie,
                EnumStagesOfGrowth.DyingPlants => ImageOfEntity.EdibleDyingNonToxicPlantWithoutBerrie
            };
        }

        private void GenerateNewInediblePlantWithBerries()
        {
            while (_localCounter != CountInediblePlantWithBerries)
            {
                _localCounter++;

                var growthStage =
                    (EnumStagesOfGrowth) _growthStage.GetValue(SimulationEngine.Rnd.Next(_growthStage.Length));

                World.ListOfInediblePlants.Add(new InediblePlantWithBerries(GetRandomPosition(),
                    growthStage, GetTheAppearanceOfInediblePlantWithBerries(growthStage), EnumOfEntities.InediblePlantWithBerries));
            }

            _localCounter = 0;
        }

        private Bitmap GetTheAppearanceOfInediblePlantWithBerries(EnumStagesOfGrowth stage)
        {
            return stage switch
            {
                EnumStagesOfGrowth.Seed => ImageOfEntity.Seed,
                EnumStagesOfGrowth.Sprout => ImageOfEntity.InedibleSproutPlantWithBerrie,
                EnumStagesOfGrowth.AdultPlants => ImageOfEntity.InedibleAdultPlantWithBerrie,
                EnumStagesOfGrowth.DyingPlants => ImageOfEntity.InedibleDyingPlantWithBerrie
            };
        }

        private void GenerateNewInediblePlantWithoutBerries()
        {
            while (_localCounter != CountInediblePlantWithoutBerries)
            {
                _localCounter++;

                var growthStage =
                    (EnumStagesOfGrowth) _growthStage.GetValue(SimulationEngine.Rnd.Next(_growthStage.Length));

                World.ListOfInediblePlants.Add(new InediblePlantWithoutBerries(GetRandomPosition(),
                    growthStage, GetTheAppearanceOfInediblePlantWithoutBerries(growthStage), EnumOfEntities.InediblePlantWithoutBerries));
            }

            _localCounter = 0;
        }

        private Bitmap GetTheAppearanceOfInediblePlantWithoutBerries(EnumStagesOfGrowth stage)
        {
            return stage switch
            {
                EnumStagesOfGrowth.Seed => ImageOfEntity.Seed,
                EnumStagesOfGrowth.Sprout => ImageOfEntity.InedibleSproutPlantWithoutBerrie,
                EnumStagesOfGrowth.AdultPlants => ImageOfEntity.InedibleAdultPlantWithoutBerrie,
                EnumStagesOfGrowth.DyingPlants => ImageOfEntity.InedibleDyingPlantWithoutBerrie
            };
        }

        public void GenerateNewEntity()
        {
            InitializeQuantitativeData();
            
            GenerateNewOmnivorousAnimal();
            GenerateNewCarnivorousAnimal();
            GenerateNewHerbivorousAnimal();
            GenerateNewHuman();

            GenerateNewEdibleNonToxicPlantWithBerries();
            GenerateNewEdibleToxicPlantWithBerries();

            GenerateNewEdibleToxicPlantWithoutBerries();
            GenerateNewEdibleNonToxicPlantWithoutBerries();

            GenerateNewInediblePlantWithBerries();
            GenerateNewInediblePlantWithoutBerries();
        }

        private void InitializeQuantitativeData()
        {
            CountCarnivorousAnimal = World.StartingNumberOfCarnivorousAnimal;
            CountHerbivorousAnimal = World.StartingNumberOfHerbivorousAnimal;
            CountOmnivorousAnimal = World.StartingNumberOfOmnivorousAnimal;
            CountHuman = World.StartingNumberOfHuman;
            
            CountEdibleNonToxicPlantWithBerries = World.StartingNumberOfEdibleNonToxicPlantWithBerries;
            CountEdibleToxicPlantWithBerries = World.StartingNumberOfEdibleToxicPlantWithBerries;
            
            CountEdibleToxicPlantWithoutBerries = World.StartingNumberOfEdibleToxicPlantWithoutBerries;
            CountEdibleNonToxicPlantWithoutBerries = World.StartingNumberOfEdibleNonToxicPlantWithoutBerries;
            
            CountInediblePlantWithBerries = World.StartingNumberOfInediblePlantWithBerries;
            CountInediblePlantWithoutBerries = World.StartingNumberOfInediblePlantWithoutBerries;
        }


        private Cell GetRandomPosition()
        {
            var randomPosition = World.Map[SimulationEngine.Rnd.Next(0, World.Map.Count)];

            while (CheckAdjacentPositions(randomPosition.X, randomPosition.Y))
            {
                randomPosition = World.Map[SimulationEngine.Rnd.Next(0, World.Map.Count)];
            }

            return randomPosition;
        }

        private static bool CheckAdjacentPositions(int x, int y)
        {
            return World.ListOfCarnivorousAnimals.Any(a => x == a.X && y == a.Y)
                   || World.ListOfOmnivorousAnimals.Any(a => x == a.X && y == a.Y)
                   || World.ListOfHerbivorousAnimals.Any(a => x == a.X && y == a.Y)
                   || World.ListOfInediblePlants.Any(p => x == p.X && y == p.Y)
                   || World.ListOfEdiblePlants.Any(p => x == p.X && y == p.Y);
        }
    }
}
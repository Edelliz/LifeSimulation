using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;

namespace Simulation_of_life
{
    public class SimulationEngine
    {
        public static Random Rnd = new();
        private GeneratingNewEntity _newEntity = new();
        
        public static EnumOfSeasons currentSeasons;
        public static EnumOfSeasons previousSeasons;

        private int _tickCounterForSeasons = 0;

        public void InitializeMap()
        {
            for (int x = 0; x < World._sizeOfWorld; x += World.SizeCell)
            {
                for (int y = 0; y < World._sizeOfWorld; y += World.SizeCell)
                {
                    World.Map.Add(new Cell(x, y));
                }
            }

            World.Summer = new Summer();

            _newEntity.GenerateNewEntity();
        }
        
        public void SimulateNewState()
        {
            DetermineTheTimeOfTheYear();

            PokePlants();
            PokeAnimals();
        }

        private void PokeAnimals()
        {
            var _animals = World.ListOfCarnivorousAnimals.Concat<Animal>(World.ListOfHerbivorousAnimals)
                .Concat(World.ListOfOmnivorousAnimals).Concat(World.ListOfHumans).ToList();
            
            foreach (var t in  _animals)
            {
                t.Move();
            }

            
        }
        private void PokePlants()
        {
            var _plants = World.ListOfEdiblePlants.Concat<Plant>(World.ListOfInediblePlants).ToList();

            foreach (var t in _plants)
            {
                t.Move();
            }

            foreach (var t in World.ListOfBerries.ToList())
            {
                t.Move();
            }
        }

        private bool _isTheFirstSeason = true;

        private void IsTheFirstSeasonOfTheGame()
        {
            if (_isTheFirstSeason)
            {
                currentSeasons = EnumOfSeasons.Winter;
                previousSeasons = currentSeasons;

                _isTheFirstSeason = false;
            }
        }
        private void DetermineTheTimeOfTheYear()
        {
            switch (_tickCounterForSeasons)
            {
                case 0:
                    World.Summer = new Summer();

                    IsTheFirstSeasonOfTheGame();

                    previousSeasons = currentSeasons;
                    currentSeasons = EnumOfSeasons.Summer;
                    break;

                case 100:
                    World.Winter = new Winter();

                    previousSeasons = currentSeasons;
                    currentSeasons = EnumOfSeasons.Winter;               
                    break;

                case 200:
                    World.Spring = new Spring();

                    previousSeasons = currentSeasons;
                    currentSeasons = EnumOfSeasons.Spring;
                    break;

                case 300: _tickCounterForSeasons = -1;
                    break;
            }

            _tickCounterForSeasons++;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Simulation_of_life
{
    public class CarnivorousAnimal : Animal
    {
        
        private  List<Animal> _listOfEdibleAnimals;
        public CarnivorousAnimal(Cell position, bool abilityToReproduce, char gender, Bitmap currentImage, EnumOfEntities type, EnumOfAnimals subspecies)
            : base(position, abilityToReproduce, gender, currentImage, type, subspecies)
        {
            Hp = SimulationEngine.Rnd.Next(400, 600);
            FullHp = Hp;
            ReproductionThreshold = (int) (World.StartingNumberOfCarnivorousAnimal * RatioReproduction);
            
            NutritionalValue = SimulationEngine.Rnd.Next(20, 70);
        }

        
        protected override bool IsGoal(int x, int y)
        {
            _listOfEdibleAnimals = (List<Animal>) World.ListOfHerbivorousAnimals.Concat<Animal>(World.ListOfOmnivorousAnimals).ToList();

            foreach (var t in _listOfEdibleAnimals.Where(t => t.X == x && t.Y == y && (t.GetType() != typeof(CarnivorousAnimal))))
            {
                NutritionalValueOfVictim = t.NutritionalValue;
                SetGoal(t);

                return true;
            }

            return false;
        }

        protected override void CheckReproductionRates()
        {
            if (AbilityToReproduce == true)
            {
                LookingForPartner();
            }
        }

        protected override void Eat()
        {
            Satiety += NutritionalValueOfVictim;
            Hp = FullHp;

            KillTheGoal();
        }
        
        protected override void DefineFoodSearch()
        {
            
            if (isFirstSearchForCarnivorousFood == 0)
            {
                SearchOfGoal(World.SizeCell, IsGoal);
                ChangeCoordinatesOfGoal(ref isFirstSearchForCarnivorousFood);
            }
            
            base.DefineFoodSearch();
        }

        public override void Die(Entity animal)
        {
            World.ListOfCarnivorousAnimals.Remove(this);
            
        }

        protected override bool IsPartner(int x, int y)
        {
            foreach (var t in World.ListOfCarnivorousAnimals.Where(t =>
                         t.X == x && t.Y == y 
                         && (t.GetType() == this.GetType()) && (this.Gender != t.Gender) && (this.AbilityToReproduce == true)
                         && (t.AbilityToReproduce == true)
                         && (IsLover == false)
                         && t.IsLover == false
                         && CurrentImage == t.CurrentImage))
            {
                Lover = t;
                Lover.Lover = this;

                IsLover = true;
                Lover.IsLover = true;
                
                SetReproductionParameters();

                return true;
            }

            return false;
        }
        protected override void Reproduce()
        {
            if (World.ListOfCarnivorousAnimals.Count >= ReproductionThreshold)
            {
                return;
            }
            
            base.Reproduce();

            World.ListOfCarnivorousAnimals.Add(new CarnivorousAnimal(new Cell(X, Y), true,
                GeneratingNewEntity.GenderOfAnimal[SimulationEngine.Rnd.Next(0, GeneratingNewEntity.GenderOfAnimal.Length)], CurrentImage, _typeOfThis, Subspecies));
        }
    }
}
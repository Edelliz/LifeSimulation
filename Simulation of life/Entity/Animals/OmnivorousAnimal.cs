using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Simulation_of_life
{
    public class OmnivorousAnimal : Animal
    {
        public Human Owner = null;
        private  List<Animal> _listOfEdibleAnimals;
        public OmnivorousAnimal(Cell position, bool abilityToReproduce, char gender, Bitmap currentImage, EnumOfEntities type, EnumOfAnimals subspecies)
            : base(position, abilityToReproduce, gender, currentImage, type, subspecies)
        {
            
            Hp = SimulationEngine.Rnd.Next(700, 1000);
            FullHp = Hp;
            ReproductionThreshold = (int) (World.StartingNumberOfOmnivorousAnimal * RatioReproduction);
            
            NutritionalValue = SimulationEngine.Rnd.Next(20, 70);
        }
        
        protected override bool IsGoal(int x, int y)
        {
            _listOfEdibleAnimals =  World.ListOfHerbivorousAnimals.Concat<Animal>(World.ListOfCarnivorousAnimals).Concat(World.ListOfHumans).ToList();
            foreach (var t in World.ListOfEdiblePlants.Where(t => t.X == x && t.Y == y && t.CurrentStageOfGrowth != EnumStagesOfGrowth.Seed))
            {
                
                SetGoal(t);
                NutritionalValueOfVictim = t.GetNutritionalValue();

                return true;
            }

            foreach (var t in World.ListOfBerries.Where(t =>
                t.GetPosition.X == x && t.GetPosition.Y == y
                                     && t.GetType() != typeof(InedibleBerrie)))
            {
                GoalOfBerries = t;

                GoalX = t.GetPosition.X;
                GoalY = t.GetPosition.Y;

                NutritionalValueOfVictim = t.NutritionalValue;

                return true;
            }

            foreach (var t in _listOfEdibleAnimals.Where(t => t.X == x && t.Y == y && (t.GetType() != typeof(OmnivorousAnimal))))
            {
                if (Owner != null && t.GetType() == typeof(Human))
                {
                    return false;
                }
                     
                SetGoal(t);
                        
                NutritionalValueOfVictim = 30;

                return true;
            }

            return false;
        }

        protected override void CheckReproductionRates()
        {
            if (World.ListOfOmnivorousAnimals.Count < ReproductionThreshold && AbilityToReproduce)
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

        protected override bool IsPartner(int x, int y)
        {
            foreach (var t in World.ListOfOmnivorousAnimals.Where(t =>
                t.X == x && t.Y == y
                         && (t.GetType() == GetType())
                         && (Gender != t.Gender)
                         && (AbilityToReproduce)
                         && (t.AbilityToReproduce)
                         && (IsLover == false) && t.IsLover == false && CurrentImage == t.CurrentImage))
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

        public override void Move()
        {
            base.Move();

            if (Owner != null && Satiety >= SatietyThreshold)
            {
                Goal = Owner;
                GoalX = Owner.X;
                GoalY = Owner.Y;
                
                ChooseTypeOfMovement();
            }
        }

        protected override void DefineFoodSearch()
        {
            if (Owner != null && (Owner._inventory.AmountOfMeat != 0 || Owner._inventory.SectionWithEdiblePlants.Count != 0))
            {
                Goal = Owner;
                GoalX = Owner.X;
                GoalY = Owner.Y;
                
                ChooseTypeOfMovement();
                
                if (X == GoalX && Y == GoalY)
                {
                    AskForFood();
                    return;
                }
            }
            else if (isFirstSearchForOmnivorousFood == 0)
            {
                SearchOfGoal(World.SizeCell, IsGoal);
                ChangeCoordinatesOfGoal(ref isFirstSearchForOmnivorousFood);
            }
            
            if (Goal == null && GoalOfBerries == null)
            {
                RandomMove();
                return;
            }

            ChooseTypeOfMovement();

            if (X == GoalX && Y == GoalY && (Goal != null || GoalOfBerries != null))
            {
                Eat();
                ResetCurrentParameters();
            }
        }

        private void AskForFood()
        {
            if (Owner._inventory.AmountOfMeat > 0)
            {
                Satiety += Owner._inventory.GetAPieceOfMeat();
                Owner._inventory.AmountOfMeat--;
                
            }

            else if (Owner._inventory.SectionWithEdiblePlants.Count > 0)
            {
                foreach (var p in Owner._inventory.SectionWithEdiblePlants.ToList()
                    .Where(p => p._typeOfThis == EnumOfEntities.EdibleNonToxicPlantWithBerries
                    || p._typeOfThis == EnumOfEntities.EdibleNonToxicPlantWithoutBerries))
                {
                    Satiety += Owner._inventory.SectionWithEdiblePlants[0].NutritionalValue;
                    Owner._inventory.SectionWithEdiblePlants.Remove(Owner._inventory.SectionWithEdiblePlants[0]);
                    
                    return;
                }
            }
        }

        public override void Die(Entity animal)
        {
            World.ListOfOmnivorousAnimals.Remove(this);
        }

        protected override void Reproduce()
        {
            if (World.ListOfOmnivorousAnimals.Count >= ReproductionThreshold)
            {
                return;
            }
            
            base.Reproduce();

            var genderChild =
                GeneratingNewEntity.GenderOfAnimal[
                    SimulationEngine.Rnd.Next(0, GeneratingNewEntity.GenderOfAnimal.Length)];

            World.ListOfOmnivorousAnimals.Add(new OmnivorousAnimal(new Cell(X, Y), true,
                genderChild, CurrentImage, _typeOfThis, Subspecies));
        }
    }
}
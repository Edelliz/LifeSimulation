using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Simulation_of_life
{
    public class Human : Animal
    {
        private List<Animal> _listOfEdibleAnimals;
        public readonly Inventory _inventory = new();
        
        private int isFirstSearchForHumanFood;
        private readonly bool theDesireToHaveAnAnimal;
        
        private int _countersForReproduction = 10;

        public Human(Cell position, bool abilityToReproduce, char gender, Bitmap currentImage,
            EnumOfEntities type, EnumOfAnimals subspecies) : base(position, abilityToReproduce, gender, currentImage,
            type, subspecies)
        {
            SetParametersOfFirstOccurrence();

            Hp = 200;
            FullHp = Hp;
            ReproductionThreshold = (int) (World.StartingNumberOfHuman * RatioReproduction);

            NutritionalValue = SimulationEngine.Rnd.Next(30, 90);
            NutritionalValue = 100;

            theDesireToHaveAnAnimal = SimulationEngine.Rnd.Next(2) == 1;
        }
        
        
        private bool IsResource(int x, int y)
        {
            var listOfEdibleAnimals = World.ListOfHerbivorousAnimals
                .Concat<Animal>(World.ListOfCarnivorousAnimals)
                .Concat(World.ListOfOmnivorousAnimals).ToList();


            foreach (var t in World.ListOfEdiblePlants.Concat<Plant>(World.ListOfInediblePlants)
                .Where(t => t.X == x && t.Y == y))
            {
                SetGoal(t);
                
                return true;
            }

            foreach (var t in World.ListOfBerries.Where(t => t.GetPosition.X == x && t.GetPosition.Y == y))
            {
                GoalOfBerries = t;

                GoalX = t.GetPosition.X;
                GoalY = t.GetPosition.Y;

                return true;
            }

            foreach (var t in listOfEdibleAnimals.Where(t =>
                t.X == x && t.Y == y && (t.GetType() != typeof(Human))))
            {
                SetGoal(t);

                return true;
            }

            return false;
        }
        
        private bool TameAnAnimal(int x, int y)
        {
            if (_inventory.AmountOfMeat == 0)
            {
                return false;
            }

            foreach (var t in World.ListOfOmnivorousAnimals.Where(t => t.X == x && t.Y == y))
            {
                t.Satiety += _inventory.GetAPieceOfMeat();
                _inventory.AmountOfMeat -= _inventory.GetAPieceOfMeat();
                t.Owner = this;
                _pet = t;

                return true;
            }

            return false;
        }
        
        protected override bool IsGoal(int x, int y)
        {
            _listOfEdibleAnimals = World.ListOfHerbivorousAnimals
                .Concat<Animal>(World.ListOfCarnivorousAnimals)
                .Concat(World.ListOfCarnivorousAnimals).ToList();


            foreach (var t in World.ListOfEdiblePlants.Where(t => t.X == x && t.Y == y))
            {
                if (t.GetType() == typeof(EdibleToxicPlantWithBerries) ||
                    t.GetType() == typeof(EdibleToxicPlantWithoutBerries))
                {
                    continue;
                }
                
                SetGoal(t);

                NutritionalValueOfVictim = t.GetNutritionalValue();
                return true;
            }

            foreach (var t in World.ListOfBerries.Where(t =>
                t.GetPosition.X == x && t.GetPosition.Y == y
                                     && t.GetType() != typeof(InedibleBerrie)))
            {
                if (t.GetType() == typeof(EdibleToxicBerrie))
                {
                    continue;
                }
                
                GoalOfBerries = t;
                GoalX = t.GetPosition.X;
                GoalY = t.GetPosition.Y;
                
                NutritionalValueOfVictim = t.NutritionalValue;

                return true;
            }

            foreach (var t in _listOfEdibleAnimals.Where(t => t.X == x && t.Y == y && t != _pet && (t.GetType() != typeof(Human))))
            {
                SetGoal(t);
                NutritionalValueOfVictim = t.NutritionalValue;
                
                return true;
            }
            
            return false;
        }
        
        protected override void Eat()
        {
            Satiety += NutritionalValueOfVictim;

            Goal?.Die(Goal);
            GoalOfBerries?.Die();

            Goal = null;
            GoalOfBerries = null;
        }

        protected override void CheckReproductionRates()
        {
            _countersForReproduction--;
            if (_countersForReproduction != 0)
            {
                return;
            }

            if (Lover != null)
            {
                SetReproductionParameters();
            }

            else
            {
                LookingForPartner();
            }

            _countersForReproduction = 10;
        }

        protected override bool IsPartner(int x, int y)
        {
            foreach (var t in World.ListOfHumans.Where(t =>
                t.X == x && t.Y == y
                         && (t.GetType() == GetType())
                         && (Gender != t.Gender)
                         && (AbilityToReproduce)
                         && (t.AbilityToReproduce)
                         && (IsLover == false) && t.IsLover == false && this.Subspecies != t.Subspecies))
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
        
        private void SearchForResources()
        {
            SearchOfGoal(World.SizeCell, IsResource);
            CreateMedicine();
        }

        private void CreateMedicine()
        {
            if (_inventory.SectionWithInediblePlants.Count > 0 && _inventory.SectionWithEdiblePlants.Count > 0)
            {
                var randomIndex = SimulationEngine.Rnd.Next(_inventory.SectionWithInediblePlants.Count);
                var randomItem = _inventory.SectionWithInediblePlants[randomIndex];
                
                _inventory.SectionWithInediblePlants.Remove(randomItem);
                _inventory.Fullness--;

                foreach (var p in _inventory.SectionWithEdiblePlants)
                {
                    if (p.GetType() == typeof(EdibleToxicPlantWithoutBerries))
                    {
                        _inventory.SectionWithEdiblePlants.Remove(p);
                        _inventory.Fullness--;
                        break;
                    }
                    else
                    {
                        randomIndex = -1;
                    }
                }

                if (randomIndex != -1)
                {
                    _inventory.Fullness++;
                    _inventory.SectionWithMedicines.Add(new Medicine());
                }
            }
        }

        protected override void Reproduce()
        {
            if (World.ListOfHumans.Count >= ReproductionThreshold)
            {
                return;
            }

            var genderChild = GeneratingNewEntity.GenderOfAnimal[SimulationEngine.Rnd.Next(0, GeneratingNewEntity.GenderOfAnimal.Length)];

            Bitmap imageChild = CurrentImage;
            EnumOfAnimals subspeciesChild = Subspecies;

            DetermineTheGenderOfTheChild(ref genderChild, ref imageChild, ref subspeciesChild);

            World.ListOfHumans.Add(new Human(new Cell(X, Y), true,
                genderChild, imageChild, _typeOfThis, subspeciesChild));
        }

        private void DetermineTheGenderOfTheChild(ref char gender, ref Bitmap img, ref EnumOfAnimals subspecies)
        {
            if (img == null) throw new ArgumentNullException(nameof(img));
            
            if (gender == GeneratingNewEntity.GenderOfAnimal[0])
            {
                img = ImageOfEntity.Man;
                subspecies = EnumOfAnimals.Man;
            }
            else
            {
                img = ImageOfEntity.Woman;
                subspecies = EnumOfAnimals.Woman;
            }
        }


        private bool CheckTheTypeOfAnimal(EnumOfEntities e)
        {
            return e switch
            {
                EnumOfEntities.CarnivorousAnimal => true,
                EnumOfEntities.OmnivorousAnimal => true,
                EnumOfEntities.HerbivorousAnimal => true,
                _ => false,
            };
        }

        private void PutInTheInventory()
        {
            if (Goal == null)
            {
                return;
            }
            
            _inventory.Fullness++;
            
            if (Goal != null && CheckTheTypeOfAnimal(Goal._typeOfThis))
            {
                _inventory.AmountOfMeat += SimulationEngine.Rnd.Next(1, 10);
                KillTheGoal();
                
                return;
            }

            if (Goal != null && CheckTheTypeOfPlant(Goal._typeOfThis))
            {
                _inventory.SectionWithEdiblePlants.Add((EdiblePlant) Goal);
                KillTheGoal();
                
                return;
            }

            if (Goal != null && (Goal.GetType() == typeof(EdibleToxicBerrie) || Goal.GetType() == typeof(EdibleNonToxicBerrie) || Goal.GetType() == typeof(InedibleBerrie)))
            {
                _inventory.SectionWithBerries.Add(GoalOfBerries);
                KillTheGoal();
                    
                return;
            }
            
            _inventory.SectionWithInediblePlants.Add((InediblePlant) Goal);
            KillTheGoal();
        }
        
        private bool CheckTheTypeOfPlant(EnumOfEntities e)
        {
            return e switch
            {
                EnumOfEntities.InediblePlantWithBerries => false,
                EnumOfEntities.InediblePlantWithoutBerries => false,
                EnumOfEntities.EdibleNonToxicPlantWithBerries => true,
                EnumOfEntities.EdibleNonToxicPlantWithoutBerries => true,
                EnumOfEntities.EdibleToxicPlantWithBerries => true,
                EnumOfEntities.EdibleToxicPlantWithoutBerries => true,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }


        public OmnivorousAnimal _pet;

        public override void Move()
        {
            SetSeasonalParameters();

            CheckReproductionRates();
            RestoreAbilityToReproduce();

            TopUpHp();

            if (theDesireToHaveAnAnimal && _pet == null)
            {
                SearchOfGoal(World.SizeCell, TameAnAnimal);
            }

            //Перемещение в сторону партнера
            if (IsLover && Lover != null && Satiety >= SatietyThreshold)
            {
                GoalX = Lover.X;
                GoalY = Lover.Y;
                ChooseTypeOfMovement();

                if (X == Lover.X && Y == Lover.Y)
                {
                    Reproduce();
                }
            }

            //Свободное перемещение животного
            else if (Satiety >= SatietyThreshold || World.ListOfEdiblePlants.Count == 0)
            {
                if (_inventory.Fullness <= _inventory.Capacity)
                {
                    if (isFirstSearchForHumanFood == 0)
                    {
                        SearchForResources();
                        ChangeCoordinatesOfGoal(ref isFirstSearchForHumanFood);
                    }

                    ChooseTypeOfMovement();

                    if (X == GoalX && Y == GoalY && (Goal != null || GoalOfBerries != null))
                    {
                        PutInTheInventory();
                        ResetCurrentParameters();
                    }
                }
                else
                {
                    RandomMove();
                }
            }

            //Перемещение к еде
            else if (Satiety < SatietyThreshold)
            {
                if (IsThereAnyEdibleFoodInTheInventory())
                {
                    return;
                }

                if (isFirstSearchForHumanFood == 0)
                {
                    SearchOfGoal(World.SizeCell, IsGoal);
                    ChangeCoordinatesOfGoal(ref isFirstSearchForHumanFood);
                }

                if (Goal == null && GoalOfBerries == null)
                {
                    RandomMove();
                }

                ChooseTypeOfMovement();

                if (X == GoalX && Y == GoalY && (Goal != null || GoalOfBerries != null))
                {
                    Eat();
                    ResetCurrentParameters();
                }
            }

            if (Goal == null)
            {
                RandomMove();
            }
        }
        
        protected override void ResetCurrentParameters()
        {
            isFirstSearchForHumanFood = 0;
            Goal = null;
            GoalOfBerries = null;
        }
        
        private bool IsThereAnyEdibleFoodInTheInventory()
        {
            if (_inventory.AmountOfMeat > 0)
            {
                _inventory.Fullness--;
                Satiety += _inventory.GetAPieceOfMeat();
                _inventory.AmountOfMeat--;

                return true;
            }

            if (_inventory.SectionWithEdiblePlants.Count > 0)
            {
                foreach (var p in _inventory.SectionWithEdiblePlants.Where(p => p.GetType() == typeof(EdibleNonToxicPlantWithBerries) ||
                    p.GetType() == typeof(EdibleNonToxicPlantWithoutBerries)))
                {
                    _inventory.Fullness--;
                    Satiety += p.NutritionalValue;
                    _inventory.SectionWithEdiblePlants.Remove(p);

                    return true;
                }
            }

            if (_inventory.SectionWithBerries.Count > 0)
            {
                foreach (var p in _inventory.SectionWithBerries.Where(p => p.GetType() == typeof(EdibleNonToxicBerrie)))
                {
                    _inventory.Fullness--;
                    Satiety += p.NutritionalValue;
                    _inventory.SectionWithBerries.Remove(p);

                    return true;
                }
            }

            return false;
        }

        private void TopUpHp()
        {
            if (Hp < FullHp * 0.6 && _inventory.SectionWithMedicines.Count != 0)
            {
                Hp += _inventory.SectionWithMedicines[0].RestoringHealth;
                _inventory.Fullness--;
                _inventory.SectionWithMedicines.Remove(_inventory.SectionWithMedicines[0]);
            }
        }
        
        public override void Die(Entity entity)
        {
            World.ListOfHumans.Remove(this);
        }
    }
}
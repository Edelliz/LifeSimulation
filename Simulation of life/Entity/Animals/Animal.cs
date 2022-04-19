using System;
using System.Drawing;

namespace Simulation_of_life
{
    public abstract class Animal : Entity
    {
        protected readonly EnumOfAnimals Subspecies;

        protected int ReproductionThreshold;
        protected double RatioReproduction = 0.8;

        public Animal Lover;
        public bool IsLover;
        private int _counterToRestoreAbilityToReproduce = SimulationEngine.Rnd.Next(10, 30);

        private bool _isFirstEntryIntoGame = true;
        private readonly int fieldOfView = World.SizeCell * 12;

        private int _randomTypeOfMovement;
        private int _randomTypeOfRandomMovement;

        protected int isFirstSearchForCarnivorousFood;
        protected int isFirstSearchForOmnivorousFood;

        protected int GoalX;
        protected int GoalY;
        protected Entity Goal;
        protected Berrie GoalOfBerries;

        public int Satiety = SimulationEngine.Rnd.Next(25, 200);
        protected readonly int SatietyThreshold = SimulationEngine.Rnd.Next(100, 200);

        private int _deltaSatiety;
        private double ratioSatiety;

        protected int FullHp;
        protected int NutritionalValueOfVictim;
        public int NutritionalValue;

        private bool AccelerationOfAnimal = false;

        protected readonly char Gender;
        protected new readonly Bitmap CurrentImage;
        protected bool AbilityToReproduce;

        private bool isSleeper;

        private readonly RandomHerdMovement _movementHerd = new();

        protected Animal(Cell position, bool abilityToReproduce, char gender, Bitmap currentImage,
            EnumOfEntities type, EnumOfAnimals subspecies) : base(position, currentImage)
        {
            AbilityToReproduce = abilityToReproduce;
            Gender = gender;
            _typeOfThis = type;
            Subspecies = subspecies;

            this.CurrentImage = currentImage;
        }

        protected void RandomMove()
        {
            Satiety -= 1;
            ChooseTypeOfRandomMovement();
            CheckSatietyValue();
        }

        private void ChooseTypeOfRandomMovement()
        {
            switch (_randomTypeOfRandomMovement)
            {
                case 0:
                {
                    var movement = new RandomMovement();
                    movement.StartMoving(ref X, ref Y, GoalX, GoalY, _randomTypeOfMovement, AccelerationOfAnimal);
                    break;
                }
                case 1:
                {
                    var movementWithinRadius = new RandomMovementWithinRadius();
                    movementWithinRadius.StartMoving(ref X, ref Y, GoalX, GoalY, _randomTypeOfMovement,
                        AccelerationOfAnimal);
                    break;
                }
                case 2:
                {
                    _movementHerd.StartMoving(ref X, ref Y, GoalX, GoalY, _randomTypeOfMovement,
                        AccelerationOfAnimal);
                    break;
                }
            }
        }

        protected void SearchOfGoal(int searchWidth, Func<int, int, bool> isGoal)
        {
            Satiety -= 1;
            CheckSatietyValue();

            if (searchWidth >= fieldOfView)
            {
                return;
            }

            for (int x = X - searchWidth; x <= X + searchWidth; x += World.SizeCell)
            {
                if (FindLoverByCoordinate(0, searchWidth, ref x, ref Y, isGoal))
                {
                    return;
                }
            }

            for (var y = Y - searchWidth + World.SizeCell; y < Y + searchWidth; y += World.SizeCell)
            {
                if (FindLoverByCoordinate(searchWidth, 0, ref X, ref y, isGoal))
                {
                    return;
                }
            }

            SearchOfGoal(searchWidth + World.SizeCell, isGoal);
        }

        protected abstract bool IsGoal(int x, int y);
        protected abstract void Eat();

        public override void Move()
        {
            SetParametersOfFirstOccurrence();

            SetSeasonalParameters();
            if (isSleeper)
            {
                Hp = FullHp;
                return;
            }

            CheckReproductionRates();
            RestoreAbilityToReproduce();

            //Перемещение в сторону партнера
            if (IsLover && Lover != null)
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
                RandomMove();
            }

            //Перемещение к еде
            else if (Satiety < SatietyThreshold)
            {
                DefineFoodSearch();
            }

            if (Goal == null)
            {
                RandomMove();
            }
        }

        protected virtual void DefineFoodSearch()
        {
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
        protected void SetGoal(Entity t)
        {
            Goal = t;
            GoalX = Goal.X;
            GoalY = Goal.Y;
        }

        protected virtual void ResetCurrentParameters()
        {
            isFirstSearchForCarnivorousFood = 0;
            isFirstSearchForOmnivorousFood = 0;
            KillTheGoal();
        }


        protected void ChangeCoordinatesOfGoal(ref int checker)
        {
            if (Goal == null)
            {
                RandomMove();
            }
            else
            {
                GoalX = Goal.X;
                GoalY = Goal.Y;
                checker = 1;
            }
        }

        protected void SetParametersOfFirstOccurrence()
        {
            if (_isFirstEntryIntoGame)
            {
                _randomTypeOfMovement = SimulationEngine.Rnd.Next(0, 3);
                _randomTypeOfRandomMovement = SimulationEngine.Rnd.Next(0, 3);
                _randomTypeOfRandomMovement = 0;

                GoalX = X;
                GoalY = Y;

                _isFirstEntryIntoGame = false;
                if (_isFirstEntryIntoGame)
                {
                    SetParametersOfFirstOccurrence();
                }
            }
        }

        protected void SetSeasonalParameters()
        {
            if (SimulationEngine.currentSeasons == SimulationEngine.previousSeasons)
            {
                return;
            }

            switch (SimulationEngine.currentSeasons)
            {
                case EnumOfSeasons.Summer:
                    World.Summer.ChangeDeltaOfSatiety(ref _deltaSatiety);
                    World.Summer.ChangeReproductionThreshold(_typeOfThis, ref RatioReproduction);
                    World.Summer.ChangeSatietyTreshold(_typeOfThis, ref ratioSatiety);
                    World.Summer.ChangeTheImage(ref base.CurrentImage, Subspecies);
                    World.Summer.BecomeSleeper(ref isSleeper, Subspecies);
                    break;

                case EnumOfSeasons.Winter:
                    World.Winter.ChangeDeltaOfSatiety(ref _deltaSatiety);
                    World.Winter.ChangeReproductionThreshold(_typeOfThis, ref RatioReproduction);
                    World.Winter.ChangeSatietyTreshold(_typeOfThis, ref ratioSatiety);
                    World.Winter.ChangeTheImage(ref base.CurrentImage, Subspecies);
                    World.Winter.BecomeSleeper(ref isSleeper, Subspecies);
                    break;

                case EnumOfSeasons.Spring:
                    World.Spring.ChangeDeltaOfSatiety(ref _deltaSatiety);
                    World.Spring.ChangeReproductionThreshold(_typeOfThis, ref RatioReproduction);
                    World.Spring.ChangeSatietyTreshold(_typeOfThis, ref ratioSatiety);
                    World.Spring.ChangeTheImage(ref base.CurrentImage, Subspecies);
                    World.Spring.BecomeSleeper(ref isSleeper, Subspecies);
                    break;
            }
        }

        protected void ChooseTypeOfMovement()
        {
            switch (_randomTypeOfMovement)
            {
                case 0:
                {
                    var oneTurnMovement = new OneTurnMovement();
                    oneTurnMovement.MoveTowardsGoal(ref X, ref Y, GoalX, GoalY, AccelerationOfAnimal);
                    break;
                }
                case 1:
                {
                    var orthogonalMovement = new OrthogonalMovement();
                    orthogonalMovement.MoveTowardsGoal(ref X, ref Y, GoalX, GoalY, AccelerationOfAnimal);
                    break;
                }
                case 2:
                {
                    var fullMovement = new FullMovement();
                    fullMovement.MoveTowardsGoal(ref X, ref Y, GoalX, GoalY, AccelerationOfAnimal);
                    break;
                }
            }
        }

        private void CheckSatietyValue()
        {
            if (Satiety <= SatietyThreshold * 0.3)
            {
                Hp -= 2;
                IsLives();
            }
        }

        private void IsLives()
        {
            if (Hp <= 0 && Satiety <= 0)
            {
                Die(this);
            }
        }

        protected abstract void CheckReproductionRates();

        protected void LookingForPartner()
        {
            if (IsLover == false && AbilityToReproduce)
            {
                SearchOfGoal(World.SizeCell, IsPartner);
                ChooseTypeOfMovement();

                if (Lover == null)
                {
                    IsLover = false;
                    RandomMove();
                }

                else if (Lover != null)
                {
                    ChooseTypeOfMovement();
                }

                else if (X == Lover.X && Y == Lover.Y)
                {
                    Reproduce();
                }
            }
        }
        
        private bool FindLoverByCoordinate(int searchWidthX, int searchWidthY, ref int x, ref int y, Func<int, int, bool> isGoal)
        {
            if (isGoal(x - searchWidthX, y - searchWidthY))
            {
                return true;
            }

            if (isGoal(x + searchWidthX, y - searchWidthY))
            {
                return true;
            }

            return false;
        }
        
        protected abstract bool IsPartner(int x, int y);

        protected void SetReproductionParameters()
        {
            GoalX = Lover.X;
            GoalY = Lover.Y;

            Lover.GoalX = X;
            Lover.GoalY = Y;

            Lover.AbilityToReproduce = false;
            AbilityToReproduce = false;
        }

        protected void RestoreAbilityToReproduce()
        {
            if (AbilityToReproduce == false)
            {
                _counterToRestoreAbilityToReproduce--;
                if (_counterToRestoreAbilityToReproduce == 0)
                {
                    AbilityToReproduce = true;
                    _counterToRestoreAbilityToReproduce = 5;
                }
            }
        }
        
        protected void KillTheGoal()
        {
            if (GoalOfBerries != null)
            {
                GoalOfBerries.Die();
            }

            if (Goal != null)
            {
                Goal.Die(Goal);
            }

            Goal = null;
            GoalOfBerries = null;
        }

        protected override void Reproduce()
        {
            IsLover = false;
            Lover.IsLover = false;
        }
    }
}
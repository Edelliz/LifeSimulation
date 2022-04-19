using System;
using System.Drawing;
using System.Linq;

namespace Simulation_of_life
{
    public abstract class Plant : Entity
    {
        private int _currentAge = 0;
        protected int AgeOfSeed;
        protected int AgeOfSprout;
        protected int AgeOfMature;
        protected int AgeOfDying;
       
        protected double СoefficientReproduction;
        private bool isAbilityToLive = true;

        protected int NumberSeed = SimulationEngine.Rnd.Next(5, 12);

        protected Bitmap ImageOfSeed;
        protected Bitmap ImageOfSprout;
        protected Bitmap ImageOfMature;
        protected Bitmap ImageOfDying;
        public Bitmap CurrentImage;

        public EnumStagesOfGrowth CurrentStageOfGrowth;

        private bool _firstEntryIntoGrowthStage = true;

        private static readonly int Dx = World.SizeCell;
        private static readonly int Dy = World.SizeCell;
        
        private int _isFirstState = 0;

        protected static readonly Tuple<int, int>[] SeedPosition =
        {
            new (-Dx, -Dy),
            new (0, -Dy),
            new (Dx, -Dy),

            new (-Dx, -Dy),
            new (-Dx, 0),
            new (-Dx, Dy),

            new (Dx, Dy),
            new (0, Dy),
            new (-Dx, Dy),

            new (-Dx, -Dy),
            new (-Dx, 0),
            new (-Dx, Dy)
        };

        protected Plant(Cell position, EnumStagesOfGrowth stageOfGrowth, Bitmap currentImage, EnumOfEntities type) : base(position, currentImage)
        {
            _typeOfThis = type;
            CurrentStageOfGrowth = stageOfGrowth;
            this.CurrentImage = currentImage;
        }
        
        protected virtual void StartLiving(EnumStagesOfGrowth stage)
        {
            if(_isFirstState == 0)
            {
                _currentAge = stage switch
                {
                    EnumStagesOfGrowth.Seed => _currentAge,
                    EnumStagesOfGrowth.Sprout => AgeOfSeed,
                    EnumStagesOfGrowth.AdultPlants => AgeOfSprout,
                    EnumStagesOfGrowth.DyingPlants => AgeOfMature                 
                };

                _isFirstState++;
            }
        }

        private void ChangeParametersAtNextStage(EnumStagesOfGrowth stage)
        {
            base.CurrentImage = stage switch
            {
                EnumStagesOfGrowth.Seed => ImageOfSeed,
                EnumStagesOfGrowth.Sprout => ImageOfSprout,
                EnumStagesOfGrowth.AdultPlants => ImageOfMature,
                EnumStagesOfGrowth.DyingPlants => ImageOfDying
            };

        }

        protected bool CheckPosition(int x, int y)
        {
            var listOfAllPlants = World.ListOfEdiblePlants.Concat<Plant>(World.ListOfInediblePlants).ToList();
            
            if (listOfAllPlants.Any(plant => plant.X == x && plant.Y == y)
                || (World.ListOfBerries.Any(berrie => berrie.GetPosition.X == x && berrie.GetPosition.Y == y))      
                    || x > World._sizeOfWorld || x < 0 || y > World._sizeOfWorld || y < 0)
            {
                return false;
            }
            

            return true;
        }

        public override void Move()
        {
            StartLiving(this.CurrentStageOfGrowth);
            SetSeasonalParameters();

            if (isAbilityToLive == false)
            {
                if(CurrentStageOfGrowth == EnumStagesOfGrowth.Seed)
                {
                    return;
                }
                else
                {
                    Die(this);
                    return;
                }
            }

            if(SimulationEngine.currentSeasons == EnumOfSeasons.Winter && CurrentStageOfGrowth == EnumStagesOfGrowth.Seed)
            {
                return;
            }

            if (_currentAge <= AgeOfSeed)
            {
                CurrentStageOfGrowth = EnumStagesOfGrowth.Seed;

                if (_firstEntryIntoGrowthStage)
                {
                    ChangeParametersAtNextStage(EnumStagesOfGrowth.Seed);

                    _firstEntryIntoGrowthStage = false;
                }

                if(_currentAge == AgeOfSeed)
                {
                    _firstEntryIntoGrowthStage = true;
                }
            }

            else if (_currentAge > AgeOfSeed && _currentAge <= AgeOfSprout)
            {
                CurrentStageOfGrowth = EnumStagesOfGrowth.Sprout;

                if (_firstEntryIntoGrowthStage)
                {
                    ChangeParametersAtNextStage(EnumStagesOfGrowth.Sprout);
                    _firstEntryIntoGrowthStage = false;
                }

                if(_currentAge == AgeOfSprout)
                {
                    _firstEntryIntoGrowthStage = true;
                }             
            }

            else if (_currentAge > AgeOfSprout && _currentAge <= AgeOfMature)
            {
                CurrentStageOfGrowth = EnumStagesOfGrowth.AdultPlants;

                if (_firstEntryIntoGrowthStage)
                {
                    ChangeParametersAtNextStage(EnumStagesOfGrowth.AdultPlants);
                    _firstEntryIntoGrowthStage = false;
                }

                Reproduce();

                if (_currentAge == AgeOfMature)
                {
                    _firstEntryIntoGrowthStage = true;
                }
            }

            else if (_currentAge > AgeOfMature && _currentAge < AgeOfDying)
            {
                CurrentStageOfGrowth = EnumStagesOfGrowth.DyingPlants;

                if (_firstEntryIntoGrowthStage)
                {
                    ChangeParametersAtNextStage(EnumStagesOfGrowth.DyingPlants);
                    _firstEntryIntoGrowthStage = false;
                }          
            }

            else if (_currentAge == AgeOfDying)
            {
                Die(this);
            }

            _currentAge++;
        }

        protected virtual void SetSeasonalParameters()
        {
            if (SimulationEngine.currentSeasons == SimulationEngine.previousSeasons)
            {
                return;
            }

            switch (SimulationEngine.currentSeasons)
            {
                case EnumOfSeasons.Summer:
                    World.Summer.ChangeReproductionThreshold(_typeOfThis, ref СoefficientReproduction);
                    World.Summer.ChangeTheAbilityToLive(_typeOfThis, ref isAbilityToLive);

                    break;

                case EnumOfSeasons.Winter:
                    World.Winter.ChangeReproductionThreshold(_typeOfThis, ref СoefficientReproduction);
                    World.Winter.ChangeTheAbilityToLive(_typeOfThis, ref isAbilityToLive);

                    break;

                case EnumOfSeasons.Spring:
                    World.Spring.ChangeReproductionThreshold(_typeOfThis, ref СoefficientReproduction);
                    World.Spring.ChangeTheAbilityToLive(_typeOfThis, ref isAbilityToLive);

                    break;
            }
        }
    }
}
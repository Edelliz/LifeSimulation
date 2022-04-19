using System.Drawing;
using System.Linq;

namespace Simulation_of_life
{
    public class HerbivorousAnimal : Animal
    {
        public HerbivorousAnimal(Cell position, bool abilityToReproduce, char gender, Bitmap currentImage,
            EnumOfEntities type, EnumOfAnimals subspecies)
            : base(position, abilityToReproduce, gender, currentImage, type, subspecies)
        {
            Hp = SimulationEngine.Rnd.Next(200, 400);
            FullHp = Hp;
            ReproductionThreshold = (int) (World.StartingNumberOfHerbivorousAnimal * RatioReproduction);

            NutritionalValue = SimulationEngine.Rnd.Next(30, 90);
        }


        protected override bool IsGoal(int x, int y)
        {
            foreach (var t in World.ListOfEdiblePlants)
            {
                if (t.CurrentStageOfGrowth != EnumStagesOfGrowth.Seed && t.X == x && t.Y == y)
                {
                    SetGoal(t);
                    NutritionalValueOfVictim = t.GetNutritionalValue();

                    return true;
                }
            }

            foreach (var t in World.ListOfBerries)
            {
                if (t.GetPosition.X == x && t.GetPosition.Y == y && t.GetType() != typeof(InedibleBerrie))
                {
                    GoalOfBerries = t;

                    GoalX = t.GetPosition.X;
                    GoalY = t.GetPosition.Y;

                    NutritionalValueOfVictim = t.NutritionalValue;

                    return true;
                }
            }

            return false;
        }

        protected override void CheckReproductionRates()
        {
            if (World.ListOfHerbivorousAnimals.Count <= ReproductionThreshold && AbilityToReproduce)
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

        //Search Partner

        protected override bool IsPartner(int x, int y)
        {
            foreach (var t in World.ListOfHerbivorousAnimals.Where(t =>
                t.X == x && t.Y == y
                         && (t.GetType() == GetType())
                         && (this.Gender != t.Gender) && (this.AbilityToReproduce)
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

        protected override void DefineFoodSearch()
        {
            SearchOfGoal(World.SizeCell, IsGoal);

            base.DefineFoodSearch();
        }

        public override void Die(Entity animal)
        {
            World.ListOfHerbivorousAnimals.Remove(this);
        }

        protected override void Reproduce()
        {
            if (World.ListOfHerbivorousAnimals.Count >= ReproductionThreshold)
            {
                return;
            }

            base.Reproduce();

            World.ListOfHerbivorousAnimals.Add(new HerbivorousAnimal(new Cell(X, Y), true,
                GeneratingNewEntity.GenderOfAnimal[
                    SimulationEngine.Rnd.Next(0, GeneratingNewEntity.GenderOfAnimal.Length)], CurrentImage, _typeOfThis,
                Subspecies));
        }
    }
}
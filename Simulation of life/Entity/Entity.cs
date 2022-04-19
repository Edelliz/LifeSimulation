
using System.Drawing;

namespace Simulation_of_life
{
    public abstract class Entity
    {
        public int Hp;
        public int X;
        public int Y;
        public Bitmap CurrentImage;
        protected int ReproduceThreshold;
        public EnumOfEntities _typeOfThis;

        public Entity(Cell position,Bitmap CurrentImage)
        {
            X = position.X;
            Y = position.Y;
            this.CurrentImage = CurrentImage;
        }

       public abstract void Die(Entity entity);
       public abstract void Move();
       protected abstract void Reproduce();
    }
}
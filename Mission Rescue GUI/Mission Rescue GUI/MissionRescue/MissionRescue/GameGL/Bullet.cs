using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionRescue.GameGL
{
    public abstract class Bullet : GameObject
    {
        protected int x;
        protected int y;

        public int X { get { return this.x; } set { this.x = value; } }
        public int Y { get { return this.y; } set { this.y = value; } }

        public Bullet(GameCell startCell,Image img ) : base(GameObjectType.BULLET, img, startCell)
        {
            this.x = startCell.X;
            this.Y = startCell.Y;
        }


        public abstract GameCell Move();

    }
}

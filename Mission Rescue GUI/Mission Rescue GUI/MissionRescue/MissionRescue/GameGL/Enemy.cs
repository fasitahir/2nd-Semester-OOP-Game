using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MissionRescue.GameGL
{
    public abstract class Enemy : GameObject
    {
        
        public GameObject previousObject;
        public Enemy(Image img, GameCell currentCell) : base(GameObjectType.ENEMY, img, currentCell)
        {
            previousObject = Game.getBlankGameObject();
        }

        public abstract GameCell Move();
    }
}

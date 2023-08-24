using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MissionRescue.GameGL
{
    public class verticalEnemy : Enemy
    {
        int health = 100;
        public int Health { get { return health; } set { health = value; } }
        public verticalEnemy(GameCell current) : base(MissionRescue.Properties.Resources.vEnemy, current)
        {
            this.Direction = GameDirection.UP;
        }
        public override GameCell Move()
        {
            GameCell nextCell = this.CurrentCell.NextCell(Direction);
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
            {
                return null;
            }
            else if (nextCell.CurrentGameObject.GameObjectType != GameObjectType.WALL && nextCell.CurrentGameObject.GameObjectType != GameObjectType.SPIKE && nextCell.CurrentGameObject.GameObjectType != GameObjectType.HEART)
            {
                CurrentCell.SetGameObject(previousObject);
                GameObjectType gameObjectType = nextCell.CurrentGameObject.GameObjectType;
                previousObject = new GameObject(gameObjectType, Game.getGameObjectImage(gameObjectType));
                CurrentCell = nextCell;
                return nextCell;
            }
            else
            {
                if (this.Direction == GameDirection.UP)
                {
                    this.Direction = GameDirection.DOWN;
                }
                else
                {
                    this.Direction = GameDirection.UP;
                }
                return CurrentCell;
            }


        }

        public void RemoveEnemy()
        {
            CurrentCell.SetGameObject(Game.getBlankGameObject());
        }

    }
}

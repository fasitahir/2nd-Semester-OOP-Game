using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MissionRescue.GameGL
{
    public class RandomEnemy : Enemy
    {
        Random random = new Random();
        int health = 100;
        public int Health { get { return health; } set { health = value; } }
        int count = 0;

        public RandomEnemy(GameCell currentCell) : base(MissionRescue.Properties.Resources.rEnemy, currentCell)
        {
            this.Direction = GameDirection.RIGHT;
        }

        public override GameCell Move()
        {
            GameCell nextCell = this.CurrentCell.NextCell(Direction);
            int number = random.Next(4);
            if (count == 2)
            {
                count = 0;
                switch (number)
                {
                    case 0:
                        this.Direction = GameDirection.RIGHT;
                        break;
                    case 1:
                        this.Direction = GameDirection.LEFT;
                        break;
                    case 2:
                        this.Direction = GameDirection.UP;
                        break;
                    case 3:
                        this.Direction = GameDirection.DOWN;
                        break;
                }
            }
            else
            {
                count++;
            }
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
                return this.CurrentCell;
            }
        }

        public void RemoveEnemy()
        {
            CurrentCell.SetGameObject(Game.getBlankGameObject());
        }

    }
}

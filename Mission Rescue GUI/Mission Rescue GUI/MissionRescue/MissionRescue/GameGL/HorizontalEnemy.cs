using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionRescue.GameGL
{
    public class HorizontalEnemy : Enemy
    {
        int health = 100;
        public int Health { get { return health; } set { health = value; } }
        public HorizontalEnemy(GameCell currentCell) : base(MissionRescue.Properties.Resources.hEnemy, currentCell)
        {
            Direction = GameDirection.LEFT;
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
                previousObject = new GameObject(gameObjectType , Game.getGameObjectImage(gameObjectType));
                CurrentCell = nextCell;
                return nextCell;
            }
            else
            {
                if (Direction == GameDirection.LEFT)
                {
                    Direction = GameDirection.RIGHT;
                }
                else
                {
                    Direction = GameDirection.LEFT;
                }
            }
            return CurrentCell;
        }
        
        public void RemoveEnemy()
        {
            CurrentCell.SetGameObject(Game.getBlankGameObject());
        }
    }
}

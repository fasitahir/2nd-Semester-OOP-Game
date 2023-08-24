using System.Windows.Forms;

namespace MissionRescue.GameGL
{
    public class PlayerBullet : Bullet
    {
        public PlayerBullet(GameCell startCell) : base(startCell , MissionRescue.Properties.Resources.snowBall)
        {
            this.x = startCell.X;
            this.Y = startCell.Y;
        }

        public override GameCell Move()
        {
            GameCell nextCell = this.CurrentCell.NextCell(this.Direction);
            if (nextCell.CurrentGameObject.GameObjectType != GameObjectType.WALL && nextCell.CurrentGameObject.GameObjectType != GameObjectType.SPIKE && nextCell.CurrentGameObject.GameObjectType != GameObjectType.HEART)
            {
                // detect enemies
                if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
                {
                    if (nextCell.CurrentGameObject is RandomEnemy)
                    {

                        ((Form1)Program.currentForm).REnemyHealth();
                    }
                    if (nextCell.CurrentGameObject is HorizontalEnemy)
                    {

                        ((Form1)Program.currentForm).HEnemyHealth();
                    }

                    if (nextCell.CurrentGameObject is verticalEnemy)
                    {

                        ((Form1)Program.currentForm).VEnemyHealth();
                    }

                    CurrentCell.SetGameObject(Game.getBlankGameObject());

                    return null;
                }
              
                //Move Bullets
                CurrentCell.SetGameObject(Game.getBlankGameObject());
                this.CurrentCell = nextCell;
                return nextCell;

            }
            //Detect Wall
            else if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL || nextCell.CurrentGameObject.GameObjectType == GameObjectType.SPIKE)
            {
                CurrentCell.SetGameObject(Game.getBlankGameObject());
                return null;
            }
            return this.CurrentCell;
        }
    }
}

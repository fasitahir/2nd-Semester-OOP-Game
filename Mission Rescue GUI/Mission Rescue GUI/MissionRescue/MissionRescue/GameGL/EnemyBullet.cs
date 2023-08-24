using MissionRescue.GameGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionRescue
{
    public class EnemyBullet : Bullet
    {
        

        public EnemyBullet(GameCell startCell) : base( startCell, MissionRescue.Properties.Resources.fireBall)
        {
            this.x = startCell.X;
            this.Y = startCell.Y;
        }

        public override GameCell Move()
        {
            GameCell nextCell = this.CurrentCell.NextCell(this.Direction);
            if (nextCell.CurrentGameObject.GameObjectType != GameObjectType.WALL && nextCell.CurrentGameObject.GameObjectType != GameObjectType.SPIKE && nextCell.CurrentGameObject.GameObjectType != GameObjectType.HEART)
            {

                if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
                {
                    CurrentCell.SetGameObject(Game.getBlankGameObject());
                    ((Form1)Program.currentForm).NickHealth(5);
                    return null;
                }
                //Move Bullets
                CurrentCell.SetGameObject(Game.getBlankGameObject());
                this.CurrentCell = nextCell;
                return nextCell;

            }
            //Detect Wall
            else if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL || nextCell.CurrentGameObject.GameObjectType == GameObjectType.SPIKE || nextCell.CurrentGameObject.GameObjectType == GameObjectType.HEART)
            {
                CurrentCell.SetGameObject(Game.getBlankGameObject());
                return null;
            }
            return this.CurrentCell;
        }

        public static void RemoveEnemyBullets(List<EnemyBullet> bullets)
        {
            foreach(EnemyBullet e in bullets)
            {
                e.CurrentCell.SetGameObject(Game.getBlankGameObject());
            } 
        }
    }
}

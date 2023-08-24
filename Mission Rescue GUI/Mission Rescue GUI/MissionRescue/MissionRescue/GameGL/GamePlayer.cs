using System.Drawing;

namespace MissionRescue.GameGL
{
    public class GamePlayer : GameObject
    {

        public GamePlayer(Image img, GameCell startCell) : base(GameObjectType.PLAYER, img, startCell)
        {
        }

        public GameCell Move()
        {
            GameCell nextCell = this.CurrentCell.NextCell(Direction);
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
            {
                return null;
            }

            else if (nextCell.CurrentGameObject.GameObjectType != GameObjectType.WALL && nextCell.CurrentGameObject.GameObjectType != GameObjectType.SPIKE)
            {
                if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
                {
                    ((Form1)Program.currentForm).ScoreUpdation();
                }
                if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.HEART)
                {
                    ((Form1)Program.currentForm).nickLives++;
                    ((Form1)Program.currentForm).NickLivesDisplay();

                }
                CurrentCell.SetGameObject(Game.getBlankGameObject());
                CurrentCell = nextCell;
                return nextCell;
            }
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.SPIKE)
            {
                ((Form1)Program.currentForm).NickHealth(1);
            }
            return this.CurrentCell;
        }
    }
}
